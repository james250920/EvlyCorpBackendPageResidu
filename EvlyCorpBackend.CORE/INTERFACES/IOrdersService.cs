using EvlyCorpBackend.CORE.DTOs;

namespace EvlyCorpBackend.CORE.SERVICES
{
    public interface IOrdersService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<OrdersListDTO>> GetAll();
        Task<OrdersListDTO> GetById(int id);
        Task<bool> Insert(OrdersInsertDTO order);
        Task<bool> Update(OrdersUpdateDTO order);
    }
}