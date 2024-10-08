using infrastructure.DATA;

namespace EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES
{
    public interface IMunicipalitiesRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Municipalities>> GetAll();
        Task<Municipalities> GetById(int id);
        Task<Municipalities> GetByIdWithCondominius(int id);
        Task<bool> Insert(Municipalities municipality);
        Task<bool> Update(Municipalities municipality);
    }
}