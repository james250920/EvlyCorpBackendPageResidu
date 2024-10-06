using EvlyCorpBackend.CORE.SETTINGS;
using EvlyCorpBackend.INFRASTRUCTURE.Data;
using infrastructure.DATA;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EvlyCorpBackend.INFRASTRUCTURE.SHARED
{
    public class JWTService : IJWTService
    {
        private readonly JWTSettings _settings;

        public JWTService(IOptions<JWTSettings> settings)
        {
            _settings = settings.Value ?? throw new ArgumentNullException(nameof(settings), "JWTSettings cannot be null.");
        }

        public string GenerateJWToken(Users user)
        {
            if (string.IsNullOrEmpty(_settings.SecretKey))
                throw new ArgumentNullException(nameof(_settings.SecretKey), "SecretKey cannot be null or empty.");

            var ssk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var sc = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Document),
                new Claim("DocumentType", user.DocumentType),
                new Claim(ClaimTypes.MobilePhone, user.Phone),
                new Claim("PhotoUrl", user.PhotoUrl ?? string.Empty),
                new Claim(ClaimTypes.StreetAddress, user.Address ?? string.Empty),
                new Claim(ClaimTypes.Country, user.DistrictId.ToString()),
                new Claim(ClaimTypes.Role, user.Role ?? string.Empty)
            };

            var payload = new JwtPayload(
                _settings.Issuer,
                _settings.Audience,
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(_settings.DurationInMinutes)
            );

            var token = new JwtSecurityToken(new JwtHeader(sc), payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
