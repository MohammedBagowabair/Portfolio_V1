using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public Guid UserId { get; set; }           // Globally unique identifier for the user

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }       // User's full name (maximum 50 characters)

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }          // Email used as the username for login

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }       // Password for authentication

        [Phone]
        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }    // User's phone number

        [Required]
        public string Role { get; set; }           // Role to differentiate Manager and Staff
    }

    // Manager class inheriting from User
    public class Manager : User
    {
        // Additional properties for Manager can be added here in the future
    }

    // Staff class inheriting from User
    public class Staff : User
    {
        // Additional properties for Staff can be added here in the future
    }

    // Driver model
    public class Driver
    {
        [Key]
        public Guid DriverId { get; set; }          // Globally unique identifier for each driver

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }        // Driver's full name (maximum 50 characters)

        [Phone]
        [Required]
        [StringLength(15)]
        public string PhoneNumber1 { get; set; }    // Driver's primary phone number

        [Phone]
        [StringLength(15)]
        public string PhoneNumber2 { get; set; }    // Driver's secondary phone number (optional)

        [Range(0, 1)]
        public decimal CommissionRate { get; set; } = 0.70M;  // Commission rate (default is 70%)
    }

    // Customer model
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }        // Globally unique identifier for each customer

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }        // Customer's full name (maximum 50 characters)

        [Phone]
        [Required]
        [StringLength(15)]
        public string PhoneNumber1 { get; set; }    // Customer's primary phone number

        [Phone]
        [StringLength(15)]
        public string PhoneNumber2 { get; set; }    // Customer's secondary phone number (optional)

        public List<Order> Orders { get; set; }     // List of orders placed by the customer
    }

    // Order model
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }           // Globally unique identifier for each order

        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }    // Customer's name (maximum 50 characters)

        [Phone]
        [Required]
        [StringLength(15)]
        public string CustomerPhone { get; set; }   // Customer's phone number

        [Required]
        [StringLength(200)]
        public string DeliveryAddress { get; set; } // Delivery address for the order

        [Required]
        public DateTime DeliveryTime { get; set; }  // Scheduled delivery time

        [Required]
        public string PaymentMethod { get; set; }   // Payment options (e.g., Cash, Deposit)

        [Range(0, 1000)]
        public decimal DeliveryFee { get; set; }    // Delivery fee for the order

        public Guid DriverId { get; set; }          // ID of the assigned driver

        public Driver AssignedDriver { get; set; }  // Navigation property for the assigned driver

        [Required]
        public string OrderStatus { get; set; } = "Submitted";  // Current status (e.g., Submitted, In Progress, Delivered)

        [StringLength(500)]
        public string Notice { get; set; }          // Additional notes for the order
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
