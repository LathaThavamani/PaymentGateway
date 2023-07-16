using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.BankSimulator;
using PaymentGateway.Models;

namespace PaymentGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Enable authorization for all API in this payment controller
    [Authorize]
    public class PaymentController : ControllerBase
    {
        // Creating a instance for bank simulator class to access properties & methods
        BankSimulator.BankSimulator simulator = new BankSimulator.BankSimulator();

        // GET api/payment
        [HttpGet]
        public ActionResult<dynamic> Get()
        {
            var message = new ResponseMessage();
            try
            {
                // Return all the processed payments if response is successful
                return Ok(simulator.GetAllPayments());
            }
            catch(Exception e)
            {
                // Show error message in response
                message.Message = e.Message;
                return Ok(message);
            }
        }

        // GET api/payment/paymentId
        [HttpGet("{id}")]
        public ActionResult<dynamic> Get(string id)
        {
            var message = new ResponseMessage();
            try
            {
                // Return the particular payment detail by payment id
                return Ok(simulator.GetPaymentDetailsById(id));
            }
            catch (Exception e)
            {
                // Show error message in response
                message.Message = e.Message;
                return Ok(message);
            }
        }

        // POST api/payment - pass payment detail as JSON object in API body
        [HttpPost]
        public ActionResult<ResponseMessage> Post([FromBody] Payment paymentObj)
        {
            var message = new ResponseMessage();
            try { 
                // Show payment success message if no errors
                simulator.ProcessPayment(paymentObj);
                message.Message = "Payment Successful";
            }
            catch(Exception e)
            {
                // Show error message in response
                message.Message = e.Message;
            }
            return Ok(message);
        }
    }
}
