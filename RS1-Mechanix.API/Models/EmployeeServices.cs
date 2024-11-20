namespace RS1_Mechanix.Models
{
    public class EmployeeServices
    {
        public string EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public Employee Employee { get; set; } = null;
        public Service Service { get; set; } = null;

    }
}
