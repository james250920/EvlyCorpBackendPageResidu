using EvlyCorpBackend.CORE.DTOs;

namespace EvlyCorpBackend.CORE.SERVICES
{
    public interface IUsersService
    {
        Task<bool> Delete(UsersDeleteDTO usersDeleteDTO);
        Task<IEnumerable<UsersListDTO>> GetAll();
        Task<UsersListDTO> GetById(UsersListDTO usersDTO);
        Task<UsersAuthenticationsDTO> Login(UsersLoginDTO usersLoginDTO);
        Task<bool> Register(UsersInsertDTO usersInsertDTO);
        Task<bool> Update(UsersUpdateDTO usersUpdateDTO);
    }
}