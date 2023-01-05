using AutoMapper;
using Business.Contract.Models.UserManagement;
using Business.Contract.Services.UserManagement;
using Data.Contract.UnitOfWork;
using Domain.Entity.Base;
using Domain.Entity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var email = await _profileManager.GetEmailByUserId(idLink);
            if (customer == null)
            {
                throw new Exception("User with this id was not found!");
            }

            var profileInfo = _mapper.Map<Person, PersonInfoDTO>(customer);
            profileInfo.Email = email;

            return profileInfo;
        }

        public async Task<PersonInfoDTO> GetUserProfileInfoById(Guid id)
        {
            var idLink = await _unitOfWork.UserRepository.GeIdLinkById(id);
            var customer = await _unitOfWork.UserRepository.FirstOrDefault(x => x.Id == idLink);
            var email = await _profileManager.GetEmailByUserId(idLink);
            if (customer == null)
            {
                throw new Exception("User with this id was not found!");
            }

            var profileInfo = _mapper.Map<Person, PersonInfoDTO>(customer);
            profileInfo.Email = email;

            return profileInfo;
        }

        public async Task<IEnumerable<PersonInfoDTO>> GetAllUsersInfo()
        {
            List<PersonInfoDTO> userList = new List<PersonInfoDTO>();

            var users = (await _unitOfWork.UserRepository.GetAll()).ToList();

            if (users == null)
            {
                throw new Exception("Customer not found!");
            }

            foreach (var item in users)
            {
                var email = await _profileManager.GetEmailByUserId(item.IdLink);
                var user = _mapper.Map<User, PersonInfoDTO>(item);
                user.Email = email;
                userList.Add(user);
            }

            var admins = (await _unitOfWork.AdminRepository.GetAll()).ToList();

            if (admins == null)
            {
                throw new Exception("Admins not found!");
            }

            foreach (var item in admins)
            {
                var email = await _profileManager.GetEmailByUserId(item.IdLink);
                var user = _mapper.Map<Admin, PersonInfoDTO>(item);
                user.Email = email;
                userList.Add(user);
            }

            return userList;
        }

        public async Task<PersonInfoDTO> GetAdminProfileInfoById(Guid id)
        {
            var admin = await _unitOfWork.AdminRepository.FirstOrDefault(x => x.IdLink == id);
            var email = await _profileManager.GetEmailByUserId(id);

            if (admin == null)
            {
                throw new Exception("Admin with this id was not found!");
            }

            var profileInfo = _mapper.Map<Admin, PersonInfoDTO>(admin);
            profileInfo.Email = email;

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
