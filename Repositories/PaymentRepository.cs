using Microsoft.EntityFrameworkCore;
using PaymentGateway.Contexts;
using PaymentGateway.Models;

namespace PaymentGateway.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        // Get all the payment details from in-memory DB
        public List<Payment> GetAllPayments()
        {
            using (var context = new PaymentApiContext())
            {
                var payments = context.Payments.ToList();
                // Assign masked card number to all the payments
                payments.ForEach(p => { p.CardNumber = MaskCardNumber(p.CardNumber); });
                return payments;
            }
        }

        // Get particular payment details using payment id from in-memory DB
        public Payment GetPaymentDetailsById(string Id)
        {
            using (var context = new PaymentApiContext())
            {
                var payment = context.Payments.Where(p => p.Id == Id).FirstOrDefault();
                if (payment != null)
                {
                    // Assign masked card number
                    payment.CardNumber = MaskCardNumber(payment.CardNumber);
                }
                return payment;
            }
        }

        // This method will store the payment detail to in-memory DB
        public void ProcessPayment(Payment paymentObj)
        {
            using (var context = new PaymentApiContext())
            {
                Guid newGuid = Guid.NewGuid();
                // Randomly generating new Guid for each new payment process
                paymentObj.Id = newGuid.ToString();
                context.Payments.AddRange(paymentObj);
                context.SaveChanges();
            }
        }

        // Mask card number except lat 4 characters to display to the user
        public string MaskCardNumber(string cardNumber, int visibleDigits = 4, char mask = '*')
        {
            // Check if the card number is valid or not
            if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length <= visibleDigits)
            {
                return cardNumber;
            }
            // Creating new masked card number
            string maskedCardNumber = new string('*', cardNumber.Length - visibleDigits) + cardNumber.Substring(cardNumber.Length - visibleDigits);
            return maskedCardNumber;
        }
    }
}
