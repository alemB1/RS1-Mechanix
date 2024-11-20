namespace RS1_Mechanix.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public ICollection<BusinessService> BusinessServices { get; set; }   = new List<BusinessService>(); 
        public ICollection<EmployeeServices> EmployeeServices { get; set; } = new List<EmployeeServices>();
        public ICollection<ServiceReservation> ServiceReservations { get; set; } = new List<ServiceReservation>();
    }
}
