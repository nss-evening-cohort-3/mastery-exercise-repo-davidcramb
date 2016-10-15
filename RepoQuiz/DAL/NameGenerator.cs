using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoQuiz.Models;

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
        public List<string> MajorCollection { get { return MajorArray.ToList(); } }

        private string[] FirstNameArray = { "Ace", "Bob", "Charles", "Dennis", "Edward", "Franklin", "Gary", "Harry", "India", "Jill", "Killian", "Lana" };
        private string[] LastNameArray = { "Argonian", "Breton", "Crowley", "Decimalpoint", "Factoid", "Gradius", "Harp", "Iguanadon", "Jernigan", "Kroninberg", "Logoslow" };
        private string[] MajorArray = { "Underwater Basket Weaving", "Gendered Glacier Studies", "Horology", "Dairy Herd Management", "Paranormal Extermination", "Xenomorph Diplomacy", "Sophism", "Animal Waste Identification" };
 
                       

        public string GetRandomLastName()
        {
            var rnd = RandomHelper.rnd;
            string randomLastName = LastNameCollection[rnd.Next(0, LastNameCollection.Count())];
            return randomLastName;
        }
        public string GetRandomNameOrMajor(List<string> Collection)
        {
            var rnd = RandomHelper.rnd;
            string randomNameOrMajor = Collection[rnd.Next(0, Collection.Count())];
            return randomNameOrMajor;
        }



        public string[] CreateStudentWithMajor()
        {
            string[] student = new string[3];
            student[0] = GetRandomNameOrMajor(FirstNameCollection);
            student[1] = GetRandomNameOrMajor(LastNameCollection);
            student[2]= GetRandomNameOrMajor(MajorCollection);
            return student;
        }

        public Student RandomizedStudent()
        {
            Student student = new Student();
            string[] randomStudentResult = CreateStudentWithMajor();
            student.FirstName = randomStudentResult[0];
            student.LastName = randomStudentResult[1];
            student.Major = randomStudentResult[2];
            return student;
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