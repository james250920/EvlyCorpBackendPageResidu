using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.CORE.DTOs
{
    public class MunicipalitiesDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? LogoUrl { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
    public class MunicipalitiesListDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? LogoUrl { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
    }
    public class MunicipalitiesInsertDTO
    {
        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? LogoUrl { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
    }
    public class MunicipalitiesUpdateDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? LogoUrl { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
        public DateTime UpdatedAt { get; set;}
    }
    public class MunicipalitiesDeleteDTO
    {
        public int Id { get; set; }
    }
    public class MunicipalitiesCondominiumsDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? LogoUrl { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        //public ICollection<CondominiumsListDTO> Condominiums { get; set; }
    }
}
