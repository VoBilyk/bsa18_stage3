using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParkingEmulator;


namespace ParkingEmulatorWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ParkingController : Controller
    {
        [HttpGet("[action]")]
        public async Task<string> FreePlaces() =>
            await Task.Run(() => JsonConvert.SerializeObject(Parking.Instance.FreeParkingSpace));

        [HttpGet("[action]")]
        public string AllPlaces()
        {
            return Parking.Instance.FreeParkingSpace.ToString();
        }

        [HttpGet("[action]")]
        public string Balance()
        {
            return Parking.Instance.Balance.ToString();
        }
    }
}
