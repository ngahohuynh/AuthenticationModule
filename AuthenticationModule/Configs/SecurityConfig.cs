using AuthenticationModule.Providers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace AuthenticationModule.Configs
{
    public static class SecurityConfig
    {
        private static void SetJwtOption(JwtBearerOptions options, byte[] key)
        {
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                RequireExpirationTime = true,
                RequireSignedTokens = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero,
            };
            options.SaveToken = true;
        }

        public static void ConfigSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            var settingsSection = configuration.GetSection("SecuritySettings");
            services.Configure<SecuritySettings>(settingsSection);
            var settings = settingsSection.Get<SecuritySettings>();
            var key = Encoding.ASCII.GetBytes(settings.Secret);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => SetJwtOption(options, key));
        }
    }
}
