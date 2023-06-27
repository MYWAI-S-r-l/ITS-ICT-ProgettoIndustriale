using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;

public interface IPriceManager
{
    Dto.Price? GetPrice(int id);

    List<Dto.Price> GetAllPrices();
}

