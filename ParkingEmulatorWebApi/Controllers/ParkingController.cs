using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingEmulator;


namespace ParkingEmulatorWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ParkingController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult FreePlaces()
        {
            return new ObjectResult(Parking.Instance.FreeParkingSpace);
        }

        [HttpGet("[action]")]
        public IActionResult TotalPlaces()
        {
            return new ObjectResult(Parking.Instance.ParkingSpace);
        }

        [HttpGet("[action]")]
        public IActionResult Balance()
        {
            return new ObjectResult(Parking.Instance.Balance);
        }
    }
}
