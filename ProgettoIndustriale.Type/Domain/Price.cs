

namespace ProgettoIndustriale.Type.Domain
{
    public class Price
    {
        public Price() { }
        public int Id { get; set; }
        public float BasePriceEur { get; set; }
        public  float IncentiveComponentEur { get; set; }
        public float UnbalancePriceEur { get; set; }
        public int IdMacroZone { get; set; }
        public int IdDate { get; set; }
        public virtual MacroZone MacroZone { get; set; }
        public virtual Date Date { get; set; }

    }
}
