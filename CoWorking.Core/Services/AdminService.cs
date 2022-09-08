using AutoMapper;
using CoWorking.Contracts.Data;
using CoWorking.Contracts.Data.Entities.UserEntity;
using CoWorking.Contracts.DTO.AdminPanelDTO;
using CoWorking.Contracts.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public AdminService(IMapper mapper,
            UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<IEnumerable<UserInfoDTO>> GetAllUsersAsync()
        {
            var users = _userManager.Users.Select(x => new UserInfoDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                UserName = x.UserName,
                Email = x.Email,
                Role = string.Join("", _userManager.GetRolesAsync(x).Result.ToArray())
            })
            .ToList();

            return users;
        }
    }
}
