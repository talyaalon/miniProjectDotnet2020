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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Window_Password.xaml
    /// </summary>
    public partial class Window_Password : Window
    {
        IBL bl = BL.Factory_BL.getBL();
        public Window_Password()
        {
            InitializeComponent();

        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {//we can drag the window by a left click mouse
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }


        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                if (((ComboBoxItem)ComboBox_of_HostOrGuest.SelectedItem) != null) //המשמתש מילא את השדה
                {
                    switch (((ComboBoxItem)ComboBox_of_HostOrGuest.SelectedItem).Content.ToString())
                    {
                        case " אורח ":
                            {


                                Registration_Guest window = new Registration_Guest();
                                window.Show();
                                break;
                            }
                        case " מארח ":
                            {
                                Registration_Host window = new Registration_Host();
                                window.Show();
                                break;
                            }
                    }
                }
                else
                {
                    MessageBox_Project x = new MessageBox_Project(":שִׂים לֵב ", "הינך צריך למלא האם אתה אורח/מארח ");
                    x.ShowDialog();
                }
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

    

        private void Guest_Window(MyGuest t)
        {
            MyGuestWindow guestWindow = new MyGuestWindow();
            guestWindow.Show();
            Close();
        }
        
        private void Sumbit_Click(object sender, RoutedEventArgs e)
        {
            if ((IDFill.Text == "207590225" || IDFill.Text == "318795093") && PasswordFill.Text == "111111111")//if it is the admin,efrat or talya
            {
                Admin_Window ad = new Admin_Window();
                ad.Show();
                this.Close();
                return;
            }
            try
            {
                if (((ComboBoxItem)ComboBox_of_HostOrGuest.SelectedItem) != null)
                {

                    switch (((ComboBoxItem)ComboBox_of_HostOrGuest.SelectedItem).Content.ToString())
                    {
                        case " אורח ":
                            {
                                MyGuest temp = bl.getMyGuest(bl.FindMyGuest(IDFill.Text));
                                if (temp.Password != PasswordFill.Text)
                                {
                                    MessageBox_Project x = new MessageBox_Project(":שִׂים לֵב ", "סיסמתך אינה נכונה");
                                    x.ShowDialog();
                                  
                                }
                                Guest_Window(temp);
                                break;
                            }
                        case " מארח ":
                            {
                                MyHost temp = bl.getMyHost(bl.FindMyHost(IDFill.Text));
                                if (temp.Password_host != PasswordFill.Text)
                                {
                                    MessageBox_Project x = new MessageBox_Project(":שִׂים לֵב ", "סיסמתך אינה נכונה אנא נסה שוב");
                                    x.ShowDialog();
                                  
                                }
                                else
                                {
                                    MyHostWindow hostWindow = new MyHostWindow(temp);
                                    hostWindow.Show();
                                    Close();
                                }

                                break;
                            }
                    }
                }
                else
                {
                    MessageBox_Project x = new MessageBox_Project(":שִׂים לֵב ", "לא מילאת את כל הפרטים " + "\n" + "אנא מלא שוב את כל הפרטים");
                    x.ShowDialog();
                   
                    Window_Password window = new Window_Password();
                    window.Show();
                }
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void ForgetPasswordLabel_Click(object sender, RoutedEventArgs e)
        {
            ForgotPassword fe = new ForgotPassword();
            fe.ShowDialog();
            this.Close();
        }

    

    //text input-->only numbers
    private void LettersBlock_Textinput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
    }


        //text input-->only letters and numbers
        private void LettersAndNumbersBlock_Textinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-z+A-Z+0-9]+").IsMatch(e.Text);
        }

        private void IDFill_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void choiceCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }
    }
}
