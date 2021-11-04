using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningApp
{
    public class AdminCustomerMethods
    {
        public static void HandleCustomersMenu(IDatabase database)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Add customer.");
            Console.WriteLine("[2] Remove customer.");
            Console.WriteLine("[3] Edit customer.");
            int intInput = Convert.ToInt32(Console.ReadLine());
            switch (intInput)
            {
                case 1:
                    AddCustomer(database);
                    break;
                case 2:
                    RemoveCustomer(database);
                    break;
                case 3:
                    EditCustomer(database);
                    break;
            }
        }
        private static void AddCustomer(IDatabase database)
        {
            Console.WriteLine("Choose name of new customer:");
            string inputName = Console.ReadLine();
            bool inputIsAdmin = false;
            Console.WriteLine("Is new customer an Admin?");
            Console.WriteLine("[1] Yes.");
            Console.WriteLine("[2] No.");
            int intInput = Convert.ToInt32(Console.ReadLine());
            switch (intInput)
            {
                case 1:
                    inputIsAdmin = true;
                    break;
                case 2:
                    break;
            }
            database.Users.Add(new User(inputName, inputIsAdmin));
        }
        private static void RemoveCustomer(IDatabase database)
        {
            Console.WriteLine("All customers:");
            WriteAllCustomers(database);
            Console.WriteLine("Type full name of customer you would like to remove: ");
            string strInput = Console.ReadLine();
            foreach (var user in database.Users)
            {
                if (strInput == user.Name)
                {
                    database.Users.Remove(user);
                    break;
                }
            }
        }
        private static void EditCustomer(IDatabase database)
        {
            Console.WriteLine("All customers:");
            WriteAllCustomers(database);
            Console.WriteLine("Type full name of customer you would like to edit: ");
            string strInput = Console.ReadLine();
            foreach (var user in database.Users)
            {
                if (strInput == user.Name)
                {
                    Console.WriteLine("What would you like to change?");
                    Console.WriteLine("[1] Name.");
                    Console.WriteLine("[2] Admin status.");
                    int intInput = Convert.ToInt32(Console.ReadLine());
                    switch (intInput)
                    {
                        case 1:
                            Console.WriteLine("Choose new name of customer:");
                            user.Name = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Is customer an Admin?");
                            Console.WriteLine("[1] Yes.");
                            Console.WriteLine("[2] No.");
                            int intInput2 = Convert.ToInt32(Console.ReadLine());
                            switch (intInput2)
                            {
                                case 1:
                                    user.IsAdmin = true;
                                    break;
                                case 2:
                                    user.IsAdmin = false;
                                    break;
                            }
                            break;
                    }
                }
            }
        }
        public static void WriteAllCustomers(IDatabase database)
        {
            foreach (var User in database.Users)
            {
                if (User.IsAdmin == false)
                {
                    Console.Write(User.Name + "\n");
                }
            }
        }
    }
}
