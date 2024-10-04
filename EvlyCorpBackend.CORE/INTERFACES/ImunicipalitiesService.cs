using EvlyCorpBackend.CORE.DTOs;

namespace EvlyCorpBackend.CORE.INTERFACES
{
    public interface ImunicipalitiesService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<MunicipalitiesListDTO>> GetAll();
        Task<bool> Insert(MunicipalitiesInsertDTO municipalitiesInsertDTO);
        Task<bool> Update(MunicipalitiesUpdateDTO municipalitiesUpdateDTO);
    }
}