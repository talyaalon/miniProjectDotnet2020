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
    /// Interaction logic for AddHostingUnit.xaml
    /// </summary>
    public partial class AddHostingUnit : Window
    {

        IBL bl = Factory_BL.getBL();
        HostingUnit My_HostUnit = new HostingUnit();
        MyHost host;
        public AddHostingUnit(MyHost h)
        {

            InitializeComponent();
            host = h;
          
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


        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextBox_of_hostingunit_name != null)
                {
                    My_HostUnit.HostingUnitName = TextBox_of_hostingunit_name.Text.ToString();
                }
                if (TextBox_price_Of_Night_To_Adult != null)
                {
                    My_HostUnit.price_Of_Night_To_Adult = double.Parse(TextBox_price_Of_Night_To_Adult.Text);
                }
                if (TextBox_price_Of_Night_To_Child != null)
                {
                    My_HostUnit.price_Of_Night_To_Child = double.Parse(TextBox_price_Of_Night_To_Child.Text);
                }
                if (ComboBox_of_Type.SelectedItem != null)
                {
                    My_HostUnit.Type = CheckEnums.CheckType(ComboBox_of_Type.SelectionBoxItem.ToString());
                }
                if (TextBox_of_Adults != null)
                {
                    My_HostUnit.Adults = int.Parse(TextBox_of_Adults.Text);
                }
                if (TextBox_of_children != null)
                {
                    My_HostUnit.Children = int.Parse(TextBox_of_children.Text);
                }
                if (ComboBox_of_Area.SelectedItem != null)
                {
                    My_HostUnit.Area = CheckEnums.CheckArea(ComboBox_of_Area.SelectionBoxItem.ToString());
                }
                if (TextBox_of_number_SubArea != null)
                {
                    My_HostUnit.SubArea = TextBox_of_number_SubArea.Text.ToString();
                }
                if (ComboBox_of_pool.SelectedItem != null)
                {
                    My_HostUnit.Pool = CheckEnums.CheckYes_Or_No(ComboBox_of_pool.SelectionBoxItem.ToString());
                }
                if (ComboBox_of_Jacuzzi.SelectedItem != null)
                {
                    My_HostUnit.Jacuzzi = CheckEnums.CheckYes_Or_No(ComboBox_of_Jacuzzi.SelectionBoxItem.ToString());
                }
                if (ComboBox_of_Garden.SelectedItem != null)
                {
                    My_HostUnit.Garden = CheckEnums.CheckYes_Or_No(ComboBox_of_Garden.SelectionBoxItem.ToString());

                }
                if (ComboBox_of_ChildrensAttractions.SelectedItem != null)
                {
                    My_HostUnit.ChildrensAttractions = CheckEnums.CheckYes_Or_No(ComboBox_of_ChildrensAttractions.SelectionBoxItem.ToString());
                }
                My_HostUnit.Owner = host;
                bl.AddHostingUnit(My_HostUnit);
                MessageBox_Project x = new MessageBox_Project("!!מעולה ", "יחידת האירוח  נוספה בהצלחה ");
                x.ShowDialog();
                MyHostWindow a = new MyHostWindow(host);
                a.Show();
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(exp.Message);

            }
        }
        private void ComboBox_of_Area_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Exit_Click(object sender, TextChangedEventArgs e)
        {
            Close();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MyHostWindow a = new MyHostWindow(host);
            a.Show();
            this.Close();

        }
    }
}
