using infrastructure.DATA;

namespace EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES
{
    public interface IOrdersRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Orders>> GetAll();
        Task<Orders> GetById(int id);
        Task<bool> Insert(Orders order);
        Task<bool> Update(Orders order);
    }
}