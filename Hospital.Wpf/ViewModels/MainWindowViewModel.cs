using System.Windows.Controls;
using GalaSoft.MvvmLight;
using Hospital.Wpf.IoC;
using Hospital.Wpf.Views;

namespace Hospital.Wpf.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowModel
    {
        public UserControl PlanningView => InjectContainer.ResolveView<PlanningView>();
    }

    public interface IMainWindowModel
    {

    }
}
