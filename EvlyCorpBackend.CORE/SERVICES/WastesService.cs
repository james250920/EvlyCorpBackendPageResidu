using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using EvlyCorpBackend.INFRASTRUCTURE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.CORE.SERVICES
{
    public class WastesService : IWastesService
    {
        private readonly IWastesRepository _wastesRepository;
        public WastesService(IWastesRepository wastesRepository)
        {
            _wastesRepository = wastesRepository;
        }
        public async Task<IEnumerable<WastesListDTO>> GetAll()
        {
            var wastes = await _wastesRepository.GetAll();
            var mastesDTO = wastes.Select(wastes => new WastesListDTO
            {
                Id = wastes.Id,
                Name = wastes.Name,
                Price = wastes.Price,
                MeasurementUnit = wastes.MeasurementUnit


            });
            return mastesDTO;
        }
        public async Task<WastesDTO> GetById(int id)
        {
            var wastes = await _wastesRepository.GetById(id);
            var wastesDTO = new WastesDTO
            {
                Id = wastes.Id,
                Name = wastes.Name,
                Price = wastes.Price,
                MeasurementUnit = wastes.MeasurementUnit,
                CreatedAt = wastes.CreatedAt,
                UpdatedAt = wastes.UpdatedAt
            };
            return wastesDTO;
        }
        public async Task<bool> Insert(WastesInsertDTO wastesInsertDTO)
        {
            var wastes = new Wastes()
            {
                Name = wastesInsertDTO.Name,
                Price = wastesInsertDTO.Price,
                MeasurementUnit = wastesInsertDTO.MeasurementUnit,
                CreatedAt = DateTime.Now
            };
            return await _wastesRepository.Insert(wastes);
        }
        public async Task<bool> Update(WastesUpdateDTO wastesUpdateDTO)
        {
            var wastes = new Wastes()
            {
                Id = wastesUpdateDTO.Id,
                Name = wastesUpdateDTO.Name,
                Price = wastesUpdateDTO.Price,
                MeasurementUnit = wastesUpdateDTO.MeasurementUnit,
                UpdatedAt = DateTime.Now
            };
            return await _wastesRepository.Update(wastes);
        }
        public async Task<bool> Delete(WastesDeleteDTO wastesDeleteDTO)
        {
            return await _wastesRepository.Delete(wastesDeleteDTO.Id);
        }
        //relacion con los condominiosWastes
        //realacon con los Orders
    }
}
