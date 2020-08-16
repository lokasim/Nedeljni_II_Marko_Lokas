using MedicalInstitution.ViewModel;
using System;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace MedicalInstitution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool imeBool;
        public bool citizenshipBool;
        public bool korisnickoBool;
        public bool lozinkaBool;
        public bool reLozinkaBool;
        public bool idNumberBool;
        public bool datumBool;
        public bool datumExprBool;
        public bool IDNumberBool;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(this);
            this.Language = XmlLanguage.GetLanguage("sr-SR");
            NameTextBox.Focus();
            SignUp.Visibility = Visibility.Collapsed;
            Images1.Visibility = Visibility.Visible;
        }

        public bool korisnik;
        public bool lozinka;

        private void KorekcijaImena(object sender, TextChangedEventArgs e)
        {
            if (NameTextBox.Text.Length <= 5)
            {
                NameTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                NameTextBox.Foreground = new SolidColorBrush(Colors.Red);
                korisnik = false;
            }
            else
            {
                NameTextBox.BorderBrush = new SolidColorBrush(Colors.Green);
                NameTextBox.Foreground = new SolidColorBrush(Colors.Black);
                korisnik = true;
            }
            Prijavi();
        }

        private void KorekcijaLozinke(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Length <= 7)
            {
                passwordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                passwordBox.Foreground = new SolidColorBrush(Colors.Red);
                lozinka = false;
            }
            else
            {
                passwordBox.BorderBrush = new SolidColorBrush(Colors.Green);
                passwordBox.Foreground = new SolidColorBrush(Colors.Black);
                lozinka = true;
            }
            Prijavi();
        }
        private void TxtBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
            if (e.Key == Key.Space)
            {
                SystemSounds.Beep.Play();
            }
        }

        private Boolean TextAllowedVelikaSlova(String s)
        {
            foreach (Char c in s.ToCharArray())
            {
                if (Char.IsLower(c) || Char.IsUpper(c) || Char.IsDigit(c) || Char.IsControl(c))
                {
                    loginFail.Visibility = Visibility.Collapsed;
                    tbCapsLock.Visibility = Visibility.Collapsed;
                    continue;
                }
                else
                {
                    tbCapsLock.Visibility = Visibility.Visible;
                    tbCapsLock.Text = "Dozvoljena su samo slova i brojevi.";
                    SystemSounds.Beep.Play();
                    return false;
                }
            }
            return true;
        }

        //samo mala slova i brojevi
        private void PreviewTextInputHandlerVelika(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextAllowedVelikaSlova(e.Text);
        }
        private void Prijavi()
        {
            if (lozinka == true && korisnik == true)
            {
                btnPrijavi.IsEnabled = true;
            }
            else
            {
                btnPrijavi.IsEnabled = false;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void Ime(object sender, TextChangedEventArgs e)
        {
            if (txtIme.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Text = "Minimum 3 karaktera";
                Hidden();
            }
            if (txtIme.Text.Length <= 2)
            {
                txtIme.BorderBrush = new SolidColorBrush(Colors.Red);
                txtIme.Foreground = new SolidColorBrush(Colors.Red);
                imeBool = false;
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtIme.BorderBrush = new SolidColorBrush(Colors.DeepPink);
                txtIme.Foreground = new SolidColorBrush(Colors.DeepPink);
                imeBool = true;
            }
            txtIme.MaxLength = 50;
            if (txtIme.Text.Length >= txtIme.MaxLength)
            {
                SystemSounds.Beep.Play();
            }
            Registruj();
        }

        private void Citizenship(object sender, TextChangedEventArgs e)
        {
            if (txtCitizenship.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Text = "Minimum 3 karaktera";
                Hidden();
            }
            if (txtCitizenship.Text.Length <= 2)
            {
                txtCitizenship.BorderBrush = new SolidColorBrush(Colors.Red);
                txtCitizenship.Foreground = new SolidColorBrush(Colors.Red);
                citizenshipBool = false;
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtCitizenship.BorderBrush = new SolidColorBrush(Colors.DeepPink);
                txtCitizenship.Foreground = new SolidColorBrush(Colors.DeepPink);
                citizenshipBool = true;
            }
            txtCitizenship.MaxLength = 70;
            if (txtCitizenship.Text.Length >= txtCitizenship.MaxLength)
            {
                SystemSounds.Beep.Play();
            }
            Registruj();
        }

        private void IDNumber(object sender, TextChangedEventArgs e)
        {
            if (txtHealthNumber.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Text = "Broj zdravstvenog  osiguranja\nmora da sadrži minimum 12 cifara";
                Hidden();
            }
            if (txtHealthNumber.Text.Length != 12)
            {
                txtHealthNumber.BorderBrush = new SolidColorBrush(Colors.Red);
                txtHealthNumber.Foreground = new SolidColorBrush(Colors.Red);
                IDNumberBool = false;
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtHealthNumber.BorderBrush = new SolidColorBrush(Colors.DeepPink);
                txtHealthNumber.Foreground = new SolidColorBrush(Colors.DeepPink);
                IDNumberBool = true;
            }
            txtHealthNumber.MaxLength = 12;
            if (txtHealthNumber.Text.Length >= txtHealthNumber.MaxLength)
            {
                SystemSounds.Beep.Play();
            }
            Registruj();
        }

        private void BLK(object sender, TextChangedEventArgs e)
        {
            if (txtIDNumber.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Text = "Broj lične karte mora da sadrži\n minimum 9 cifara";
                Hidden();
            }
            if (txtIDNumber.Text.Length < 9)
            {
                txtIDNumber.BorderBrush = new SolidColorBrush(Colors.Red);
                txtIDNumber.Foreground = new SolidColorBrush(Colors.Red);
                idNumberBool = false;
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtIDNumber.BorderBrush = new SolidColorBrush(Colors.DeepPink);
                txtIDNumber.Foreground = new SolidColorBrush(Colors.DeepPink);
                idNumberBool = true;
            }
            txtIDNumber.MaxLength = 9;
            if (txtIDNumber.Text.Length >= txtIDNumber.MaxLength)
            {
                SystemSounds.Beep.Play();
            }
            Registruj();
        }

        private void Datum(object sender, RoutedEventArgs e)
        {
            datumBool = true;
            //dpDatumRodjenja.BorderBrush = new SolidColorBrush(Color.FromArgb(255, (139), (195), (74)));
            if (dpDatumRodjenja.Text.Length < 7)
            {
                dpDatumRodjenja.BorderBrush = new SolidColorBrush(Colors.Red);
                dpDatumRodjenja.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                dpDatumRodjenja.BorderBrush = new SolidColorBrush(Colors.DeepPink);
                dpDatumRodjenja.Foreground = new SolidColorBrush(Colors.DeepPink);
            }
        }

        private void DatumExpr(object sender, RoutedEventArgs e)
        {
            datumExprBool = true;

            //dpDatumRodjenja.BorderBrush = new SolidColorBrush(Color.FromArgb(255, (139), (195), (74)));
            if (dpDatumRodjenja.Text.Length < 7)
            {
                dpDatumRodjenja.BorderBrush = new SolidColorBrush(Colors.Red);
                dpDatumRodjenja.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                dpDatumRodjenja.BorderBrush = new SolidColorBrush(Colors.DeepPink);
                dpDatumRodjenja.Foreground = new SolidColorBrush(Colors.DeepPink);
            }
        }

        private void Korisnicko(object sender, TextChangedEventArgs e)
        {
            if (txtKorisnickoIme.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Foreground = new SolidColorBrush(Colors.Red);
                tbCapsLock.Text = "Minimum 6 karaktera";
                Hidden();
            }
            if (txtKorisnickoIme.Text.Length <= 5)
            {
                txtKorisnickoIme.BorderBrush = new SolidColorBrush(Colors.Red);
                txtKorisnickoIme.Foreground = new SolidColorBrush(Colors.Red);
                korisnickoBool = false;
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtKorisnickoIme.BorderBrush = new SolidColorBrush(Colors.DeepPink);
                txtKorisnickoIme.Foreground = new SolidColorBrush(Colors.DeepPink);
                korisnickoBool = true;
            }
            txtKorisnickoIme.MaxLength = 30;
            if (txtKorisnickoIme.Text.Length >= txtKorisnickoIme.MaxLength)
            {
                SystemSounds.Beep.Play();
            }
            Registruj();
        }

        private void Lozinka(object sender, TextChangedEventArgs e)
        {
            
            //password rules 
            int minUpper = 1;
            int minLower = 1;
            int minCharacter = 1;
            int minNumber = 1;
            int minLength = 8;
            //entered password
            string enteredPassword = txtLozinkaRegistracija.Text.ToString();

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
            if (upper < minUpper && lower < minLower && length < minLength && character < minCharacter && number < minNumber)
            {
                lozinkaBool = false;
            }
            else
            {
                lozinkaBool = true;
            }

            if (upper < minUpper)
            {
                mupper.Visibility = Visibility.Collapsed;
                mupperError.Visibility = Visibility.Visible;
            }
            else
            {
                mupper.Visibility = Visibility.Visible;
                mupperError.Visibility = Visibility.Collapsed;
            }
            if (lower < minLower)
            {
                mlower.Visibility = Visibility.Collapsed;
                mlowerError.Visibility = Visibility.Visible;
            }
            else
            {
                mlower.Visibility = Visibility.Visible;
                mlowerError.Visibility = Visibility.Collapsed;
            }
            if (length < minLength)
            {
                mminCharacter.Visibility = Visibility.Collapsed;
                mminCharacterError.Visibility = Visibility.Visible;
            }
            else
            {
                mminCharacter.Visibility = Visibility.Visible;
                mminCharacterError.Visibility = Visibility.Collapsed;
            }
            if (character < minCharacter)
            {
                mspecial.Visibility = Visibility.Collapsed;
                mspecialError.Visibility = Visibility.Visible;
            }
            else
            {
                mspecial.Visibility = Visibility.Visible;
                mspecialError.Visibility = Visibility.Collapsed;
            }
            if (number < minNumber)
            {
                mnumber.Visibility = Visibility.Collapsed;
                mnumberError.Visibility = Visibility.Visible;
            }
            else
            {
                mnumber.Visibility = Visibility.Visible;
                mnumberError.Visibility = Visibility.Collapsed;
            }


            if (txtLozinkaRegistracija.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Foreground = new SolidColorBrush(Colors.Red);
                tbCapsLock.Text = "Lozinka mora da sadrži minimum:\n   8 karaktera,\n   jedno malo slovo\n   jedno veliko slovo\n   jedan broj\n   jedan specijalni karakter";
            }
            string lozinka = txtLozinkaRegistracija.Text.ToString();
            string reLozinka = txtReLozinkaRegistracija.Text.ToString();
            if (txtLozinkaRegistracija.Text.Length <= 7)
            {
                txtLozinkaRegistracija.BorderBrush = new SolidColorBrush(Colors.Red);
                txtLozinkaRegistracija.Foreground = new SolidColorBrush(Colors.Red);
                lozinkaBool = false;
            }
            else
            {
                //tbCapsLock.Visibility = Visibility.Collapsed;
                txtLozinkaRegistracija.BorderBrush = new SolidColorBrush(Colors.DeepPink);
                txtLozinkaRegistracija.Foreground = new SolidColorBrush(Colors.DeepPink);
                lozinkaBool = true;
            }

            if (reLozinka != lozinka)
            {
                txtReLozinkaRegistracija.BorderBrush = new SolidColorBrush(Colors.Red);
                txtReLozinkaRegistracija.Foreground = new SolidColorBrush(Colors.Red);
                reLozinkaBool = false;
                Registruj();
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtReLozinkaRegistracija.BorderBrush = new SolidColorBrush(Colors.DeepPink);
                txtReLozinkaRegistracija.Foreground = new SolidColorBrush(Colors.DeepPink);
                reLozinkaBool = true;
                Registruj();
            }

            Registruj();
        }
        public void Hidden()
        {
            mupper.Visibility = Visibility.Hidden;
            mupperError.Visibility = Visibility.Hidden;
            mlower.Visibility = Visibility.Hidden;
            mlowerError.Visibility = Visibility.Hidden;
            mminCharacter.Visibility = Visibility.Hidden;
            mminCharacterError.Visibility = Visibility.Hidden;
            mspecial.Visibility = Visibility.Hidden;
            mspecialError.Visibility = Visibility.Hidden;
            mnumber.Visibility = Visibility.Hidden;
            mnumberError.Visibility = Visibility.Hidden;
        }
        private void LozinkaRe(object sender, TextChangedEventArgs e)
        {

            if (txtReLozinkaRegistracija.Focus())
            {
                tbCapsLock.Visibility = Visibility.Visible;
                tbCapsLock.FontSize = 16;
                tbCapsLock.Foreground = new SolidColorBrush(Colors.Red);
                tbCapsLock.Text = "Lozinke se ne poklapaju";
                Hidden();
            }
            string lozinka = txtLozinkaRegistracija.Text.ToString();
            string reLozinka = txtReLozinkaRegistracija.Text.ToString();
            //if(reLozinka == lozinka)

            if (reLozinka != lozinka)
            {
                txtReLozinkaRegistracija.BorderBrush = new SolidColorBrush(Colors.Red);
                txtReLozinkaRegistracija.Foreground = new SolidColorBrush(Colors.Red);
                reLozinkaBool = false;
                Registruj();
            }
            else
            {
                tbCapsLock.Visibility = Visibility.Collapsed;
                txtReLozinkaRegistracija.BorderBrush = new SolidColorBrush(Colors.DeepPink);
                txtReLozinkaRegistracija.Foreground = new SolidColorBrush(Colors.DeepPink);
                reLozinkaBool = true;
                Registruj();
            }
            Registruj();
        }

        private void Registruj()
        {
            if (korisnickoBool == true &&
                citizenshipBool == true &&
                imeBool == true &&
                idNumberBool == true &&
                IDNumberBool == true &&
                lozinkaBool == true &&
                reLozinkaBool == true &&
                datumExprBool == true &&
                txtLozinkaRegistracija.Text.ToString().Equals(txtReLozinkaRegistracija.Text.ToString()))
            {
                btnRegistracija.IsEnabled = true;
            }
            else
            {
                btnRegistracija.IsEnabled = false;
            }
        }

        private Boolean TextAllowed(String s)
        {
            foreach (Char c in s.ToCharArray())
            {
                if (Char.IsLetter(c) || Char.IsControl(c))
                {

                    continue;
                }
                else
                {
                    SystemSounds.Beep.Play();
                    return false;
                }
            }
            return true;
        }

        private void PreviewTextInputHandler(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextAllowed(e.Text);
        }

        // banned pasting value
        private void PastingHandler(object sender, DataObjectPastingEventArgs e)
        {
            String s = (String)e.DataObject.GetData(typeof(String));
            if (!TextAllowed(s)) e.CancelCommand();
        }

        private Boolean NumberAllowed(String s)
        {
            foreach (Char c in s.ToCharArray())
            {
                if (Char.IsDigit(c) || Char.IsControl(c))
                {

                    continue;
                }
                else
                {
                    SystemSounds.Beep.Play();
                    return false;
                }
            }
            return true;
        }

        //only numbers
        private void PreviewNumberInputHandler(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = !NumberAllowed(e.Text);
        }

        private void BtnVratiPrijavu_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Napusti(object sender, RoutedEventArgs e)
        {
            //porukaError.Visibility = Visibility.Collapsed;
        }

        private void Registruj_Click(object sender, RoutedEventArgs e)
        {
            SignUp.Visibility = Visibility.Visible;
            Images1.Visibility = Visibility.Collapsed;
            login.Visibility = Visibility.Collapsed;
            Images0.Visibility = Visibility.Visible;
        }
    }
}

