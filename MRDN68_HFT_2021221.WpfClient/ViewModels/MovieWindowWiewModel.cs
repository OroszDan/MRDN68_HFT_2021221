using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MRDN68_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MRDN68_HFT_2021221.WpfClient.ViewModels
{
    class MovieWindowWiewModel : ObservableRecipient
    {
        public RestCollection<Movie> Movies { get; set; }
        private Movie selectedMovie;

        public Movie SelectedMovie
        {
            get { return selectedMovie; }
            set 
            { //legyen inkább deepcopy

                if (value != null)
                {
                    selectedMovie = new Movie()
                    {
                        DirectorId = value.DirectorId,
                        Name = value.Name,
                        Rating = value.Rating,
                        Id = value.Id,
                        Year = value.Year,
                        Director = value.Director,
                        Showtimes = value.Showtimes
                    };
                    OnPropertyChanged();
                    //SetProperty(ref selectedMovie, value);
                    //(UpdateCommand as RelayCommand).NotifyCanExecuteChanged();
                    
                }

                (DeleteCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ICommand CreateCommand { get; set; }
        public ICommand ReadCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand Exit { get; set; }
        public MovieWindowWiewModel()
        {
           // SelectedMovie = new Movie();
            if (!IsInDesignMode)
            {
                Movies = new RestCollection<Movie>("http://localhost:65512/", "movie", "hub");

                CreateCommand = new RelayCommand(
                    () =>
                    {
                        Movies.Add(new Movie()
                        {
                            Name=SelectedMovie.Name,
                            Rating = SelectedMovie.Rating,
                            Year = SelectedMovie.Year,
                            DirectorId = SelectedMovie.DirectorId
                        });
                    }
                    );

                DeleteCommand = new RelayCommand(
                    () =>
                    {
                        Movies.Delete(selectedMovie.Id);
                    },
                    () =>
                    selectedMovie != null
                    );

                UpdateCommand = new RelayCommand(
                    () =>
                    {
                        Movies.Update(selectedMovie); //buggy
                    });

                SelectedMovie = new Movie();
            }
            
        }
    }
}
