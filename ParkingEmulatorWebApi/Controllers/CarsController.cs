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
        public void Init()
        {
            Parking.Instance.AddCar(new Car(CarType.Passenger, 100));
            Parking.Instance.AddCar(new Car(CarType.Truck, 250));

            Parking.Instance.AddCar(new Car(CarType.Bus));

        }
        [HttpGet(Name = "Get")]
        public IActionResult Get()
        {
            Init();
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

            return new NoContentResult();
        }


        [HttpPost("{type}/{value:decimal}")]
        public IActionResult Post(string type, decimal value)
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
            Parking.Instance.AddCar(car);

            return new ObjectResult(car);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Car item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var car = new Car(item.Type, item.Balance);
            try
            {
                Parking.Instance.AddCar(car);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

            return new ObjectResult(car);
        }
    }
}
