using Newtonsoft.Json;
using System.IO;

namespace BokningApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseClass oldData = JsonConvert.DeserializeObject<DatabaseClass>(File.ReadAllText(@"c:\Repos\BookingApp\Database.json"));
            Database.Users = oldData?.Users ?? Database.Users;
            Database.Instructors = oldData?.Instructors ?? Database.Instructors;
            Database.Bookings = oldData?.Bookings ?? Database.Bookings;

            bool runLoop = true;
            while (runLoop)
            {
                MenuMethods.Login();
                MenuMethods.RunMenu();
                runLoop = false;
            }
            var options = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented,
            };
            var db = new DatabaseClass(Database.Users, Database.Instructors, Database.Bookings);
            string newData = JsonConvert.SerializeObject(db, options);
            File.WriteAllText(@"c:\Repos\BookingApp\Database.json", newData);
        }
    }
}
//To do list:
// - Robust kod. Tänka på de olika scenarion som ej får ske och
// hantera dessa. T.ex. ska det inte gå att ta bort en giraff
// om det finns en bokning på den.
// - Cancel funktion på alla menyer.
// - Felhantering
//
