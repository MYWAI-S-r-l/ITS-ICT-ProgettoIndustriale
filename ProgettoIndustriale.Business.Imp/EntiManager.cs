using ProgettoIndustriale.Type;
using Dto = ProgettoIndustriale.Type.Dto;
using Domain = ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.Business.Imp;

public class EntiManager : IEntiManager
{
    private readonly ProgettoIndustrialeContext _context;
    public EntiManager(ProgettoIndustrialeContext context)
    {
        _context = context;
    }

    public Dto.Ente? GetEnte(int enteId)
    {
        var domainEnte = GetDomainEnte(enteId);
        return domainEnte == null ? null : MyMapper<Domain.Ente, Dto.Ente>.Map(domainEnte);
    }

    private Domain.Ente? GetDomainEnte(int? enteId)
    {
        if (enteId == null)
            return null;
        var domainEnte = _context.Enti
            .FirstOrDefault(ente => ente.Id == enteId && !ente.IsDeleted);
        return domainEnte;
    }
    
    public bool DeleteEnte(int enteId)
    {
        var domainEnte = _context.Enti
            .FirstOrDefault(ente => ente.Id == enteId && !ente.IsDeleted);
        if (domainEnte == null)
            return false;
        domainEnte.IsDeleted = true;
        _context.SaveChanges();
        return true;
    }

    public Dto.Ente? SaveEnte(Dto.Ente? enteToSave)
    {
        if (enteToSave == null)
            return null;
        var domainEnte = new Domain.Ente
        {
            Nome = enteToSave.Nome,
            Sigla = enteToSave.Sigla,
            Descrizione = enteToSave.Descrizione,
            IsDeleted = false,
        };
        _context.Enti.Add(domainEnte);
        _context.SaveChanges();
        enteToSave.Id = domainEnte.Id;
        return enteToSave;
    }

    public Dto.Ente? EditEnte(Dto.Ente? enteToEdit)
    {
        if (enteToEdit == null)
            return null;
        var domainEnte = GetDomainEnte(enteToEdit.Id);
        if (domainEnte == null)
            return null;
        domainEnte.Nome = enteToEdit.Nome;
        domainEnte.Sigla = enteToEdit.Sigla;
        domainEnte.Descrizione = enteToEdit.Descrizione;
        _context.Update(domainEnte);
        _context.SaveChanges();
        return MyMapper<Domain.Ente, Dto.Ente>.Map(domainEnte);
    }

    public List<Dto.Ente> GetAllEnti()
    {
        var allEnti = _context.Enti
            .Where(x => !x.IsDeleted)
            .ToList();
        return MyMapper<Domain.Ente, Dto.Ente>.MapList(allEnti);
    }
}