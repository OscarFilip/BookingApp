using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningApp
{
    public interface IDatabase
    {
        List<User> Users { get; set; }
        List<Instructor> Instructors { get; set; }
        List<Booking> Bookings { get; set; }
        User ActiveUser { get; set; }
    }
}
