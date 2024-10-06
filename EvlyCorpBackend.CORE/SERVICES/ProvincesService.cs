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
    public class ProvincesService : IProvincesService
    {
        private readonly IProvincesRepository _provincesRepository;
        public ProvincesService(IProvincesRepository provincesRepository)
        {
            _provincesRepository = provincesRepository;
        }
        public async Task<IEnumerable<ProvincesDepartmentsDTO>> GetAll()
        {
            var provinces = await _provincesRepository.GetAll();
            var ProvincesDTO = provinces.Select(provinces => new ProvincesDepartmentsDTO
            {
                Id = provinces.Id,
                Name = provinces.Name,
                Department = new DepartmentsListDTO
                {
                    Id = provinces.Department.Id,
                    Name = provinces.Department.Name,

                }

            });
            return ProvincesDTO;
        }
        public async Task<bool> Insert(ProvincesInsertDTO provincesInsertDTO)
        {
            var province = new Provinces();
            province.Name = provincesInsertDTO.Name;
            province.CreatedAt = provincesInsertDTO.CreatedAt;
            province.DepartmentId = provincesInsertDTO.DepartmentId;

            var result = await _provincesRepository.Insert(province);
            return result;
        }
        public async Task<bool> Update(ProvincesUpdateDTO provincesUpdateDTO)
        {
            var province = await _provincesRepository.GetById(provincesUpdateDTO.Id);
            if (province == null)
            {
                return false;
            }
            province.Name = provincesUpdateDTO.Name;
            province.UpdatedAt = provincesUpdateDTO.UpdatedAt;
            province.DepartmentId = provincesUpdateDTO.DepartmentId;

            var result = await _provincesRepository.Update(province);
            return result;
        }
        public async Task<bool> Delete(ProvincesDeleteDTO provincesDeleteDTO)
        {
            var result = await _provincesRepository.Delete(provincesDeleteDTO.Id);
            return result;
        }
        public async Task<ProvincesDepartmentsDTO> GetById(int id)
        {
            var province = await _provincesRepository.GetById(id);
            if (province == null)
            {
                return null;
            }
            var ProvincesDTO = new ProvincesDepartmentsDTO
            {
                Id = province.Id,
                Name = province.Name,
                Department = new DepartmentsListDTO
                {
                    Id = province.Department.Id,
                    Name = province.Department.Name,
                }
            };
            return ProvincesDTO;
        }
    }
}
