using AuthenticationModule.Providers;
using BusinessLogic.Contracts;
using BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthenticationModule.Controllers
{
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenGenerator tokenGenerator;
        private readonly IAuthService authService;

        public AuthController(ITokenGenerator tokenGenerator, IAuthService authService)
        {
            this.tokenGenerator = tokenGenerator;
            this.authService = authService;
        }


        [HttpPost]
        [Route("login")]
        public async Task<TokenResponse> Login([FromBody] UserLogin userLogin) => await tokenGenerator.GenerateToken(userLogin);

        [HttpPost]
        [Route("register")]
        public async Task<UserResponse> Register([FromBody] UserRegister userRegister) => await authService.Register(userRegister);
    }
}
