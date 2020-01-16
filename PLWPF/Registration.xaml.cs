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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        IBL bl = BL.Factory_BL.getBL();
        MyGuest This_Guest = new MyGuest();
        MyHost This_Host = new MyHost();

        public Registration()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;//CENTER THE SCREEN
            InitializeComponent();

            this.DataContext = This_Guest;
        }

        private void Sumbit_Click(object sender, RoutedEventArgs e)
        {
            if (((ComboBoxItem)ComboBox_of_HostOrGuest.SelectedItem).Content.ToString() == "אורח")
            {
                bl.AddGuest(This_Guest);
            }

            if (((ComboBoxItem)ComboBox_of_HostOrGuest.SelectedItem).Content.ToString() == "מארח")
            {
                bl.AddHost(This_Host);
            }

        }
        private void choiceCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (((ComboBoxItem)ComboBox_of_HostOrGuest.SelectedItem).Content.ToString() != "")
                {

                    switch (((ComboBoxItem)ComboBox_of_HostOrGuest.SelectedItem).Content.ToString())
                    {
                        case "אורח":
                            {

                                This_Guest.FirstName = FirstNameFill.Text.ToString();
                                This_Guest.LastName = LastNameFill.Text.ToString();
                                This_Guest.Id = IdFill.Text.ToString();
                                This_Guest.Password = PasswordFill.Text.ToString();


                                break;
                            }
                        case "מארח":
                            {
                                This_Host.FirstName = FirstNameFill.Text.ToString();
                                This_Host.LastName = LastNameFill.Text.ToString();
                                This_Host.Id = IdFill.Text.ToString();
                                This_Host.Password = PasswordFill.Text.ToString();
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
            Close();
        }
    }
}
