using System.Windows;
using Hospital.Caching;
using Hospital.Core.Repository;
using Hospital.Data.Repositories;
using Hospital.Wpf.IoC;
using Hospital.Wpf.ViewModels;
using Hospital.Wpf.Views;
using Unity;

namespace Hospital.Wpf
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var unity = new UnityContainer();
            unity.RegisterType<IRepository, MemoryRepository>();
            CacheContext.SetRepository(unity.Resolve<IRepository>());
            unity.RegisterType<IMainWindowModel, MainWindowViewModel>();

            InjectContainer.RegisterView<PlanningView>(unity.Resolve<PlanningView>());
            InjectContainer.RegisterView<ListOfEmployeesView>(unity.Resolve<ListOfEmployeesView>());
            InjectContainer.RegisterView<AddEmployeeView>(unity.Resolve<AddEmployeeView>());
            InjectContainer.RegisterView<EmployeesView>(unity.Resolve<EmployeesView>());
            InjectContainer.RegisterView<MainWindow>(unity.Resolve<MainWindow>());
            
            var mainWindow = unity.Resolve<AuthenticationWindow>(); // Creating Main window

            mainWindow.Show();
        }
    }
}
