using CinemaReserve.ResponseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCinemaClient.ViewModels
{
    public class ProjectionsViewModel : ViewModelBase, IPageViewModel
    {
        
        public string Name
        {
            get { return "Projections View"; }
        }


        private ObservableCollection<ProjectionViewModel> projectionsLists;

        public IEnumerable<ProjectionViewModel> ProjectionsList
        {
            get
            {
                if (this.projectionsLists == null)
                {
                    //TODO:
                    var cinemaId=1;
                    var movieId=10;
                    this.ProjectionsList = DataPersister.GetProjections(cinemaId,movieId);
                }
                return this.projectionsLists;
            }
            set
            {
                if (this.projectionsLists == null)
                {
                    this.projectionsLists = new ObservableCollection<ProjectionViewModel>();
                }
                this.projectionsLists.Clear();
                foreach (var item in value)
                {
                    this.projectionsLists.Add(item);
                }
            }
        }

    }
}
