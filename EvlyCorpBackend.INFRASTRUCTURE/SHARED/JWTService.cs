using EvlyCorpBackend.CORE.SETTINGS;
using EvlyCorpBackend.INFRASTRUCTURE.Data;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.INFRASTRUCTURE.SHARED
{
    public class JWTService : IJWTService
    {
        public JWTSettings _settings { get; }

        public JWTService(IOptions<JWTSettings> settings)
        {
            if (settings == null || settings.Value == null)
                throw new ArgumentNullException(nameof(settings), "JWTSettings cannot be null.");

            _settings = settings.Value;

            if (string.IsNullOrEmpty(_settings.SecretKey))
                throw new ArgumentNullException(nameof(_settings.SecretKey), "SecretKey cannot be null or empty.");
        }

        public string GenerateJWToken(Users user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null.");

            var ssk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var sc = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(sc);

            // Manejo de claims
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName ?? "Unknown"} {user.LastName ?? "Unknown"}"),
                new Claim(ClaimTypes.Email, user.Email ?? "no-email@domain.com"),
                new Claim(ClaimTypes.NameIdentifier, user.Document ?? "NoDocument"),
                new Claim("DocumentType", user.DocumentType ?? "Unknown"),
                new Claim(ClaimTypes.MobilePhone, user.Phone ?? "NoPhone"),
                new Claim("PhotoUrl", user.PhotoUrl ?? string.Empty), // Se asigna vacío si es nulo
                new Claim(ClaimTypes.StreetAddress, user.Address ?? string.Empty), // Se asigna vacío si es nulo
                new Claim(ClaimTypes.Country, user.DepartmentId.ToString()), // Se usa Country para DepartmentId
                new Claim(ClaimTypes.Role, user.Role ?? "User")
            };

            var payload = new JwtPayload(
                _settings.Issuer ?? "UnknownIssuer",
                _settings.Audience ?? "UnknownAudience",
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(_settings.DurationInMinutes > 0 ? _settings.DurationInMinutes : 60) // Duración predeterminada de 60 minutos si es 0 o menos
            );

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
