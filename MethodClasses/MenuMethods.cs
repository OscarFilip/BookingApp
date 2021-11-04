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
        public static void Login(IDatabase database)
        {
            User activeUser = new User();
            bool runMethod = true;
            while (runMethod)
            {
                Console.WriteLine("Hi! Please log in. ");
                Console.WriteLine("Username: ");
                string searchUserName = Console.ReadLine();
                foreach (var user in database.Users)
                {
                    if (user.Name == searchUserName)
                    {
                        database.ActiveUser = user;
                        runMethod = false;
                    }
                }
            }
        }
        public static void RunMenu(IDatabase database)
        {
            if (database.ActiveUser.IsAdmin == true)
            {
                AdminMenu(database);
            }
            if (database.ActiveUser.IsAdmin == false)
            {
                CustomerMenu(database);
            }
        }


        public static void AdminMenu(IDatabase database)
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
                        AdminInstructorMethods.HandleInstructorsMenu(database);
                        break;
                    case 2:
                        AdminBookingMethods.HandleBookingsMenu(database);
                        break;
                    case 3:
                        AdminCustomerMethods.HandleCustomersMenu(database);
                        break;
                    case 4:
                        runLoop = false;
                        break;
                }
            }
        }
        private static void CustomerMenu(IDatabase database)
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
                        CustomerCustomerMethods.HandleBookings(database);
                        break;
                    case 2:
                        Console.WriteLine("Choose new name:");
                        database.ActiveUser.Name = Console.ReadLine();
                        break;
                    case 3:
                        runLoop = false;
                        break;
                }
            }
        }
        

        
        



    }
}
