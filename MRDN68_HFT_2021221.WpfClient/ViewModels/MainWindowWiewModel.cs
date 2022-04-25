using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using MRDN68_HFT_2021221.WpfClient.Services;
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
    class MainWindowWiewModel : ObservableRecipient
    {
        IEditorWindowService service;

        public ICommand GetDirectorsCommand { get; set; }
        public ICommand GetMoviesCommand { get; set; }
        public ICommand GetShowtimesCommand { get; set; }
        public ICommand GetQueriesCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowWiewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IEditorWindowService>())
        {

        }

        public MainWindowWiewModel(IEditorWindowService windowservice)
        {
            this.service = windowservice;
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
