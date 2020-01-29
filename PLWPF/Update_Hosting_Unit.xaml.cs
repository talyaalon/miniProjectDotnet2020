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
    /// Interaction logic for Update_Hosting_Unit.xaml
    /// </summary>
    public partial class Update_Hosting_Unit : Window
    {
        IBL bl = Factory_BL.getBL();
        HostingUnit My_HostUnit = new HostingUnit();
        public Update_Hosting_Unit()
        {
            InitializeComponent();


        }

        private void ButtonUpdateTrainee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                My_HostUnit = bl.GetName_GiveHostingUnit(NameTextBox.Text.ToString());
                if (My_HostUnit == null)
                {
                    throw new Exception("השם יחידת אירוח שביקשת לעדכן אינו נמצא ברשימה");
                }
                if(TextBox_price_Of_Night_To_Adult != null)
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
                MessageBox.Show("הוכנס לעידכון, לחץ על 'אישור' אחרי הזנת הפרטים מחדש  ");
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message);
            }
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
                bl.UpdateHostingUnit(this.My_HostUnit);
                MessageBox_Project x = new MessageBox_Project("!!מעולה ", "העידכון עבר בהצלחה");
                x.ShowDialog();
                Close();
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(exp.Message);

            }

        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_of_Area_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void KeyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
