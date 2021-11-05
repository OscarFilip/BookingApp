using BokningApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningApp
{
    public static class Database
    {
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Instructor> Instructors { get; set; } = new List<Instructor>();
        public static List<Booking> Bookings { get; set; } = new List<Booking>();
        public static User ActiveUser { get; set; }

        static Database()
        {
            AddTestdata();
        }

        private static void AddTestdata()
        {
            Users.Add(new User("Admin", true));
            Users.Add(new User("Marie Svensson", false));
            Users.Add(new User("Martin Skog", false));
            Users.Add(new User("Karl Von Linne", false));
            Users.Add(new User("Sven Berg", false));

            Instructors.Add(new Instructor("Markus Johansson", Level.Examined, Level.NoLevel, Level.LevelOne, Level.LevelTwo));
            Instructors.Add(new Instructor("Mads Madsen", Level.LevelFour, Level.LevelFour, Level.LevelOne, Level.NoLevel));
            Instructors.Add(new Instructor("Julia Berg", Level.LevelTwo, Level.LevelTwo, Level.NoLevel, Level.NoLevel));
            Instructors.Add(new Instructor("Therese Svan", Level.LevelThree, Level.NoLevel, Level.NoLevel, Level.NoLevel));
            Instructors.Add(new Instructor("Pär Sten", Level.LevelTwo, Level.NoLevel, Level.Examined, Level.Examined));

            Bookings.Add(new Booking(Users[1], "Nils", Instructors[0], Day.Monday, TimeOfLesson.FirstLesson, Discipline.AlpineSki, Level.LevelOne));
            Users[1].UserBookings.Add(new Booking(Users[1], "Nils", Instructors[0], Day.Monday, TimeOfLesson.FirstLesson, Discipline.AlpineSki, Level.LevelOne));
        }
    }
}
