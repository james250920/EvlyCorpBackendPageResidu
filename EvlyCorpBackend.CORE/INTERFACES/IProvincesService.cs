using EvlyCorpBackend.CORE.DTOs;

namespace EvlyCorpBackend.CORE.INTERFACES
{
    public interface IProvincesService
    {
        Task<bool> Delete(ProvincesDeleteDTO provincesDeleteDTO);
        Task<IEnumerable<ProvincesListDTO>> GetAll();
        Task<ProvincesDTO> GetById(int id);
        Task<bool> Insert(ProvincesInsertDTO provincesInsertDTO);
        Task<bool> Update(ProvincesUpdateDTO provincesUpdateDTO);
    }
}