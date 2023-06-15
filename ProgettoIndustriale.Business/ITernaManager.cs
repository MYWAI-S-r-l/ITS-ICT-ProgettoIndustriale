using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;

public interface ITernaManager
{
    //Recupera da DB Token Terna il Terna Token
    Dto.TernaToken? GetTernaToken();
    //Aggiorna il record del token in tabella & datetime aggiunta
    Dto.TernaToken? UpdateToken(Dto.TernaToken tokenToSave);
}