using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.CORE.DTOs
{
    public class CondominiumWastesDTO
    {
        public int Id { get; set; }

        public decimal Weight { get; set; }

        public bool FreeCollection { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int WasteId { get; set; }
        public string status { get; set; }

        public int CondominiumId { get; set; }
    }
    public class CondominiumWastesPartDTO
    {
        public int Id { get; set; }

        public decimal Weight { get; set; }

        public bool FreeCollection { get; set; }
        public string Status { get; set; }

    }


    public class CondominiumWastesInsertDTO
    {

        public decimal Weight { get; set; }

        public bool FreeCollection { get; set; }

        public DateTime CreatedAt { get; set; }

        public int WasteId { get; set; }
        public string status { get; set; }

        public int CondominiumId { get; set; }
    }
    public class CondominiumWastesUpdateDTO
    {
        public int Id { get; set; }

        public decimal Weight { get; set; }

        public bool FreeCollection { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int WasteId { get; set; }
        public string status { get; set; }

        public int CondominiumId { get; set; }
    }

    public class CondominiumWastesListDTO
    {
        public int Id { get; set; }

        public decimal Weight { get; set; }

        public bool FreeCollection { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public string status { get; set; }
        public WastesListDTO Waste { get; set; }
        public CondominiumsListDTO Condominium { get; set; }
    }
}
