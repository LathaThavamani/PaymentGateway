using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Models
{
    public class Payment
    {
        public string? Id { get; set; }
        [StringLength(12,ErrorMessage ="Card number should be 12 characters")]
        public string CardNumber { get; set; }
        public string ExpirtMonthDate { get; set; }
        public double amount { get; set; }
        [StringLength(3, ErrorMessage = "Currency should be 3 characters")]
        public string Currency { get; set; }
        [Range(100,999,ErrorMessage = "Card number should be 3 digits number")]
        public int CVV { get; set; }
    }
}
