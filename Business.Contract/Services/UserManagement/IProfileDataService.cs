using Business.Contract.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Contract.Services.UserManagement
{
    public interface IProfileDataService
    {
        public Task<PersonInfoDTO> GetUserProfileInfoByIdLink(Guid idLink);
        public Task<PersonInfoDTO> GetUserProfileInfoById(Guid id);
        public Task<PersonInfoDTO> GetAdminProfileInfoById(Guid id);
        public Task<string> GetRole(Guid userId);
    }
}
