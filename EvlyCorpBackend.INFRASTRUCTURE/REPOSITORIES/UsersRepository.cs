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
            try
            {
                await _context.Users.AddAsync(user);
                int rows = await _context.SaveChangesAsync();
                return rows > 0;
            }
            catch (DbUpdateException ex)
            {
                
                Console.WriteLine($"Error inserting user: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
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
            catch (DbUpdateException ex)
            {
                
                Console.WriteLine($"Error deleting user: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Update(Users user)
        {
            try
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
            catch (DbUpdateException ex)
            {
                
                Console.WriteLine($"Error updating user: {ex.Message}");
                return false;
            }
        }

        public async Task<Users> GetUserCredentials(string email, string password)
        {
            try
            {
                return await _context.Users
                    .Where(x => x.Email == email && x.Password == password)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error retrieving user credentials: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error retrieving all users: {ex.Message}");
                return Enumerable.Empty<Users>();
            }
        }

        public async Task<Users> GetById(int id)
        {
            try
            {
                return await _context.Users
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error retrieving user by ID: {ex.Message}");
                return null;
            }
        }
        public async Task<bool> GetByEmail(string email)
        {
            try
            {
                return await _context.Users
                    .Where(x => x.Email == email)
                    .AnyAsync();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error retrieving user by email: {ex.Message}");
                return false;
            }
        }
    }
}
