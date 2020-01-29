using BE;
using BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;



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
            // this.ComboBox_of_Area.ItemsSource= Enum.GetValues(typeof(BE.My_enum.Area));
           
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
                if (email != null)
                {
                    my_Guest.MailAddress = email.Text.ToString();
                }
                if (TextBox_of_number_phon != null)
                {
                    my_Guest.FhoneNumber = TextBox_of_number_phon.Text.ToString();
                }
                if (TextBox_of_number_SubArea != null)
                {
                    my_Guest.SubArea = TextBox_of_number_SubArea.Text.ToString();
                }
                if (TextBox_of_Adults != null)
                {
                    my_Guest.Adults = int.Parse(TextBox_of_Adults.Text.ToString());
                }
                if (TextBox_of_children != null)
                {
                    my_Guest.Children =int.Parse(TextBox_of_children.Text.ToString());
                }
                if(DatePicker_EntryDate.SelectedDate != null)
                {
                    my_Guest.EntryDate = DateTime.Parse(DatePicker_EntryDate.Text);
                }
                if (DatePicker_ReleaseDate.SelectedDate != null)
                {
                    my_Guest.ReleaseDate = DateTime.Parse(DatePicker_ReleaseDate.Text);
                }
                if (ComboBox_of_Area.SelectedItem != null)
                {
                   my_Guest.Area = CheckEnums.CheckArea(ComboBox_of_Area.SelectionBoxItem.ToString());
                }
                if (ComboBox_of_Type.SelectedItem != null)
                {
                    my_Guest.Type = CheckEnums.CheckType(ComboBox_of_Type.SelectionBoxItem.ToString());
                }
                if (ComboBox_of_pool.SelectedItem != null)
                {
                    my_Guest.Pool = CheckEnums.CheckAreaoptions(ComboBox_of_pool.SelectionBoxItem.ToString());
                }
                if (ComboBox_of_Jacuzzi.SelectedItem != null)
                {
                    my_Guest.Jacuzzi = CheckEnums.CheckAreaoptions(ComboBox_of_Jacuzzi.SelectionBoxItem.ToString());
                }
                if (ComboBox_of_Garden.SelectedItem != null)
                {
                    my_Guest.Garden = CheckEnums.CheckAreaoptions(ComboBox_of_Garden.SelectionBoxItem.ToString());
                }
                if (ComboBox_of_ChildrensAttractions.SelectedItem != null)
                {
                    my_Guest.ChildrensAttractions = CheckEnums.CheckAreaoptions(ComboBox_of_ChildrensAttractions.SelectionBoxItem.ToString());
                }
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(exp.Message);

            }

  
            // בדיקה שמילא את כל השדות של הטקסט
            if ((TextBox_of_privat_name.Text == "")
                   || (TextBox_of_Family_name.Text == "")
                   || (email.Text == "")
                   || (TextBox_of_number_phon.Text == "")
                   || (TextBox_of_Adults.Text == "")
                   || (TextBox_of_children.Text == ""))

            {
                MessageBox_Project x = new MessageBox_Project(":שִׂים לֵב ", "לא מילאת את כל השדות אנא מלא את כל השדות");
            }
            bl.AddGuestRequest(my_Guest); // ההעברה למימוש
         
        }
        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();//create window
            main.Show();//show window
            this.Close();

        }

        //text input-->only numbers
        private void LettersBlock_Textinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        //text input-->only letters 
        private void JustLetters_Textinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-z+A-Z+א-ת]+").IsMatch(e.Text);
        }

        private void Email_LostFocus(object sender, RoutedEventArgs e)
        {
            e.Handled = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").IsMatch(email.Text);
            if (e.Handled == false)
                this.email.BorderBrush = Brushes.Red;
            else
                this.email.BorderBrush = Brushes.LightSlateGray;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_of_Area_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

    