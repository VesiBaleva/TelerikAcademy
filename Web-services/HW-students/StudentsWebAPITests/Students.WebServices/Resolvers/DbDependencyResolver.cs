using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Students.DataLayer;
using Students.Repositories;
using Students.Models;
using Students.WebServices.Controllers;

namespace Students.WebServices.Resolvers
{
    public class DbDependencyResolver : IDependencyResolver
    {
        private static DbContext studentsContext = new StudentsContext();

        private static IRepository<Student> repositoryStudent = new DbStudentRepository(studentsContext);

        private static IRepository<School> repositorySchool = new DbSchoolRepository(studentsContext);

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(repositoryStudent);
            }
            else if (serviceType == typeof(SchoolController))
            {
                return new SchoolController(repositorySchool);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}