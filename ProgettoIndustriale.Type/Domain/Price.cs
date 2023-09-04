using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoIndustriale.Type.Domain
{
    public class Price
    {
        public Price()
        { }

        [Column("ID_price")]
        public int Id { get; set; }

        [Column("base_price_EURxMWh")]
        public double BasePriceEur { get; set; }

        [Column("incentive_component_EURxMWh")]
        public double IncentiveComponentEur { get; set; }

        [Column("unbalance_price_EURxMWh")]
        public double UnbalancePriceEur { get; set; }

        [Column("COD_macrozone")]
        public int IdMacroZone { get; set; }

        [Column("COD_date")]
        public int IdDate { get; set; }

        public virtual MacroZone? MacroZone { get; set; }
        public virtual Date? Date { get; set; }
    }
}