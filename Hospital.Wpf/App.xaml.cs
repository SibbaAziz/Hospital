using System.Windows;
using Hospital.Core.Repository;
using Hospital.Data.Repositories;
using Hospital.Wpf.ViewModels;
using Unity;

namespace Hospital.Wpf
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var unity = new UnityContainer();
            unity.RegisterType<IRepository, MemoryRepository>();
            unity.RegisterType<IMainWindowModel, MainWindowViewModel>();
            var mainWindow = unity.Resolve<MainWindow>(); // Creating Main window

            mainWindow.Show();
        }
    }
}
