using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentWebApi.Models;

namespace PaymentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {
        private readonly PayemntDetailsContext _context;

        public PaymentDetailsController(PayemntDetailsContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetails>>> GetPaymentDetails()
        {
            return await _context.PaymentDetails.ToListAsync();
        }

        
        // POST: api/PaymentDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PaymentDetails>> PostPaymentDetails(PaymentDetails paymentDetails)
        {
            try
            {
                var cardCheck = new Regex(@"^(1298|1267|4512|4567|8901|8933)([\-\s]?[0-9]{4}){3}$");
                var monthCheck = new Regex(@"^([1-9]|1[0-2])$");
                var yearCheck = new Regex(@"^20[0-9]{2}$");
                var cvvCheck = new Regex(@"^\d{3}$");

                if (!cardCheck.IsMatch(paymentDetails.CardNumber))
                {
                    return BadRequest("Invalid Request");
                }
                if (!cvvCheck.IsMatch(paymentDetails.SecurityCode))
                {
                    return BadRequest("Invalid Request");
                }
               
                if (!monthCheck.IsMatch(paymentDetails.ExpiryDate.Month.ToString()) || !yearCheck.IsMatch(paymentDetails.ExpiryDate.Year.ToString())) // <3 - 6>
                {
                    return BadRequest("Invalid Request");
                }

                var lastDateOfExpiryMonth = DateTime.DaysInMonth(paymentDetails.ExpiryDate.Year, paymentDetails.ExpiryDate.Month); //get actual expiry date
                var cardExpiry = new DateTime(paymentDetails.ExpiryDate.Year, paymentDetails.ExpiryDate.Month, lastDateOfExpiryMonth, 23, 59, 59);
                if(cardExpiry < DateTime.Now)
                {
                    return BadRequest("Invalid Request");
                }
                _context.PaymentDetails.Add(paymentDetails);
                await _context.SaveChangesAsync();

                return Ok("Payemnt Processed");

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}
