using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hospital.Authentication;
using Hospital.Wpf.IoC;

namespace Hospital.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour AuthenticationWindow.xaml
    /// </summary>
    public partial class AuthenticationWindow : Window
    {
        public AuthenticationWindow()
        {
            InitializeComponent();
        }

        private void Connecter(object sender, RoutedEventArgs e)
        {
            var window = InjectContainer.ResolveView<MainWindow>() as Window;

            if (AuthenticationService.Login(Login.Text, Password.Password))
            {
                window.Show();
                Close();
            }
            else
            {
                Error.Text = "Login ou mot de passe incorrect !";
            }
        }
    }
}
