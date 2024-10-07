using infrastructure.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.CORE.DTOs
{
    public class UsersDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Document { get; set; } = null!;
        public string DocumentType { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? PhotoUrl { get; set; }
        public string Email { get; set; } = null!;
        public string? Address { get; set; }
        public int DistrictId { get; set; }
        public string Role { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
    public class UsersListDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Document { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? PhotoUrl { get; set; }
        public string Email { get; set; } = null!;
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DistrictsListDTO District { get; set; } = null!;

    }
    public class UsersInsertDTO
    {
    
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Document { get; set; } = null!;
        public string DocumentType { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? PhotoUrl { get; set; }
        public string Email { get; set; } = null!;
        public string? Address { get; set; }
        public int DistrictId { get; set; }
        public string Role { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
       
    }
    public class UsersUpdateDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Document { get; set; } = null!;
        public string DocumentType { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? PhotoUrl { get; set; }
        public string Email { get; set; } = null!;
        public string? Address { get; set; }
        public int DistrictId { get; set; }
        public string Role { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
    }
    public class UsersDeleteDTO
    {
        public int Id { get; set; }
    }
   
    public class UsersAuthenticationsDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Document { get; set; } = null!;
        public string DocumentType { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? PhotoUrl { get; set; }
        public string Email { get; set; } = null!;
        public string? Address { get; set; }
        public int DistrictId { get; set; }
        public string Role { get; set; } = null!;
        public string? Token { get; set; }
    }
    public class UsersLoginDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
    public class UserUpdateProfileDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }

    //Reciclers
    public class UsersRecyclerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Document { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? PhotoUrl { get; set; }
        public string Email { get; set; } = null!;
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DistrictsListDTO District { get; set; } = null!;
    }


}
