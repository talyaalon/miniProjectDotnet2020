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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MyHostWindow.xaml
    /// </summary>
    public partial class MyHostWindow : Window
    {
        MyHost host;
        public MyHostWindow(MyHost h)
        {
            InitializeComponent();
            host = h;

        }




        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_add(object sender, RoutedEventArgs e)
        {
            AddHostingUnit ad = new AddHostingUnit(host);
            ad.Show();
            this.Close();


        }

        private void Button_Click_delete(object sender, RoutedEventArgs e)
        {
            Delete_Hosting_Unit ad = new Delete_Hosting_Unit(host);
            ad.Show();
            this.Close();

        }

        private void Button_Click_update(object sender, RoutedEventArgs e)
        {
            Update_Hosting_Unit ad = new Update_Hosting_Unit();
            ad.Show();
            this.Close();


        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Window_Password a = new Window_Password();
            a.Show();
            this.Close();
        }
    }
}