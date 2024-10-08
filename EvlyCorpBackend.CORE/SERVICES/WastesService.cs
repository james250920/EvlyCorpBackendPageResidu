using EvlyCorpBackend.CORE.DTOs;
using EvlyCorpBackend.CORE.INTERFACES;
using EvlyCorpBackend.INFRASTRUCTURE.REPOSITORIES;
using infrastructure.DATA;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Globalization;
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
            wastes.UpdatedAt = DateTime.Now;

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

        public async Task<MemoryStream> ExportToCsv()
        {
            var wastes = await _wastesRepository.GetAll();
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream, Encoding.UTF8);

            // Escribir encabezados
            await writer.WriteLineAsync("ID,Name,Price,Measurement Unit,Created At,Updated At");

            // Escribir datos
            foreach (var waste in wastes)
            {
                var line = $"{waste.Id},{waste.Name},{waste.Price.ToString(CultureInfo.InvariantCulture)},{waste.MeasurementUnit},{waste.CreatedAt},{waste.UpdatedAt}";
                await writer.WriteLineAsync(line);
            }

            await writer.FlushAsync();
            stream.Position = 0; // Volver al inicio del stream para que se pueda leer
            return stream;
        }


    }
}
