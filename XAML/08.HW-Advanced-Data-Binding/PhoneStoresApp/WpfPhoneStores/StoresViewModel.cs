using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfPhoneStores
{
    public class StoresViewModel : ViewModelBase
    {
        private ICommand addNewCommand;

        private ICommand addNewPhoneCommand;

        private ObservableCollection<StoreViewModel> stores;

        private string name;
        
        public string StoresDocumentPath { get; set; }

        private StoreViewModel newStoreViewModel;


        public StoresViewModel()
        {
            this.Phones = new ObservableCollection<PhoneViewModel>();
            this.Phones.Add(new PhoneViewModel()
            {
                
            });
            this.newStoreViewModel = new StoreViewModel();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }

        public ObservableCollection<PhoneViewModel> Phones { get; set; }

        public IEnumerable<StoreViewModel> Stores
        {
            get
            {
                if (this.stores == null)
                {
                    this.Stores = DataPersister.GetStores("..\\..\\stores.xml");
                }
                return this.stores;
            }
            set
            {
                if (this.stores == null)
                {
                    this.stores = new ObservableCollection<StoreViewModel>();
                }
                this.stores.Clear();
                foreach (var item in value)
                {
                    this.stores.Add(item);
                }
            }
        }

        public ICommand AddNewPhone
        {
            get
            {
                if (this.addNewPhoneCommand == null)
                {
                    this.addNewPhoneCommand = new RelayCommand(this.HandleAddNewPhoneCommand);
                }
                return this.addNewPhoneCommand;
            }
        }

        public ICommand AddNew
        {
            get
            {
                if (this.addNewCommand == null)
                {
                    this.addNewCommand = new RelayCommand(this.HandleAddNewCommand);
                }
                return this.addNewCommand;
            }
        }

        

        private void HandleAddNewPhoneCommand(object parameter)
        {
            this.Phones.Add(new PhoneViewModel());
        }
                

        private void HandleAddNewCommand(object parameter)
        {
            try
            {
                DataPersister.AddStore("..\\..\\stores.xml", this.Name,this.Phones.Where(ph=>!String.IsNullOrEmpty(ph.Vendor)));
                this.Stores = DataPersister.GetStores("..\\..\\stores.xml");
                this.NewStore = new StoreViewModel();
                this.Phones.Clear();

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error has occured!");
            }

        }

        


        // public StoresViewModel()
        // {
        //     this.StoresDocumentPath = "..\\..\\stores.xml";
        //     this.newStoreViewModel = new StoreViewModel();
        // }
        //
        // public ICommand AddNew
        // {
        //     get
        //     {
        //         if (this.addNewCommand == null)
        //         {
        //             this.addNewCommand = new RelayCommand(this.HandleAddNewCommand);
        //         }
        //         return this.addNewCommand;
        //     }
        // }
        //
        public StoreViewModel NewStore
        {
            get
            {
                return this.newStoreViewModel;
            }
            set
            {
                this.newStoreViewModel = value;
                this.OnPropertyChanged("NewStore");
            }
        }
        //
        // public string SuccessMessage
        // {
        //     get
        //     {
        //         return this.successMessage;
        //     }
        //     set
        //     {
        //         this.successMessage = value;
        //         this.OnPropertyChanged("SuccessMessage");
        //     }
        // }
        //
        // public string ErrorMessage
        // {
        //     get
        //     {
        //         return this.errorMessage;
        //     }
        //     set
        //     {
        //         this.errorMessage = value;
        //         this.OnPropertyChanged("ErrorMessage");
        //     }
        // }
        //
        // public IEnumerable<PhoneViewModel> Phones
        // {
        //     get
        //     {
        //         if (this.phonesViewModels == null)
        //         {
        //             this.Phones = DataPersister.GetPhones(PhonesStoreDocumentPath);
        //         }
        //         return phonesViewModels;
        //     }
        //     set
        //     {
        //         if (this.phonesViewModels == null)
        //         {
        //             this.phonesViewModels = new ObservableCollection<PhoneViewModel>();
        //         }
        //         this.phonesViewModels.Clear();
        //         foreach (var item in value)
        //         {
        //             this.phonesViewModels.Add(item);
        //         }
        //     }
        // }
        //
        // 
        //
        // private void HandleAddNewCommand(object obj)
        // {
        //     try
        //     {
        //         DataPersister.AddStore(this.StoresDocumentPath, this.NewStore);
        //         this.Stores = DataPersister.GetStores(this.StoresDocumentPath);
        //         this.SetSuccessMessage(string.Format("{0} {1} successfully added!", this.NewStore.Name));
        //         this.NewStore = new StoreViewModel();
        //     }
        //     catch (Exception ex)
        //     {
        //         this.SetErrorMessage(string.Format("Adding {0} {1} failed with exception {2} ", this.NewStore.Name, ex.Message));
        //     }
        // }
        //
        // private void SetSuccessMessage(string text)
        // {
        //     this.SuccessMessage = text;
        //     var timer = new DispatcherTimer();
        //     timer.Tick += (snd, args) =>
        //     {
        //         this.SuccessMessage = "";
        //         timer.Stop();
        //     };
        //     timer.Interval = TimeSpan.FromSeconds(2);
        //     timer.Start();
        // }
        //
        // private void SetErrorMessage(string text)
        // {
        //     this.SuccessMessage = text;
        //     var timer = new DispatcherTimer();
        //     timer.Tick += (snd, args) =>
        //     {
        //         this.SuccessMessage = "";
        //         timer.Stop();
        //     };
        //     timer.Interval = TimeSpan.FromSeconds(2);
        //     timer.Start();
        // }

        
    }
}
