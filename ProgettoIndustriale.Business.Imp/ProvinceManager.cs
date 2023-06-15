using ProgettoIndustriale.Type;
using Dto = ProgettoIndustriale.Type.Dto;
using Domain = ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.Business.Imp;

public class ProvinceManager : IProvinceManager
{
    private readonly ProgettoIndustrialeContext _context;
    public ProvinceManager(ProgettoIndustrialeContext context)
    {
        _context = context;
    }

    public Dto.Provincia? GetProvincia(string codice)
    {
        var domainProvincia = GetDomainProvincia(codice);
        return domainProvincia == null ? null : MyMapper<Domain.Province, Dto.Provincia>.Map(domainProvincia);
    }

    private Domain.Province? GetDomainProvincia(string? codice)
    {
        if (codice == null)
            return null;
        var domainProvincia = _context.Province
            .FirstOrDefault(provincia => provincia.Codice == codice);
        return domainProvincia;
    }
    
    public bool DeleteProvincia(string codice)
    {
        var domainProvincia = _context.Province
            .FirstOrDefault(provincia => provincia.Codice == codice);
        if (domainProvincia == null)
            return false;
        _context.Remove(domainProvincia);
        _context.SaveChanges();
        return true;
    }

    public bool DeleteProvince()
    {
        _context.RemoveRange(_context.Province.ToList());
        _context.SaveChanges();
        return true;
    }

    public Dto.Provincia? SaveProvincia(Dto.Provincia? provinciaToSave)
    {
        if (provinciaToSave == null)
            return null;
        var domainProvincia = new Domain.Provincia
        {
            Codice = provinciaToSave.Codice,
            Nome = provinciaToSave.Nome,
            Sigla = provinciaToSave.Sigla,
            Regione = provinciaToSave.Regione,
     
        };
        _context.Province.Add((Domain.Province)domainProvincia);
        _context.SaveChanges();
        provinciaToSave.Codice = domainProvincia.Codice;
        return provinciaToSave;
    }

    public List<Dto.Provincia> SaveProvince(List<Dto.Provincia> provinceToSave)
    {
        if (provinceToSave == null || provinceToSave.Count == 0)
            return new List<Dto.Provincia>();

        var domainProvince = provinceToSave.ConvertAll(
            p => new Domain.Provincia 
                {
                    Codice = p.Codice,
                    Nome = p.Nome,
                    Sigla = p.Sigla,
                    Regione = p.Regione,
                }
            );

        _context.Province.AddRange((IEnumerable<Domain.Province>)domainProvince);
        _context.SaveChanges();

        return provinceToSave;
    }

    public Dto.Provincia? EditProvincia(Dto.Provincia? provinciaToEdit)
    {
        if (provinciaToEdit == null)
            return null;
        var domainProvincia = GetDomainProvincia(provinciaToEdit.Codice);
        if (domainProvincia == null)
            return null;
        domainProvincia.Codice = provinciaToEdit.Codice;
        domainProvincia.Nome = provinciaToEdit.Nome;
        domainProvincia.Sigla = provinciaToEdit.Sigla;
        domainProvincia.Regione = provinciaToEdit.Regione;
        _context.Update(domainProvincia);
        _context.SaveChanges();
        return MyMapper<Domain.Province, Dto.Provincia>.Map(domainProvincia);
    }

    public List<Dto.Provincia> GetAllProvince()
    {
        var allProvince = _context.Province.ToList();
        return MyMapper<Domain.Province, Dto.Provincia>.MapList(allProvince);
    }
}