using AutoMapper;
using Business.Contract.Models.UserManagement;
using Business.Contract.Services.UserManagement;
using Data.Contract.UnitOfWork;
using Domain.Entity.Base;
using Domain.Entity.Users;
using System;
using System.Threading.Tasks;

namespace Business.Services.UserManagement
{
    public class ProfileDataService : IProfileDataService
    {
        private readonly IAuthentificationUnitOfWork _unitOfWork;
        private readonly IProfileManager _profileManager;
        private readonly IMapper _mapper;

        public ProfileDataService(IAuthentificationUnitOfWork unitOfWork, IMapper mapper, IProfileManager profileManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _profileManager = profileManager;
        }

        public async Task<PersonInfoDTO> GetUserProfileInfoByIdLink(Guid idLink)
        {
            var customer = await _unitOfWork.UserRepository.FirstOrDefault(x => x.IdLink == idLink);
            var name = await _profileManager.GetNameByUserId(idLink);
            if (customer == null)
            {
                throw new Exception("User with this id was not found!");
            }

            var profileInfo = _mapper.Map<Person, PersonInfoDTO>(customer);
            profileInfo.Name = name;

            return profileInfo;
        }

        public async Task<PersonInfoDTO> GetUserProfileInfoById(Guid id)
        {
            var idLink = await _unitOfWork.UserRepository.GeIdLinkById(id);
            var customer = await _unitOfWork.UserRepository.FirstOrDefault(x => x.Id == idLink);
            var name = await _profileManager.GetNameByUserId(idLink);
            if (customer == null)
            {
                throw new Exception("User with this id was not found!");
            }

            var profileInfo = _mapper.Map<Person, PersonInfoDTO>(customer);
            profileInfo.Name = name;

            return profileInfo;
        }

        public async Task<PersonInfoDTO> GetAdminProfileInfoById(Guid id)
        {
            var admin = await _unitOfWork.AdminRepository.FirstOrDefault(x => x.IdLink == id);
            var name = await _profileManager.GetNameByUserId(id);

            if (admin == null)
            {
                throw new Exception("Admin with this id was not found!");
            }

            var profileInfo = _mapper.Map<Admin, PersonInfoDTO>(admin);
            profileInfo.Name = name;

            return profileInfo;
        }

        public async Task<string> GetRole(Guid userId)
        {
            var tempUser = await _unitOfWork.UserRepository.GetById(userId);
            var user = _mapper.Map<Person, PersonInfoDTO>(tempUser);
            return user.Role;
        }
    }
}
