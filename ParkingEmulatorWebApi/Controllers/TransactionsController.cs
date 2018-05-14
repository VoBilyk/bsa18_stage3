using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingEmulator;

namespace ParkingEmulatorWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult LogFIle()
        {
            var file = File(Settings.logFile, "text/plain");
            return new ObjectResult(file);

            // TODO
            //return System.IO.File.ReadAllText(Settings.logFile);
        }

        [HttpGet("[action]")]
        public IActionResult LastMinuteHistory()
        {
            var transactions = Parking.Instance.GetLastMinuteTransactions;

            if (transactions == null)
            {
                return new EmptyResult();
            }

            return new ObjectResult(transactions);
        }
        
        [HttpGet("[action]/{id}")]
        public IActionResult LastMinuteHistory(Guid id)
        {
            var transactions = Parking.Instance.GetLastMinuteTransactionsForCar(id);

            if (transactions == null)
            {
                return new EmptyResult();
            }

            return new ObjectResult(transactions);
        }
       
        
        // PUT: api/Transacrions/5
        [HttpPut("{id}/{value}")]
        public IActionResult RefillCarBalance(Guid id, decimal value)
        {
            try
            {
                Parking.Instance.RefillCarBalance(id, value);
            }
            catch (InvalidOperationException)
            {
                return BadRequest($"Not found CarId: {id}");
            }

            return Ok("Success");
        }
    }
}
