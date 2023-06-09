﻿using Microsoft.EntityFrameworkCore;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Data;
using ProgettoIndustriale.Type;
using Domain = ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.Business.Imp
{
    
    
    
    public class CommodityManager : ICommodityManager
    {
        private readonly ProgettoIndustrialeContext _context;
        public CommodityManager(ProgettoIndustrialeContext context)
        {
            _context = context;
        }
        public List<Dto.Commodity> getAllCommodities()
        {
            List<Domain.Commodity> commodities = _context.Commodity.ToList();
            return MyMapper<Domain.Commodity, Dto.Commodity>.MapList(commodities);
        }

        public List<Dto.Commodity> getComoditybyDates(DateTime startDate, DateTime endDate)
        {


            List<Domain.Commodity> commodities = _context.Commodity.Include(X=>X.Date).Where(p=>p.Date.DateTime > startDate && p.Date.DateTime < endDate).ToList();
            return MyMapper<Domain.Commodity,Dto.Commodity>.MapList(commodities);

        }
    }
}
