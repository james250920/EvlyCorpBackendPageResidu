using EvlyCorpBackend.CORE.DTOs;

namespace EvlyCorpBackend.CORE.INTERFACES
{
    public interface IUsersService
    {
        Task<IEnumerable<UsersDepartmentsDTO>> GetAll();
        Task<UsersDepartmentsDTO> GetById(int id);
        Task<UsersAuthenticationsDTO> Login(UsersLoginDTO usersLoginDTO);
        Task<bool> Register(UsersInsertDTO usersInsertDTO);
        Task<bool> Update(UsersUpdateDTO usersUpdateDTO);
    }
}