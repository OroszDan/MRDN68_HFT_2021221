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
    class ShowtimeWindowViewModel : ObservableRecipient
    {
        public RestCollection<Showtime> Showtimes { get; set; }
        private Showtime selectedShowtime;

        public Showtime SelectedShowtime
        {
            get { return selectedShowtime; }
            set
            { //legyen inkább deepcopy

                if (value != null)
                {
                    selectedShowtime = new Showtime()
                    {
                        MovieId = value.MovieId,
                        CinemaName = value.CinemaName,
                         City = value.City,
                        Id = value.Id,
                         DateTime = value.DateTime,
                         Movie = value.Movie,
                         Room = value.Room
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
        public ICommand ExitCommand { get; set; }
        public ShowtimeWindowViewModel()
        {
            // SelectedMovie = new Movie();
            if (!IsInDesignMode)
            {
                Showtimes = new RestCollection<Showtime>("http://localhost:65512/", "showtime", "hub");

                CreateCommand = new RelayCommand(
                    () =>
                    {
                        Showtimes.Add(new Showtime()
                        {
                            CinemaName = SelectedShowtime.CinemaName,
                            Room = SelectedShowtime.Room,
                            City = SelectedShowtime.City,
                            MovieId = SelectedShowtime.MovieId,
                            DateTime = SelectedShowtime.DateTime
                             
                        });
                    }
                    );

                DeleteCommand = new RelayCommand(
                    () =>
                    {
                        Showtimes.Delete(selectedShowtime.Id);
                    },
                    () =>
                    selectedShowtime != null
                    );

                UpdateCommand = new RelayCommand(
                    () =>
                    {
                        Showtimes.Update(selectedShowtime); 
                    });

                ExitCommand = new RelayCommand(() => Application.Current.Shutdown());

                SelectedShowtime = new Showtime();
            }

        }
    }
}

