using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RepoQuiz.DAL;
namespace RepoQuiz.Tests.DAL
{
    [TestClass]
    public class StudentRepositoryTests
    {
        [TestMethod]
        public void EnsureStudentRepoInstanceOfType()
        {
            StudentRepository repo = new StudentRepository();
            Assert.IsNotNull(repo);
        }
    }
}
