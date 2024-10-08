using infrastructure.DATA;

namespace EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES
{
    public interface ICondominiumsRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Condominiums>> GetAll();
        Task<Condominiums> GetById(int id);
        Task<bool> Insert(Condominiums condominium);
        Task<bool> Update(Condominiums condominium);
    }
}