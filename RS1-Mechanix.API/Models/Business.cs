namespace RS1_Mechanix.Models
{
    public class Business
    {
        public int BusinessId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ICollection<BusinessService> BusinessServices { get; set; }
        public ICollection<BusinessScore> BusinessScores { get; set; } = new List<BusinessScore>();

    }
}
