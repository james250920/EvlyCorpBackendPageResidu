using infrastructure.DATA;

namespace EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES
{
    public interface IProvincesRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Provinces>> GetAll();
        Task<Provinces> GetById(int id);
        Task<bool> Insert(Provinces province);
        Task<bool> Update(Provinces province);
    }
}