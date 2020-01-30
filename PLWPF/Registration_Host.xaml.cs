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
    public partial class Registration_Host : Window
    {
        IBL bl = BL.Factory_BL.getBL();
        MyGuest This_Guest = new MyGuest();
        MyHost This_Host = new MyHost();

        public Registration_Host()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;//CENTER THE SCREEN
            InitializeComponent();
        }

        private void Sumbit_Click(object sender, RoutedEventArgs e)
        {
            This_Host.FhoneNumber = FhoneFill.Text.ToString();
            This_Host.MailAddress = email.Text.ToString();
            This_Host.BankAccountNumber = Convert.ToInt32(BankAccountNumberFill.Text);
            
            This_Host.BankAccuont.BankName = BankNameFill.Text.ToString();
            This_Host.BankAccuont.BankNumber = int.Parse(BankAccountNumberFill.Text); // מספר חשבון בנק 
            This_Host.BankAccuont.BranchNumber= int.Parse(BankNumberFill.Text);
            This_Host.BankAccuont.BranchAddress = BranchAddressFill.Text.ToString();
            This_Host.BankAccuont.BranchCity = BranchCityFill.Text.ToString();
            This_Host.CollectionClearance = CheckEnums.CheckYes_Or_No(ComboBox_of_YesOrNo.SelectionBoxItem.ToString());

            bl.AddHost(this.This_Host);
            

            Window_Password window = new Window_Password();
            window.Show();
            this.Close();
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
        private void Email_LostFocus(object sender, RoutedEventArgs e)
        {
            e.Handled = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").IsMatch(email.Text);
            if (e.Handled == false)
                this.email.BorderBrush = Brushes.Red;
            else
                this.email.BorderBrush = Brushes.LightSlateGray;
        }



        private void IDFill_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void choiceCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
