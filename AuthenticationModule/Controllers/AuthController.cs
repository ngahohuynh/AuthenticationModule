using AuthenticationModule.Providers;
using BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthenticationModule.Controllers
{
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenGenerator tokenGenerator;

        public AuthController(ITokenGenerator tokenGenerator)
        {
            this.tokenGenerator = tokenGenerator;
        }


        [HttpPost]
        public async Task<TokenResponse> Login([FromBody] UserLogin userLogin)
        {
            return await tokenGenerator.GenerateToken(userLogin);
        }
    }
}
