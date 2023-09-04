using System.Text.Json.Serialization;

namespace ProgettoIndustriale.Type.Dto
{
    public class Generation
    {
        public Generation() { }

        public int Id { get; set; }

        public double GenerationGhw { get; set; }

        public string? Type { get; set; }

        public Date Date { get; set; }
        
        [JsonPropertyName("actualGeneration")]
        public List<GenerationData> GenerationData { get; set; }

    }
}