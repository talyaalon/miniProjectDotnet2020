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
using BL;
using BE;


namespace PLWPF
{
    /// <summary>
    ///Interaction logic for MainWindow.xaml
    /// </summary>
    public  partial class MainWindow : Window
    {
        IBL bl = BL.Factory_BL.getBL();
        public MainWindow()
        {
           // IBL my_BL;
            InitializeComponent();
        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            Window_Password ad = new Window_Password();
            ad.Show();
            Close();
        }

        private void Host_Click(object sender, RoutedEventArgs e)
        {
            Window_Password ad = new Window_Password();
            ad.Show();
            Close();
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            Window_Password ad = new Window_Password();
            ad.Show();
            Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
