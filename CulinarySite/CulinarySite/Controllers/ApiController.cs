using Microsoft.AspNetCore.Mvc;

namespace CulinaryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
 //   [Consumes("application/json")]
    public abstract class ApiController : ControllerBase
    {
      
    }
}
