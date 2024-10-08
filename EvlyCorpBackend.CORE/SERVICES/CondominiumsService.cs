using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES;
using infrastructure.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.CORE.SERVICES
{
    public class CondominiumsService : ICondominiumsService
    {
        private readonly ICondominiumsRepository _repository;

        public CondominiumsService(ICondominiumsRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Insert(CondominiumsInsertDTO condominium)
        {
            var condominiums = new Condominiums()
            {
                Name = condominium.Name,
                Status = "ACTIVE",
                PostalCode = condominium.PostalCode,
                GoogleMapUrl = condominium.GoogleMapUrl,
                TotalArea = condominium.TotalArea,
                ProfitRate = condominium.ProfitRate,
                UnitTypes = condominium.UnitTypes,
                UnitsPerCondominium = condominium.UnitsPerCondominium,
                IncorporationDate = condominium.IncorporationDate,
                Address = condominium.Address,
                CreatedAt = DateTime.Now,
                MunicipalityId = condominium.MunicipalityId,
                RepresentativeId = condominium.RepresentativeId,
                ManagementCompanyId = condominium.ManagementCompanyId
            };
            return await _repository.Insert(condominiums);

        }
        public async Task<bool> Update(CondominiumsDTO condominium)
        {
            var condominiums = new Condominiums()
            {
                Id = condominium.Id,
                Name = condominium.Name,
                Status = condominium.Status,
                PostalCode = condominium.PostalCode,
                GoogleMapUrl = condominium.GoogleMapUrl,
                TotalArea = condominium.TotalArea,
                ProfitRate = condominium.ProfitRate,
                UnitTypes = condominium.UnitTypes,
                UnitsPerCondominium = condominium.UnitsPerCondominium,
                IncorporationDate = condominium.IncorporationDate,
                Address = condominium.Address,
                CreatedAt = condominium.CreatedAt,
                UpdatedAt = DateTime.Now,
                MunicipalityId = condominium.MunicipalityId,
                RepresentativeId = condominium.RepresentativeId,
                ManagementCompanyId = condominium.ManagementCompanyId
            };
            return await _repository.Update(condominiums);
        }
        public async Task<bool> Delete(CondominiumsDeleteDTO condominiumsDeleteDTO)
        {
            return await _repository.Delete(condominiumsDeleteDTO.Id);
        }
        public async Task<CondominiumsListDTO> GetById(int id)
        {
            var condominiums = await _repository.GetById(id);


            if (condominiums == null)
            {
                return null;
            }

            return new CondominiumsListDTO()
            {
                Id = condominiums.Id,
                Name = condominiums.Name,
                PostalCode = condominiums.PostalCode,
                GoogleMapUrl = condominiums.GoogleMapUrl,
                TotalArea = condominiums.TotalArea,
                ProfitRate = condominiums.ProfitRate,
                UnitTypes = condominiums.UnitTypes,
                UnitsPerCondominium = condominiums.UnitsPerCondominium,
                IncorporationDate = condominiums.IncorporationDate,
                Address = condominiums.Address,
                CreatedAt = condominiums.CreatedAt,
                UpdatedAt = condominiums.UpdatedAt,

                Municipality = condominiums.Municipality != null ? new MunicipalitiesListDTO()
                {
                    Id = condominiums.Municipality.Id,
                    Name = condominiums.Municipality.Name,
                    Address = condominiums.Municipality.Address,
                    LogoUrl = condominiums.Municipality.LogoUrl,
                    Phone = condominiums.Municipality.Phone,
                    Email = condominiums.Municipality.Email,
                } : null,

                Representative = condominiums.Representative != null ? new UsersListDTO()
                {
                    Id = condominiums.Representative.Id,
                    FirstName = condominiums.Representative.FirstName,
                    LastName = condominiums.Representative.LastName,
                    Document = condominiums.Representative.Document,
                    Phone = condominiums.Representative.Phone,
                    PhotoUrl = condominiums.Representative.PhotoUrl,
                    Email = condominiums.Representative.Email,
                    Address = condominiums.Representative.Address,
                    CreatedAt = condominiums.Representative.CreatedAt,
                    UpdatedAt = condominiums.Representative.UpdatedAt,

                    District = condominiums.Representative.District != null ? new DistrictsListDTO()
                    {
                        Id = condominiums.Representative.District.Id,
                        Name = condominiums.Representative.District.Name,
                        Province = condominiums.Representative.District.Province != null ? new ProvincesDepartmentsDTO()
                        {
                            Id = condominiums.Representative.District.Province.Id,
                            Name = condominiums.Representative.District.Province.Name,
                            Department = condominiums.Representative.District.Province.Department != null ? new DepartmentsListDTO()
                            {
                                Id = condominiums.Representative.District.Province.Department.Id,
                                Name = condominiums.Representative.District.Province.Department.Name
                            } : null

                        } : null

                    } : null

                } : null,
                ManagementCompany = condominiums.ManagementCompany != null ? new ManagementCompanyListDTO()
                {
                    Id = condominiums.ManagementCompany.Id,
                    Name = condominiums.ManagementCompany.Name,
                    TaxAddress = condominiums.ManagementCompany.TaxAddress,
                    WebsiteUrl = condominiums.ManagementCompany.WebsiteUrl,
                    Ruc = condominiums.ManagementCompany.Ruc,
                    LogoUrl = condominiums.ManagementCompany.LogoUrl,
                    Email = condominiums.ManagementCompany.Email,
                    Phone = condominiums.ManagementCompany.Phone,
                    CreatedAt = condominiums.ManagementCompany.CreatedAt,
                    UpdatedAt = condominiums.ManagementCompany.UpdatedAt
                } : null
            };
        }

        public async Task<IEnumerable<CondominiumsListDTO>> GetAll()
        {
            var condominiums = await _repository.GetAll();

            return condominiums.Select(x => new CondominiumsListDTO()
            {
                Id = x.Id,
                Name = x.Name,
                PostalCode = x.PostalCode,
                GoogleMapUrl = x.GoogleMapUrl,
                TotalArea = x.TotalArea,
                ProfitRate = x.ProfitRate,
                UnitTypes = x.UnitTypes,
                UnitsPerCondominium = x.UnitsPerCondominium,
                IncorporationDate = x.IncorporationDate,
                Address = x.Address,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,

                Municipality = x.Municipality != null ? new MunicipalitiesListDTO()
                {
                    Id = x.Municipality.Id,
                    Name = x.Municipality.Name,
                    Address = x.Municipality.Address,
                    LogoUrl = x.Municipality.LogoUrl,
                    Phone = x.Municipality.Phone,
                    Email = x.Municipality.Email,
                } : null,

                Representative = x.Representative != null ? new UsersListDTO()
                {
                    Id = x.Representative.Id,
                    FirstName = x.Representative.FirstName,
                    LastName = x.Representative.LastName,
                    Document = x.Representative.Document,
                    Phone = x.Representative.Phone,
                    PhotoUrl = x.Representative.PhotoUrl,
                    Email = x.Representative.Email,
                    Address = x.Representative.Address,
                    CreatedAt = x.Representative.CreatedAt,
                    UpdatedAt = x.Representative.UpdatedAt,

                    District = x.Representative.District != null ? new DistrictsListDTO()
                    {
                        Id = x.Representative.District.Id,
                        Name = x.Representative.District.Name,

                        Province = x.Representative.District.Province != null ? new ProvincesDepartmentsDTO()
                        {
                            Id = x.Representative.District.Province.Id,
                            Name = x.Representative.District.Province.Name,

                            Department = x.Representative.District.Province.Department != null ? new DepartmentsListDTO()
                            {
                                Id = x.Representative.District.Province.Department.Id,
                                Name = x.Representative.District.Province.Department.Name
                            } : null

                        } : null

                    } : null

                } : null,
                ManagementCompany = x.ManagementCompany != null ? new ManagementCompanyListDTO()
                {
                    Id = x.ManagementCompany.Id,
                    Name = x.ManagementCompany.Name,
                    TaxAddress = x.ManagementCompany.TaxAddress,
                    WebsiteUrl = x.ManagementCompany.WebsiteUrl,
                    Ruc = x.ManagementCompany.Ruc,
                    LogoUrl = x.ManagementCompany.LogoUrl,
                    Email = x.ManagementCompany.Email,
                    Phone = x.ManagementCompany.Phone,
                    CreatedAt = x.ManagementCompany.CreatedAt,
                    UpdatedAt = x.ManagementCompany.UpdatedAt
                } : null


            }).ToList();
        }
        public async Task<IEnumerable<CondominiumsListByRepreDTO>> GetAllR()
        {
            var condominiums = await _repository.GetAll();

            return condominiums.Select(x => new CondominiumsListByRepreDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status,
                PostalCode = x.PostalCode,
                GoogleMapUrl = x.GoogleMapUrl,
                TotalArea = x.TotalArea,
                ProfitRate = x.ProfitRate,
                UnitTypes = x.UnitTypes,
                UnitsPerCondominium = x.UnitsPerCondominium,
                IncorporationDate = x.IncorporationDate,
                Address = x.Address,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                RepresentativeId = x.RepresentativeId
            }).ToList();
        }
    }
}










