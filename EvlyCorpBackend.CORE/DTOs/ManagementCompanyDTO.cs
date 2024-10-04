using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.CORE.DTOs
{
    public class ManagementCompanyDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? TaxAddress { get; set; }

        public string? WebsiteUrl { get; set; }

        public string Ruc { get; set; } = null!;

        public string? LogoUrl { get; set; }

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
    public class ManagementCompanyInsertDTO
    {
        public string Name { get; set; } = null!;

        public string? TaxAddress { get; set; }

        public string? WebsiteUrl { get; set; }

        public string Ruc { get; set; } = null!;

        public string? LogoUrl { get; set; }

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public DateTime CreatedAt { get; set;}
    }
    public class ManagementCompanyUpdateDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? TaxAddress { get; set; }

        public string? WebsiteUrl { get; set; }

        public string Ruc { get; set; } = null!;

        public string? LogoUrl { get; set; }

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
    public class ManagementCompanyListDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? TaxAddress { get; set; }

        public string? WebsiteUrl { get; set; }

        public string Ruc { get; set; } = null!;

        public string? LogoUrl { get; set; }

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
    public class ManagementCompanyDeleteDTO
    {
        public int Id { get; set; }
    }
}
