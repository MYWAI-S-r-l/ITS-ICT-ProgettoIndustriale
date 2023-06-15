namespace ProgettoIndustriale.Type.Domain
{
    public class MacroZone
    {
        public MacroZone()
        { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string BiddingZone { get; set; }
        public virtual ICollection<Region> Regions { get; set; }

    }
}