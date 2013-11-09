using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Students.Models;
using Students.Repositories;
using Students.WebServices.Models;

namespace Students.WebServices.Controllers
{
    public class StudentsController : ApiController
    {
        private IRepository<Student> studentsRepository;

        public StudentsController(IRepository<Student> studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }


        public IEnumerable<StudentModel> GetAll()
        {
            var studentEntities = this.studentsRepository.All();

            var studentModels =
                    from studentEntity in studentEntities
                    select new StudentModel()
                    {
                        Id = studentEntity.Id,
                        FirstName = studentEntity.FirstName,
                        LastName = studentEntity.LastName,
                        Age = studentEntity.Age,
                        Grade = studentEntity.Grade,
                        SchoolId = studentEntity.School.Id
                    };
            return studentModels.ToList();
        }

        public StudentDetails GetSingle(int id)
        {
            var entity = this.studentsRepository.Get(id);
            var model = new StudentDetails()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Grade = entity.Grade,
                SchoolId = entity.SchoolId,
                Marks = (from mark in entity.Marks
                         select new MarkModel()
                         {
                             Subject = mark.Subject,
                             Value = mark.Value
                         }
                        ).ToList()
            };

            return model;
        }

        public HttpResponseMessage PostStudents(StudentDetails model)
        {
            List<Mark> newMarks = new List<Mark>();
            foreach (var mark in model.Marks)
            {
                var markEntity = new Mark()
                {
                    Subject = mark.Subject,
                    Value = mark.Value
                };

                newMarks.Add(markEntity);

            }
           
            var entityToAdd = new Student()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Grade = model.Grade,
                SchoolId = model.SchoolId,
                Marks = newMarks
            };
            var createdEntity = this.studentsRepository.Add(entityToAdd);

            var createdModel = new StudentDetails()
            {
                Id = createdEntity.Id,
                FirstName = createdEntity.FirstName,
                LastName = createdEntity.LastName,
                Grade = createdEntity.Grade,
                Age = createdEntity.Age,
                SchoolId = createdEntity.SchoolId
            };

            

            var response = Request.CreateResponse<StudentDetails>(HttpStatusCode.Created, createdModel);
            var resourceLink = Url.Link("DefaultApi", new { id = createdModel.Id });

            response.Headers.Location = new Uri(resourceLink);
            return response;
        }

        //api/students?subject=math&value=5
        public IQueryable<StudentModel> GetBySubject(string subject, int value)
        {
            var studentEntities = this.studentsRepository.All();

           
            var model =
                (from entity in studentEntities
                where entity.Marks.Any(x=>x.Subject==subject && x.Value==value)
                select new StudentModel()
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Age = entity.Age,
                    Grade = entity.Grade,
                    SchoolId = entity.SchoolId,
                  // Marks = (from mark in entity.Marks
                  //          select new MarkModel()
                  //          {
                  //              Subject = mark.Subject,
                  //              Value = mark.Value
                  //          })
               });

            return model;
        }
    }
}
