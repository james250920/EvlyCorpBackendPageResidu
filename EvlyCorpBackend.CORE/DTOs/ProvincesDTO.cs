using EvlyCorpBackend.INFRASTRUCTURE.Data;
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
    }
    public class ProvincesInsertDTO
    {
        public string Name { get; set; } = null!;
    }
    public class ProvincesUpdateDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
    public class ProvincesListDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
    public class ProvincesDeleteDTO
    {
        public int Id { get; set; }
    }
    public class ProvincesDepartmentsDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Departments> Departments { get; set; }
    }
}
