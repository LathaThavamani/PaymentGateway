using PaymentGateway.Models;

namespace PaymentGateway.Repositories
{
    public interface IPaymentRepository
    {
        public List<Payment> GetAllPayments();
    }
}
