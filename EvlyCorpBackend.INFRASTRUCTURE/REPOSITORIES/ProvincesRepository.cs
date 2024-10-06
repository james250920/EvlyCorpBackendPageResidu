using EvlyCorpBackend.INFRASTRUCTURE.Data;
using infrastructure.DATA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES
{
    public class ProvincesRepository : IProvincesRepository
    {
        private readonly ResiduContext _context;
        public ProvincesRepository(ResiduContext context)
        {
            _context = context;
        }
        public async Task<bool> Insert(Provinces province)
        {
            await _context.Provinces.AddAsync(province);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Update(Provinces province)
        {
            _context.Provinces.Update(province);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var province = await _context.Provinces.FindAsync(id);
            if (province == null)
            {
                return false;
            }
            _context.Provinces.Remove(province);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;

        }
        public async Task<IEnumerable<Provinces>> GetAll()
        {
            return await _context.Provinces.Include(x => x.Department).ToListAsync();
        }
        public async Task<Provinces> GetById(int id)
        {
            return await _context.Provinces.Where(x => x.Id == id).Include(X => X.Department).FirstOrDefaultAsync();
        }
    }
}
