using CoWorking.Contracts.Data;
using CoWorking.Contracts.Data.Entities.RefreshTokenEntity;
using CoWorking.Contracts.Data.Entities.UserEntity;
using CoWorking.Contracts.DTO.AuthenticationDTO;
using CoWorking.Contracts.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        protected readonly UserManager<User> _userManager;
        protected readonly SignInManager<User> _signInManager;
        protected readonly IJwtService _jwtService;
        protected readonly IRepository<RefreshToken> _refreshTokenRepository;

        public AuthenticationService(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IJwtService jwtService,
            IRepository<RefreshToken> refreshTokenRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<UserAutorizationDTO> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if(user != null)
            {
                return await GenerateUserTokens(user);
            }

            return new UserAutorizationDTO();
        }

        private async Task<UserAutorizationDTO> GenerateUserTokens(User user)
        {
            var claims = _jwtService.SetClaims(user);

            var token = _jwtService.CreateToken(claims);
            var refeshToken = await CreateRefreshToken(user);

            var tokens = new UserAutorizationDTO()
            {
                Token = token,
                RefreshToken = refeshToken
            };

            return tokens;
        }

        private async Task<string> CreateRefreshToken(User user)
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

        public async Task RegistrationAsync(User user, string password, string roleName)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                StringBuilder errorMessage = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    errorMessage.Append(error.Description.ToString() + " ");
                }
                throw new Exception();
            }
        }
    }
}
