using EvlyCorpBackend.CORE.DTOs;

namespace EvlyCorpBackend.CORE.INTERFACES
{
    public interface IDistrictsService
    {
        Task<bool> Delete(DistrictsDeleteDTO district);
        Task<IEnumerable<DistrictsListDTO>> GetAll();
        Task<DistrictsListDTO> GetById(int id);
        Task<bool> Insert(DistrictsInsertDTO district);
        Task<bool> Update(DistrictsUpdateDTO district);
    }
}