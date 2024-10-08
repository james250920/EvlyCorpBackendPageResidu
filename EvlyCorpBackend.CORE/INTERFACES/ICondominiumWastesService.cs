using EvlyCorpBackend.CORE.DTOs;

namespace EvlyCorpBackend.CORE.INTERFACES
{
    public interface ICondominiumWastesService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<CondominiumWastesListDTO>> GetAll();
        Task<IEnumerable<CondominiumWastesListRepreDTO>> GetAllre();
        Task<CondominiumWastesListDTO> GetById(int id);
        Task<CondominiumWastesListRepreDTO> GetByIdRepres(int id);
        Task<bool> Insert(CondominiumWastesInsertDTO condominiumWastesInsertDTO);
        Task<bool> Update(CondominiumWastesUpdateDTO condominiumWastesUpdateDTO);
    }
}