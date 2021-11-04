using BokningApp.Enums;
using System;
using System.Collections.Generic;

namespace BokningApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();




            bool runLoop = true;
            while (runLoop)
            {
                MenuMethods.Login(database);
                MenuMethods.RunMenu(database);
            }
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
