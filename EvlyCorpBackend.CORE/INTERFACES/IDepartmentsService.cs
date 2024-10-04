using EvlyCorpBackend.CORE.DTOs;

namespace EvlyCorpBackend.CORE.INTERFACES
{
    public interface IDepartmentsService
    {
        Task<bool> Delete(DepartmentsDeleteDTO department);
        Task<IEnumerable<DepartmentsProvincesDTO>> GetAll();
        Task<DepartmentsProvincesDTO> GetById(int id);
        Task<bool> Insert(DepartmentsInsertDTO department);
        Task<bool> Update(DepartmentsUpdateDTO departmentUpdateDto);
    }
}