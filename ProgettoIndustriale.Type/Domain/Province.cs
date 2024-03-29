﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoIndustriale.Type.Domain
{
    public partial class Province
    {
        public Province()
        {
        }

        [Column("ID_province")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("longitude")]
        public string? Longitude { get; set; }

        [Column("latitude")]
        public string? Latitude { get; set; }

        [Column("surface")]
        public float Altitude { get; set; }

        [Column("altitude")]
        public float Surface { get; set; }

        [Column("residents")]
        public int Residents { get; set; }

        [Column("population_density")]
        public decimal PopulationDensity { get; set; }

        [Column("number_cities")]
        public int NCities { get; set; }

        public int IdRegion { get; set; }

        public virtual Region? Region { get; set; }
        public virtual ICollection<Industry>? Industries { get; set; }

        public virtual ICollection<Weather>? Weathers { get; set; }
    }
}