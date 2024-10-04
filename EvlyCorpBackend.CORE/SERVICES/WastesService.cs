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
            if(wastes == null)
            {
                return null;
            }
            var wasteDTO = new WastesDTO
            {
                Id = wastes.Id,
                Name = wastes.Name,
                Price = wastes.Price,
                MeasurementUnit = wastes.MeasurementUnit,
                CreatedAt = wastes.CreatedAt,
                UpdatedAt = wastes.UpdatedAt

            };
            return wasteDTO;

        }
        public async Task<bool> Insert(WastesInsertDTO wastesInsertDTO)
        {
            var wastes = new Wastes();
            wastes.Name = wastesInsertDTO.Name;
            wastes.Price = wastesInsertDTO.Price;
            wastes.MeasurementUnit = wastesInsertDTO.MeasurementUnit;
            wastes.CreatedAt = DateTime.Now;
            
            var result = await _wastesRepository.Insert(wastes);
            return result;
            
        }
        public async Task<bool> Update(WastesUpdateDTO wastesUpdateDTO)
        {
            var wastes = await _wastesRepository.GetById(wastesUpdateDTO.Id);
            if (wastes == null)
            {
                return false;
            }
            wastes.Name = wastesUpdateDTO.Name;
            wastes.Price = wastesUpdateDTO.Price;
            wastes.MeasurementUnit = wastesUpdateDTO.MeasurementUnit;
            wastes.UpdatedAt = DateTime.Now;
            
            var result = await _wastesRepository.Update(wastes);
            return result;
        }

        public async Task<bool> Delete(WastesDeleteDTO wastesDeleteDTO)
        {
            var wastes = await _wastesRepository.GetById(wastesDeleteDTO.Id);
            if (wastes == null)
            {
                return false;
            }
            var result = await _wastesRepository.Delete(wastesDeleteDTO.Id);
            return result;
           
        }
        //relacion con los condominiosWastes
        //realacon con los Orders
    }
}
