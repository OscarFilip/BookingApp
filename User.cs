using BokningApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningApp
{
    public class User
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public List<Booking> UserBookings { get; set; } = new List<Booking>();
        public User(string name, bool isAdmin)
        {
            Name = name;
            IsAdmin = isAdmin;
        }
        public User()
        {
        }
    }
}
