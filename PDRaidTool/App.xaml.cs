using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PDRaidTool.UI;
using PDRaidTool.Utilities;
using PDRaidTool.Utilities.Interfaces;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);  
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IMainViewModel, MainWindow>();
            container.RegisterType<IMainViewModel, MainViewModel>();

            container.RegisterType<IPreferenceFinder, PreferenceCalculation>();
            container.RegisterType<IDataAccess, DataAccess>();

            container.Resolve<MainWindow>().Show();
        }
    }
}
