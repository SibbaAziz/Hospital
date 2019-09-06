using Hospital.Wpf.ViewModels;
using Unity;

namespace Hospital.Wpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow
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
