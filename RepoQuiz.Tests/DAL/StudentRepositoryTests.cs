using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RepoQuiz.DAL;
using RepoQuiz.Models;
using Moq;
using System.Linq;
using System.Data.Entity;

namespace RepoQuiz.Tests.DAL
{
    [TestClass]
    public class StudentRepositoryTests
    {
        Mock<StudentContext> mock_student_context { get; set; }
        Mock<DbSet<Student>> mock_student_table { get; set; }
        List<Student> student_list { get; set; }
        StudentRepository repo = new StudentRepository();

        public void ConnectMocksToDataStore()
        {
            var queryable_student_table = student_list.AsQueryable();
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(queryable_student_table.Provider);
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(queryable_student_table.Expression);
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(queryable_student_table.ElementType);
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_student_table.GetEnumerator());

            mock_student_context.Setup(c => c.Students).Returns(mock_student_table.Object);
        }
        [TestInitialize]
        public void Initialize()
        {
            mock_student_context = new Mock<StudentContext>();
            mock_student_table = new Mock<DbSet<Student>>();
            student_list = new List<Student>();
            repo = new StudentRepository(mock_student_context.Object);
            NameGenerator nameGen = new NameGenerator();
            ConnectMocksToDataStore();
        }
        [TestCleanup]
        public void TearDown()
        {
            repo = null;
        }

        [TestMethod]
        public void EnsureStudentRepoInstanceOfType()
        {
            Assert.IsNotNull(repo);
        }
        [TestMethod]
        public void EnsureRepoHasContext()
        {
            Assert.IsInstanceOfType(repo.Context, typeof(StudentContext));
        }
        [TestMethod]
        public void EnsureDatabaseIsEmpty()
        {
            //current count of database entities in Students is 15
            int actualCount = repo.GetAllStudents().Count;
            int expectedCount = 15;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [TestMethod]
        public void EnsureCanAddStudent()
        {
            NameGenerator nameGen = new NameGenerator();
            Student Student1 = nameGen.RandomizedStudent();
            repo.AddStudent(Student1);
            int expectedCount = 1;
            int actualCount = repo.GetAllStudents().Count;
            Assert.IsTrue(expectedCount == actualCount);
        }
    }
}
