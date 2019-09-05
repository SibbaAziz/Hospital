using Hospital.Wpf.ViewModels;
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
        public IMainWindowModel Repository
        {
            set => DataContext = value;
        }
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
