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
    public class CondominiumWastesService : ICondominiumWastesService
    {
        private readonly ICondominiumWastesRepository _condominiumWastesRepository;

        public CondominiumWastesService(ICondominiumWastesRepository condominiumWastesRepository)
        {
            _condominiumWastesRepository = condominiumWastesRepository;

        }

        public async Task<bool> Insert(CondominiumWastesInsertDTO condominiumWastesInsertDTO)
        {
            var condominiumWastes = new CondominiumWastes()
            {
                Weight = condominiumWastesInsertDTO.Weight,
                FreeCollection = condominiumWastesInsertDTO.FreeCollection,
                CreatedAt = DateTime.Now,
                WasteId = condominiumWastesInsertDTO.WasteId,
                Status = "Activo",
                CondominiumId = condominiumWastesInsertDTO.CondominiumId
            };

            return await _condominiumWastesRepository.Insert(condominiumWastes);


        }

        public async Task<bool> Update(CondominiumWastesUpdateDTO condominiumWastesUpdateDTO)
        {
            var condominiumWastes = new CondominiumWastes
            {
                Id = condominiumWastesUpdateDTO.Id,
                Weight = condominiumWastesUpdateDTO.Weight,
                FreeCollection = condominiumWastesUpdateDTO.FreeCollection,
                UpdatedAt = DateTime.Now,
                WasteId = condominiumWastesUpdateDTO.WasteId,
                Status = condominiumWastesUpdateDTO.status,
                CondominiumId = condominiumWastesUpdateDTO.CondominiumId
            };

            var result = await _condominiumWastesRepository.Update(condominiumWastes);


            return result;
            ;
        }
        public async Task<bool> Delete(int id)
        {
            return await _condominiumWastesRepository.Delete(id);
        }
        public async Task<CondominiumWastesListDTO> GetById(int id)
        {
            var condominiumWastes = await _condominiumWastesRepository.GetById(id);

            if (condominiumWastes == null)
            {
                return null; 
            }

            var condominiumWastesDTO = new CondominiumWastesListDTO
            {
                Id = condominiumWastes.Id,
                Weight = condominiumWastes.Weight,
                FreeCollection = condominiumWastes.FreeCollection,
                CreatedAt = condominiumWastes.CreatedAt,
                UpdatedAt = condominiumWastes.UpdatedAt,
                status = condominiumWastes.Status,

                Waste = condominiumWastes.Waste != null ? new WastesListDTO
                {
                    Id = condominiumWastes.Waste.Id,
                    Name = condominiumWastes.Waste.Name,
                    Price = condominiumWastes.Waste.Price,
                    MeasurementUnit = condominiumWastes.Waste.MeasurementUnit
                } : null,

                Condominium = condominiumWastes.Condominium != null ? new CondominiumsListDTO
                {
                    Id = condominiumWastes.Condominium.Id,
                    Name = condominiumWastes.Condominium.Name,
                    PostalCode = condominiumWastes.Condominium.PostalCode,
                    GoogleMapUrl = condominiumWastes.Condominium.GoogleMapUrl,
                    TotalArea = condominiumWastes.Condominium.TotalArea,
                    ProfitRate = condominiumWastes.Condominium.ProfitRate,
                    UnitTypes = condominiumWastes.Condominium.UnitTypes,
                    UnitsPerCondominium = condominiumWastes.Condominium.UnitsPerCondominium,
                    IncorporationDate = condominiumWastes.Condominium.IncorporationDate,
                    Address = condominiumWastes.Condominium.Address,
                    CreatedAt = condominiumWastes.Condominium.CreatedAt,
                    UpdatedAt = condominiumWastes.Condominium.UpdatedAt,

                    Municipality = condominiumWastes.Condominium.Municipality != null ? new MunicipalitiesListDTO
                    {
                        Id = condominiumWastes.Condominium.Municipality.Id,
                        Name = condominiumWastes.Condominium.Municipality.Name,
                        Address = condominiumWastes.Condominium.Municipality.Address,
                        LogoUrl = condominiumWastes.Condominium.Municipality.LogoUrl,
                        Phone = condominiumWastes.Condominium.Municipality.Phone,
                        Email = condominiumWastes.Condominium.Municipality.Email,
                    } : null, 

                    Representative = condominiumWastes.Condominium.Representative != null ? new UsersListDTO
                    {
                        Id = condominiumWastes.Condominium.Representative.Id,
                        FirstName = condominiumWastes.Condominium.Representative.FirstName,
                        LastName = condominiumWastes.Condominium.Representative.LastName,
                        Document = condominiumWastes.Condominium.Representative.Document,
                        Phone = condominiumWastes.Condominium.Representative.Phone,
                        PhotoUrl = condominiumWastes.Condominium.Representative.PhotoUrl,
                        Email = condominiumWastes.Condominium.Representative.Email,
                        Address = condominiumWastes.Condominium.Representative.Address,
                        CreatedAt = condominiumWastes.Condominium.Representative.CreatedAt,
                        UpdatedAt = condominiumWastes.Condominium.Representative.UpdatedAt,

                        District = condominiumWastes.Condominium.Representative.District != null ? new DistrictsListDTO
                        {
                            Id = condominiumWastes.Condominium.Representative.District.Id,
                            Name = condominiumWastes.Condominium.Representative.District.Name,
                            Province = condominiumWastes.Condominium.Representative.District.Province != null ? new ProvincesDepartmentsDTO
                            {
                                Id = condominiumWastes.Condominium.Representative.District.Province.Id,
                                Name = condominiumWastes.Condominium.Representative.District.Province.Name,
                                Department = condominiumWastes.Condominium.Representative.District.Province.Department != null ? new DepartmentsListDTO
                                {
                                    Id = condominiumWastes.Condominium.Representative.District.Province.Department.Id,
                                    Name = condominiumWastes.Condominium.Representative.District.Province.Department.Name,
                                } : null 
                            } : null 

                        } : null 

                    } : null 

                } : null 
            };

            return condominiumWastesDTO;
        }


        public async Task<List<CondominiumWastesListDTO>> GetAll()
        {
            var condominiumWastes = await _condominiumWastesRepository.GetAll();

            var condominiumWastesDTO = condominiumWastes.Select(c => new CondominiumWastesListDTO
            {
                Id = c.Id,
                Weight = c.Weight,
                FreeCollection = c.FreeCollection,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt,
                status = c.Status,

                Waste = c.Waste != null ? new WastesListDTO
                {
                    Id = c.Waste.Id,
                    Name = c.Waste.Name,
                    Price = c.Waste.Price,
                    MeasurementUnit = c.Waste.MeasurementUnit
                } : null, 

                Condominium = c.Condominium != null ? new CondominiumsListDTO
                {
                    Id = c.Condominium.Id,
                    Name = c.Condominium.Name,
                    PostalCode = c.Condominium.PostalCode,
                    GoogleMapUrl = c.Condominium.GoogleMapUrl,
                    TotalArea = c.Condominium.TotalArea,
                    ProfitRate = c.Condominium.ProfitRate,
                    UnitTypes = c.Condominium.UnitTypes,
                    UnitsPerCondominium = c.Condominium.UnitsPerCondominium,
                    IncorporationDate = c.Condominium.IncorporationDate,
                    Address = c.Condominium.Address,
                    CreatedAt = c.Condominium.CreatedAt,
                    UpdatedAt = c.Condominium.UpdatedAt,

                    Municipality = c.Condominium.Municipality != null ? new MunicipalitiesListDTO
                    {
                        Id = c.Condominium.Municipality.Id,
                        Name = c.Condominium.Municipality.Name,
                        Address = c.Condominium.Municipality.Address,
                        LogoUrl = c.Condominium.Municipality.LogoUrl,
                        Phone = c.Condominium.Municipality.Phone,
                        Email = c.Condominium.Municipality.Email,
                    } : null, 

                    Representative = c.Condominium.Representative != null ? new UsersListDTO
                    {
                        Id = c.Condominium.Representative.Id,
                        FirstName = c.Condominium.Representative.FirstName,
                        LastName = c.Condominium.Representative.LastName,
                        Document = c.Condominium.Representative.Document,
                        Phone = c.Condominium.Representative.Phone,
                        PhotoUrl = c.Condominium.Representative.PhotoUrl,
                        Email = c.Condominium.Representative.Email,
                        Address = c.Condominium.Representative.Address,
                        CreatedAt = c.Condominium.Representative.CreatedAt,
                        UpdatedAt = c.Condominium.Representative.UpdatedAt,

                        District = c.Condominium.Representative.District != null ? new DistrictsListDTO
                        {
                            Id = c.Condominium.Representative.District.Id,
                            Name = c.Condominium.Representative.District.Name,
                            Province = c.Condominium.Representative.District.Province != null ? new ProvincesDepartmentsDTO
                            {
                                Id = c.Condominium.Representative.District.Province.Id,
                                Name = c.Condominium.Representative.District.Province.Name,
                                Department = c.Condominium.Representative.District.Province.Department != null ? new DepartmentsListDTO
                                {
                                    Id = c.Condominium.Representative.District.Province.Department.Id,
                                    Name = c.Condominium.Representative.District.Province.Department.Name,
                                } : null 
                            } : null 

                        } : null 

                    } : null 

                } : null 
            });

            return condominiumWastesDTO.ToList();
        }




    }
}
