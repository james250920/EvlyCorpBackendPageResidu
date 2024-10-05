using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using EvlyCorpBackend.INFRASTRUCTURE.Data;
using EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES;
using EvlyCorpBackend.INFRASTRUCTURE.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.CORE.SERVICES
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IJWTService _jwtService;

        public UsersService(IUsersRepository usersRepository, IJWTService jWTService)
        {
            _usersRepository = usersRepository;
            _jwtService = jWTService;
        }
        public async Task<bool> Register(UsersInsertDTO usersInsertDTO)
        {
            var existsUser = await _usersRepository.GetByEmail(usersInsertDTO.Email);
            if (existsUser)
            {
                return false;
            }
            var user = new Users
            {
                FirstName = usersInsertDTO.FirstName,
                LastName = usersInsertDTO.LastName,
                Document = usersInsertDTO.Document,
                DocumentType = usersInsertDTO.DocumentType,
                Phone = usersInsertDTO.Phone,
                PhotoUrl = usersInsertDTO.PhotoUrl,
                Email = usersInsertDTO.Email,
                Address = usersInsertDTO.Address,
                DepartmentId = usersInsertDTO.DepartmentId,
                Password = usersInsertDTO.Password,
                Role = usersInsertDTO.Role,
                CreatedAt = DateTime.Now
            };
            return await _usersRepository.Insert(user);
        }
        public async Task<UsersAuthenticationsDTO> Login(UsersLoginDTO usersLoginDTO)
        {
            var user = await _usersRepository.GetUserCredentials(usersLoginDTO.Email, usersLoginDTO.Password);
            if (user == null)
            {
                return null;
            }

            var token = _jwtService.GenerateJWToken(user);
            var userAuth = new UsersAuthenticationsDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Document = user.Document,
                DocumentType = user.DocumentType,
                Phone = user.Phone,
                PhotoUrl = user.PhotoUrl,
                Email = user.Email,
                Address = user.Address,
                DepartmentId = user.DepartmentId,
                Token = token
            };
            return userAuth;

        }
        public async Task<IEnumerable<UsersDepartmentsDTO>> GetAll()
        {
            var users = await _usersRepository.GetAll();
            var usersDTO = users.Select(u => new UsersDepartmentsDTO
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Document = u.Document,
                DocumentType = u.DocumentType,
                Phone = u.Phone,
                PhotoUrl = u.PhotoUrl,
                Email = u.Email,
                Address = u.Address,
                DepartmentId = u.DepartmentId,
                CreatedAt = u.CreatedAt,
                UpdatedAt = u.UpdatedAt,
                Department = new DepartmentsListDTO()
                {
                    Id = u.Department.Id,
                    Name = u.Department.Name,
                    ProvinceId = u.Department.ProvinceId
                }
            });
            return usersDTO;
        }
        public async Task<UsersDepartmentsDTO> GetById(int id)
        {
            var user = await _usersRepository.GetById(id);
            var userDTO = new UsersDepartmentsDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Document = user.Document,
                DocumentType = user.DocumentType,
                Phone = user.Phone,
                PhotoUrl = user.PhotoUrl,
                Email = user.Email,
                Address = user.Address,
                DepartmentId = user.DepartmentId,
                CreatedAt = user.CreatedAt,

                UpdatedAt = user.UpdatedAt,
                Department = new DepartmentsListDTO()
                {
                    Id = user.Department.Id,
                    Name = user.Department.Name,
                    ProvinceId = user.Department.ProvinceId
                }
            };
            return userDTO;
        }
        public async Task<bool> Update(UsersUpdateDTO usersUpdateDTO)
        {
            var user = await _usersRepository.GetById(usersUpdateDTO.Id);
            if (user == null)
            {
                return false;
            }

            user.FirstName = usersUpdateDTO.FirstName;
            user.LastName = usersUpdateDTO.LastName;
            user.Document = usersUpdateDTO.Document;
            user.DocumentType = usersUpdateDTO.DocumentType;
            user.Phone = usersUpdateDTO.Phone;
            user.PhotoUrl = usersUpdateDTO.PhotoUrl;
            user.Email = usersUpdateDTO.Email;
            user.Address = usersUpdateDTO.Address;
            user.DepartmentId = usersUpdateDTO.DepartmentId;
            user.Password = usersUpdateDTO.Password;
            user.UpdatedAt = DateTime.Now;
            var result = await _usersRepository.Update(user);
            return result;


        }


    }
}
