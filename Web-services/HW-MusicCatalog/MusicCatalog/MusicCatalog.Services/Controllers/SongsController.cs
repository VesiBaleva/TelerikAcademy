using CodeFirst.Data;
using CodeFirst.Model;
using MusicCatalog.Repositories;
using MusicCatalog.Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicCatalog.Services.Controllers
{
    public class SongsController : ApiController
    {
        private IRepository<Song> songRepository;
        private IRepository<Album> albumRepository;
        private IRepository<Artist> artistRepository;

        public SongsController()
        {
            var dbContext = new MusicCatalogContext();
            this.songRepository = new DBSongsRepository(dbContext);
            this.albumRepository = new DBAlbumsRepository(dbContext);
            this.artistRepository = new DBArtistsRepository(dbContext);
        }

        public SongsController(IRepository<Song> repository)
        {
            this.songRepository = repository;
        }

        public SongsController(IRepository<Album> repository)
        {
            this.albumRepository = repository;
        }

        public SongsController(IRepository<Artist> repository)
        {
            this.artistRepository = repository;
        }

        [HttpGet]
        public IEnumerable<SongModel> GetAll()
        {
            var songEntities = this.songRepository.All();

            var songModels =
                from songEntity in songEntities
                select new SongModel()
                {
                    Id = songEntity.Id,
                    Title = songEntity.Title,
                    Year = songEntity.Year,
                    Genre = songEntity.Genre
                };

            return songModels.ToList();
        }

        [HttpGet]
        public SongFullModel GetById(int id)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The song is invalid");
                throw new HttpResponseException(errResponse);
            }

            var entity = this.songRepository.Get(id);

            var model = new SongFullModel()
            {
                Id = entity.Id,
                Title = entity.Title,
                Year=entity.Year,
                Genre = entity.Genre,   
                AlbumTitle=entity.Album.Title,
                ArtistName=entity.Artist.Name,
                ArtistDateOfBird = entity.Artist.DateOfBirth
            };
            return model;
        }

        [HttpPost]
        public HttpResponseMessage PostSong(SongDetailsModel model)
        {
            if (model == null || model.Title == null || model.Title.Length < 6)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The title of the Song should be at least 6 characters");
                return errResponse;
            }


            var entityAlbum = this.albumRepository.All().Where(x => x.Title == model.FromAlbum).FirstOrDefault();
            if (entityAlbum == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "This album doesn't exist!");
            }

            var entityArtist = this.artistRepository.All().Where(x => x.Name == model.ArtistName).FirstOrDefault();
            
            if (entityArtist == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "This artist doesn't exist!");
            }        
            
            var entityToAdd = new Song
            {
                Title = model.Title,
                Year = model.Year,
                Genre = model.Genre,
                Album = entityAlbum,
                Artist = entityArtist
            };

            var createdEntity = this.songRepository.Add(entityToAdd);
            
            var createdModel = new SongFullModel()
            {
                Id = createdEntity.Id,
                Title = createdEntity.Title,
                Year = createdEntity.Year,
                Genre = createdEntity.Genre,
                ArtistName = createdEntity.Artist.Name,
                AlbumTitle = createdEntity.Album.Title
            };

            var response = Request.CreateResponse<SongFullModel>(HttpStatusCode.Created, createdModel);
            var resourceLink = Url.Link("DefaultApi", new { Id = createdModel.Id});
            response.Headers.Location = new Uri(resourceLink);      
            return response;
        }

        public HttpResponseMessage DeleteSong(int id)
        {
            var entity = this.songRepository.All().Where(x=>x.Id==id).FirstOrDefault();
            
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            this.songRepository.Delete(id);

            var response = Request.CreateResponse(HttpStatusCode.OK, "The song has been succsesfully deleted!");
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
