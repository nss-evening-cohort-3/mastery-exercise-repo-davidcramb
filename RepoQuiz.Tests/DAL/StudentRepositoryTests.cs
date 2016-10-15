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
        List<Student> student_list;
        public void ConnectMocksToDataStore()
        {
            var queryable_student_table = student_list.AsQueryable();
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(queryable_student_table.Provider);
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(queryable_student_table.Expression);
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(queryable_student_table.ElementType);
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_student_table.GetEnumerator());

            mock_student_context.Setup(c => c.Students).Returns(mock_student_table.Object);
        }

        [TestMethod]
        public void EnsureStudentRepoInstanceOfType()
        {
            StudentRepository repo = new StudentRepository();
            Assert.IsNotNull(repo);
        }
        [TestMethod]
        public void EnsureRepoHasContext()
        {
            StudentRepository repo = new StudentRepository();
            Assert.IsInstanceOfType(repo.Context, typeof(StudentContext));
        }
        [TestMethod]
        public void EnsureCanRetrieveListOfStudents()
        {
            StudentRepository repo = new StudentRepository();
            //current count of database entities in Students is 15
            int actualCount = repo.GetAllStudents().Count;
            int expectedCount = 15;
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
