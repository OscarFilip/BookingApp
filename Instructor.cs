using BokningApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningApp
{
    public class Instructor
    {
        public string Name { get; set; }
        public Level AlpineSkiLevel { get; set; }
        public Level AlpineSnowboardLevel { get; set; }
        public Level CrosscountryLevel { get; set; }
        public Level SitskiLevel { get; set; }

        public Instructor(string name, Level alpineSkiLevel, Level alpineSnowboardLevel, Level crosscountrylevel, Level sitskiLevel)
        {
            Name = name;
            AlpineSkiLevel = alpineSkiLevel;
            AlpineSnowboardLevel = alpineSnowboardLevel;
            CrosscountryLevel = crosscountrylevel;
            SitskiLevel = sitskiLevel;
        }
        public Instructor()
        {

        }
    }
}
