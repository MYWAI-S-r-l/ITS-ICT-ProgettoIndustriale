namespace ProgettoIndustriale.Type.Dto
{
    public class Dates
    {

        public Dates() { }

        public int Id { get; set; }

        public DateTime dateTime { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int Day { get; set; }

        public TimeOnly time { get; set; }
    }
}
