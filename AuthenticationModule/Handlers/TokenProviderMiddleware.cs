using BusinessLogic.Contracts;
using BusinessLogic.Handlers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace AuthenticationModule.Handlers
{
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate next;

        public TokenProviderMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        private static async Task<UserIdentity> CreateIIdentity(HttpContext context, string username)
        {
            var authService = context.RequestServices.GetService<IAuthService>();
            return new UserIdentity(await authService.Login(username));
        }

        public async Task Invoke(HttpContext context)
        {
            var authenticateInfo = await context.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme);
            var bearerTokenIdentity = authenticateInfo?.Principal;

            if (bearerTokenIdentity != null)
            {
                var identity = await CreateIIdentity(context, bearerTokenIdentity.Identity.Name);
                context.User = new UserClaimsPrincipal(identity);
            }

            await next(context);
        }
    }
}
