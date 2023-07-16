using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Models
{
    // Payment Data model to store and retrieve payment data with few validation
    public class Payment
    {
        public string? Id { get; set; }
        [StringLength(12,MinimumLength =12,ErrorMessage ="Card number should be 12 characters")]
        public string CardNumber { get; set; }
        public string ExpirtMonthDate { get; set; }
        public double amount { get; set; }
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Currency should be 3 characters")]
        public string Currency { get; set; }
        [Range(100,999,ErrorMessage = "CVV should be 3 digits range between 000-999")]
        public int CVV { get; set; }
    }
}
