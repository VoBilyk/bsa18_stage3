using ParkingEmulator;

namespace ParkingEmulatorWebApi.Models
{
    public class CarBodyCreator
    {
        public decimal Balance { get; set; }

        public CarType CarType { get; set; } = 0;
    }
}