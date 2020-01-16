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
using BE;
using BL;
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
            Registration re = new Registration();
            re.ShowDialog();
            // Close();
        }

        private void Guest_Window(MyGuest t)
        {
            MyGuestWindow guestWindow = new MyGuestWindow();
            guestWindow.Show();
            Close();
        }

        private void Host_Window(MyHost t)
        {
            MyHostWindow hostWindow = new MyHostWindow();
            hostWindow.Show();
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
                if (((ComboBoxItem)ComboBox_of_HostOrGuest.SelectedItem).Content.ToString() != "")
                {

                    switch (((ComboBoxItem)ComboBox_of_HostOrGuest.SelectedItem).Content.ToString())
                    {
                        case "אורח":
                            {
                                MyGuest temp = bl.getMyGuest(bl.FindMyGuest(IDFill.Text));
                                if (temp.Password != PasswordFill.Text)
                                {
                                    throw new NotImplementedException("הסיסמא אינה נכונה");
                                }
                                Guest_Window(temp);
                                break;
                            }
                        case "מארח":
                            {
                                MyHost temp = bl.getMyHost(bl.FindMyHost(IDFill.Text));
                                if (temp.Password != PasswordFill.Text)
                                {
                                    throw new NotImplementedException("הסיסמא אינה נכונה");
                                }
                                Host_Window(temp);
                                break;
                            }
                    }
                }
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void ForgetPasswordLabel_Click(object sender, RoutedEventArgs e)
        {
            ForgotPassword fe = new ForgotPassword(IDFill.Text);
            fe.ShowDialog();
            this.Close();
        }

        private void choiceCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
