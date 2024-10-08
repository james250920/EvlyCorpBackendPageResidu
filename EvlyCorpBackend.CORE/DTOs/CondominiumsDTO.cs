using infrastructure.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.CORE.DTOs
{
    public class CondominiumsDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Status { get; set; } = null!;

        public string? PostalCode { get; set; }

        public string? GoogleMapUrl { get; set; }

        public decimal? TotalArea { get; set; }

        public decimal? ProfitRate { get; set; }

        public string UnitTypes { get; set; } = null!;

        public int UnitsPerCondominium { get; set; }

        public DateTime? IncorporationDate { get; set; }

        public string? Address { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int MunicipalityId { get; set; }

        public int RepresentativeId { get; set; }

        public int ManagementCompanyId { get; set; } // Foreign Key para ManagementCompany


    }
    public class CondominiumsInsertDTO
    {


        public string Name { get; set; } = null!;

        public string Status { get; set; } = null!;

        public string? PostalCode { get; set; }

        public string? GoogleMapUrl { get; set; }

        public decimal? TotalArea { get; set; }

        public decimal? ProfitRate { get; set; }

        public string UnitTypes { get; set; } = null!;

        public int UnitsPerCondominium { get; set; }

        public DateTime? IncorporationDate { get; set; }

        public string? Address { get; set; }

        public DateTime CreatedAt { get; set; }

        public int MunicipalityId { get; set; }

        public int RepresentativeId { get; set; }
        public int ManagementCompanyId { get; set; } // Foreign Key para ManagementCompany


    }
    public class CondominiumsUpdateDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Status { get; set; } = null!;

        public string? PostalCode { get; set; }

        public string? GoogleMapUrl { get; set; }

        public decimal? TotalArea { get; set; }

        public decimal? ProfitRate { get; set; }

        public string UnitTypes { get; set; } = null!;

        public int UnitsPerCondominium { get; set; }
        public string? Address { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int MunicipalityId { get; set; }

        public int RepresentativeId { get; set; }
        public int ManagementCompanyId { get; set; } // Foreign Key para ManagementCompany




    }
    public class CondominiumsDeleteDTO
    {
        public int Id { get; set; }
    }
    public class CondominiumsListDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;


        public string? PostalCode { get; set; }

        public string? GoogleMapUrl { get; set; }

        public decimal? TotalArea { get; set; }

        public decimal? ProfitRate { get; set; }

        public string UnitTypes { get; set; } = null!;

        public int UnitsPerCondominium { get; set; }

        public DateTime? IncorporationDate { get; set; }

        public string? Address { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
   
        public MunicipalitiesListDTO Municipality { get; set; } = null!;

        public UsersListDTO Representative { get; set; } = null!;
        public ManagementCompanyListDTO ManagementCompany { get; set; } = null!;
    }
    public class CondominiumsListRDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;


        public string? PostalCode { get; set; }

        public string? GoogleMapUrl { get; set; }

        public decimal? TotalArea { get; set; }

        public decimal? ProfitRate { get; set; }

        public string UnitTypes { get; set; } = null!;

        public int UnitsPerCondominium { get; set; }

        public DateTime? IncorporationDate { get; set; }

        public string? Address { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public UsersListDTO Representative { get; set; }
        public ManagementCompanyListDTO Company { get; set; }

    }


}
