using Microsoft.AspNetCore.Mvc;
using PaymentGateway.BankSimulator;
using PaymentGateway.Models;

namespace PaymentGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        BankSimulator.BankSimulator simulator = new BankSimulator.BankSimulator();

        [HttpGet]
        public ActionResult<dynamic> Get()
        {
            var message = new ResponseMessage();
            try
            {
                return Ok(simulator.GetAllPayments());
            }
            catch(Exception e)
            {
                message.Message = e.Message;
                return Ok(message);
            }
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public ActionResult<dynamic> Get(string id)
        {
            var message = new ResponseMessage();
            try
            {
                return Ok(simulator.GetPaymentDetailsById(id));
            }
            catch (Exception e)
            {
                message.Message = e.Message;
                return Ok(message);
            }
        }

        [HttpPost]
        public ActionResult<ResponseMessage> Post([FromBody] Payment paymentObj)
        {
            var message = new ResponseMessage();
            try { 
                simulator.ProcessPayment(paymentObj);
                message.Message = "Payment Successful";
            }
            catch(Exception e)
            {
                message.Message = e.Message;
            }
            return Ok(message);
        }
    }
}
