using AuthenticationModule.Handlers;
using AuthenticationModule.Providers;
using BusinessLogic;
using Microsoft.Extensions.DependencyInjection;

namespace AuthenticationModule.Configs
{
    public static class DIConfig
    {
        public static void RegisterDI(this IServiceCollection services)
        {
            services.RegisterServicesDI();
            
            services.AddHttpContextAccessor();

            services.AddSingleton<TokenProviderMiddleware>();

            services.AddScoped<ValidateModelAttribute>();

            services.AddScoped<ITokenGenerator, TokenGenerator>();
        }
    }
}
