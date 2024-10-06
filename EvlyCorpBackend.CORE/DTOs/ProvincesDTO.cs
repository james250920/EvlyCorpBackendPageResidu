
using infrastructure.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.CORE.DTOs
{
    public class ProvincesDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int? DepartmentId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


    }
    public class ProvincesInsertDTO
    {

        public string Name { get; set; } = null!;

        public int? DepartmentId { get; set; }

        public DateTime CreatedAt { get; set; }

    }
    public class ProvincesUpdateDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int? DepartmentId { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
   
    public class ProvincesDeleteDTO
    {
        public int Id { get; set; }
    }
    public class ProvincesDepartmentsDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;


        public DepartmentsListDTO Department { get; set; }
    }
}
