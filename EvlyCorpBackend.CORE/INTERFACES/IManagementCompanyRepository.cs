using infrastructure.DATA;

namespace EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES
{
    public interface IManagementCompanyRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<ManagementCompany>> GetAll();
        Task<ManagementCompany> GetById(int id);
        Task<bool> Insert(ManagementCompany managementCompany);
        Task<bool> Update(ManagementCompany managementCompany);
    }
}