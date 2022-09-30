using CulinarySite.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryApi.Controllers
{
    public class HomeController : BaseController
    {
        // [Authorize]
        public ActionResult Get()
        {
            return Ok("works");
        }
    }
}
