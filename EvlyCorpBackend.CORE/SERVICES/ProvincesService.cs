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
    public class ProvincesService : IProvincesService
    {
        private readonly IProvincesRepository _provincesRepository;
        public ProvincesService(IProvincesRepository provincesRepository)
        {
            _provincesRepository = provincesRepository;
        }
        public async Task<IEnumerable<ProvincesListDTO>> GetAll()
        {
            var provinces = await _provincesRepository.GetAll();
            var ProvincesDTO = provinces.Select(provinces => new ProvincesListDTO
            {
                Id = provinces.Id,
                Name = provinces.Name
            });
            return ProvincesDTO;
        }
        public async Task<bool> Insert(ProvincesInsertDTO provincesInsertDTO)
        {
            var province = new Provinces();
            province.Name = provincesInsertDTO.Name;
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
            var result = await _provincesRepository.Update(province);
            return result;
        }
        public async Task<bool> Delete(ProvincesDeleteDTO provincesDeleteDTO)
        {
            var result = await _provincesRepository.Delete(provincesDeleteDTO.Id);
            return result;
        }
        public async Task<ProvincesDTO> GetById(int id)
        {
            var province = await _provincesRepository.GetById(id);
            if (province == null)
            {
                return null;
            }
            var ProvincesDTO = new ProvincesDTO
            {
                Id = province.Id,
                Name = province.Name
            };
            return ProvincesDTO;
        }
    }
}
