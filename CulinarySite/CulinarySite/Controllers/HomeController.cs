
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryApi.Controllers
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
