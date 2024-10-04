using EvlyCorpBackend.INFRASTRUCTURE.Data;

namespace EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES
{
    public interface IDistrictsRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<DistrictsUpdatetDTO>> GetAll();
        Task<DistrictsUpdatetDTO> GetById(int id);
        Task<bool> Insert(DistrictsUpdatetDTO district);
        Task<bool> Update(DistrictsUpdatetDTO district);
    }
}