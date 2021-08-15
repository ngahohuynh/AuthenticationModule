using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationModule.Controllers
{
    [Route("api/home")]
    [Authorize]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public object SayHello()
        {
            return new { Message = "Hello World!!" };
        }
    }
}
