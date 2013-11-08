using CinemaReserve.ResponseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WpfCinemaClient.Helpers;

namespace WpfCinemaClient.ViewModels
{
    public class CinemasListViewModel : ViewModelBase, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Cinemas list";
            }
        }

        private ICommand navigateToCinemaCommand;

        private ObservableCollection<CinemaViewModel> cinemasLists;

        public IEnumerable<CinemaViewModel> CinemasList
        {
            get
            {
                if (this.cinemasLists == null)
                {
                    this.CinemasList = DataPersister.GetCinemas();
                }
                return this.cinemasLists;
            }
            set
            {
                if (this.cinemasLists == null)
                {
                    this.cinemasLists = new ObservableCollection<CinemaViewModel>();
                }
                this.cinemasLists.Clear();
                foreach (var item in value)
                {
                    this.cinemasLists.Add(item);
                }
            }
        }

        public ICommand NavigateToCinemaCommand
        {
            get
            {
                if (this.navigateToCinemaCommand == null)
                {
                    this.navigateToCinemaCommand = new RelayCommand(this.HandleNavigateToCinemaCommand);
                }

                return this.navigateToCinemaCommand;
            }
        }

        public MovieModel SelectedCinema { get; set; }

        private void HandleNavigateToCinemaCommand(object parameter)
        {
            if (SelectedCinema == null)
            {
                return;
            }



            var newVM = new MoviesListViewModel()
            {
            //    //RecipeName = this.SelectedRecipe.Name,
            //    //Products = this.SelectedRecipe.Products,
            //    //CookingSteps = this.SelectedRecipe.CookingSteps,
            //    //ImagePath = this.SelectedRecipe.ImagePath,
            //    //Comments = new CommentsListViewModel()
            //    //{
            //    //    CommentsList = DataPersister.GetComments(this.SelectedRecipe.Id),
            //    //    RecipeId = this.SelectedRecipe.Id
            //    //}
            };


          //  var moviesList = DataPersister.GetMoviesByCinema(

            this.RaiseMoviesNavigate(newVM);
        }

        public event EventHandler<MoviesNavigateArgs> MoviesNavigate;

        private void RaiseMoviesNavigate(MoviesListViewModel vm)
        {
            //if (this.MoviesNavigate != null)
            //{
                this.MoviesNavigate(this, new MoviesNavigateArgs(vm));
            //}
        }

        public CinemasListViewModel()
        {            
            
        }
    }
}
