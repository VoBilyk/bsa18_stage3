using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingEmulator
{
    class Transaction
    {
        public Transaction(Guid carId, decimal writtenOffMoney)
        {
            DateTime = DateTime.Now;
            CarId = carId;
            WrittenOffMoney = writtenOffMoney;
        }

        public DateTime DateTime { get; private set; }

        public Guid CarId { get; private set; }

        public decimal WrittenOffMoney { get; private set; }

        public override string ToString()
        {
            return String.Format($"Time: {DateTime}, " +
                                 $"CarId: {CarId}, " +
                                 $"WrittenOffMoney {WrittenOffMoney}");
        }
    }
}
