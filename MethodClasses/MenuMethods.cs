using BokningApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningApp
{
    public class MenuMethods
    {
        public static void Login()
        {
            User activeUser = new User();
            bool runMethod = true;
            while (runMethod)
            {
                Console.WriteLine("Hi! Please log in. ");
                Console.WriteLine("Username: ");
                string searchUserName = Console.ReadLine();
                foreach (var user in Database.Users)
                {
                    if (user.Name == searchUserName)
                    {
                        Database.ActiveUser = user;
                        runMethod = false;
                    }
                    if (searchUserName == "0")
                    {
                        
                    }
                }
            }
        }
        public static void RunMenu()
        {
            if (Database.ActiveUser.IsAdmin == true)
            {
                AdminMenu();
            }
            if (Database.ActiveUser.IsAdmin == false)
            {
                CustomerMenu();
            }
        }


        public static void AdminMenu()
        {
            bool runLoop = true;
            while (runLoop)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] Handle instructors.");
                Console.WriteLine("[2] Handle bookings.");
                Console.WriteLine("[3] Handle customers.");
                Console.WriteLine("[4] Logout.");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)

                {
                    case 1:
                        AdminInstructorMethods.HandleInstructorsMenu();
                        break;
                    case 2:
                        AdminBookingMethods.HandleBookingsMenu();
                        break;
                    case 3:
                        AdminCustomerMethods.HandleCustomersMenu();
                        break;
                    case 4:
                        runLoop = false;
                        break;
                }
            }
        }
        private static void CustomerMenu()
        {
            bool runLoop = true;
            while (runLoop)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] Handle bookings.");
                Console.WriteLine("[2] Change username.");
                Console.WriteLine("[3] Logout.");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)

                {
                    case 1:
                        CustomerCustomerMethods.HandleBookings();
                        break;
                    case 2:
                        Console.WriteLine("Choose new name:");
                        Database.ActiveUser.Name = Console.ReadLine();
                        break;
                    case 3:
                        runLoop = false;
                        break;
                }
            }
        }
        

        
        



    }
}
