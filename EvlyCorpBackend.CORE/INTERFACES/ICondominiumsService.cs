using EvlyCorpBackend.CORE.DTOs;

namespace EvlyCorpBackend.CORE.SERVICES
{
    public interface ICondominiumsService
    {
        Task<bool> Delete(CondominiumsDeleteDTO condominiumsDeleteDTO);
        Task<IEnumerable<CondominiumsListDTO>> GetAll();
        Task<CondominiumsListDTO> GetById(int id);
        Task<bool> Insert(CondominiumsInsertDTO condominium);
        Task<bool> Update(CondominiumsDTO condominium);
        Task<IEnumerable<CondominiumsListByRepreDTO>> GetAllR();
    }
}