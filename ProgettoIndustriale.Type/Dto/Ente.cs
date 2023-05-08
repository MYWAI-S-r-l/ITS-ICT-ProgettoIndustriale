namespace ProgettoIndustriale.Type.Dto;

public class Ente
{
    public Ente()
    {
    }
    
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sigla { get; set; }
    
    public bool IsDeleted { get; set; }
}
