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
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for ListOfOrder.xaml
    /// </summary>
    public partial class ListOfOrder : Window
    {
        IBL bl;
        public ListOfOrder()
        {
            
            InitializeComponent();
            bl = BL.Factory_BL.getBL();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.OrdersDataList.ItemsSource = bl.GetOrderList();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Admin_Window a = new Admin_Window();
            a.Show();
            this.Close();
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();


        }
    }
}
