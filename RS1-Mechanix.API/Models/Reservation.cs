namespace RS1_Mechanix.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Name { get; set; }
        public ICollection<ServiceReservation> ServiceReservations { get; set; } = new List<ServiceReservation>();  

    }
}
