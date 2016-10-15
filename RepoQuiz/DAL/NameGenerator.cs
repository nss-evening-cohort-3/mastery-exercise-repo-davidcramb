using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepoQuiz.DAL
{
    public class NameGenerator
    {
        // This class should be used to generate random names and Majors for Students.
        // This is NOT your Repository
        // All methods should be Unit Tested :)
        public NameGenerator()
        {
        }
        public List<string> FirstNameCollection { get { return FirstNameArray.ToList(); } }
        public List<string> LastNameCollection { get { return LastNameArray.ToList(); } }

        public string[] FirstNameArray = { "Ace", "Bob", "Charles", "Dennis", "Edward", "Franklin", "Gary", "Harry", "India", "Jill", "Killian", "Lana" };
        public string[] LastNameArray = { "Argonian", "Breton", "Crowley", "Decimalpoint", "Factoid", "Gradius", "Harp", "Iguanadon", "Jernigan", "Kroninberg", "Logoslow" };

 
        public string GetRandomLastName()
        {
            var rnd = RandomHelper.rnd;
            string randomLastName = LastNameCollection[rnd.Next(0, LastNameCollection.Count())];
            return randomLastName;
        }
    }
    class RandomHelper
    {
        public static Random rnd { get; }
        static RandomHelper()
        {
            rnd = new Random();
        }
    }
}