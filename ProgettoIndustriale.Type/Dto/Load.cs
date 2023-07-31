namespace ProgettoIndustriale.Type.Dto
{
    public class Load
    {
        public Load() { }

        public int Id { get; set; }
        public double totalLoadMW { get; set; }
        public double forecastTotalLoadMw { get; set; }
        public Date Date { get; set; }
        public  MacroZone MacroZone { get; set; }

    }
}