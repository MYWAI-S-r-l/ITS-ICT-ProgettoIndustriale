namespace ProgettoIndustriale.Type.Domain
{
    public class MacroZone
    {
        public MacroZone()
        { }

        //[Column("ID_macrozone")]
        public int Id { get; set; }

        //[Column("name")]
        public string? Name { get; set; }

        //[Column("bidding_zone")]
        public string? BiddingZone { get; set; }

        public virtual ICollection<Region>? Regions { get; set; }
        public virtual ICollection<Load>? Loads { get; set; }

        public virtual ICollection<Price>? Prices { get; set; }
    }
}