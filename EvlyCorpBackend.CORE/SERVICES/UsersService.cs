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

            // Acceder al primer ManagementCompany si existe
            var firstCondominium = user.Condominiums?.FirstOrDefault();
            var managementCompany = firstCondominium?.ManagementCompany;

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

                // Mapeo del distrito
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
                            Name = user.District.Province.Department.Name
                        } : null
                    } : null
                } : null,

                Role = user.Role,
                /*Mapeo de ManagementCompany
                Company = managementCompany != null ? new ManagementCompanyListDTO
                {
                    Id = managementCompany.Id,
                    Name = managementCompany.Name,
                    TaxAddress = managementCompany.TaxAddress,
                    WebsiteUrl = managementCompany.WebsiteUrl,
                    Ruc = managementCompany.Ruc,
                    LogoUrl = managementCompany.LogoUrl,
                    Email = managementCompany.Email,
                    Phone = managementCompany.Phone,
                    CreatedAt = managementCompany.CreatedAt,
                    UpdatedAt = managementCompany.UpdatedAt
                } : null,
                */
                // Mapeo del departamento
                Department = user.District?.Province?.Department != null ? new DepartmentsUsersDTO
                {
                    Id = user.District.Province.Department.Id,
                    Name = user.District.Province.Department.Name,
                    CreatedAt = user.District.Province.Department.CreatedAt,
                    UpdatedAt = user.District.Province.Department.UpdatedAt
                } : null,

                // Lista de condominios
                Condominiums = user.Condominiums?.Select(condominium => new CondominiumsListRDTO
                {
                    Id = condominium.Id,
                    Name = condominium.Name,
                    PostalCode = condominium.PostalCode,
                    GoogleMapUrl = condominium.GoogleMapUrl,
                    TotalArea = condominium.TotalArea,
                    ProfitRate = condominium.ProfitRate,
                    UnitTypes = condominium.UnitTypes,
                    UnitsPerCondominium = condominium.UnitsPerCondominium,
                    IncorporationDate = condominium.IncorporationDate,
                    Address = condominium.Address,
                    CreatedAt = condominium.CreatedAt,
                    UpdatedAt = condominium.UpdatedAt,

                    // Mapeo del representante
                    Representative = condominium.Representative != null ? new UsersListDTO
                    {
                        Id = condominium.Representative.Id,
                        FirstName = condominium.Representative.FirstName,
                        LastName = condominium.Representative.LastName,
                        Document = condominium.Representative.Document,
                        Phone = condominium.Representative.Phone,
                        PhotoUrl = condominium.Representative.PhotoUrl,
                        Email = condominium.Representative.Email,
                        Address = condominium.Representative.Address,
                        CreatedAt = condominium.Representative.CreatedAt,
                        UpdatedAt = condominium.Representative.UpdatedAt,

                        // Mapeo del distrito del representante
                        District = condominium.Representative.District != null ? new DistrictsListDTO
                        {
                            Id = condominium.Representative.District.Id,
                            Name = condominium.Representative.District.Name,
                            Province = condominium.Representative.District.Province != null ? new ProvincesDepartmentsDTO
                            {
                                Id = condominium.Representative.District.Province.Id,
                                Name = condominium.Representative.District.Province.Name,
                                Department = condominium.Representative.District.Province.Department != null ? new DepartmentsListDTO
                                {
                                    Id = condominium.Representative.District.Province.Department.Id,
                                    Name = condominium.Representative.District.Province.Department.Name
                                } : null
                            } : null
                        } : null
                    } : null,

                    Company = condominium.ManagementCompany != null ? new ManagementCompanyListDTO
                    {
                        Id = condominium.ManagementCompany.Id,
                        Name = condominium.ManagementCompany.Name,
                        TaxAddress = condominium.ManagementCompany.TaxAddress,
                        WebsiteUrl = condominium.ManagementCompany.WebsiteUrl,
                        Ruc = condominium.ManagementCompany.Ruc,
                        LogoUrl = condominium.ManagementCompany.LogoUrl,
                        Email = condominium.ManagementCompany.Email,
                        Phone = condominium.ManagementCompany.Phone,
                        CreatedAt = condominium.ManagementCompany.CreatedAt,
                        UpdatedAt = condominium.ManagementCompany.UpdatedAt
                    } : null
                }).ToList(),

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
       
        public async Task<UsersListDTO> GetByIdRecycler(int usersDTO)
        {
            var user = await _usersRepository.GetByIdRecycler(usersDTO);

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
        public async Task<IEnumerable<UsersListDTO>> GetAllRecyclers()
        {
            var users = await _usersRepository.GetAllRecyclers();

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

    }
}

       

            


 