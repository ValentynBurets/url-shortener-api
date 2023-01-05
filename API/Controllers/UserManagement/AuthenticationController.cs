using API.Controllers.Base;
using AutoMapper;
using Business.Contract.Models.UserManagement;
using Business.Contract.Services.UserManagement;
using Data.Identity.Data;
using Domain.Entity.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers.UserManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly UserManager<AuthorisationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;
        private readonly IProfileRegistrationService _profileRegistrationService;


        private readonly IProfileDataService _profileDataService;
        private readonly IProfileManager _profileManager;




        public AuthenticationController(
        UserManager<AuthorisationUser> userManager,
        IMapper mapper,
        IAuthManager authManager,
        IProfileRegistrationService profileRegistrationService,
        IProfileDataService profileDataService, IProfileManager profileManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _authManager = authManager;
            _profileRegistrationService = profileRegistrationService;

            _profileDataService = profileDataService;
            _profileManager = profileManager;
        }

        [NonAction]
        private async Task<IActionResult> RegisterUser(PersonDTO userModel, string role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _mapper.Map<AuthorisationUser>(userModel);
                user.UserName = userModel.Email;

                var result = await _userManager.CreateAsync(user, userModel.Password);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                await _userManager.AddToRoleAsync(user, role);

                await _profileRegistrationService.CreateProfile(user);

                if (!await _authManager.ValidateUser(userModel))
                {
                    return Unauthorized();
                }

                return Accepted(new
                {
                    Token = await _authManager.CreateToken()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //[Authorize(Roles = "User")]
        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser([FromBody] PersonDTO userModel)
        {
            return await RegisterUser(userModel, "User");
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAdmin([FromBody] PersonDTO userModel)
        {
            return await RegisterUser(userModel, "Admin");
        }

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] PersonDTO userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!await _authManager.ValidateUser(userModel))
                {
                    return Unauthorized();
                }

                return Accepted(new
                {
                    Token = await _authManager.CreateToken()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> TestGet()
        {
            List<PersonInfoDTO> usersInfoList = null;

            try
            {
                if (User.IsInRole("Admin"))
                {
                    usersInfoList = (List<PersonInfoDTO>)await _profileDataService.GetAllUsersInfo();
                }
                else
                {
                    throw new Exception("Invalid role!");
                }
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }

            return Ok(usersInfoList);
        }
    }
}
