namespace RS1_Mechanix.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
        // add fk for tasks
        /*
         IMPORTANT!!!
        If logic is bad fix this!!!!
        For reservations we have a join table with navigation properties,
        and from there the employee can grab all of the services he's trained for
        - create a method inside the employee controller for this bc it gets messy?
         */

    }
}
 