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
    public class CondominiumWastesRepository : ICondominiumWastesRepository
    {
        private readonly ResiduContext _context;

        public CondominiumWastesRepository(ResiduContext context)
        {
            _context = context;
        }

        public async Task<bool> Insert(CondominiumWastes condominiumWastes)
        {
            await _context.CondominiumWastes.AddAsync(condominiumWastes);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Update(CondominiumWastes condominiumWastes)
        {
            _context.CondominiumWastes.Update(condominiumWastes);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var condominiumWastes = await _context.CondominiumWastes.FindAsync(id);
            _context.CondominiumWastes.Remove(condominiumWastes);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        public async Task<IEnumerable<CondominiumWastes>> GetAll()
        {
            return await _context.CondominiumWastes
                .Include(x => x.Condominium).Include(y => y.Waste).ToListAsync();
        }
        public async Task<CondominiumWastes> GetById(int id)
        {
            return await _context.CondominiumWastes
                .Include(x => x.Condominium).Include(y => y.Waste)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
