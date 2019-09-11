using System.Windows.Controls;
using GalaSoft.MvvmLight;
using Hospital.Wpf.IoC;
using Hospital.Wpf.Views;

namespace Hospital.Wpf.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowModel
    {
        public Control PlanningView => InjectContainer.ResolveView<PlanningView>();
        public Control Employees => InjectContainer.ResolveView<EmployeesView>();
    }

    public interface IMainWindowModel
    {

    }
}
