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
    [Route("api/Transacrions")]
    public class TransacrionsController : Controller
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
            return Parking.Instance.GetTransactionsForLastMinute;
        }
        
        [HttpGet("[action]/{id}")]
        public string LastMinuteHistoryForCar(Guid id)
        {
            return "value";
        }
        
        // POST: api/Transacrions
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Transacrions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
