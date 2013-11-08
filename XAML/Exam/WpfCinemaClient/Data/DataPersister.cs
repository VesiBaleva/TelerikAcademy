using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaReserve.ResponseModels;
using WpfCinemaClient.ViewModels;
using System.Net.Mail;

namespace WpfCinemaClient.ViewModels
{
    public class DataPersister
    {
        protected static string AccessToken { get; set; }

        private const string BaseServicesUrl = "http://localhost:50971/api/";

        internal static IEnumerable<CinemaViewModel> GetCinemas()
        {
            var cinemaModel = HttpRequester.Get<IEnumerable<CinemaModel>>(BaseServicesUrl + "cinemas");
            return cinemaModel.
                AsQueryable().
                 Select(model => new CinemaViewModel()
                 {
                     Id = model.Id,
                     Name = model.Name
                 });
        }

        internal static IEnumerable<MovieModel> GetMoviesByCinema(int cinemaId)
        {
            var movieModel = HttpRequester.Get<IEnumerable<MovieModel>>(BaseServicesUrl + "cinemas/" + cinemaId);
            return movieModel.
                AsQueryable().
                 Select(model => new MovieModel()
                 {
                     Id = model.Id,
                     Title = model.Title
                 });
        }

        internal static IEnumerable<ProjectionModel> GetProjections(int cinemaId, int movieId)
        {
            var projectionsModel = HttpRequester.Get<IEnumerable<ProjectionModel>>(BaseServicesUrl + "cinemas/" + cinemaId + "/projections/" + movieId);
            return projectionsModel.AsQueryable().Select(model => new ProjectionModel()
            {
                Id = model.Id,
                Time = model.Time,
                Movie = new MovieModel()
                {
                    Id = model.Movie.Id,
                    Title = model.Movie.Title
                },
                Cinema = new CinemaModel()
                {
                    Id = model.Cinema.Id,
                    Name = model.Cinema.Name
                }
            });
        }


        internal static IEnumerable<MovieModel> GetMovies()
        {
            var movieModel = HttpRequester.Get<IEnumerable<MovieModel>>(BaseServicesUrl + "movies");
            return movieModel.
                AsQueryable().
                 Select(model => new MovieModel()
                 {
                     Id = model.Id,
                     Title = model.Title
                 });
        }

        internal static IEnumerable<MovieDetailsModel> GetMovieDetails(int movieId)
        {
            var movieDetailsModel = HttpRequester.Get<IEnumerable<MovieDetailsModel>>(BaseServicesUrl + "movies/" + movieId);
            return movieDetailsModel.AsQueryable()
                .Select(model => new MovieDetailsModel()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    Actors = model.Actors,
                    Projections = model.Projections.AsQueryable().Select(proj => new ProjectionModel()
                    {
                        Id = proj.Id,
                        Time = proj.Time,
                        Movie = new MovieModel()
                        {
                            Id = proj.Movie.Id,
                            Title = proj.Movie.Title
                        },
                        Cinema = new CinemaModel()
                        {
                            Id = proj.Cinema.Id,
                            Name = proj.Cinema.Name
                        }
                    })
                });
        }

        internal static IEnumerable<MovieModel> GetMoviesByKeyword(string search)
        {
            var moviesModel = HttpRequester.Get<IEnumerable<MovieModel>>(BaseServicesUrl + "movies?keyword=" + search.ToLower());
            return moviesModel.AsQueryable().Select(model => new MovieModel()
            {
                Id = model.Id,
                Title = model.Title
            });
        }

        internal static IEnumerable<ProjectionDetailsModel> GetProjectionDetails(int projectionId)
        {
            var projectionDetailsModel = HttpRequester.Get<IEnumerable<ProjectionDetailsModel>>(BaseServicesUrl + "projections/" + projectionId);
            return projectionDetailsModel.AsQueryable().Select(model => new ProjectionDetailsModel()
                {
                    Id = model.Id,
                    Time = model.Time,
                    Movie = new MovieModel()
                    {
                        Id = model.Movie.Id,
                        Title = model.Movie.Title
                    },
                    Seats = model.Seats.AsQueryable().Select(seat => new SeatModel()
                    {
                         Row = seat.Row,
                         Column = seat.Column,
                         Status = seat.Status
                    })
                });
        }

        internal static void MakeReservation(int projectionId, string email, IEnumerable<SeatViewModel> seats)
        {
            try
            {
                new MailAddress(email);
            }
            catch (FormatException ex)
            {
                throw new FormatException("Email is invalid", ex);
            }

            var reservationModel = new CreateReservationModel()
            {
               
                Email = email,
                Seats = seats.Select(t => new SeatModel()
                {                      
                    Column = t.Column,
                    Row = t.Row
                })

            };

        }

        internal static void ChangeState(int projId)
        {
            HttpRequester.Put(BaseServicesUrl + "projections/" + projId);
        }

        //internal static void RegisterUser(string username, string email, string authenticationCode)
        //{
        //    //Validation!!!!!
        //    //validate username
        //    //validate email
        //    //validate authentication code
        //    //use validation from WebAPI
        //    //var userModel = new UserModel()
        //    //{
        //    //    Username = username,
        //    //    Email = email,
        //    //    AuthCode = authenticationCode
        //    //};
        //    //HttpRequester.Post(BaseServicesUrl + "users/register",
        //    //    userModel);
        //}

        //internal static string LoginUser(string username, string authenticationCode)
        //{
        //    //Validation!!!!!
        //    //validate username
        //    //validate email
        //    //validate authentication code
        //    //use validation from WebAPI
        //    //var userModel = new UserModel()
        //    //{
        //    //    Username = username,
        //    //    AuthCode = authenticationCode
        //    //};
        //    //var loginResponse = HttpRequester.Post<LoginResponseModel>(BaseServicesUrl + "auth/token",
        //    //    userModel);
        //    //AccessToken = loginResponse.AccessToken;
        //    //return loginResponse.Username;
        //}

        //internal static bool LogoutUser()
        //{
        //    //var headers = new Dictionary<string, string>();
        //    //headers["X-accessToken"] = AccessToken;
        //    //var isLogoutSuccessful = HttpRequester.Put(BaseServicesUrl + "users/logout", headers);
        //    //return isLogoutSuccessful;
        //}

        //internal static void CreateNewTodosList(string title, IEnumerable<TodoViewModel> todos)
        //{
        //    //var listModel = new TodolistModel()
        //    //{
        //    //    Title = title,
        //    //    Todos = todos.Select(t => new TodoModel()
        //    //    {
        //    //        Text = t.Text
        //    //    })
        //    //};

        //    //var headers = new Dictionary<string, string>();
        //    //headers["X-accessToken"] = AccessToken;

        //    //var response =
        //    //    HttpRequester.Post<ListCreatedModel>(BaseServicesUrl + "lists", listModel, headers);
        //}

        //internal static IEnumerable<TodoListViewModel> GetTodoLists()
        //{
        //    //var headers = new Dictionary<string, string>();
        //    //headers["X-accessToken"] = AccessToken;

        //    //var todoListsModels =
        //    //    HttpRequester.Get<IEnumerable<TodolistModel>>(BaseServicesUrl + "lists", headers);
        //    //return todoListsModels.
        //    //    AsQueryable().
        //    //     Select(model => new TodoListViewModel()
        //    //      {
        //    //          Id = model.Id,
        //    //          Title = model.Title,
        //    //          Todos = model.Todos.AsQueryable().Select(todo => new TodoViewModel()
        //    //          {
        //    //              Id = todo.Id,
        //    //              Text = todo.Text,
        //    //              IsDone = todo.IsDone
        //    //          })
        //    //      });
        //}

        //internal static void ChangeState(int todoId)
        //{
        //    //var headers = new Dictionary<string, string>();
        //    //headers["X-accessToken"] = AccessToken;

        //    //HttpRequester.Put(BaseServicesUrl + "todos/" + todoId, headers);
        //}
    }
}