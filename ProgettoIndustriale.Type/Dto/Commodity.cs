namespace ProgettoIndustriale.Type.Dto
{
    public class Commodity
    {
        public Commodity() { }

        public int Id { get; set; }

        public string? Name { get; set; }
        public double ValueUsd { get; set; }

        //trasforma ---> dizionario {data,valore}
        //forse utilizzo oggetto intermedio ?

        public Date? Date { get; set; }
        public List<Dictionary<string, string>>? Data { get; set; }

        public string? Unit { get; set; }
    }
}