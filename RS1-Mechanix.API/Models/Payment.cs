namespace RS1_Mechanix.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public float Cost { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        
    }
}
