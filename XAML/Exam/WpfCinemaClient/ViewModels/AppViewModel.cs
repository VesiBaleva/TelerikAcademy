using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfCinemaClient.ViewModels
{
    public class AppViewModel:ViewModelBase
    {
        private ICommand changeViewModelCommand;

        private IPageViewModel currentViewModel;

        public IPageViewModel CurrentViewModel
        {
            get
            {
                return this.currentViewModel;
            }
            set
            {
                this.currentViewModel = value;
                this.OnPropertyChanged("CurrentViewModel");
            }
        }

        public CinemasListViewModel cinemasVM { get; set; }

        public List<IPageViewModel> ViewModels { get; set; }

        public ICommand ChangeViewModel
        {
            get
            {
                if (this.changeViewModelCommand == null)
                {
                    this.changeViewModelCommand =
                        new RelayCommand(this.HandleChangeViewModelCommand);
                }
                return this.changeViewModelCommand;
            }
        }

        private void HandleChangeViewModelCommand(object parameter)
        {
            var newCurrentViewModel = parameter as IPageViewModel;
            this.CurrentViewModel = newCurrentViewModel;
        }

        public AppViewModel()
        {
            this.ViewModels = new List<IPageViewModel>();
            this.ViewModels.Add(new CinemasListViewModel());
            var cinemasVM = new CinemasListViewModel();
          //  loginVM.LoginSuccess += this.LoginSuccessful;
            this.cinemasVM = cinemasVM;
            this.CurrentViewModel = this.cinemasVM;
        }
    }
}
