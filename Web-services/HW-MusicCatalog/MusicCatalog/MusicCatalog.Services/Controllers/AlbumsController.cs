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
    public class AlbumsController : ApiController
    {
        private IRepository<Album> albumRepository;
        private IRepository<Song> songRepository;
        private IRepository<Artist> artistRepository;

        public AlbumsController()
        {
            var dbContext = new MusicCatalogContext();
            this.albumRepository = new DBAlbumsRepository(dbContext);
            this.songRepository = new DBSongsRepository(dbContext);
            this.artistRepository = new DBArtistsRepository(dbContext);
        }

        public AlbumsController(IRepository<Album> repository)
        {
            this.albumRepository = repository;
        }

        public AlbumsController(IRepository<Artist> repository)
        {
            this.artistRepository = repository;
        }

        public AlbumsController(IRepository<Song> repository)
        {
            this.songRepository = repository;
        }

        [HttpGet]
        public IEnumerable<AlbumModel> GetAll()
        {
            var albumEntities = this.albumRepository.All();

            var albumModels =
                from albumEntity in albumEntities
                select new AlbumModel()
                {
                    Id = albumEntity.Id,
                    Title = albumEntity.Title,
                    Year = albumEntity.Year,
                    Producer = albumEntity.Producer
                };

            return albumModels.ToList();
        }

        [HttpGet]
        public AlbumFullModel GetById(int id)
        {
            if (id <= 0)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The album is invalid");
                throw new HttpResponseException(errResponse);
            }

            var entity = this.albumRepository.Get(id);
            var model = new AlbumFullModel()
            {
                Id = entity.Id,
                Title = entity.Title,
                Songs = (from song in entity.Songs
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
        public HttpResponseMessage PostAlbum(AlbumModel model)
        {
            if (model == null || model.Title == null || model.Title.Length < 6)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The title of the Album should be at least 6 characters");
                return errResponse;
            }

            var entityToAdd = new Album
            {
                Title = model.Title,
                Year = model.Year,
                Producer = model.Producer
            };

            var createdEntity = this.albumRepository.Add(entityToAdd);
            
            var createdModel = new AlbumModel()
            {
                Id = createdEntity.Id,
                Title = createdEntity.Title,
                Year = createdEntity.Year,
                Producer = createdEntity.Producer
            };

            var response = Request.CreateResponse<AlbumModel>(HttpStatusCode.Created, createdModel);
            var resourceLink = Url.Link("DefaultApi", new { Id = createdModel.Id});
            response.Headers.Location = new Uri(resourceLink);      
            return response;
        }

        public HttpResponseMessage DeleteAlbum(int id)
        {
            var entity = this.albumRepository.All().Where(x => x.Id == id).FirstOrDefault();

            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var songsEntity = this.songRepository.All().Where(x=>x.AlbumId==id).ToList();

            foreach (var item in songsEntity)
            {
                this.songRepository.Delete(item.Id);
            }

            var artistsEntity = this.artistRepository.All().Where(x => x.AlbumId == id).ToList();

            foreach (var item in artistsEntity)
            {
                this.artistRepository.Delete(item.Id);
            }

            this.albumRepository.Delete(id);

            var response = Request.CreateResponse(HttpStatusCode.OK, "The album has been succsesfully deleted!");
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
