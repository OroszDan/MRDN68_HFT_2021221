using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using MRDN68_HFT_2021221.WpfClient.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MRDN68_HFT_2021221.WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddSingleton<IEditorWindowService, EditorWindowService>()
                //.AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
                //.AddSingleton<ITrooperEditorService, TrooperEditorViaWindow>()
                .BuildServiceProvider());
        }
    }
}
