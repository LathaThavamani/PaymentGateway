using PaymentGateway.Models;

namespace PaymentGateway.Repositories
{
    // Payment Repository interface with defined set of methods
    public interface IPaymentRepository
    {
        public List<Payment> GetAllPayments();
        public Payment GetPaymentDetailsById(string Id);
        public void ProcessPayment(Payment paymentObj);
    }
}
