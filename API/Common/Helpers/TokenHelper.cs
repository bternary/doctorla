using CoreLibrary;
using Data.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Common.Helpers
{
    public class TokenHelper
    {
        internal static string Key { get; set; }
        internal static string Issuer { get; set; }
        static TokenHelper()
        {
            using (var serviceScope = ServiceActivator.GetScope())
            {
                IConfiguration config = serviceScope.ServiceProvider.GetRequiredService<IConfiguration>();
                Key = config["Jwt:Key"];
                Issuer = config["Jwt:Issuer"];
            }
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        internal static string GenerateJSONWebToken(User user)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                new Claim(ClaimTypes.Actor, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.UserType.Name),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
                var token = new JwtSecurityToken(
                    issuer: Issuer,
                    audience: Issuer,
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                    );
                var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
                return encodetoken;
            }
            catch (Exception ex)
            {
                LogsServices.Log("Login - GenerateJSONWebToken", ex.Message.ToString(), 3);
                return null;
            }
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        internal static ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key)),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date               
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }
    }
}
