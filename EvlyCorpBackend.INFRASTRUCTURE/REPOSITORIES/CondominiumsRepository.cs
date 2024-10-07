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
    public class CondominiumsRepository : ICondominiumsRepository
    {
        private readonly ResiduContext _context;

        public CondominiumsRepository(ResiduContext context)
        {
            _context = context;
        }
        //insert
        public async Task<bool> Insert(Condominiums condominium)
        {
            await _context.Condominiums.AddAsync(condominium);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Update(Condominiums condominium)
        {
            _context.Condominiums.Update(condominium);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var condominium = await _context.Condominiums.FindAsync(id);
            _context.Condominiums.Remove(condominium);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<Condominiums>> GetAll()
        {
            return await _context.Condominiums
                .Include(x => x.Municipality)
                .Include(x => x.Representative).ThenInclude(x => x.District).ThenInclude(x => x.Province).ThenInclude(x => x.Department)
                .ToListAsync();
        }

        public async Task<Condominiums> GetById(int id)
        {
            return await _context.Condominiums
                .Include(x => x.Municipality)
                .Include(x => x.Representative).ThenInclude(x => x.District).ThenInclude(x => x.Province).ThenInclude(x => x.Department)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
