using Microsoft.EntityFrameworkCore;
using PaymentGateway.Contexts;
using PaymentGateway.Models;

namespace PaymentGateway.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public PaymentRepository()
        {
            using (var context = new PaymentApiContext())
            {
                var payments = new List<Payment>
                {
                new Payment
                {
                    Id =1,
                    CardNumber ="123456789",
                    ExpirtMonthDate="05/05",
                    amount=10.99,
                    Currency="EUR",
                    CVV=123
                },
                
                };
                context.Payments.AddRange(payments);
                context.SaveChanges();
            }
        }
        public List<Payment> GetAllPayments()
        {
            using (var context = new PaymentApiContext())
            {
                var payments = context.Payments.ToList();
                return payments;
            }
        }
    }
}
