using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using EvlyCorpBackend.INFRASTRUCTURE.Data;
using EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.CORE.SERVICES
{
    public class DepartmentsService : IDepartmentsService
    {
        private readonly IDepartmentsRepository _departmentsRepository;

        public DepartmentsService(IDepartmentsRepository departmentsRepository)
        {
            _departmentsRepository = departmentsRepository;

        }
       

        public async Task<IEnumerable<DepartmentsProvincesDTO>> GetAll()
        {
            var departments = await _departmentsRepository.GetAll();

            var departmentsDTO = departments.Select(p => new DepartmentsProvincesDTO
            {
                Id = p.Id,
                Name = p.Name,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Province = new ProvincesListDTO()
                {
                    Id = p.Province.Id,
                    Name = p.Province.Name
                }
            });
            return departmentsDTO;
        }
        public async Task<DepartmentsProvincesDTO> GetById(int id)
        {
            var department = await _departmentsRepository.GetById(id);
            var departmentsDTO = new DepartmentsProvincesDTO
            {
                Id = department.Id,
                Name = department.Name,
                CreatedAt = department.CreatedAt,
                UpdatedAt = department.UpdatedAt,
                Province = new ProvincesListDTO()
                {
                    Id = department.Province.Id,
                    Name = department.Province.Name
                }
            };
            return departmentsDTO;

        }
        
        public async Task<bool> Insert(DepartmentsInsertDTO department)

        {
           
            var departmentEntity = new Departments()
            {
                Name = department.Name,
                ProvinceId = department.ProvinceId,
                CreatedAt = DateTime.Now

            };
            


            return await _departmentsRepository.Insert(departmentEntity)  ;
        }

        public async Task<bool> Update(DepartmentsUpdateDTO departmentUpdateDto)
        {
            var departments = await _departmentsRepository.GetById(departmentUpdateDto.Id);
            if (departments == null)
                return false;

            departments.Id = departmentUpdateDto.Id;
            departments.Name = departmentUpdateDto.Name;
            departments.ProvinceId = departmentUpdateDto.ProvinceId;
            departments.UpdatedAt = DateTime.Now;

            var result = await _departmentsRepository.Update(departments);
            return result;

        }
        public async Task<bool> Delete(DepartmentsDeleteDTO department)
        {
            return await _departmentsRepository.Delete(department.Id);
        }
    }
}
