namespace ProgettoIndustriale.Type.Dto
{
    public class Price
    {
        public Price() { }

        public int Id { get; set; }
        public float basePriceEur { get; set; }
        public float incentiveComponentEur { get; set; }
        public float unbalancePriceEur { get; set; }
        public MacroZone? MacroZone { get; set; }
        public Date? Date { get; set; }
    }
}