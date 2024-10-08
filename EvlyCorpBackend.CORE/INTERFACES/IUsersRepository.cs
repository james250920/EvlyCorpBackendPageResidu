using EvlyCorpBackend.CORE.DTOs;
using infrastructure.DATA;

namespace EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES
{
    public interface IUsersRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Users>> GetAll();
        Task<bool> GetByEmail(string email);
        Task<Users> GetById(int id);
        Task<Users> GetUserCredentials(string email, string password);
        Task<bool> Insert(Users user);
        Task<bool> Update(Users user);
        Task UpdatePartialAsync(int userId, UserUpdateProfileDTO userUpdateDto);
        Task<Users> GetByIdRecycler(int id);
        Task<IEnumerable<Users>> GetAllRecyclers();
    }
     
}