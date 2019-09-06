using Hospital.Wpf.IoC;
using Hospital.Wpf.ViewModels;
using Hospital.Wpf.Views;
using MahApps.Metro.Controls;
using Unity;

namespace Hospital.Wpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        [Dependency]
        public IMainWindowModel VieModel
        {
            set => DataContext = value;
        }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
