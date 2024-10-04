﻿using EvlyCorpBackend.INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES
{
    public class DistrictsRepository : IDistrictsRepository
    {
        private readonly ResiduContext _context;
        public DistrictsRepository(ResiduContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DistrictsUpdatetDTO>> GetAll()
        {
            return await _context.Districts.Include(x => x.Province).Include(y => y.Department).ToListAsync();
        }
        public async Task<DistrictsUpdatetDTO> GetById(int id)
        {
            return await _context.Districts
                .Include(x => x.Province)
                .Include(y => y.Department)
                .FirstOrDefaultAsync(z => z.Id == id);
        }
        public async Task<bool> Insert(DistrictsUpdatetDTO district)
        {
            await _context.Districts.AddAsync(district);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Update(DistrictsUpdatetDTO district)
        {
            _context.Districts.Update(district);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var district = await GetById(id);
            _context.Districts.Remove(district);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

    }
}
