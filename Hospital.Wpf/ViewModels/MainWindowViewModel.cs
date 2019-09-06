using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Hospital.Core.Models;
using Hospital.Core.Repository;
using Hospital.Wpf.Controls;
using Hospital.Wpf.IoC;
using Hospital.Wpf.Views;

namespace Hospital.Wpf.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowModel
    {
        public UserControl PlanningView => InjectContainer.ResolveView(typeof(PlanningView));
    }

    public interface IMainWindowModel
    {

    }
}
