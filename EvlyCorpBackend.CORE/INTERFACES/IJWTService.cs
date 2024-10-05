using EvlyCorpBackend.INFRASTRUCTURE.Data;

namespace EvlyCorpBackend.INFRASTRUCTURE.SHARED
{
    public interface IJWTService
    {
        string GenerateJWToken(Users user);
    }
}