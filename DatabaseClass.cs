using System.Collections.Generic;

namespace BokningApp
{
    public class DatabaseClass : IDatabase
    {
        public List<User> Users { get; set; } = new List<User>();
        public List<Instructor> Instructors { get; set; } = new List<Instructor>();
        public List<Booking> Bookings { get; set; } = new List<Booking>();
        public User ActiveUser { get; set; }

        public DatabaseClass(List<User> users, List<Instructor> instructors, List<Booking> bookings)
        {
            Users = users;
            Instructors = instructors;
            Bookings = bookings;
        }
    }
}
