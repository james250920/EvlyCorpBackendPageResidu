using EvlyCorpBackend.INFRASTRUCTURE.Data;

namespace EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES
{
    public interface IDepartmentsRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Departments>> GetAll();
        Task<Departments> GetById(int id);
        Task<bool> Insert(Departments department);
        Task<bool> Update(Departments department);
    }
}