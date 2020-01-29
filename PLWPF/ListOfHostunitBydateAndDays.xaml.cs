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
    /// Interaction logic for ListOfHostunitBydateAndDays.xaml
    /// </summary>
    public partial class ListOfHostunitBydateAndDays : Window
    {
        IBL bl = Factory_BL.getBL();
        public ListOfHostunitBydateAndDays()
        {

            InitializeComponent();
        }
        //text input-->only numbers
        private void LettersBlock_Textinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_of_Days_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Button__Click(object sender, RoutedEventArgs e)
        {
            bl.List_of_available_units(DateTime.Parse(DatePicker_EntryDate.Text), int.Parse(TextBox_of_Days.Text.ToString()));

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Admin_Window a = new Admin_Window();
            a.Show();
            this.Close();
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
    }
}
