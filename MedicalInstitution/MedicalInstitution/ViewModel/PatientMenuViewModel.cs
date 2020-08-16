using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicalInstitution.Command;
using MedicalInstitution.Views;

namespace MedicalInstitution.ViewModel
{
    class PatientMenuViewModel : ViewModelBase
    {
        readonly PatientMenu patientMenu;

        public PatientMenuViewModel(PatientMenu patientMenu)
        {
            this.patientMenu = patientMenu;
        }

        private ICommand review;
        public ICommand Review
        {
            get
            {
                if (review == null)
                {
                    review = new RelayCommand(param => ReviewExecute(), param => CanReviewExecute());
                }
                return review;
            }
        }

        private async void ReviewExecute()
        {
            patientMenu.progress.Value = 0;
            patientMenu.ReviewResult.Visibility = System.Windows.Visibility.Visible;
            patientMenu.ResultStack.Visibility = System.Windows.Visibility.Collapsed;
            for (int i = 0; i < 100; i++)
            {
                patientMenu.btnPrijavi.IsEnabled = false;
                patientMenu.progress.Value++;
                await Task.Delay(50);
                if (i < 20)
                {
                    patientMenu.loading.Text = "5".ToString();
                }
                else if (i < 40)
                {
                    patientMenu.loading.Text = "4".ToString();
                }
                else if (i < 60)
                {
                    patientMenu.loading.Text = "3".ToString();
                }
                else if (i < 80)
                {
                    patientMenu.loading.Text = "2".ToString();
                }
                else if (i < 99)
                {
                    patientMenu.loading.Text = "1".ToString();
                }
                else
                {
                    patientMenu.loading.Text = "Rezultati su gotovi".ToString();
                }
            }
            patientMenu.btnPrijavi.IsEnabled = true;
            patientMenu.ResultStack.Visibility = System.Windows.Visibility.Visible;
            Random rnd = new Random();
            int randomNum = rnd.Next(0, 2);
            if (randomNum == 1)
            {
                patientMenu.resultTest.Text = "Pozitivan test";
            }
            else
            {
                patientMenu.resultTest.Text = "Negativan test";
            }
        }
        private bool CanReviewExecute()
        {
            return true;
        }
    }
}
