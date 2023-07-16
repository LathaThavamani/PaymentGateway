using Microsoft.EntityFrameworkCore;
using PaymentGateway.Contexts;
using PaymentGateway.Models;

namespace PaymentGateway.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {


        //            {
        //    "id": 1,
        //    "cardNumber": "123456789",
        //    "expirtMonthDate": "05/05",
        //    "amount": 10.99,
        //    "currency": "EUR",
        //    "cvv": 123
        //}

        public List<Payment> GetAllPayments()
        {
            using (var context = new PaymentApiContext())
            {
                var payments = context.Payments.ToList();
                payments.ForEach(p => { p.CardNumber = MaskCardNumber(p.CardNumber); });
                return payments;
            }
        }

        public Payment GetPaymentDetailsById(string Id)
        {
            using (var context = new PaymentApiContext())
            {
                var payment = context.Payments.Where(p => p.Id == Id).FirstOrDefault();
                if (payment != null)
                {
                    payment.CardNumber = MaskCardNumber(payment.CardNumber);
                }
                return payment;
            }
        }

        public void ProcessPayment(Payment paymentObj)
        {
            using (var context = new PaymentApiContext())
            {
                Guid newGuid = Guid.NewGuid();
                paymentObj.Id = newGuid.ToString();
                context.Payments.AddRange(paymentObj);
                context.SaveChanges();
            }
        }

        public string MaskCardNumber(string cardNumber, int visibleDigits = 4, char mask = '*')
        {
            // Check if the card number is valid or not
            if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length <= visibleDigits)
            {
                return cardNumber;
            }
            string maskedCardNumber = new string('*', cardNumber.Length - visibleDigits) + cardNumber.Substring(cardNumber.Length - visibleDigits);
            return maskedCardNumber;
        }
    }
}
