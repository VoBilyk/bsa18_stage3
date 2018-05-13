using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ParkingEmulator
{
    static class ParkingServices
    {

        // Parking actions
        static public string GetAllParkingPlace()
        {
            return Parking.Instance.ParkingSpace.ToString();
        }

        static public string GetFreeParkingPlace()
        {
            return Parking.Instance.FreeParkingSpace.ToString();
        }

        static public string GetParkingBalance()
        {
            return Parking.Instance.Balance.ToString();
        }

        // Transaction actions
        static public string GetTransactionsLogFile()
        {
            var log = String.Empty;

            try
            {
                log = File.ReadAllText(Settings.logFile);
            }
            catch (FileNotFoundException)
            {
                return "Error, file Transactions.log not found";
            }

            return "Transactions.log";
        }

        static public IEnumerable<Transaction> GetTransactionForLastMinute()
        {
            return Parking.Instance.GetTransactionsForLastMinute;
        }
    }
}
