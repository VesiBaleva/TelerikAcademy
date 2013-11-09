using Students.Models;
using Students.Repositories;
using Students.WebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Students.WebServices.Controllers
{
    public class SchoolController : ApiController
    {
        private IRepository<School> schoolsRepository;

        public SchoolController(IRepository<School> schoolsRepository)
        {
            this.schoolsRepository = schoolsRepository;
        }

        public IEnumerable<SchoolModel> GetAll()
        {
            var schoolEntities = this.schoolsRepository.All();

            var schoolModels =
                    from schoolEntity in schoolEntities
                    select new SchoolModel()
                    {
                        Id = schoolEntity.Id,
                        SchoolName = schoolEntity.Name,
                        Location = schoolEntity.Location
                    };

            return schoolModels.ToList();
        }

        public SchoolDetails GetSingle(int id)
        {
            var entity = this.schoolsRepository.Get(id);
            var model = new SchoolDetails()
            {
                Id = entity.Id,
                Name = entity.Name,
                Location = entity.Location,
                Students = ( from student in entity.Students
                            select new StudentDetails()
                            {
                                Id = student.Id,
                                FirstName = student.FirstName,
                                LastName = student.LastName,
                                Grade = student.Grade,
                                Age = student.Age
                            }).ToList()               
            };

            return model;
        }

        public HttpResponseMessage PostSchool(SchoolModel model)
        {
            var entityToAdd = new School()
            {
                Name = model.SchoolName,
                Location = model.Location
            };

            var createdEntity = this.schoolsRepository.Add(entityToAdd);


            var createdModel = new SchoolModel()
            {
                Id = createdEntity.Id,
                SchoolName = createdEntity.Name,
                Location = createdEntity.Location
            };

            var response = Request.CreateResponse<SchoolModel>(HttpStatusCode.Created, createdModel);
            var resourceLink = Url.Link("DefaultApi", new { id = createdModel.Id });

            response.Headers.Location = new Uri(resourceLink);
            return response;
        }
    }
}
