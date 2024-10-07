using EvlyCorpBackend.CORE.DTOs;
using infrastructure.DATA;

namespace EvlyCorpBackend.CORE.SERVICES
{
    public interface IUsersService
    {
        Task<bool> Delete(UsersDeleteDTO usersDeleteDTO);
        Task<IEnumerable<UsersListDTO>> GetAll();
        Task<UsersListDTO> GetById(int usersDTO);
        Task<UsersAuthenticationsDTO> Login(UsersLoginDTO usersLoginDTO);
        Task<bool> Register(UsersInsertDTO usersInsertDTO);
        Task<bool> Update(UsersUpdateDTO usersUpdateDTO);
        Task UpdatePartialAsync(int userId, UserUpdateProfileDTO userUpdateDto);

    }
}