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
    public class ManagementCompanyService : IManagementCompanyService
    {
        private readonly IManagementCompanyRepository _managementCompanyRepository;

        public ManagementCompanyService(IManagementCompanyRepository managementCompanyRepository)
        {
            _managementCompanyRepository = managementCompanyRepository;
        }

        public async Task<IEnumerable<ManagementCompanyDTO>> GetAll()
        {
            var managementCompany = await _managementCompanyRepository.GetAll();
            var managementCompanyDTO = managementCompany.Select(managementCompany => new ManagementCompanyDTO
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
            });
            return managementCompanyDTO;
        }

        public async Task<bool> Insert(ManagementCompanyInsertDTO managementCompanyInsertDTO)
        {
            var managementCompany = new ManagementCompany();
            managementCompany.Name = managementCompanyInsertDTO.Name;
            managementCompany.TaxAddress = managementCompanyInsertDTO.TaxAddress;
            managementCompany.WebsiteUrl = managementCompanyInsertDTO.WebsiteUrl;
            managementCompany.Ruc = managementCompanyInsertDTO.Ruc;
            managementCompany.LogoUrl = managementCompanyInsertDTO.LogoUrl;
            managementCompany.Email = managementCompanyInsertDTO.Email;
            managementCompany.Phone = managementCompanyInsertDTO.Phone;
            managementCompany.CreatedAt = DateTime.Now;
            var result = await _managementCompanyRepository.Insert(managementCompany);
            return result;
        }
        public async Task<bool> Update(ManagementCompanyUpdateDTO managementCompanyUpdateDTO)
        {
            var managementCompany = await _managementCompanyRepository.GetById(managementCompanyUpdateDTO.Id);
            if (managementCompany == null)
            {
                return false;
            }
            managementCompany.Name = managementCompanyUpdateDTO.Name;
            managementCompany.TaxAddress = managementCompanyUpdateDTO.TaxAddress;
            managementCompany.WebsiteUrl = managementCompanyUpdateDTO.WebsiteUrl;
            managementCompany.Ruc = managementCompanyUpdateDTO.Ruc;
            managementCompany.LogoUrl = managementCompanyUpdateDTO.LogoUrl;
            managementCompany.Email = managementCompanyUpdateDTO.Email;
            managementCompany.Phone = managementCompanyUpdateDTO.Phone;
            managementCompany.UpdatedAt = DateTime.Now;
            var result = await _managementCompanyRepository.Update(managementCompany);
            return result;
        }
        public async Task<bool> Delete(ManagementCompanyDeleteDTO managementCompanyDeleteDTO)
        {
            var result = await _managementCompanyRepository.Delete(managementCompanyDeleteDTO.Id);
            return result;
        }
        public async Task<ManagementCompanyDTO> GetById(int id)
        {
            var managementCompany = await _managementCompanyRepository.GetById(id);
            if (managementCompany == null)
            {
                return null;
            }
            var managementCompanyDTO = new ManagementCompanyDTO
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
            };
            return managementCompanyDTO;
        }



    }
}
