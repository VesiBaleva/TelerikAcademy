using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Linq;

namespace WPFImageGallery
{
    public class AlbumViewModel:INotifyPropertyChanged
    {
        private ImageViewModel currentImage;

        private ICommand prevCommand;
        private ICommand nextCommand;

        public ObservableCollection<ImageViewModel> images;

        public string Title { get; set; }

        public ImageViewModel CurrentImage
        {
            get
            {
                var view = CollectionViewSource.GetDefaultView(this.Images);
                this.currentImage = view.CurrentItem as ImageViewModel;
                return this.currentImage;
            }
            set
            {
                this.currentImage = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("CurrentImage"));
                }
            }
        }

        public IEnumerable<ImageViewModel> ImagesEnumerable { get; set; }

        public ObservableCollection<ImageViewModel> Images
        {
            get
            {
                if (this.images == null)
                {
                    this.images = new ObservableCollection<ImageViewModel>();
                    foreach (var image in ImagesEnumerable)
                    {
                        this.images.Add(image);
                    }
                }
                return this.images;
            }
        }

        public AlbumViewModel()
        {
        }

        private void HandleExecutePrevCommand(object obj)
        {
            var view = CollectionViewSource.GetDefaultView(this.Images);
            view.MoveCurrentToPrevious();
            if (view.IsCurrentBeforeFirst)
            {
                view.MoveCurrentToLast();
            }
            this.CurrentImage = view.CurrentItem as ImageViewModel; 
        }
        private void HandleExecuteNextCommand(object obj)
        {
            var view = CollectionViewSource.GetDefaultView(this.Images);
            view.MoveCurrentToNext();
            if (view.IsCurrentAfterLast)
            {
                view.MoveCurrentToFirst();
            }
            this.CurrentImage = view.CurrentItem as ImageViewModel; 
        }
        

        public static Expression<Func<XElement, AlbumViewModel>> FromXElement
        {
            get
            {
                return element =>
                    new AlbumViewModel()
                    {
                        Title = element.Element("title").Value,
                        ImagesEnumerable = from image in element.Elements("image")
                                 select new ImageViewModel()
                        {
                            Title = image.Element("title").Value,
                            ImagePath =image.Element("image").Value
                        }
                    };
            }
        }

        public ICommand Prev
        {
            get
            {
                if (this.prevCommand == null)
                {
                    this.prevCommand = new RelayCommand(
                        this.HandleExecutePrevCommand);
                }
                return this.prevCommand;
            }
        }

        public ICommand Next
        {
            get
            {
                if (this.nextCommand == null)
                {
                    this.nextCommand = new RelayCommand(
                        this.HandleExecuteNextCommand);
                }
                return this.nextCommand;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        
    }
}
