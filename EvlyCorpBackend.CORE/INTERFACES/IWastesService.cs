using EvlyCorpBackend.CORE.DTOs;

namespace EvlyCorpBackend.CORE.INTERFACES
{
    public interface IWastesService
    {
        Task<bool> Delete(WastesDeleteDTO wastesDeleteDTO);
        Task<IEnumerable<WastesListDTO>> GetAll();
        Task<WastesDTO> GetById(int id);
        Task<bool> Insert(WastesInsertDTO wastesInsertDTO);
        Task<bool> Update(WastesUpdateDTO wastesUpdateDTO);
    }
}