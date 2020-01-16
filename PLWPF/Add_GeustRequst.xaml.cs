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
    /// Interaction logic for Add_GeustRequst.xaml
    /// </summary>
    public partial class Add_GeustRequst : Window
    {
        IBL bl = Factory_BL.getBL();
        public GuestRequest my_Guest = new GuestRequest();
        public Add_GeustRequst()
        {
            InitializeComponent();
        }
        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextBox_of_privat_name != null)
                {
                    my_Guest.PrivateName = TextBox_of_privat_name.Text.ToString();
                }
                if (TextBox_of_Family_name != null)
                {
                    my_Guest.FamilyName = TextBox_of_Family_name.Text.ToString();
                }
                if (TextBox_of_mail_address != null)
                {
                    my_Guest.MailAddress = TextBox_of_mail_address.Text.ToString();
                }
                if (TextBox_of_number_phon != null)
                {
                    my_Guest.FhoneNumber = TextBox_of_number_phon.Text.ToString();
                }
                if (TextBox_of_number_SubArea != null)
                {
                    my_Guest.FhoneNumber = TextBox_of_number_SubArea.Text.ToString();
                }
                if (TextBox_of_Adults != null)
                {
                    my_Guest.FhoneNumber = TextBox_of_Adults.Text.ToString();
                }
                if (TextBox_of_children != null)
                {
                    my_Guest.FhoneNumber = TextBox_of_children.Text.ToString();
                }
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(exp.Message);

            }

  
            // בדיקה שמילא את כל השדות של הטקסט
            if ((TextBox_of_privat_name.Text == "")
                   || (TextBox_of_Family_name.Text == "")
                   || (TextBox_of_mail_address.Text == "")
                   || (TextBox_of_number_phon.Text == "")
                   || (TextBox_of_number_SubArea.Text == "")
                   || (TextBox_of_Adults.Text == "")
                   || (TextBox_of_children.Text == ""))

            {
                throw new Exception("צריך למלא את כל השדות");
            }
            bl.addGuestRequest(this.my_Guest); // ההעברה למימוש
        }
        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();//create window
            main.Show();//show window
            this.Close();

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_of_Area_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

    