namespace ProgettoIndustriale.Type.Dto;

public class Province
{
    public Province(){ }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Longitude { get; set; }
    public string Latitude { get; set; }
    public float Altitude { get; set; }
    public float Surface { get; set; }
    public int Residents { get; set; }
    public float PopulationDensity { get; set; }
    public int NCities { get; set; }

    public Region Region { get; set; }
}

//decidete cosa fare con i COD