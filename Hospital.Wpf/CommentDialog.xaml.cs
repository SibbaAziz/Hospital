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

namespace Hospital.Wpf
{
    /// <summary>
    /// Logique d'interaction pour CommentDialog.xaml
    /// </summary>
    public partial class CommentDialog : Window
    {
        public CommentDialog(string name, string job)
        {
            InitializeComponent();
            Name.Text = $"{name} - ";
            Job.Text = $"{job}";
        }

        public string Comment => CommentTb.Text;

        private void Add(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
