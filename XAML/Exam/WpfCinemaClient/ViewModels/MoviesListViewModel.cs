using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfCinemaClient.Helpers;

namespace WpfCinemaClient.ViewModels
{
    public class MoviesListViewModel:ViewModelBase,IPageViewModel
    {
        
        public string Name
        {
            get {return "Movies in selected cinema"; }
        }

        private ICommand navigateToProjectionsCommand;

        private ObservableCollection<CinemaViewModel> moviesLists;

        public IEnumerable<CinemaViewModel> CinemasList
        {
            get
            {
                if (this.moviesLists == null)
                {
                    this.CinemasList = DataPersister.GetCinemas();
                }
                return this.moviesLists;
            }
            set
            {
                if (this.moviesLists == null)
                {
                    this.moviesLists = new ObservableCollection<CinemaViewModel>();
                }
                this.moviesLists.Clear();
                foreach (var item in value)
                {
                    this.moviesLists.Add(item);
                }
            }
        }

        public ICommand NavigateToProjectionsCommand
        {
            get
            {
                if (this.navigateToProjectionsCommand == null)
                {
                    this.navigateToProjectionsCommand = new RelayCommand(this.HandleNavigateToProjectionsCommand);
                }

                return this.navigateToProjectionsCommand;
            }
        }

        public MovieViewModel SelectedMovie { get; set; }

        private void HandleNavigateToProjectionsCommand(object parameter)
        {
            if (SelectedMovie == null)
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

            this.RaiseProjectionsNavigate(newVM);
        }

        public event EventHandler<ProjectionsNavigateArgs> ProjectionsNavigate;

        private void RaiseProjectionsNavigate(MoviesListViewModel vm)
        {
            //if (this.MoviesNavigate != null)
            //{
                this.ProjectionsNavigate(this, new ProjectionsNavigateArgs(vm));
            //}
        }

        public MoviesListViewModel()
        {            
            
        }
    }
}
