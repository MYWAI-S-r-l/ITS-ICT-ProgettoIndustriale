namespace ProgettoIndustriale.Type.Dto;

public class Industry
{
    public Industry() { }

    public int Id { get; set; }
    public string? Ateco { get; set; }
    public string? Description { get; set; }
    public int CountActive { get; set; }
    public Province? Province { get; set; }
}

//decidete cosa fare con i COD