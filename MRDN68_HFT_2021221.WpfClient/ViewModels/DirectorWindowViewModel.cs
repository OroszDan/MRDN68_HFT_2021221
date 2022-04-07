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
    class DirectorWindowViewModel : ObservableRecipient
    {
        public RestCollection<Director> Directors { get; set; }
        private Director selectedDirector;

        public Director SelectedDirector
        {
            get { return selectedDirector; }
            set
            { //legyen inkább deepcopy

                if (value != null)
                {
                    selectedDirector = new Director()
                    {
                         BirthYear = value.BirthYear,
                        Name = value.Name                     
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
        public DirectorWindowViewModel()
        {
            // SelectedMovie = new Movie();
            if (!IsInDesignMode)
            {
                Directors = new RestCollection<Director>("http://localhost:65512/", "director", "hub");

                CreateCommand = new RelayCommand(
                    () =>
                    {
                        Directors.Add(new Director()
                        {
                            Name = SelectedDirector.Name,
                            BirthYear = SelectedDirector.BirthYear
                        });
                    }
                    );

                DeleteCommand = new RelayCommand(
                    () =>
                    {
                        Directors.Delete(selectedDirector.Id);
                    },
                    () =>
                    selectedDirector != null
                    );

                UpdateCommand = new RelayCommand(
                    () =>
                    {
                        Directors.Update(selectedDirector); //buggy
                    });

                SelectedDirector = new Director();
            }

        }
    }
}

