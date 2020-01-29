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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MyGuestWindow.xaml
    /// </summary>
    public partial class MyGuestWindow : Window
    {
        public MyGuestWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add_GeustRequst ad = new Add_GeustRequst();
            ad.Show();
            this.Close();
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Update_GeustRequst up = new Update_GeustRequst();
            up.Show();
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
