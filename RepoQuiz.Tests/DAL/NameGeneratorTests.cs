using System;
using System.Collections.Generic;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void EnsureGetRandomNameFromListWithMethod()
        {
            NameGenerator randomLastName = new NameGenerator();
            string actualName = randomLastName.GetRandomLastName();
            string expectedName = randomLastName.GetRandomLastName();
            Console.WriteLine(actualName);
            Console.WriteLine(expectedName);
            //Once namepool array has all names, the chance that both vars will have the same output is very slim, but it is still possible this test may fail. Ideally, expected and actual name will be different instances.
            Assert.AreNotEqual(expectedName, actualName);
        }
        [TestMethod]
        public void EnsureGetRandomMethodWorksOnFirstName()
        {
            NameGenerator randomFirstName = new NameGenerator();
            //string firstNameInstance = randomFirstName.GetRandomomFirstName;
        }
    }
}
