﻿using System;
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
        public int DepartmentId { get; set; }
        public string Password { get; set; } = null!;
        public string? Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class UsersListDTO
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
        public int DepartmentId { get; set; }

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
        public int DepartmentId { get; set; }
        public string Password { get; set; } = null!;
        public string? Role { get; set; }
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
        public int DepartmentId { get; set; }
        public string Password { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
    }
    public class UsersDeleteDTO
    {
        public int Id { get; set; }
    }
    public class UsersDepartmentsDTO
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
        public int DepartmentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DepartmentsListDTO Department { get; set; } = null!;
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
        public int DepartmentId { get; set; }
        public string? Token { get; set; }
    }
    public class UsersLoginDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
