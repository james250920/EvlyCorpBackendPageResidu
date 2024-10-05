using EvlyCorpBackend.INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ResiduContext _context;

        public UsersRepository(ResiduContext context)
        {
            _context = context;
        }

        public async Task<bool> Insert(Users user)
        {

                await _context.Users.AddAsync(user);
                int rows = await _context.SaveChangesAsync();
                return rows > 0;
           
        }

        public async Task<bool> Delete(int id)
        {
            
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return false;
                }

                _context.Users.Remove(user);
                int rows = await _context.SaveChangesAsync();
                return rows > 0;
            
        }

        public async Task<bool> Update(Users user)
        {
           
                var existingUser = await _context.Users.FindAsync(user.Id);
                if (existingUser == null)
                {
                    return false;
                }

                _context.Entry(existingUser).CurrentValues.SetValues(user);
                int rows = await _context.SaveChangesAsync();
                return rows > 0;
            
        }

        public async Task<Users> GetUserCredentials(string email, string password)
        {
            
                return await _context.Users
                    .Where(x => x.Email == email && x.Password == password)
                    .FirstOrDefaultAsync();
          
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
         
                return await _context.Users.Include(x => x.Department).ToListAsync();
            
           
        }

        public async Task<Users> GetById(int id)
        {
                return await _context.Users
                    .Where(x => x.Id == id).Include(x => x.Department)
                    .FirstOrDefaultAsync();
            
            
        }

        public async Task<bool> GetByEmail(string email)
        {
            return await _context.Users
                .Where(x => x.Email == email)
                .AnyAsync();

        }
        

    }
}
