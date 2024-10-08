using EvlyCorpBackend.INFRASTRUCTURE.Data;
using infrastructure.DATA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES
{
    public class DepartmentsRepository : IDepartmentsRepository
    {
        private readonly ResiduContext _context;
        public DepartmentsRepository(ResiduContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Departments>> GetAll()
        {
            return await _context.Departments
                .ToListAsync();
        }
        public async Task<Departments> GetById(int id)
        {
            return await _context.Departments
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> Insert(Departments department)
        {
            await _context.Departments.AddAsync(department);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;

        }
        public async Task<bool> Update(Departments department)
        {
            _context.Departments.Update(department);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var department = await GetById(id);
            _context.Departments.Remove(department);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }



    }
}
