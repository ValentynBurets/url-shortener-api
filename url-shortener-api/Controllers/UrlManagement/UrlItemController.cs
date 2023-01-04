using Business.Contract.Models.UrlItemManagement;
using Business.Contract.Services.UrlItemManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using url_shortener_api.Controllers.Base;

namespace url_shortener_api.Controllers.UrlManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlItemController : BaseController
    {
        private readonly IUrlItemService _urlItemService;

        public UrlItemController(IUrlItemService urlItemService)
        {
            _urlItemService = urlItemService;
        }
        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Create(CreateUrlItemDTO newUrlItem)
        {
            try
            {
                return Ok(await _urlItemService.Create(newUrlItem, GetUserId()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Delete(Guid urlItemId)
        {
            try
            {
                await _urlItemService.Delete(urlItemId);
                return Ok(urlItemId + " url item deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult> GetById(Guid urlItemId)
        {
            try
            {
                return Ok(await _urlItemService.GetById(urlItemId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _urlItemService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
