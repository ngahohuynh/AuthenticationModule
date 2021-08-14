using BusinessLogic.Contracts;
using BusinessLogic.DTOs;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationModule.Providers
{
    public interface ITokenGenerator
    {
        Task<TokenResponse> GenerateToken(UserLogin userLogin);
    }
    
    public class TokenGenerator : ITokenGenerator
    {
        private readonly SecuritySettings securitySettings;
        private readonly IAuthService authService;

        public readonly SigningCredentials SigningCredentials;

        public TokenGenerator(
            IOptions<SecuritySettings> options,
            IAuthService authService)
        {
            this.securitySettings = options.Value;
            this.authService = authService;

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.securitySettings.Secret));
            SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        }

        public async Task<TokenResponse> GenerateToken(UserLogin userLogin)
        {
            var user = await authService.Login(userLogin);

            var claims = new List<Claim>
            {
                CreateClaim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                CreateClaim(ClaimTypes.Name, user.Username)
            };

            var identity = new ClaimsIdentity(claims, "Bearer");

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                claims: identity.Claims,
                notBefore: now,
                expires: now.AddSeconds(securitySettings.Expiration),
                signingCredentials: SigningCredentials);

            return new TokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                User = new UserResponse() { Id = user.Id, Name = user.Name, Username = user.Username, Type = user.Type }
            };
        }

        private static Claim CreateClaim(string type, string value)
        {
            return new Claim(type, value, null, ClaimsIdentity.DefaultIssuer, "Provider");
        }
    }
}
