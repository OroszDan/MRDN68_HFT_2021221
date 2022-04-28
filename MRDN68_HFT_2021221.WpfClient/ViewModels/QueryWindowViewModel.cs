using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using MRDN68_HFT_2021221.Models;
using MRDN68_HFT_2021221.WpfClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MRDN68_HFT_2021221.WpfClient.ViewModels
{
    class QueryWindowViewModel : ObservableRecipient
    {
        public RestService service { get; set; }
        public List<KeyValuePair<string, int>> Query1
        {
            get
            {
                return service.Get<KeyValuePair<string, int>>("moviestat/getquery1");
            }
        }

        public List<AgeRating> Query2
        {
            get
            {
                return service.Get<AgeRating>("showtimestat/getquery2");
            }
        }

        public List<string> Query3
        {
            get
            {
                return service.Get<string>("showtimestat/getquery3");
            }
        }

        public List<string> Query4
        {
            get
            {
                return service.Get<string>("showtimestat/getquery4");
            }
        }

        public List<DateTime> Query5
        {
            get
            {
                return service.Get<DateTime>("showtimestat/getquery5");
            }
        }

        public ICommand ExitCommand { get; set; }
        //public ICommand GetShowtimesCommand { get; set; }
        //public ICommand GetQueriesCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        //public QueryWindowViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IEditorWindowService>())
        //{

        //}

        public QueryWindowViewModel()
        {

            service = new RestService("http://localhost:65512/");

            ExitCommand = new RelayCommand(() => Application.Current.Shutdown());

            //GetQuery1 = new RelayCommand(
            //    () => service.EditDirector()
            //    );
            //GetMoviesCommand = new RelayCommand(
            //    () => service.EditMovie()
            //    );
            //GetShowtimesCommand = new RelayCommand(
            //    () => service.EditShowtime()
            //    );
            //GetQueriesCommand = new RelayCommand(
            //    () => service.ShowQueries()
            //    );
        }
    }
}
