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
    public class ManagementCompanyRepository : IManagementCompanyRepository
    {
        private readonly ResiduContext _context;

        public ManagementCompanyRepository(ResiduContext context)
        {
            _context = context;
        }

        public async Task<bool> Insert(ManagementCompany managementCompany)
        {
            await _context.ManagementCompany.AddAsync(managementCompany);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Update(ManagementCompany managementCompany)
        {
            _context.ManagementCompany.Update(managementCompany);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var managementCompany = await _context.ManagementCompany.FindAsync(id);
            if (managementCompany == null)
            {
                return false;
            }
            _context.ManagementCompany.Remove(managementCompany);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;

        }
        public async Task<IEnumerable<ManagementCompany>> GetAll()
        {
            return await _context.ManagementCompany.ToListAsync();
        }
        public async Task<ManagementCompany> GetById(int id)
        {
            return await _context.ManagementCompany.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
