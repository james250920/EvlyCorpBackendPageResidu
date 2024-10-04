using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using EvlyCorpBackend.INFRASTRUCTURE.Data;
using EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.CORE.SERVICES
{
    public class DistrictsService : IDistrictsService
    {
        private readonly IDistrictsRepository _districtsRepository;
        public DistrictsService(IDistrictsRepository districtsRepository)
        {
            _districtsRepository = districtsRepository;
        }
        public async Task<IEnumerable<DistrictsListDTO>> GetAll()
        {
            var districts = await _districtsRepository.GetAll();
            var districtsDTO = districts.Select(x => new DistrictsListDTO
            {
                Id = x.Id,
                Name = x.Name,
                Department = new DepartmentsProvincesDTO
                {
                    Id = x.Department.Id,
                    Name = x.Department.Name,
                    Province = new ProvincesListDTO
                    {
                        Id = x.Department.Province.Id,
                        Name = x.Department.Province.Name
                    }
                },

            }).ToList();
            return districtsDTO;
        }
        public async Task<DistrictsListDTO> GetById(int id)
        {
            var district = await _districtsRepository.GetById(id);
            var districtsDTO = new DistrictsListDTO
            {
                Id = district.Id,
                Name = district.Name,
                Department = new DepartmentsProvincesDTO
                {
                    Id = district.Department.Id,
                    Name = district.Department.Name,
                    Province = new ProvincesListDTO
                    {
                        Id = district.Department.Province.Id,
                        Name = district.Department.Province.Name
                    }
                }

            };
            return districtsDTO;
        }
        public async Task<bool> Insert(DistrictsInsertDTO district)
        {
            var districtEntity = new DistrictsUpdatetDTO
            {
                Name = district.Name,
                ProvinceId = district.ProvinceId,
                DepartmentId = district.DepartmentId
            };
            return await _districtsRepository.Insert(districtEntity);
        }
        public async Task<bool> Update(DistrictsUpdateDTO district)
        {
            var districtEntity = new DistrictsUpdatetDTO
            {
                Id = district.Id,
                Name = district.Name,
                ProvinceId = district.ProvinceId,
                DepartmentId = district.DepartmentId
            };
            return await _districtsRepository.Update(districtEntity);
        }
        public async Task<bool> Delete(DistrictsDeleteDTO district)
        {
            return await _districtsRepository.Delete(district.Id);
        }
    }
}
