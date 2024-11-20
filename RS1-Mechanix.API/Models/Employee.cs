namespace RS1_Mechanix.Models
{
    public class Employee
    {
        public string EmployeeId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public Schedule Schedule { get; set; } // not null 1-1
        public ICollection<EmployeeServices> EmployeeServices { get; set; } = new List<EmployeeServices>();
    }
}
