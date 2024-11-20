namespace RS1_Mechanix.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public State State { get; set; }
        public Service Service { get; set; }
        public Schedule Schedule { get; set; }
        public int StateId { get; set;}
        public int ServiceId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime Date { get; set; }

    }
}
