using System;
using System.Collections.Generic;
using Moq;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.Models;
using RepoQuiz.DAL;

namespace RepoQuiz.Tests.DAL
{
    [TestClass]
    public class NameGeneratorTests
    {
        [TestMethod]
        public void EnsureInstanceofNameGenerator()
        {
            NameGenerator nameGen = new NameGenerator();
            Assert.IsNotNull(nameGen);
        }
        [TestMethod]
        public void EnsureListFirstNameAccess()
        {
            NameGenerator firstName = new NameGenerator();
            string actualName = firstName.FirstNameCollection[0];
            string expectedName = "Ace";
            Assert.AreEqual(expectedName, actualName);
        }
        [TestMethod]
        public void EnsureListLastNameAccess()
        {
            NameGenerator lastName = new NameGenerator();
            string actualName = lastName.LastNameCollection[0];
            string expectedName = "Argonian";
            Assert.AreEqual(expectedName, actualName);
        }
        [TestMethod]
        public void EnsureMajorAccess()
        {
            NameGenerator major = new NameGenerator();
            string actualMajor = major.MajorCollection[0];
            string expectedMajor = "Underwater Basket Weaving";
            Assert.AreEqual(expectedMajor, actualMajor);
        }
        [TestMethod]
        public void EnsureGetRandomNameFromListWithMethod()
        {
            NameGenerator randomLastName = new NameGenerator();
            string actualName = randomLastName.GetRandomLastName();
            string expectedName = randomLastName.GetRandomLastName();
            Console.WriteLine(actualName);
            Console.WriteLine(expectedName);
            //Once namepool array has all names, the chance that both vars will have the same output is very slim, but it is still possible this test may fail. Ideally, expected and actual name will be different instances.
            //I'm refactoring this method to remain DRY but keeping the old method and this test
            Assert.AreNotEqual(expectedName, actualName);
        }
        [TestMethod]
        public void EnsureGetRandomNameOrMajorWorksWithParameterOfList()
        {
            NameGenerator NameGen = new NameGenerator();
            string fname1 = NameGen.GetRandomNameOrMajor(NameGen.FirstNameCollection);
            string fname2 = NameGen.GetRandomNameOrMajor(NameGen.FirstNameCollection);
            Assert.AreNotEqual(fname1, fname2);

            string lname1 = NameGen.GetRandomNameOrMajor(NameGen.LastNameCollection);
            string lname2 = NameGen.GetRandomNameOrMajor(NameGen.LastNameCollection);
            Assert.AreNotEqual(lname1, lname2);

            string major1 = NameGen.GetRandomNameOrMajor(NameGen.MajorCollection);
            string major2 = NameGen.GetRandomNameOrMajor(NameGen.MajorCollection);
            Assert.AreNotEqual(major1, major2);
        }
        [TestMethod]
        public void EnsureCreateStudentReturnsAStudent()
        {
            NameGenerator nameGen = new NameGenerator();
            string[] Student = nameGen.CreateStudentWithMajor();
            Assert.IsTrue(nameGen.FirstNameCollection.Any(Student[0].Contains));
            Assert.IsTrue(nameGen.LastNameCollection.Any(Student[1].Contains));
            Assert.IsTrue(nameGen.MajorCollection.Any(Student[2].Contains));
        }
        [TestMethod]
        public void EnsureCanCreateStudentObjectConstructedByMethod()
        {
            NameGenerator nameGen = new NameGenerator();
            Student newStudent = nameGen.RandomizedStudent();
            Assert.IsInstanceOfType(newStudent, typeof(Student));
            Assert.IsTrue(nameGen.FirstNameCollection.Any(newStudent.FirstName.Contains));
        }
    }
}
