using AutoMapper;
using CoWorking.Contracts.Data;
using CoWorking.Contracts.Data.Entities.RefreshTokenEntity;
using CoWorking.Contracts.Data.Entities.UserEntity;
using CoWorking.Contracts.DTO.AuthenticationDTO;
using CoWorking.Contracts.DTO.UserDTO;
using CoWorking.Contracts.Exceptions;
using CoWorking.Contracts.Services;
using CoWorking.Core.Validators;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace CoWorking.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        protected readonly UserManager<User> _userManager;
        protected readonly SignInManager<User> _signInManager;
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly IJwtService _jwtService;
        protected readonly IRepository<RefreshToken> _refreshTokenRepository;
        protected readonly IMapper _mapper;

        public AuthenticationService(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IJwtService jwtService,
            IRepository<RefreshToken> refreshTokenRepository,
            IMapper mapper,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _refreshTokenRepository = refreshTokenRepository;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<UserAutorizationDTO> LoginAsync(UserLoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                throw new HttpException(System.Net.HttpStatusCode.Unauthorized, 
                    "Incorrect Email or Password!");
            }

            if (user != null)
            {
                return await GenerateUserTokenAsync(user);
            }

            return new UserAutorizationDTO() { IsAuthenticated = false };
        }

        private async Task<UserAutorizationDTO> GenerateUserTokenAsync(User user)
        {
            var claims = _jwtService.SetClaims(user);

            var token = _jwtService.CreateToken(claims);
            var refeshToken = await CreateRefreshTokenAsync(user);

            var tokens = new UserAutorizationDTO()
            {
                Token = token,
                RefreshToken = refeshToken,
                IsAuthenticated = true
            };

            return tokens;
        }

        private async Task<string> CreateRefreshTokenAsync(User user)
        {
            var refeshToken = _jwtService.CreateRefreshToken();

            RefreshToken rt = new RefreshToken()
            {
                Token = refeshToken,
                UserId = user.Id
            };

            await _refreshTokenRepository.AddAsync(rt);
            await _refreshTokenRepository.SaveChangesAsync();

            return refeshToken;
        }

        public async Task LogoutAsync(UserAutorizationDTO userTokensDTO)
        {
            var specification = new RefreshTokens.SearchRefreshToken(userTokensDTO.RefreshToken);
            var refeshTokenFromDb = await _refreshTokenRepository.GetFirstBySpecAsync(specification);

            if (refeshTokenFromDb == null)
            {
                return;
            }

            await _refreshTokenRepository.DeleteAsync(refeshTokenFromDb);
            await _refreshTokenRepository.SaveChangesAsync();
        }

        public async Task<UserAutorizationDTO> RefreshTokenAsync(UserAutorizationDTO userTokensDTO)
        {
            var specification = new RefreshTokens.SearchRefreshToken(userTokensDTO.RefreshToken);
            var refeshTokenFromDb = await _refreshTokenRepository.GetFirstBySpecAsync(specification);

            if (refeshTokenFromDb == null)
            {
                throw new Exception();
            }

            var claims = _jwtService.GetClaimsFromExpiredToken(userTokensDTO.Token);
            var newToken = _jwtService.CreateToken(claims);
            var newRefreshToken = _jwtService.CreateRefreshToken();

            refeshTokenFromDb.Token = newRefreshToken;
            await _refreshTokenRepository.UpdateAsync(refeshTokenFromDb);
            await _refreshTokenRepository.SaveChangesAsync();

            var tokens = new UserAutorizationDTO()
            {
                Token = newToken,
                RefreshToken = newRefreshToken
            };

            return tokens;
        }

        public async Task RegistrationAsync(UserRegistrationDTO model)
        {
            if (await Validator.IsUniqueUserName(_userManager, model.UserName))
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest,
                    "User with this Username was already exists");
            }

            if(await Validator.IsUniqueUserEmail(_userManager, model.Email))
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest,
                    "User with this Email was already exists");
            }

            if(await Validator.IsSystemRoleAndNoAdmin(_roleManager, model.Role))
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest,
                    "You can't register with this role");
            }

            var user = new User();
            _mapper.Map(model, user);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                StringBuilder errorMessage = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    errorMessage.Append(error.Description.ToString() + " ");
                }
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, errorMessage.ToString());
            }

            await _userManager.AddToRoleAsync(user, model.Role);
        }
    }
}
