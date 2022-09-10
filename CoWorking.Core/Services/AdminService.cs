using AutoMapper;
using CoWorking.Contracts.Data;
using CoWorking.Contracts.Data.Entities.BookingEntity;
using CoWorking.Contracts.Data.Entities.UserEntity;
using CoWorking.Contracts.DTO.AdminPanelDTO;
using CoWorking.Contracts.DTO.BookingDTO;
using CoWorking.Contracts.Exceptions;
using CoWorking.Contracts.Services;
using Microsoft.AspNetCore.Identity;

namespace CoWorking.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Booking> _bookingRepository;
        private readonly IRepository<User> _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminService(IMapper mapper,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IRepository<User> userRepository,
            IRepository<Booking> bookingRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _userRepository = userRepository;
            _bookingRepository = bookingRepository; 
        }

        public async Task AddBookingAsync(CreateBookingDTO model)
        {
            var booking = new Booking();
            _mapper.Map(model, booking);

            await _bookingRepository.AddAsync(booking);
            await _bookingRepository.SaveChangesAsync();
        }

        public async Task AddRangeOfBooking(List<CreateBookingDTO> models)
        {
            var bookingList = _mapper.Map<List<CreateBookingDTO>, List<Booking>>(models);

            await _bookingRepository.AddRangeAsync(bookingList);
            await _bookingRepository.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound,
                    "User not found!");
            }

            await _userManager.RemoveFromRoleAsync(user, await GetUserRoleAsync(_userManager, user));
            await _userManager.DeleteAsync(user);
        }

        public async Task<IEnumerable<UserInfoDTO>> GetAllUsersAsync()
        {
            var scecification = new Users.UsersWithRole(_userManager);
            var users = await _userRepository.GetListBySpecAsync(scecification);

            return users;
        }

        public async Task<UserInfoDTO> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound,
                    "User not found!");
            }

            var userInfo = new UserInfoDTO();

            _mapper.Map(user, userInfo);
            userInfo.Role = await GetUserRoleAsync(_userManager, user);

            return userInfo;
        }

        public async Task<UserInfoDTO> PutUserAsync(UserInfoDTO model)
        {
            var userName = await _userManager.FindByNameAsync(model.UserName);

            if (userName != null && userName.Id != model.Id)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound,
                    "User with this Username was already exists");
            }

            var userEmail = await _userManager.FindByEmailAsync(model.Email);

            if (userEmail != null && userEmail.Id != model.Id)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound,
                    "User with this Email was already exists");
            }

            var changedRole = await _roleManager.FindByNameAsync(model.Role);

            if (changedRole == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound,
                    "System don't have this role!");
            }

            var user = await _userRepository.GetByKeyAsync(model.Id);

            _mapper.Map(model, user);
            await _userManager.UpdateAsync(user);
            await _userManager.RemoveFromRoleAsync(user, await GetUserRoleAsync(_userManager, user));
            await _userManager.AddToRoleAsync(user, changedRole.Name);

            return model;
        }

        private async Task<string> GetUserRoleAsync(UserManager<User> manager, User user)
        {
            return manager.GetRolesAsync(user).Result[0];
        }
    }
}
