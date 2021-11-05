using BokningApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningApp
{
    public class AdminBookingMethods
    {
        public static void HandleBookingsMenu()
        {
            bool runLoop = true;
            while (runLoop)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] Add booking.");
                Console.WriteLine("[2] Remove booking.");
                Console.WriteLine("[3] Edit bookings.");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        AdminAddBooking();
                        break;
                    case 2:
                        AdminRemoveBooking();
                        break;
                    case 3:
                        AdminEditBooking();
                        break;
                }
            }
        }

        private static void AdminAddBooking()
        {
            var thisUser = PlaceBookingOnCustomer();

            Console.WriteLine("What is the name of the student: ");
            string inputName = Console.ReadLine();

            var inputDiscipline = ChooseTypeOfLesson();

            var inputLevel = ChooseLevelOfLesson();

            var inputInstructor = ChooseInstructorForLesson(inputDiscipline, inputLevel);

            var inputDay = ChooseDayForLesson();

            var inputTime = ChooseTimeForLesson(inputInstructor, inputDay);

            Database.Bookings.Add(new Booking(thisUser, inputName, inputInstructor, inputDay, inputTime, inputDiscipline, inputLevel));
            thisUser.UserBookings.Add(Database.Bookings.Last());
        }

        public static TimeOfLesson ChooseTimeForLesson(Instructor instructor, Day day)
        {
            var choosenTime = TimeOfLesson.FirstLesson;
            List<TimeOfLesson> availableTimes = new List<TimeOfLesson>();
            availableTimes.Add(TimeOfLesson.FirstLesson);
            availableTimes.Add(TimeOfLesson.SecondLesson);
            availableTimes.Add(TimeOfLesson.ThirdLesson);
            availableTimes.Add(TimeOfLesson.FourthLesson);
            Console.WriteLine("Available times for this instructor on this day: ");
            foreach (var booking in Database.Bookings)
            {
                if (instructor == booking.Instructor && day == booking.Day)
                {
                    availableTimes.Remove(booking.TimeOfLesson);
                }
            }
            foreach (var avaibleTime in availableTimes)
            {
                if (avaibleTime == TimeOfLesson.FirstLesson)
                {
                    Console.WriteLine("[1] 09:00");
                }
                if (avaibleTime == TimeOfLesson.SecondLesson)
                {
                    Console.WriteLine("[2] 10:30");
                }
                if (avaibleTime == TimeOfLesson.ThirdLesson)
                {
                    Console.WriteLine("[3] 13:15");
                }
                if (avaibleTime == TimeOfLesson.FourthLesson)
                {
                    Console.WriteLine("[4] 15:00");
                }
            }
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    choosenTime = TimeOfLesson.FirstLesson;
                    break;
                case 2:
                    choosenTime = TimeOfLesson.SecondLesson;
                    break;
                case 3:
                    choosenTime = TimeOfLesson.ThirdLesson;
                    break;
                case 4:
                    choosenTime = TimeOfLesson.FourthLesson;
                    break;

            }
            return choosenTime;
        }

        public static Day ChooseDayForLesson()
        {
            Console.WriteLine("Choose day for lesson: ");
            var values = Enum.GetValues(typeof(Day));
            List<string> strList = new List<string>();
            foreach (var value in values)
            {
                strList.Add(Convert.ToString(value));
            }
            for (int i = 0; i < strList.Count; i++)
            {
                Console.WriteLine("[" + (i + 1) + "] " + strList[i]);
            }
            var inputDay = Day.Monday; ;
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    inputDay = Day.Monday; ;
                    break;
                case 2:
                    inputDay = Day.Tuesday;
                    break;
                case 3:
                    inputDay = Day.Wednesday;
                    break;
                case 4:
                    inputDay = Day.Thursday;
                    break;
                case 5:
                    inputDay = Day.Friday;
                    break;
                case 6:
                    inputDay = Day.Saturday;
                    break;
                case 7:
                    inputDay = Day.Sunday;
                    break;
            }
            return inputDay;
        }

        public static Instructor ChooseInstructorForLesson(Discipline inputDiscipline, Level inputLevel)
        {

            List<Instructor> competentInstructors = new List<Instructor>();
            for (int i = 0; i < Database.Instructors.Count; i++)
            {
                if (inputDiscipline == Discipline.AlpineSki)
                {
                    if (Database.Instructors[i].AlpineSkiLevel >= inputLevel)
                    {
                        competentInstructors.Add(Database.Instructors[i]);
                    }
                }
                if (inputDiscipline == Discipline.AlpineSnowboard)
                {
                    if (Database.Instructors[i].AlpineSnowboardLevel >= inputLevel)
                    {
                        competentInstructors.Add(Database.Instructors[i]);
                    }
                }
                if (inputDiscipline == Discipline.Crosscountry)
                {
                    if (Database.Instructors[i].CrosscountryLevel >= inputLevel)
                    {
                        competentInstructors.Add(Database.Instructors[i]);
                    }
                }
                if (inputDiscipline == Discipline.Sitski)
                {
                    if (Database.Instructors[i].SitskiLevel >= inputLevel)
                    {
                        competentInstructors.Add(Database.Instructors[i]);
                    }
                }
            }
            Console.WriteLine("All competent enough instructors for choosen lesson type and level: ");
            foreach (var instructor in competentInstructors)
            {
                Console.WriteLine(instructor.Name);
            }
            Instructor choosenInstructor = new Instructor();
            Console.WriteLine("Write full name of wanted instructor: ");
            string strInput = Console.ReadLine();
            foreach (var instructor in competentInstructors)
            {
                if (strInput == instructor.Name)
                {
                    choosenInstructor = instructor;
                }
            }
            return choosenInstructor;
        }

        public static Level ChooseLevelOfLesson()
        {
            Console.WriteLine("Choose level of lesson: ");
            var values = Enum.GetValues(typeof(Level));
            List<string> strList = new List<string>();
            foreach (var value in values)
            {
                strList.Add(Convert.ToString(value));
            }
            for (int i = 1; i < (strList.Count - 1); i++)
            {
                Console.WriteLine("[" + i + "] " + strList[i]);
            }
            var inputLevel = Level.NoLevel; ;
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    inputLevel = Level.LevelOne;
                    break;
                case 2:
                    inputLevel = Level.LevelTwo;
                    break;
                case 3:
                    inputLevel = Level.LevelThree;
                    break;
                case 4:
                    inputLevel = Level.LevelFour;
                    break;
            }
            return inputLevel;
        }

        private static User PlaceBookingOnCustomer()
        {
            User thisUser = new User();
            Console.WriteLine("Place the booking on which customer: ");
            AdminCustomerMethods.WriteAllCustomers();
            Console.WriteLine("Type full name of which customer to book on: ");
            string inputUser = Console.ReadLine();
            foreach (var User in Database.Users)
            {
                if (inputUser == User.Name)
                {
                    thisUser = User;
                }
            }
            return thisUser;
        }

        public static Discipline ChooseTypeOfLesson()
        {
            Console.WriteLine("Choose type of lesson: ");
            var values = Enum.GetValues(typeof(Discipline));
            List<string> strList = new List<string>();
            foreach (var value in values)
            {
                strList.Add(Convert.ToString(value));
            }
            for (int i = 0; i < strList.Count; i++)
            {
                Console.WriteLine("[" + (i + 1) + "] " + strList[i]);
            }
            var inputDiscipline = Discipline.AlpineSki;
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    inputDiscipline = Discipline.AlpineSki;
                    break;
                case 2:
                    inputDiscipline = Discipline.AlpineSnowboard;
                    break;
                case 3:
                    inputDiscipline = Discipline.Crosscountry;
                    break;
                case 4:
                    inputDiscipline = Discipline.Sitski;
                    break;
            }
            return inputDiscipline;
        }

        private static void AdminRemoveBooking()
        {
            AdminCustomerMethods.WriteAllCustomers();
            Console.WriteLine("On which customer would you like to remove a booking? Write full name of customer: ");
            string strInput = Console.ReadLine();
            foreach (var User in Database.Users)
            {
                if(strInput == User.Name)
                {
                    foreach (var booking in User.UserBookings)
                    {
                        WriteBooking(booking);
                    }
                    Console.WriteLine("Type booking number of booking you would like to remove: ");
                    int intInput = Convert.ToInt32(Console.ReadLine());
                    foreach (var booking in User.UserBookings)
                    {
                        if (intInput == booking.BookingNumber)
                        {
                            User.UserBookings.Remove(booking);
                            Database.Bookings.Remove(booking);
                            break;
                        }
                    }
                }
            }
        }

        private static void AdminEditBooking()
        {
            AdminCustomerMethods.WriteAllCustomers();
            Console.WriteLine("On which customer would you like to edit a booking? Write full name of customer: ");
            string strInput = Console.ReadLine();
            foreach (var User in Database.Users)
            {
                if (strInput == User.Name)
                {
                    foreach (var booking in User.UserBookings)
                    {
                        WriteBooking(booking);
                    }
                    Console.WriteLine("Type booking number of booking you would like to edit: ");
                    int intInput = Convert.ToInt32(Console.ReadLine());
                    foreach (var booking in User.UserBookings)
                    {
                        if (intInput == booking.BookingNumber)
                        {
                            Console.WriteLine("What would you like to change?");
                            Console.WriteLine("[1] User booked on.");
                            Console.WriteLine("[2] Student name.");
                            Console.WriteLine("[3] Instructor, type of lesson or when.");
                            int intInput2 = Convert.ToInt32(Console.ReadLine());
                            switch (intInput2)
                            {
                                case 1:
                                    booking.BookedBy = PlaceBookingOnCustomer();
                                    break;
                                case 2:
                                    Console.WriteLine("What is the name of the student: ");
                                    booking.StudentName = Console.ReadLine();
                                    break;
                                case 3:
                                    var inputDiscipline = ChooseTypeOfLesson();

                                    var inputLevel = ChooseLevelOfLesson();

                                    var inputInstructor = ChooseInstructorForLesson(inputDiscipline, inputLevel);

                                    var inputDay = ChooseDayForLesson();

                                    var inputTime = ChooseTimeForLesson(inputInstructor, inputDay);

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
        public static void WriteBooking(Booking booking)
        {
            Console.Write("Booking number: " + booking.BookingNumber + "\n");
            Console.Write("Booked by: " + booking.BookedBy.Name + ", ");
            Console.Write("student name: " + booking.StudentName + ", ");
            Console.Write("instructor name: " + booking.Instructor.Name + "\n");
            Console.Write("When: " + booking.Day + " at ");
            if (booking.TimeOfLesson == TimeOfLesson.FirstLesson)
            {
                Console.Write("09:00");
            }
            if (booking.TimeOfLesson == TimeOfLesson.SecondLesson)
            {
                Console.Write("10:30");
            }
            if (booking.TimeOfLesson == TimeOfLesson.ThirdLesson)
            {
                Console.Write("13:15");
            }
            if (booking.TimeOfLesson == TimeOfLesson.FourthLesson)
            {
                Console.Write("15:00");
            }
            Console.Write(".");
            Console.Write("\n");
            Console.Write("Lesson type: " + booking.Discipline + " " + booking.Level);
            Console.Write("\n");
        }
    }
}
