using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES;
using infrastructure.DATA;
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


        public async Task<IEnumerable<DepartmentsListDTO>> GetAll()
        {
            var departments = await _departmentsRepository.GetAll();

            var departmentsDTO = departments.Select(p => new DepartmentsListDTO
            {
                Id = p.Id,
                Name = p.Name,


            });
            return departmentsDTO;
        }
        public async Task<DepartmentsDTO> GetById(int id)
        {
            var department = await _departmentsRepository.GetById(id);
            var departmentsDTO = new DepartmentsDTO
            {
                Id = department.Id,
                Name = department.Name,
                CreatedAt = department.CreatedAt,
                UpdatedAt = department.UpdatedAt,

            };
            return departmentsDTO;

        }

        public async Task<bool> Insert(DepartmentsInsertDTO department)

        {

            var departmentEntity = new Departments()
            {
                Name = department.Name,
                CreatedAt = DateTime.Now

            };

            return await _departmentsRepository.Insert(departmentEntity);
        }

        public async Task<bool> Update(DepartmentsUpdateDTO departmentUpdateDto)
        {
            var departments = await _departmentsRepository.GetById(departmentUpdateDto.Id);
            if (departments == null)
                return false;

            departments.Id = departmentUpdateDto.Id;
            departments.Name = departmentUpdateDto.Name;
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
