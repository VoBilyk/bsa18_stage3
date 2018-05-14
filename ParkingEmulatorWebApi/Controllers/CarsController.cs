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
        [HttpGet]
        public IActionResult Get()
        {
            var item = Parking.Instance.GetCars;
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var item = Parking.Instance.GetCars.First(c => c.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Parking.Instance.RemoveCar(id);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }

            return new NoContentResult();
        }


        [HttpPost]
        public IActionResult Post([FromBody] Car item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            try
            {
                Parking.Instance.AddCar(item);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            return CreatedAtRoute("Get", new { id = item.Id });
            //return new NoContentResult();

            //return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }
    }
}
