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
                return payments;
            }
        }

        public Payment GetPaymentDetailsById(string Id)
        {
            using (var context = new PaymentApiContext())
            {
                var payment = context.Payments.Where(p => p.Id == Id).FirstOrDefault();
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
    }
}
