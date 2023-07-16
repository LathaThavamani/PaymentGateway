using PaymentGateway.Models;

namespace PaymentGateway.Repositories
{
    public interface IPaymentRepository
    {
        public List<Payment> GetAllPayments();
        public Payment GetPaymentDetailsById(string Id);
        public void ProcessPayment(Payment paymentObj);
    }
}
