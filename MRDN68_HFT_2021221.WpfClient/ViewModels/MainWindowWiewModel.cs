using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MRDN68_HFT_2021221.WpfClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MRDN68_HFT_2021221.WpfClient.ViewModels
{
    class MainWindowWiewModel : ObservableRecipient
    {
        IEditorWindowService service;

        public ICommand GetDirectorsCommand { get; set; }
        public ICommand GetMoviesCommand { get; set; }
        public ICommand GetShowtimesCommand { get; set; }
        public ICommand GetQueriesCommand { get; set; }

        public MainWindowWiewModel(IEditorWindowService services)
        {
            this.service = services;
            GetDirectorsCommand = new RelayCommand(
                () => service.EditDirector()
                );
            GetMoviesCommand = new RelayCommand(
                () => service.EditMovie()
                );
            GetShowtimesCommand = new RelayCommand(
                () => service.EditShowtime()
                );
            GetQueriesCommand = new RelayCommand(
                () => service.ShowQueries()
                );
        }

        

    }
}
