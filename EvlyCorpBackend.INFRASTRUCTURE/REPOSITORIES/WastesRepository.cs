using EvlyCorpBackend.CORE.INTERFACES;
using EvlyCorpBackend.INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES
{
    public class WastesRepository : IWastesRepository
    {
        private readonly ResiduContext _context;

        public WastesRepository(ResiduContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Wastes>> GetAll()
        {
            return await _context.Wastes.
                Include(x => x.CondominiumWastes).
                ThenInclude(x => x.Orders).ToListAsync();
        }
        public async Task<Wastes> GetById(int id)
        {
            return await _context.Wastes.
                Include(y => y.CondominiumWastes).
                ThenInclude(r => r.Orders).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Insert(Wastes wastes)
        {
            await _context.Wastes.AddAsync(wastes);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
      
        public async Task<bool> Update(Wastes wastes)
        {
            _context.Wastes.Update(wastes);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
       
        public async Task<bool> Delete(int id)
        {
            var wastes = await GetById(id);
            _context.Wastes.Remove(wastes);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
      
        
    }
}
