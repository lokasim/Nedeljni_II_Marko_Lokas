using MedicalInstitution.ViewModel;
using System.Windows;
using System.Windows.Markup;

namespace MedicalInstitution.Views
{
    /// <summary>
    /// Interaction logic for PatientMenu.xaml
    /// </summary>
    public partial class PatientMenu : Window
    {
        public PatientMenu()
        {
            InitializeComponent();
            this.DataContext = new PatientMenuViewModel(this);
            this.Language = XmlLanguage.GetLanguage("sr-SR");
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            MainWindow main = new MainWindow();

            main.ShowDialog();
        }
    }
}
