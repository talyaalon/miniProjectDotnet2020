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
    public partial class Registration_Guest : Window
    {
        IBL bl = BL.Factory_BL.getBL();
        MyGuest This_Guest = new MyGuest();
       

        public Registration_Guest()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;//CENTER THE SCREEN
            InitializeComponent();
        }

        private void Sumbit_Click(object sender, RoutedEventArgs e)
        {

            This_Guest.FirstName = FirstNameFill.Text.ToString();
            This_Guest.LastName = LastNameFill.Text.ToString();
            This_Guest.Id = IdFill.Text.ToString();
            This_Guest.Password = PasswordFill.Text.ToString();
            bl.AddGuest(this.This_Guest);
            Close();

            Window_Password window = new Window_Password();
            window.Show();
          

        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

        //text input-->only letters and numbers
        private void LettersAndNumbersBlock_Textinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-z+A-Z+0-9]+").IsMatch(e.Text);
        }

        private void IDFill_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
