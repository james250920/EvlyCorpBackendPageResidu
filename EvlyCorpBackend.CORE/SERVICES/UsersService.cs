using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES;
using EvlyCorpBackend.INFRASTRUCTURE.SHARED;
using infrastructure.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                DistrictId = usersInsertDTO.DistrictId,
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
            var userDTO = new UsersAuthenticationsDTO
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
                DistrictId = user.DistrictId,
                Role = user.Role,
                Token = token
            };
            return userDTO;
        }
        public async Task<bool> Update(UsersUpdateDTO usersUpdateDTO)
        {
            var user = new Users
            {
                Id = usersUpdateDTO.Id,
                FirstName = usersUpdateDTO.FirstName,
                LastName = usersUpdateDTO.LastName,
                Document = usersUpdateDTO.Document,
                DocumentType = usersUpdateDTO.DocumentType,
                Phone = usersUpdateDTO.Phone,
                PhotoUrl = usersUpdateDTO.PhotoUrl,
                Email = usersUpdateDTO.Email,
                Address = usersUpdateDTO.Address,
                DistrictId = usersUpdateDTO.DistrictId,
                Role = usersUpdateDTO.Role,
                Password = usersUpdateDTO.Password,
                UpdatedAt = DateTime.Now
            };
            return await _usersRepository.Update(user);
        }
        public async Task<bool> Delete(UsersDeleteDTO usersDeleteDTO)
        {
            return await _usersRepository.Delete(usersDeleteDTO.Id);
        }

        public async Task<UsersListDTO> GetById(int usersDTO)
        {
            var user = await _usersRepository.GetById(usersDTO);

            if (user == null)
            {
                // Manejo del caso en que el usuario no es encontrado
                throw new ArgumentNullException(nameof(user), "User not found.");
            }

            var userDTO = new UsersListDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Document = user.Document,
                Phone = user.Phone,
                PhotoUrl = user.PhotoUrl,
                Email = user.Email,
                Address = user.Address,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                District = user.District != null ? new DistrictsListDTO
                {
                    Id = user.District.Id,
                    Name = user.District.Name,
                    Province = user.District.Province != null ? new ProvincesDepartmentsDTO
                    {
                        Id = user.District.Province.Id,
                        Name = user.District.Province.Name,
                        Department = user.District.Province.Department != null ? new DepartmentsListDTO
                        {
                            Id = user.District.Province.Department.Id,
                            Name = user.District.Province.Department.Name,
                        } : null
                    } : null
                } : null
            };

            return userDTO;
        }






        public async Task<IEnumerable<UsersListDTO>> GetAll()
        {
            var users = await _usersRepository.GetAll();

            return users.Select(user => new UsersListDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Document = user.Document,
                Phone = user.Phone,
                PhotoUrl = user.PhotoUrl,
                Email = user.Email,
                Address = user.Address,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                
                District = user.District != null ? new DistrictsListDTO
                {
                    Id = user.District.Id,
                    Name = user.District.Name,
                    Province = user.District.Province != null ? new ProvincesDepartmentsDTO
                    {
                        Id = user.District.Province.Id,
                        Name = user.District.Province.Name,
                        Department = user.District.Province.Department != null ? new DepartmentsListDTO
                        {
                            Id = user.District.Province.Department.Id,
                            Name = user.District.Province.Department.Name,
                        } : null 
                    } : null  
                } : null  
            }).ToList();  
        }

        public async Task UpdatePartialAsync(int userId, UserUpdateProfileDTO userUpdateDto)
        {
            await _usersRepository.UpdatePartialAsync(userId, userUpdateDto);
        }
        
    }
}

       

            


 