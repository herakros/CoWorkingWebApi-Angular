﻿using CoWorking.Contracts.Roles;

namespace CoWorking.Contracts.DTO.AdminPanelDTO
{
    public class UserInfoDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public AuthorizationRoles Role { get; set; }
    }
}
