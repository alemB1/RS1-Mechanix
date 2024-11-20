namespace RS1_Mechanix.Models
{
    public class BusinessScore
    {
        public  int Id { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public int Rating { get; set; }
    }
}
