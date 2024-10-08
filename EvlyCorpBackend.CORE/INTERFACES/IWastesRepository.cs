using infrastructure.DATA;

namespace EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES
{
    public interface IWastesRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Wastes>> GetAll();
        Task<Wastes> GetById(int id);
        Task<bool> Insert(Wastes wastes);
        Task<bool> Update(Wastes wastes);
    }
}