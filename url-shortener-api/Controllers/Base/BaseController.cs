using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace url_shortener_api.Controllers.Base
{
    public class BaseController : Controller
    {
        protected Guid GetUserId()
        {
            return Guid.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
