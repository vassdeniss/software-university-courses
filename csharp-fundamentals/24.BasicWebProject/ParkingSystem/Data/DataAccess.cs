using ParkingSystem.Data.Models;
using System.Collections.Generic;

namespace ParkingSystem.Data
{
    public class DataAccess
    {
        public static List<Car> CarList { get; set; } = new List<Car>();
    }
}
