using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;

public interface IDateManager
{
       Dto.Date? GetDate(int id);
   
       List<Dto.Date> GetAllDates();
}

