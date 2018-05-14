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
        public string LogFIle()
        {
            var file = File(Settings.logFile, "text/plain");
            // TODO
            return System.IO.File.ReadAllText(Settings.logFile);
        }

        [HttpGet("[action]")]
        public IEnumerable<Transaction> LastMinuteHistory()
        {
            return Parking.Instance.GetLastMinuteTransactions;
        }
        
        [HttpGet("[action]/{id}")]
        public IEnumerable<Transaction> LastMinuteHistory(Guid id)
        {
            return Parking.Instance.GetLastMinuteTransactionsForCar(id);
        }
       
        
        // PUT: api/Transacrions/5
        [HttpPut("{id}")]
        public IActionResult RefillCarBalance(Guid id, [FromBody]decimal value)
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
