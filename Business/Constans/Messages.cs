using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public static class Messages
    {
        public static string CarAdded = "Car added.";
        public static string CarNameİnvalid = "Given car name is invalid!";
        public static string MaintenanceTime = "system is currently under maintenance!";
        public static string CarListed = "Cars has been listed";
        public static string CarUpdated = "car has been Uptaded";
        public static string CarDeleted = "car has been Deleted";
        public static string UserListed = "Users Listed";
        public static string carLimitError = "Car limit Exceted";
        public static string carPriceLower = "If car model year is equal or over 2015, car price has to be more than 250 dolar ";

        public static string UserAdded = "User added";
        public static string UserDeleted = "User deleted";
        public static string UserUpdated = "User updated";

        public static string ColourUpdated { get; internal set; }
        public static string ColourDeleted { get; internal set; }
    }
}
