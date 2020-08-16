using System.Windows;

namespace MedicalInstitution.Views
{
    /// <summary>
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        public AdminMenu()
        {
            InitializeComponent();
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            MainWindow main = new MainWindow();

            main.ShowDialog();
        }
    }
}
