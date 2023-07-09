namespace SignalRApi.DataAccess
{
    public enum ECity
    {
        Ankara = 1,
        Istanbul = 2,
        Antalya = 3,
        Bursa = 4,
        Izmir = 5
    }
    public class Visitor
    {
        public int Id { get; set; }
        public ECity City { get; set; }
        public int VisitCount { get; set; }
        public DateTime Date { get; set; }
    }
}
