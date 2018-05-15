using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingEmulator;
using Newtonsoft.Json;

namespace ParkingEmulatorWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult LogFIle()
        {
            string[] file;
            try
            {
                file = System.IO.File.ReadAllText(Settings.logFile).Split("\r\n");
            }
            catch (Exception)
            {
                return BadRequest("File error");
            }

            return new JsonResult(file);
        }

        [HttpGet("[action]")]
        public IActionResult LastMinuteHistory()
        {
            var transactions = Parking.Instance.GetLastMinuteTransactions;

            if (transactions == null)
            {
                return new EmptyResult();
            }

            return new JsonResult(transactions);
        }
        
        [HttpGet("[action]/{id}")]
        public IActionResult LastMinuteHistory(Guid id)
        {
            var transactions = Parking.Instance.GetLastMinuteTransactionsForCar(id);

            if (transactions == null)
            {
                return new EmptyResult();
            }

            return new JsonResult(transactions);
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
