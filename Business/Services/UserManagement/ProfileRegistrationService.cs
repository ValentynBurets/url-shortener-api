using Business.Contract.Services.UserManagement;
using Data.Contract.UnitOfWork;
using Data.Identity.Data;
using Domain.Entity.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.UserManagement
{
    public class ProfileRegistrationService : IProfileRegistrationService
    {
        private readonly UserManager<AuthorisationUser> _userManager;
        private IAuthentificationUnitOfWork _unitOfWork;
        public ProfileRegistrationService(UserManager<AuthorisationUser> userManager,
            IAuthentificationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<bool> CreateProfile(AuthorisationUser user)
        {
            IList<string> role = await _userManager.GetRolesAsync(user);
            if (role.Contains("User"))
            {
                await _unitOfWork.UserRepository.Add(new User(Guid.Parse(user.Id)));
                await _unitOfWork.Save();
                return true;
            }
            else if (role.Contains("Admin"))
            {
                await _unitOfWork.AdminRepository.Add(new Admin(Guid.Parse(user.Id)));
                await _unitOfWork.Save();
                return true;
            }
            else
            {
                throw new Exception("Role is not set");
            }
        }
    }
}
