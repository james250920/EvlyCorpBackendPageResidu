using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES;
using infrastructure.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.CORE.SERVICES
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }


        public async Task<bool> Insert(OrdersInsertDTO order)
        {
            var newOrder = new Orders
            {
                CondominiumWasteId = order.CondominiumWasteId,
                WasteId = order.WasteId,
                Status = order.Status,
                CreatedAt = order.CreatedAt
            };
            return await _ordersRepository.Insert(newOrder);
        }
        public async Task<bool> Update(OrdersUpdateDTO order)
        {
            var newOrder = new Orders
            {
                Id = order.Id,
                CondominiumWasteId = order.CondominiumWasteId,
                WasteId = order.WasteId,
                Status = order.Status,
                UpdatedAt = order.UpdatedAt
            };
            return await _ordersRepository.Update(newOrder);
        }
        public async Task<bool> Delete(int id)
        {
            return await _ordersRepository.Delete(id);
        }

        public async Task<IEnumerable<OrdersListDTO>> GetAll()
        {
            var orders = await _ordersRepository.GetAll();
            return orders.Select(x => new OrdersListDTO
            {
                Id = x.Id,
                Status = x.Status,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                CondominiumWaste = new CondominiumWastesPartDTO
                {
                    Id = x.CondominiumWaste.Id,
                    Weight = x.CondominiumWaste.Weight,
                    FreeCollection = x.CondominiumWaste.FreeCollection,
                    Status = x.CondominiumWaste.Status


                },
                Waste = new WastesListDTO
                {
                    Id = x.Waste.Id,
                    Name = x.Waste.Name,

                }
            });
        }
        public async Task<OrdersListDTO> GetById(int id)
        {
            var order = await _ordersRepository.GetById(id);
            return new OrdersListDTO
            {
                Id = order.Id,
                Status = order.Status,
                CreatedAt = order.CreatedAt,
                UpdatedAt = order.UpdatedAt,
                CondominiumWaste = new CondominiumWastesPartDTO
                {
                    Id = order.CondominiumWaste.Id,
                    Weight = order.CondominiumWaste.Weight,
                    FreeCollection = order.CondominiumWaste.FreeCollection,
                    Status = order.CondominiumWaste.Status
                },
                Waste = new WastesListDTO
                {
                    Id = order.Waste.Id,
                    Name = order.Waste.Name
                }
            };
        }


    }
}
