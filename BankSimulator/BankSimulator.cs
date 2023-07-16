using PaymentGateway.Models;
using PaymentGateway.Repositories;

namespace PaymentGateway.BankSimulator
{
    // Bank Simulator to mock a Bank
    public class BankSimulator
    {
        // Interface for payment repository with defined methods
        readonly IPaymentRepository paymentRepository = new PaymentRepository();
        public static void Main()
        {
        }

        // Get all the payments already processed
        public List<Payment> GetAllPayments()
        {
            return paymentRepository.GetAllPayments();
        }

        // Get details of particular payment using payment id
        public Payment GetPaymentDetailsById(string Id)
        {
            return paymentRepository.GetPaymentDetailsById(Id);
        }

        // Complete the payment process and store the process details
        public void ProcessPayment(Payment paymentObj)
        {
            paymentRepository.ProcessPayment(paymentObj);
        }
    }
}
