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

            return new JsonResult(item);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var item = Parking.Instance.GetCars.First(c => c.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return new JsonResult(item);
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

            return NoContent();
        }


        [HttpPost]
        public IActionResult Post([FromBody]Models.CarBodyCreator carCreator)
        {
            if (carCreator == null)
            {
                return BadRequest("");
            }


            if(!Enum.IsDefined(typeof(CarType), carCreator.CarType))
            {
                return BadRequest("Error, Wrong car type");
            }

            var car = new Car(carCreator.CarType, carCreator.Balance);

            try
            {
                Parking.Instance.AddCar(car);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex);
            }

            return new JsonResult(car);
        }
    }
}