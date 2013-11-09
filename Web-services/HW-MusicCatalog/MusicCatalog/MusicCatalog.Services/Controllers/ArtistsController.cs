using CodeFirst.Data;
using CodeFirst.Model;
using MusicCatalog.Repositories;
using MusicCatalog.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicCatalog.Services.Controllers
{
    public class ArtistsController : ApiController
    {
        private IRepository<Song> songRepository;
        private IRepository<Album> albumRepository;
        private IRepository<Artist> artistRepository;

        public ArtistsController()
        {
            var dbContext = new MusicCatalogContext();
            this.songRepository = new DBSongsRepository(dbContext);
            this.albumRepository = new DBAlbumsRepository(dbContext);
            this.artistRepository = new DBArtistsRepository(dbContext);
        }

        public ArtistsController(IRepository<Song> repository)
        {
            this.songRepository = repository;
        }

        public ArtistsController(IRepository<Album> repository)
        {
            this.albumRepository = repository;
        }

        public ArtistsController(IRepository<Artist> repository)
        {
            this.artistRepository = repository;
        }

        [HttpGet]
        public IEnumerable<ArtistModel> GetAll()
        {
            var artistEntities = this.artistRepository.All();

            var artistModels =
                from artistEntity in artistEntities
                select new ArtistModel()
                {
                    Id = artistEntity.Id,
                    Name = artistEntity.Name,
                    Country = artistEntity.Country,
                    DateOfBirth = artistEntity.DateOfBirth,
                    AlbumTitle = artistEntity.Album.Title
                };

            return artistModels.ToList();
        }

        [HttpGet]
        public ArtistDetailsModel GetById(int id)
        {
           if (id <= 0)
           {
               var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The artist is invalid");
               throw new HttpResponseException(errResponse);
           }
          
           var entity = this.artistRepository.Get(id);
          
           var model = new ArtistDetailsModel()
           {
               Name = entity.Name,
               Country = entity.Country,
               DateOfBirth = entity.DateOfBirth,
               AlbumName = entity.Album.Title,
               Songs = (from song in entity.Album.Songs
                        select new SongModel()
                        {
                            Id = song.Id,
                            Title = song.Title,
                            Genre = song.Genre,
                            Year = song.Year
                        }).ToList()
           };
           return model;
        }

        [HttpPost]
        public HttpResponseMessage PostArtist(ArtistDetailsModel model)
        {
          if (model == null || model.Name == null )
          {
              var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The name of the Artist should be valid");
              return errResponse;
          }
         
         
          var entityAlbum = this.albumRepository.All().Where(x => x.Title == model.AlbumName).FirstOrDefault();
          
            if (entityAlbum == null)
          {
              return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "This album doesn't exist!");
          }
          
          var entityToAdd = new Artist
          {
              Name = model.Name,
              Country = model.Country,
              DateOfBirth = model.DateOfBirth,
              Album = entityAlbum
          };
         
          var createdEntity = this.artistRepository.Add(entityToAdd);
          
          var createdModel = new ArtistModel()
          {
              Id = createdEntity.Id,
              Name = createdEntity.Name,
              Country = createdEntity.Country,
              DateOfBirth = createdEntity.DateOfBirth
          };
         
          var response = Request.CreateResponse<ArtistModel>(HttpStatusCode.Created, createdModel);
          var resourceLink = Url.Link("DefaultApi", new { Id = createdModel.Id});
          response.Headers.Location = new Uri(resourceLink);      
          return response;
        }

        public HttpResponseMessage DeleteArtist(int id)
        {
            var entity = this.artistRepository.All().Where(x => x.Id == id).FirstOrDefault();

            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var songsEntity = this.songRepository.All().Where(x => x.ArtistId == id).ToList();

            foreach (var item in songsEntity)
            {
                this.songRepository.Delete(item.Id);
            }
                        

            this.artistRepository.Delete(id);

            var response = Request.CreateResponse(HttpStatusCode.OK, "The artist has been succsesfully deleted!");
            return response;

        }

       //
        //GET all


        //GET by Id
        //POST
        //PUT
        //DELETE
    }

    
}
