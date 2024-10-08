using infrastructure.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.CORE.DTOs
{
    public class OrdersDTO
    {
        public int Id { get; set; }

        public string Status { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int CondominiumWasteId { get; set; }

        public int WasteId { get; set; }



    }
    public class OrdersListDTO
    {
        public int Id { get; set; }

        public string Status { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public CondominiumWastesPartDTO CondominiumWaste { get; set; }

        public WastesListDTO Waste { get; set; }
    }
    public class OrdersInsertDTO
    {
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public int CondominiumWasteId { get; set; }
        public int WasteId { get; set; }

    }
    public class OrdersUpdateDTO
    {
        public int Id { get; set; }

        public string Status { get; set; } = null!;

        public DateTime UpdatedAt { get; set; }

        public int CondominiumWasteId { get; set; }

        public int WasteId { get; set; }


    }
    public class OrdersDeleteDTO
    {
        public int Id { get; set; }
    }

}
