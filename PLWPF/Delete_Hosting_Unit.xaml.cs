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
    /// Interaction logic for Delete_Hosting_Unit.xaml
    /// </summary>
    public partial class Delete_Hosting_Unit : Window
    {
        IBL bl = Factory_BL.getBL();
        MyHost host;
        public HostingUnit My_HostUnit = new HostingUnit();
        public Delete_Hosting_Unit(MyHost h)
        {
            InitializeComponent();
            host = h;
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //text input-->only letters 
        private void JustLetters_Textinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^a-z+A-Z+א-ת]+").IsMatch(e.Text);
        }

        private void HostUnitFill_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                My_HostUnit = bl.GetName_GiveHostingUnit(HostUnitFill.Text.ToString());
                if (My_HostUnit == null)
                {
                    MessageBox_Project t = new MessageBox_Project("!!שגיאה ", "השם יחידת אירוח שביקשת לעדכן אינו נמצא ברשימה");
                    t.ShowDialog();
                }
                bl.deleteHostingUnit(My_HostUnit);
                MessageBox_Project x = new MessageBox_Project("!!מעולה ", "היחידה נמחקה בהצלחה");
                x.ShowDialog();
                Close();
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(exp.Message);

            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MyHostWindow a = new MyHostWindow(host);
            a.Show();
            this.Close();
        }
    }
}
