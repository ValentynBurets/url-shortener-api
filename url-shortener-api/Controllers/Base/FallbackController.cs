using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Mime;

namespace url_shortener_api.Controllers.Base
{
    //Whenever the route is not going to be matched, all of the load is going to be forwarded to this controller.
    public class FallbackController : Controller
    {
        public IActionResult Index()
        {
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"),
                MediaTypeNames.Text.Html);
        }
    }
}
