using MedicalInstitution.Command;
using MedicalInstitution.Models;
using MedicalInstitution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedicalInstitution.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        readonly MainWindow mainWindow;

        #region Properties
        private List<tblPatient> patientList;
        public List<tblPatient> PatientList
        {
            get
            {
                return patientList;
            }
            set
            {
                patientList = value;
                OnPropertyChanged("PatientList");
            }
        }

        private tblPatient patient;
        public tblPatient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                patient = value;
                OnPropertyChanged("Patient");
            }
        }
        private bool isUpdatePatient;
        public bool IsUpdatePatient
        {
            get
            {
                return isUpdatePatient;
            }
            set
            {
                isUpdatePatient = value;
            }
        }
        
        private List<tblDoctor> doctorList;
        public List<tblDoctor> DoctorList
        {
            get
            {
                return doctorList;
            }
            set
            {
                doctorList = value;
                OnPropertyChanged("DoctorList");
            }
        }

        private tblDoctor doctor;
        public tblDoctor Doctor
        {
            get
            {
                return doctor;
            }
            set
            {
                doctor = value;
                OnPropertyChanged("Doctor");
            }
        }
        private bool isUpdateDoctor;
        public bool IsUpdateDoctor
        {
            get
            {
                return isUpdateDoctor;
            }
            set
            {
                isUpdateDoctor = value;
            }
        }
        #endregion

        public MainWindowViewModel(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;

            patient = new tblPatient();
            
            Service s = new Service();
            DoctorList = s.GetAllDoctor().ToList();
        }

        private ICommand exit;
        public ICommand Exit
        {
            get
            {
                if (exit == null)
                {
                    exit = new RelayCommand(param => ExitExecute(), param => CanExitExecute());
                }
                return exit;
            }
        }

        /// <summary>
        /// Exit application
        /// </summary>
        private void ExitExecute()
        {
            MessageBoxResult dialog = Xceed.Wpf.Toolkit.MessageBox.Show("Da li želite napustiti aplikaciju?", "Izlaz", MessageBoxButton.YesNo);

            if (dialog == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private bool CanExitExecute()
        {
            return true;
        }

        private ICommand refreshDoctor;
        public ICommand RefreshDoctor
        {
            get
            {
                if (refreshDoctor == null)
                {
                    refreshDoctor = new RelayCommand(param => DoctorCBXExecute(), param => CanDoctorCBXExecute());
                }
                return refreshDoctor;
            }
        }
        private void DoctorCBXExecute()
        {
            mainWindow.cbxDoctor.Text = "";
        }

        private bool CanDoctorCBXExecute()
        {
            if (mainWindow.cbxDoctor.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool PasswordCorrect(string password)
        {
            //password rules 
            int minUpper = 1;
            int minLower = 1;
            int minLength = 8;
            int maxLength = 30;
            string allowedSpecials;

            //entered password
            string enteredPassword = mainWindow.txtLozinkaRegistracija.Text.ToString();

            //get individual characters
            char[] characters = enteredPassword.ToCharArray();

            //checking variables

            int upper = 0;
            int lower = 0;
            int character = 0;
            int number = 0;
            int length = enteredPassword.Length;
            int illegalCharacters = 0;


            //check the entered password
            foreach (char enteredCharacters in characters)
            {
                if (char.IsUpper(enteredCharacters))
                {
                    upper = upper + 1;
                }
                else if (char.IsLower(enteredCharacters))
                {
                    lower = lower + 1;
                }
                else if (char.IsNumber(enteredCharacters))
                {
                    number = number + 1;
                }
                else if (enteredCharacters > 32 && enteredCharacters < 127 && !Char.IsDigit(enteredCharacters) && !Char.IsLetter(enteredCharacters))
                {
                    character = character + 1;
                }
                else
                {
                    illegalCharacters = illegalCharacters + 1;
                }

                // MessageBox.Show(chars.ToString());
            }

            if (upper < minUpper || lower < minLower || length < minLength || length > maxLength)
            {
                //MessageBox.Show("Something's not right, your password does not meet the minimum security criteria");
                return false;
            }
            else
            {
                //code to proceed this step
                return true;

            }
        }

        private ICommand login;
        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    login = new RelayCommand(param => LoginExecute(), param => CanLoginExecute());
                }
                return login;
            }
        }

        /// <summary>
        /// Method for login user
        /// </summary>
        private void LoginExecute()
        {
            
            //string username = mainWindow.NameTextBox.Text;

            //// Hash password
            //var hasher = new SHA256Managed();
            //var unhashed = Encoding.Unicode.GetBytes(mainWindow.passwordBox.Password);
            //var hashed = hasher.ComputeHash(unhashed);
            //var hashedPassword = Convert.ToBase64String(hashed);

            //string password = hashedPassword;

            //Service s = new Service();

            ////Checks if there is a username and password in the database
            //tblGuest userLogin = s.GetUsernamePassword(username, password);

            //if (userLogin != null)
            //{
            //    PrintMessage();

            //    CakeMenu cakeMenu = new CakeMenu
            //    {
            //        Owner = mainWindow
            //    };
            //    mainWindow.Hide();
            //    cakeMenu.ShowDialog();
            //}
            //else
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("Korisničko ime ili lozinka nisu ispravni,\n pokušajte opet.", "Nalog nije pronađen.");
            //}
        }
        

        private bool CanLoginExecute()
        {
            if (Convert.ToBoolean(mainWindow.GenreM.IsChecked) || Convert.ToBoolean(mainWindow.GenreZ.IsChecked) || Convert.ToBoolean(mainWindow.GenreX.IsChecked) || Convert.ToBoolean(mainWindow.GenreN.IsChecked))
            {

                mainWindow.msgPol.Visibility = Visibility.Collapsed;
                return true;
            }
            else if(doctorBool == true )
            {
                return false;
            }
            //else if(PasswordCorrect(mainWindow.txtLozinkaRegistracija.Text.ToString()) == false)
            //{
            //    return false;
            //}
            else
            {
                mainWindow.msgPol.Visibility = Visibility.Visible;
                return false;
            }

            
        }

        public bool doctorBool;

        async void PrintMessage()
        {
            Service s = new Service();
            List<tblDoctor> tblDoctorList = s.GetAllDoctor().ToList();

            if (tblDoctorList.Count < 1)
            {
                await Task.Delay(1000);
                Xceed.Wpf.Toolkit.MessageBox.Show($"Trenutno ne postoji ni jedan lekar u sistemu", "Obaveštenje");
                doctorBool = false;
            }
            else
            {
                doctorBool = true;
            }
        }

        private ICommand newPatient;
        public ICommand NewPatient
        {
            get
            {
                if (newPatient == null)
                {
                    newPatient = new RelayCommand(param => NewPatientExecute(), param => CanNewPatientExecute());
                }
                return newPatient;
            }
        }

        //Return to the login page
        private void NewPatientExecute()
        {
            PrintMessage();
            
        }
        private bool CanNewPatientExecute()
        {
            return true;
        }

        private ICommand backToLogin;
        public ICommand BackToLogin
        {
            get
            {
                if (backToLogin == null)
                {
                    backToLogin = new RelayCommand(param => BackLoginExecute(), param => CanBackLoginExecute());
                }
                return backToLogin;
            }
        }

        //Return to the login page
        private void BackLoginExecute()
        {
            mainWindow.NameTextBox.Text = "";
            mainWindow.passwordBox.Password = "";
            mainWindow.login.Visibility = Visibility.Visible;
            mainWindow.Images0.Visibility = Visibility.Collapsed;
            mainWindow.Images1.Visibility = Visibility.Visible;
            mainWindow.SignUp.Visibility = Visibility.Collapsed;
            mainWindow.tbCapsLock.Visibility = Visibility.Collapsed;
            mainWindow.NameTextBox.Focus();
            mainWindow.txtCitizenship.Text = "";
            mainWindow.txtHealthNumber.Text = "";
            mainWindow.txtIDNumber.Text = "";
            mainWindow.txtIme.Text = "";
            mainWindow.cbxDoctor.Text = "";
            mainWindow.dpDatumRodjenja.Text = "";
            mainWindow.dpExpirationDate.Text = "";
            mainWindow.txtKorisnickoIme.Text = "";
            mainWindow.txtLozinkaRegistracija.Text = "";
            mainWindow.txtReLozinkaRegistracija.Text = "";

            return;
        }
        private bool CanBackLoginExecute()
        {
            return true;
        }

        private ICommand signUp;
        public ICommand SignUp
        {
            get
            {
                if (signUp == null)
                {
                    signUp = new RelayCommand(param => SignUpExecute(), param => CanSignUpExecute());
                }
                return signUp;
            }
        }
        //Create new user
        private void SignUpExecute()
        {
            try
            {

                PasswordCorrect(mainWindow.txtLozinkaRegistracija.Text.ToString());

                Service s = new Service();

                string jmbg = Patient.BLK;
                string AN = Patient.HealthInsuranceCardNumber;
                string user = Patient.UsernameLogin;



                //uniqueness check JMBG
                tblPatient patientJMBG = s.GetPatientBLK(jmbg);

                if (patientJMBG != null)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Korisnik već postoji sa tim Brojem lične karte, pokušajte opet.", "JMBG");
                    return;
                }

                //uniqueness check Health Insurance Card Number
                tblPatient patientAN = s.GetPatientHealthInsuranceCardNumber(AN);

                if (patientAN != null)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Broj zdravstvenog osiguranja već neko koristi, pokušajte sa drugim brojem.", "Broj zdravstvenog osiguranja");
                    return;
                }


                //uniqueness check username
                tblPatient employeeUserPatient = s.GetPatientUsername(user);

                if (employeeUserPatient != null)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Korisničko ime je zauzeto, pokušajte neko drugo.", "Korisničko ime");
                    return;
                }

                // Hash Password
                var hasher = new SHA256Managed();
                var unhashed = Encoding.Unicode.GetBytes(this.Patient.PasswordLogin);
                var hashed = hasher.ComputeHash(unhashed);
                var hashedPassword = Convert.ToBase64String(hashed);

                this.Patient.PasswordLogin = hashedPassword;
                if (mainWindow.cbxDoctor.Text != "")
                {
                    Patient.UniqueNumberDoctor = Convert.ToInt32(Doctor.DoctorID);
                }
                if (Patient.Gender == 0)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Niste izabrali pol.", "Pol pacijenta");
                    return;
                }
                s.AddPatient(Patient);
                IsUpdateDoctor = true;
                mainWindow.NameTextBox.Text = "";
                mainWindow.passwordBox.Password = "";
                mainWindow.login.Visibility = Visibility.Visible;
                mainWindow.Images0.Visibility = Visibility.Collapsed;
                mainWindow.Images1.Visibility = Visibility.Visible;
                mainWindow.SignUp.Visibility = Visibility.Collapsed;

                string poruka = Patient.NameSurname + ",\nUspešno ste se registrovali.";
                Xceed.Wpf.Toolkit.MessageBox.Show(poruka, "Registracija pacijenta", MessageBoxButton.OK);
                mainWindow.NameTextBox.Focus();
                
                mainWindow.txtCitizenship.Text = "";
                mainWindow.txtHealthNumber.Text = "";
                mainWindow.txtIDNumber.Text = "";
                mainWindow.txtIme.Text = "";
                mainWindow.cbxDoctor.Text = "";
                mainWindow.dpDatumRodjenja.Text = "";
                mainWindow.dpExpirationDate.Text = "";
                mainWindow.txtKorisnickoIme.Text = "";
                mainWindow.txtLozinkaRegistracija.Text = "";
                mainWindow.txtReLozinkaRegistracija.Text = "";
                mainWindow.mupper.Visibility = Visibility.Hidden;
                mainWindow.mupperError.Visibility = Visibility.Hidden;
                mainWindow.mlower.Visibility = Visibility.Hidden;
                mainWindow.mlowerError.Visibility = Visibility.Hidden;
                mainWindow.mminCharacter.Visibility = Visibility.Hidden;
                mainWindow.mminCharacterError.Visibility = Visibility.Hidden;
                mainWindow.mspecial.Visibility = Visibility.Hidden;
                mainWindow.mspecialError.Visibility = Visibility.Hidden;
                mainWindow.mnumber.Visibility = Visibility.Hidden;
                mainWindow.mnumberError.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSignUpExecute()
        {
            return true;
        }
    }
}
