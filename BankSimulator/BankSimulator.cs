using PaymentGateway.Models;
using PaymentGateway.Repositories;

namespace PaymentGateway.BankSimulator
{
    public class BankSimulator
    {

        readonly IPaymentRepository paymentRepository = new PaymentRepository();
        public static void Main()
        {
        }

        public List<Payment> GetAllPayments()
        {
            return paymentRepository.GetAllPayments();
        }

        public Payment GetPaymentDetailsById(string Id)
        {
            return paymentRepository.GetPaymentDetailsById(Id);
        }

        public void ProcessPayment(Payment paymentObj)
        {
            paymentRepository.ProcessPayment(paymentObj);
        }
    }
}
