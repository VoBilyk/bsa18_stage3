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
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost("{type}/{value?}")]
        public IActionResult Post(string type, decimal value = 0)
        {
            CarType carType;
            try
            {
                carType = Enum.Parse<CarType>(type);
            }
            catch (Exception)
            {
                return BadRequest("Error, Wrong car type");
            }

            var car = new Car(carType, value);

            try
            {
                Parking.Instance.AddCar(car);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex);
            }

            return new ObjectResult(car);
        }
    }
}
