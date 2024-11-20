namespace RS1_Mechanix.Models
{
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
