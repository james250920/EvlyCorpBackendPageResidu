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
    public class MunicipalitiesService : ImunicipalitiesService
    {
        private readonly IMunicipalitiesRepository _municipalitiesRepository;
        public MunicipalitiesService(IMunicipalitiesRepository municipalitiesRepository)
        {
            _municipalitiesRepository = municipalitiesRepository;
        }
        public async Task<IEnumerable<MunicipalitiesListDTO>> GetAll()
        {
            var municipalities = await _municipalitiesRepository.GetAll();
            var MunicipalitiesDTO = municipalities.Select(municipalities => new MunicipalitiesListDTO
            {
                Id = municipalities.Id,
                Name = municipalities.Name,
                Address = municipalities.Address,
                LogoUrl = municipalities.LogoUrl,
                Phone = municipalities.Phone,
                Email = municipalities.Email

            });
            return MunicipalitiesDTO;
        }
        public async Task<bool> Insert(MunicipalitiesInsertDTO municipalitiesInsertDTO)
        {
            var municipality = new Municipalities();
            municipality.Name = municipalitiesInsertDTO.Name;
            municipality.Address = municipalitiesInsertDTO.Address;
            municipality.LogoUrl = municipalitiesInsertDTO.LogoUrl;
            municipality.Phone = municipalitiesInsertDTO.Phone;
            municipality.Email = municipalitiesInsertDTO.Email;
            municipality.CreatedAt = DateTime.Now;
            municipality.UpdatedAt = DateTime.Now;
            var result = await _municipalitiesRepository.Insert(municipality);
            return result;

        }
        public async Task<bool> Update(MunicipalitiesUpdateDTO municipalitiesUpdateDTO)
        {
            var municipality = await _municipalitiesRepository.GetById(municipalitiesUpdateDTO.Id);
            if (municipality == null)
            {
                return false;
            }
            municipality.Name = municipalitiesUpdateDTO.Name;
            municipality.Address = municipalitiesUpdateDTO.Address;
            municipality.LogoUrl = municipalitiesUpdateDTO.LogoUrl;
            municipality.Phone = municipalitiesUpdateDTO.Phone;
            municipality.Email = municipalitiesUpdateDTO.Email;
            municipality.UpdatedAt = DateTime.Now;
            var result = await _municipalitiesRepository.Update(municipality);
            return result;
        }
        public async Task<bool> Delete(int id)
        {
            var result = await _municipalitiesRepository.Delete(id);
            return result;
        }

    }
}
