using infrastructure.DATA;

namespace EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES
{
    public interface ICondominiumWastesRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<CondominiumWastes>> GetAll();
        Task<CondominiumWastes> GetById(int id);
        Task<bool> Insert(CondominiumWastes condominiumWastes);
        Task<bool> Update(CondominiumWastes condominiumWastes);
    }
}