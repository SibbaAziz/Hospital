using System.Windows;

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
