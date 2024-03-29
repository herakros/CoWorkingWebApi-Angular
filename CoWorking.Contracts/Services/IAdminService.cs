﻿using CoWorking.Contracts.DTO.AdminPanelDTO;
using CoWorking.Contracts.DTO.BookingDTO;

namespace CoWorking.Contracts.Services
{
    public interface IAdminService
    {
        Task<IEnumerable<UserInfoDTO>> GetAllUsersAsync();

        Task<UserInfoDTO> PutUserAsync(UserInfoDTO model);

        Task DeleteUserAsync(string id);

        Task<UserInfoDTO> GetUserByIdAsync(string id);
    }
}
