using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Students.Repositories;
using Students.Models;
using Students.DataLayer;
using System.Transactions;
using System.Data.Entity;
using System.Linq;

namespace Students.Repositories.Tests
{
    [TestClass]
    public class StudentsRepositoryTests
    {
        private TransactionScope scope;
        private DbContext dbContext;
        private IRepository<Student> repository;
        private int schoolId;

        public StudentsRepositoryTests()
        {
            this.dbContext = new StudentsContext();
            this.repository = new DbStudentRepository(dbContext);
        }

        [TestInitialize]
        public void TestInit()
        {
            scope = new TransactionScope();            
        }

        [TestCleanup]
        public void TestTearDown()
        {
            scope.Dispose();
        }

        [TestMethod]
        public void MyTestMethod2()
        {
            var stud = new Student()
            {
                FirstName = "Tesss Ime First",
                LastName = "tessst Ime Last",
                Age = 65,
                Grade = 4,
                SchoolId=1
            };
            
            dbContext.Set<Student>().Add(stud);
            dbContext.SaveChanges();
            Assert.IsTrue(stud.Id > 0);
        }

        [TestMethod]
        public void Add_WhenNameIsValid_ShouldAddStudentToDatabase()
        {
            
            var newStudent = new Student()
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                Age = 25,
                Grade = 4,
                SchoolId = 1
            };

            var createdStudent = this.repository.Add(newStudent);
            var foundStudent = this.dbContext.Set<Student>().Find(createdStudent.Id);
            Assert.IsNotNull(foundStudent);
            Assert.AreEqual(newStudent.FirstName, foundStudent.FirstName);
        }

        [TestMethod]
        public void All_WhenStudentDataIsValid()
        {
            var student1 = new Student()
            {
                FirstName = "Andrew",
                LastName = "Fuller",
                Age = 29,
                Grade = 4,
                SchoolId = 1
            };

            var student2 = new Student()
            {
                FirstName = "Robert",
                LastName = "King",
                Age = 20,
                Grade = 1,
                SchoolId = 1
            };

            int oldStudentsCount = this.dbContext.Set<Student>().Count();

            this.repository.Add(student1);
            this.repository.Add(student2);

            var studentsFound = this.repository.All();

            Assert.AreEqual(oldStudentsCount + 2, studentsFound.Count());
            Assert.IsTrue(studentsFound.Any(s => s.Id == student1.Id));
            Assert.IsTrue(studentsFound.Any(s => s.Id == student2.Id));
        }

    }
}
