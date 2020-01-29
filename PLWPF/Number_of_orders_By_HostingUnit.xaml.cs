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
    /// Interaction logic for Number_of_orders_By_HostingUnit.xaml
    /// </summary>
    public partial class Number_of_orders_By_HostingUnit : Window
    {
        IBL bl = BL.Factory_BL.getBL();
        public Number_of_orders_By_HostingUnit()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HostingUnit myhostingUnit = bl.GetName_GiveHostingUnit(TextBox_of_hostingunit_name.Text.ToString());
                if (myhostingUnit == null)
                {
                    throw new Exception("לא קיימת יחידת אירוח כזאת במאגר ");
                }
                int number = bl.Number_of_orders_accepted(myhostingUnit);
                MessageBox_Project x = new MessageBox_Project(":מס' ההזמנות שנסגרו בהצלחה ביחידה זו", "הזמנות:  " + number);
                x.ShowDialog();
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message);
            }
        }
        //text input-->only letters 
        private void JustLetters_Textinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-z+A-Z+א-ת]+").IsMatch(e.Text);
        }


        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Admin_Window a = new Admin_Window();
            a.Show();
            this.Close();
        }
    }
}
