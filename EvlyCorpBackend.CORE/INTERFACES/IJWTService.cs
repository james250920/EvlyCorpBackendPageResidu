using EvlyCorpBackend.CORE.SETTINGS;
using EvlyCorpBackend.INFRASTRUCTURE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.CORE.INTERFACES
{
    public interface IJWTService
    {
        JWTSettings _settings { get; }

        string GenerateJWToken(Users user);
    }
}
