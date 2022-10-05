using Microsoft.AspNetCore.Mvc;

namespace CulinarySite.Api.Controllers
{
    public class HomeController : ApiController
    {
        // [Authorize]
        public ActionResult Get()
        {
            return Ok("works");
        }
    }
}
