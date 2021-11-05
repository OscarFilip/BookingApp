using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningApp
{
    public class CustomerCustomerMethods
    {
        internal static void HandleBookings()
        {
            bool runLoop = true;
            while (runLoop)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] Book a lesson.");
                Console.WriteLine("[2] Cancel a booked lesson.");
                Console.WriteLine("[3] Change a booked lesson.");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("What is the name of the student: ");
                        string inputName = Console.ReadLine();

                        var inputDiscipline = AdminBookingMethods.ChooseTypeOfLesson();

                        var inputLevel = AdminBookingMethods.ChooseLevelOfLesson();

                        var inputInstructor = AdminBookingMethods.ChooseInstructorForLesson(inputDiscipline, inputLevel);

                        var inputDay = AdminBookingMethods.ChooseDayForLesson();

                        var inputTime = AdminBookingMethods.ChooseTimeForLesson( inputInstructor, inputDay);

                        Database.Bookings.Add(new Booking(Database.ActiveUser, inputName, inputInstructor, inputDay, inputTime, inputDiscipline, inputLevel));
                        Database.ActiveUser.UserBookings.Add(Database.Bookings.Last());
                        break;
                    case 2:
                        RemoveBooking();
                        break;
                    case 3:
                        EditBooking();
                        break;
                }
            }
        }
        private static void RemoveBooking()
        {
            foreach (var booking in Database.ActiveUser.UserBookings)
            {
                AdminBookingMethods.WriteBooking(booking);
            }
            Console.WriteLine("Type booking number of booking you would like to remove: ");
            int intInput = Convert.ToInt32(Console.ReadLine());
            foreach (var booking in Database.ActiveUser.UserBookings)
            {
                if (intInput == booking.BookingNumber)
                {
                    Database.ActiveUser.UserBookings.Remove(booking);
                    Database.Bookings.Remove(booking);
                    break;
                }
            }
        }
        private static void EditBooking()
        {
            foreach (var booking in Database.ActiveUser.UserBookings)
            {
                AdminBookingMethods.WriteBooking(booking);
            }
            Console.WriteLine("Type booking number of booking you would like to edit: ");
            int intInput = Convert.ToInt32(Console.ReadLine());
            foreach (var booking in Database.ActiveUser.UserBookings)
            {
                if (intInput == booking.BookingNumber)
                {
                    Console.WriteLine("What would you like to change?");
                    Console.WriteLine("[1] Student name.");
                    Console.WriteLine("[2] Instructor, type of lesson or when.");
                    int intInput2 = Convert.ToInt32(Console.ReadLine());
                    switch (intInput2)
                    {
                        case 1:
                            Console.WriteLine("What is the new name of the student: ");
                            booking.StudentName = Console.ReadLine();
                            break;
                        case 2:
                            var inputDiscipline = AdminBookingMethods.ChooseTypeOfLesson();

                            var inputLevel = AdminBookingMethods.ChooseLevelOfLesson();

                            var inputInstructor = AdminBookingMethods.ChooseInstructorForLesson(inputDiscipline, inputLevel);

                            var inputDay = AdminBookingMethods.ChooseDayForLesson();

                            var inputTime = AdminBookingMethods.ChooseTimeForLesson(inputInstructor, inputDay);

                            booking.Discipline = inputDiscipline;
                            booking.Level = inputLevel;
                            booking.Instructor = inputInstructor;
                            booking.Day = inputDay;
                            booking.TimeOfLesson = inputTime;
                            break;

                    }
                }
            }
        }
    }
}
