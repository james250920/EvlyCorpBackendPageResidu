namespace EvlyCorpBackend.CORE.DTOs
{
    public class DepartmentsDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
    public class DepartmentsListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        
    }
    public class DepartmentsInsertDTO
    {
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

    
    }
    public class DepartmentsUpdateDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public int? ProvinceId { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class DepartmentsDeleteDTO
    {
        public int Id { get; set; }
    }

    ///usersReferences
    public class DepartmentsUsersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}


