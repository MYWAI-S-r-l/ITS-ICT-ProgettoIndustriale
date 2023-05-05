using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Business;

public interface IEntiManager
{
    Dto.Ente? GetEnte(int enteId);

    bool DeleteEnte(int enteId);

    Dto.Ente? SaveEnte(Dto.Ente? enteToDelete);

    Dto.Ente? EditEnte(Dto.Ente? enteToEdit);
    List<Dto.Ente> GetAllEnti();
}