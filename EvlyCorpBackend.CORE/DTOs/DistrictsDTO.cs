using EvlyCorpBackend.INFRASTRUCTURE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.CORE.DTOs
{
    public class DistrictsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ProvinceId { get; set; }
        public int? DepartmentId { get; set; }
    }
    public class DistrictsInsertDTO
    {
        public string Name { get; set; } = null!;
        public int ProvinceId { get; set; }
        public int? DepartmentId { get; set; }
    }
    public class DistrictsUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ProvinceId { get; set; }
        public int? DepartmentId { get; set; }
    }
    public class DistrictsDeleteDTO
    {
        public int Id { get; set; }
    }
    public class DistrictsListDTO 
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual DepartmentsProvincesDTO Department { get; set; }


    }

}
