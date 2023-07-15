namespace PaymentGateway.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string ExpirtMonthDate { get; set; }
        public double amount { get; set; }
        public string Currency { get; set; }
        public int CVV { get; set; }
    }
}
