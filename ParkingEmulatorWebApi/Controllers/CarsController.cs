using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingEmulator;

namespace ParkingEmulatorWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Cars")]
    public class CarsController : Controller
    {
        // GET: api/Cars
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return Parking.Instance.GetCars;
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public Car Get(Guid id)
        {
            return Parking.Instance.GetCar(id);
        }
        
        // POST: api/Cars
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Cars/5
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
