namespace ProgettoIndustriale.Type.Dto;

using System.Collections.Generic;

public class GeoCodingResponse
{
    public List<Location> Results { get; set; }
    public double GenerationTimeMs { get; set; }
}