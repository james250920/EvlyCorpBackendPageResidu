using infrastructure.DATA;

namespace EvlyCorpBackend.INFRASTRUCTURE.SHARED
{
    public interface IJWTService
    {
        string GenerateJWToken(Users user);
    }
}