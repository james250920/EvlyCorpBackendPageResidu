using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.CORE.SERVICES
{
    public class UsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        //public async Task<bool> SignUp(UsersInsertDTO user)
        //{
            //var existsUser = await _usersRepository.GetByEmail(user.Email);
            //if (existsUser != null)
            //{
            //    return false;
           // }
           // var newUser = new Users
           // {
           //     Name = user.Name,
            //    Email = user.Email,
            //    Password = user.Password,
            //    CreatedAt = DateTime.Now
            //};
           // return await _usersRepository.Insert(newUser);
       // }

    }
}
