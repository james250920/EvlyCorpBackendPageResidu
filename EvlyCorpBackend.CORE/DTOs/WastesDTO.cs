﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvlyCorpBackend.CORE.DTOs
{
    public class WastesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string MeasurementUnit { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class WastesListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string MeasurementUnit { get; set; } = null!;

    }
    public class WastesInsertDTO
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string MeasurementUnit { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class WastesUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string MeasurementUnit { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }   
    public class WastesDeleteDTO
    {
        public int Id { get; set; }
    }



}
