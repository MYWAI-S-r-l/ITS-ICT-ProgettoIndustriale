﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.Type.Domain
{
    public partial class Region
    {
        public Region()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int IdMacrozone { get; set; }

        public virtual Macrozone Macrozone { get; set; }
        public virtual ICollection<Province> Provinces { get; set; }    
    }
}