namespace RS1_Mechanix.Models
{
    public class ServiceReservation
    {
        public int ServiceId { get; set; }
        public int ReservationId { get; set; }
        public Service Service { get; set; }
        public Reservation Reservation { get; set; }
    }
}
