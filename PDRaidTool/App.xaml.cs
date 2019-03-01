using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PDRaidTool.ViewModels;
using PDRaidTool.ViewModels.Interfaces;
using Unity;

namespace PDRaidTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IMainViewModel, MainViewModel>();



            var mainViewModel = container.Resolve<MainViewModel>();
            var window = new MainWindow { DataContext = mainViewModel };
            window.Show();
        }
    }
}
