using infrastructure.DATA;

namespace EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES
{
    public interface IDistrictsRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Districts>> GetAll();
        Task<Districts> GetById(int id);
        Task<bool> Insert(Districts district);
        Task<bool> Update(Districts district);
    }
}