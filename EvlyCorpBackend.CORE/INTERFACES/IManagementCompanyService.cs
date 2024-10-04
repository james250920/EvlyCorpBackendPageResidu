using EvlyCorpBackend.CORE.DTOs;

namespace EvlyCorpBackend.CORE.INTERFACES
{
    public interface IManagementCompanyService
    {
        Task<bool> Delete(ManagementCompanyDeleteDTO managementCompanyDeleteDTO);
        Task<IEnumerable<ManagementCompanyDTO>> GetAll();
        Task<ManagementCompanyDTO> GetById(int id);
        Task<bool> Insert(ManagementCompanyInsertDTO managementCompanyInsertDTO);
        Task<bool> Update(ManagementCompanyUpdateDTO managementCompanyUpdateDTO);
    }
}