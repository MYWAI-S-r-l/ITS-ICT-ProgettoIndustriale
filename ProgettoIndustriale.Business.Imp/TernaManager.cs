using ProgettoIndustriale.Type;
using Dto = ProgettoIndustriale.Type.Dto;
using Domain = ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.Business.Imp;

public class TernaManager : ITernaManager
{
    private readonly ProgettoIndustrialeContext _context;
    public TernaManager(ProgettoIndustrialeContext context)
    {
        _context = context;
    }
    public Dto.TernaToken? GetTernaToken()
    {
        var domainToken = GetDomainTernaToken();
        return domainToken == null ? null : MyMapper<Domain.TernaToken, Dto.TernaToken>.Map(domainToken);
    }

    private Domain.TernaToken? GetDomainTernaToken()
    {
        var domainToken = _context.TernaToken.FirstOrDefault();
        return domainToken;
    }

    public Dto.TernaToken? UpdateToken(Dto.TernaToken tokenToSave)
    {
        if (tokenToSave == null)
            return null;
        var domainToken = new Domain.TernaToken
        {
            TokenType = tokenToSave.TokenType,
            AccessToken = tokenToSave.AccessToken,
            AddedTime = tokenToSave.AddedTime
        };
        //cleans the table, only one record allowed
        _context.RemoveRange(_context.TernaToken.ToList());
        //adds new records
        _context.TernaToken.Add(domainToken);
        _context.SaveChanges();
        tokenToSave.Id = domainToken.Id;
        return tokenToSave;
    }

}
