using EvlyCorpBackend.CORE.DTOs;

namespace EvlyCorpBackend.CORE.SERVICES
{
    public interface IProvincesService
    {
        Task<bool> Delete(ProvincesDeleteDTO provincesDeleteDTO);
        Task<IEnumerable<ProvincesDepartmentsDTO>> GetAll();
        Task<ProvincesDepartmentsDTO> GetById(int id);
        Task<bool> Insert(ProvincesInsertDTO provincesInsertDTO);
        Task<bool> Update(ProvincesUpdateDTO provincesUpdateDTO);
    }
}