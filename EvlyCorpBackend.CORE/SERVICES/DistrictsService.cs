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

            var districtDTO = districts
                .Where(d => d != null)
                .Select(district => new DistrictsListDTO
                {
                    Id = district.Id,
                    Name = district.Name,
                    Province = district.Province != null ? new ProvincesDepartmentsDTO
                    {
                        Id = district.Province?.Id ?? 0,
                        Name = district.Province?.Name ?? string.Empty,
                        Department = district.Province.Department != null ? new DepartmentsListDTO
                        {
                            Id = district.Province.Department?.Id ?? 0,
                            Name = district.Province.Department?.Name ?? string.Empty 
                        } : null 
                    } : null 
                })
                .ToList();

            return districtDTO;
        }

        public async Task<DistrictsListDTO> GetById(int id)
        {
            var district = await _districtsRepository.GetById(id);

    
            if (district == null)
            {
                return null; 
            }

            return new DistrictsListDTO
            {
                Id = district.Id,
                Name = district.Name,

                Province = district.Province != null ? new ProvincesDepartmentsDTO
                {
                    Id = district.Province.Id,
                    Name = district.Province.Name,

                    Department = district.Province.Department != null ? new DepartmentsListDTO
                    {
                        Id = district.Province.Department.Id,
                        Name = district.Province.Department.Name
                    } : null 

                } : null 
            };
        }

        public async Task<bool> Insert(DistrictsInsertDTO district)
        {
            var districtEntity = new Districts();
            districtEntity.Name = district.Name;
            districtEntity.CreatedAt = district.CreatedAt;
            districtEntity.ProvinceId = district.ProvinceId;
 
            var result = await _districtsRepository.Insert(districtEntity);
            return result;
        }
        public async Task<bool> Update(DistrictsUpdateDTO district)
        {
            var districtEntity = await _districtsRepository.GetById(district.Id);
            if (districtEntity == null)
            {
                return false;
            }

            districtEntity.Name = district.Name;
            districtEntity.UpdatedAt = district.UpdatedAt;
            districtEntity.ProvinceId = district.ProvinceId;

            var result = await _districtsRepository.Update(districtEntity);
            return result;
        }
        public async Task<bool> Delete(DistrictsDeleteDTO district)
        {
            return await _districtsRepository.Delete(district.Id);
        }
    }
}
