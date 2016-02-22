using System;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using EmployeeReferralApp.ConfigurationSettings;

namespace EmployeeReferralApp.Infrastructure.Services
{
    public class JWTTokenGenerator : ITokenGenerator
    {
        private readonly JwtSettings _jwtSettings;

        public JWTTokenGenerator(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        public string GenerateFor(string username)
        {
            var credentials = new SigningCredentials(
                new InMemorySymmetricSecurityKey(_jwtSettings.JwtKey.Value.ToByteArray()),
                "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256",
                "http://www.w3.org/2001/04/xmlenc#sha256"
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username), 
                }),
                TokenIssuerName = _jwtSettings.JwtIssuer,
                AppliesToAddress = _jwtSettings.JwtAllowedAudience,
                SigningCredentials = credentials,

                // default life of the jwt token is an hour
                // increase to 20 years (practically forever)
                Lifetime = new Lifetime(DateTime.UtcNow, DateTime.UtcNow.AddYears(20))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}