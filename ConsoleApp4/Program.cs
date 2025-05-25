using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }

    public class Manager : User
    {

    }

    public class Staff : User
    {

    }


    public class Driver
    {
        public int DriverId { get; set; }         // Unique ID for each driver
        public string DriverName { get; set; }     // Driver's full name
        public string DriverPhone1 { get; set; }  // Driver's phone number
        public string DriverPhone2 { get; set; }  // Driver's phone number
        public decimal CommissionRate { get; set; } = 0.70M;   // Commission rate (default is 70%)
    }
    public class Customer
    {
        public int CustomerId { get; set; }          // Unique ID for each customer
        public string CustomerName { get; set; }     // Customer's name
        public string PhoneNumber1 { get; set; }      // Customer's phone number
        public string PhoneNumber2 { get; set; }
        public List<Order> Orders { get; set; }      // List of orders placed by the customer
    }


    public class Order
    {
        public int OrderId { get; set; }           // Unique order ID
        public string CustomerName { get; set; }   // Customer name
        public string CustomerPhone { get; set; }  // Customer phone number
        public string DeliveryAddress { get; set; }  // Delivery address for the order
        public DateTime DeliveryTime { get; set; }   // Scheduled delivery time
        public string PaymentMethod { get; set; }    // Payment options (e.g., Cash, Deposit)
        public decimal DeliveryFee { get; set; }     // Delivery fee for the order
        public int DriverId { get; set; }            // ID of the assigned driver
        public Driver AssignedDriver { get; set; }   // Navigation property for driver
        public string OrderStatus { get; set; } = "Submitted";  // Current status (e.g., Submitted, In Progress, Delivered)
        public string Notice { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
