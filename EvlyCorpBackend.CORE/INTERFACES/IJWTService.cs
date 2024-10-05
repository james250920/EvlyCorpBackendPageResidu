using EvlyCorpBackend.CORE.SETTINGS;
using EvlyCorpBackend.INFRASTRUCTURE.Data;

namespace EvlyCorpBackend.INFRASTRUCTURE.SHARED
{
    public interface IJWTService
    {
        JWTSettings _settings { get; }

        string GenerateJWToken(Users user);
    }
}