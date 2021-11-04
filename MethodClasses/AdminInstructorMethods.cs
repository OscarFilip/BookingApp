using BokningApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningApp
{
    public class AdminInstructorMethods
    {
        public static void HandleInstructorsMenu(IDatabase database)
        {
            bool runLoop = true;
            while (runLoop)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] Add instructor.");
                Console.WriteLine("[2] Remove Instructor.");
                Console.WriteLine("[3] Edit Instructor.");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        AddInstructor(database);
                        break;
                    case 2:
                        RemoveInstructor(database);
                        break;
                    case 3:
                        EditInstructor(database);
                        break;
                }
            }
        }



        private static void AddInstructor(IDatabase database)
        {
            Console.WriteLine("Name of Instructor: ");
            string name = Console.ReadLine();
            Console.WriteLine("Choose level of alpine ski discipline:");
            Level alpineSkiLevel = AddDisciplineToIntructor();
            Console.WriteLine("Choose level of alpine snowboard discipline:");
            Level alpineSnowboardLevel = AddDisciplineToIntructor();
            Console.WriteLine("Choose level of crosscountry discipline:");
            Level crosscountryLevel = AddDisciplineToIntructor();
            Console.WriteLine("Choose level of sitski discipline:");
            Level sitskiLevel = AddDisciplineToIntructor();
            database.Instructors.Add(new Instructor(name, alpineSkiLevel, alpineSnowboardLevel, crosscountryLevel, sitskiLevel));
        }

        private static Level AddDisciplineToIntructor()
        {
            Console.WriteLine("[0] No level.");
            Console.WriteLine("[1] Level one.");
            Console.WriteLine("[2] Level two.");
            Console.WriteLine("[3] Level three.");
            Console.WriteLine("[4] Level four.");
            Console.WriteLine("[5] Examined.");
            int input = Convert.ToInt32(Console.ReadLine());
            Level inputLevel = Level.NoLevel;
            switch (input)
            {
                case 0:
                    inputLevel = Level.NoLevel;
                    break;
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
                case 5:
                    inputLevel = Level.Examined;
                    break;
            }
            return inputLevel;
        }
        private static void RemoveInstructor(IDatabase database)
        {
            WriteAllInstructors(database);
            Console.WriteLine("Write the full name of the instructor you want to remove: ");
            
            string input = Console.ReadLine();
             
            database.Instructors.RemoveAll(Instructor => Instructor.Name == input);
        }
        private static void EditInstructor(IDatabase database)
        {
            WriteAllInstructors(database);
            Console.WriteLine("Write the full name of the instructor you want to Edit: ");
            string strInput = Console.ReadLine();
            foreach (var Instructor in database.Instructors)
            {
                if (Instructor.Name == strInput)
                {
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("[1] Change Name.");
                    Console.WriteLine("[2] Change alpine ski level.");
                    Console.WriteLine("[3] Change alpine snowboard level.");
                    Console.WriteLine("[4] Change crosscountry level.");
                    Console.WriteLine("[5] Change sitski level.");
                    int input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine("Write name: ");
                            Instructor.Name = Console.ReadLine();
                            break;
                        case 2:
                            Instructor.AlpineSkiLevel = AddDisciplineToIntructor();
                            break;
                        case 3:
                            Instructor.AlpineSnowboardLevel = AddDisciplineToIntructor();
                            break;
                        case 4:
                            Instructor.CrosscountryLevel = AddDisciplineToIntructor();
                            break;
                        case 5:
                            Instructor.SitskiLevel = AddDisciplineToIntructor();
                            break;
                    }
                }
            }
        }

        private static void WriteAllInstructors(IDatabase database)
        {
            Console.WriteLine("All Instructors:");
            foreach (var Instructor in database.Instructors)
            {
                Console.Write(Instructor.Name + ", ");
                Console.Write("Alpine ski: " + Instructor.AlpineSkiLevel + ", ");
                Console.Write("Alpine snowboard: " + Instructor.AlpineSnowboardLevel + ", ");
                Console.Write("Crosscountry: " + Instructor.CrosscountryLevel + ", ");
                Console.Write("Sitski: " + Instructor.SitskiLevel);
                Console.Write("\n");
            }
        }
    }
}
