using AutoMapper;
using CoWorking.Contracts.Data;
using CoWorking.Contracts.Data.Entities.UserEntity;
using CoWorking.Contracts.DTO.UserDTO;
using CoWorking.Contracts.Exceptions;
using CoWorking.Contracts.Services;
using Microsoft.AspNetCore.Identity;

namespace CoWorking.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;
        private readonly UserManager<User> _userManager;
        public UserService(IMapper mapper, 
            IRepository<User> userRepository, 
            UserManager<User> userManager)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<UserProfileDTO> GetUserInfo(string userId)
        {
            var user = await _userRepository.GetByKeyAsync(userId);

            if(user is null)
            {
                throw new UserNotFoundException();
            }

            var userProfile = new UserProfileDTO();
            _mapper.Map(user, userProfile);

            return userProfile;
        }
    }
}
