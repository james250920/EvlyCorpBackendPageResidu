using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvlyCorpBackend.INFRASTRUCTURE.Data;
using System.Runtime.InteropServices;
using infrastructure.DATA;

namespace EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES
{
    public class MunicipalitiesRepository : IMunicipalitiesRepository
    {
        private readonly ResiduContext _context;
        public MunicipalitiesRepository(ResiduContext context)
        {
            _context = context;
        }
        //insert 
        public async Task<bool> Insert(Municipalities municipality)
        {
            await _context.Municipalities.AddAsync(municipality);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        //update
        public async Task<bool> Update(Municipalities municipality)
        {
            _context.Municipalities.Update(municipality);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        //delete
        public async Task<bool> Delete(int id)
        {
            var municipality = await _context.Municipalities.FindAsync(id);
            _context.Municipalities.Remove(municipality);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        //read
        public async Task<IEnumerable<Municipalities>> GetAll()
        {
            return await _context.Municipalities.ToListAsync();
        }
        public async Task<Municipalities> GetById(int id)
        {
            return await _context.Municipalities.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Municipalities> GetByIdWithCondominius(int id)
        {
            return await _context.Municipalities.Include(x => x.Condominiums)
                .Where(y => y.Id == id).FirstOrDefaultAsync();
        }

    }
}
