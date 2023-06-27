﻿using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;

public interface IProvinceManager
{
        Dto.Province? GetProvince(int id);
   
        List<Dto.Province> GetAllProvinces();
}
