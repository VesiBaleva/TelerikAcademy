using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfPhoneStores
{
    public class StoreViewModel:ViewModelBase
    {
        private string name;

        private ObservableCollection<PhoneViewModel> phonesViewModels;

        private ObservableCollection<OperatingSystemViewModel> operationalSystems;

        private StoreViewModel newStoreViewModel;

        //public StoreViewModel()
        //{            
        //    this.newPhoneViewModel = new PhoneViewModel();
        //}

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.OnPropertyChanged("name");
            }
        }

        
      //  public StoreViewModel NewStore
      //  {
      //      get
      //      {
      //          return this.newStoreViewModel;
      //      }
      //      set
      //      {
      //          this.newStoreViewModel = value;
      //          this.OnPropertyChanged("NewStore");
      //      }
      //  }
      //
        public IEnumerable<PhoneViewModel> Phones
        {
            get
            {
                return phonesViewModels;
            }
            set
            {
                if (this.phonesViewModels == null)
                {
                    this.phonesViewModels = new ObservableCollection<PhoneViewModel>();
                }
                this.phonesViewModels.Clear();
                foreach (var item in value)
                {
                    this.phonesViewModels.Add(item);
                }
            }
        }

        public IEnumerable<OperatingSystemViewModel> OperationalSystems
        {
            get
            {
                return this.operationalSystems;
            }
            set
            {
                if (this.operationalSystems == null)
                {
                    this.operationalSystems = new ObservableCollection<OperatingSystemViewModel>();
                }
                this.operationalSystems.Clear();
                foreach (var item in value)
                {
                    this.operationalSystems.Add(item);
                }
            }
        }

    }
}
