using EvlyCorpBackend.CORE.DTOs;

namespace EvlyCorpBackend.CORE.SERVICES
{
    public interface ICondominiumWastesService
    {
        Task<bool> Delete(int id);
        Task<List<CondominiumWastesListDTO>> GetAll();
        Task<CondominiumWastesListDTO> GetById(int id);
        Task<bool> Insert(CondominiumWastesInsertDTO condominiumWastesInsertDTO);
        Task<bool> Update(CondominiumWastesUpdateDTO condominiumWastesUpdateDTO);
    }
}