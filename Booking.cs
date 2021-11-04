using BokningApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningApp
{
    public class Booking
    {
        public int BookingNumber { get; set; }
        public User BookedBy { get; set; }
        public string StudentName { get; set; }
        public Instructor Instructor { get; set; }
        public Day Day { get; set; }
        public TimeOfLesson TimeOfLesson { get; set; }
        public Discipline Discipline { get; set; }
        public Level Level { get; set; }

        public Booking(User bookedBy, string studentName, Instructor instructor, Day day, TimeOfLesson timeOfLesson, Discipline discipline, Level level)
        {
            Random rnd = new Random();
            BookingNumber = rnd.Next(100, 999);
            BookedBy = bookedBy;
            StudentName = studentName;
            Instructor = instructor;
            Day = day;
            TimeOfLesson = timeOfLesson;
            Discipline = discipline;
            Level = level;

        }
    }
}
