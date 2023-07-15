using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Models;
using PaymentGateway.Repositories;

namespace PaymentGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        readonly IPaymentRepository _paymentRepository;
        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        [HttpGet]
        public ActionResult<List<Payment>> Get()
        {
            return Ok(_paymentRepository.GetAllPayments());
        }

        //// GET api/<PaymentController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<PaymentController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}
    }
}
