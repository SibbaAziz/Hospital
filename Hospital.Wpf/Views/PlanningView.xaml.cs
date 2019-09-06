using System.ComponentModel;
using System.Reflection;
using System.Windows.Controls;
using Hospital.Core.Repository;
using Hospital.Wpf.ViewModels;
using Unity;

namespace Hospital.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour PlanningView.xaml
    /// </summary>
    public partial class PlanningView : UserControl
    {
        [Dependency]
        public PlanningViewModel ViewModel
        {
            set => DataContext = value;
        }

        public PlanningView()
        {
            InitializeComponent();
        }
    }
}
