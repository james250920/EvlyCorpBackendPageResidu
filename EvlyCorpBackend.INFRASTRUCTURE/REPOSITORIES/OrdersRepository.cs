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
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ResiduContext _context;

        public OrdersRepository(ResiduContext context)
        {
            _context = context;
        }

        public async Task<bool> Insert(Orders order)
        {
            await _context.Orders.AddAsync(order);
            var rows = await _context.SaveChangesAsync();
            return rows > 0;

        }
        public async Task<bool> Update(Orders order)
        {
            _context.Orders.Update(order);
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<IEnumerable<Orders>> GetAll()
        {
            return await _context.Orders
                .Include(x => x.Waste)
                .Include(y => y.CondominiumWaste)
                .ToListAsync();
        }
        public async Task<Orders> GetById(int id)
        {
            return await _context.Orders
                .Include(x => x.Waste)
                .Include(y => y.CondominiumWaste)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<bool> Delete(int id)
        {
            var order = await _context.Orders.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (order == null)
            {
                return false;
            }
            _context.Orders.Remove(order);
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}



