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
    /// Interaction logic for MessageBoxProject.xaml
    /// </summary>
    public partial class MessageBox_Project : Window
    {
        public MessageBox_Project(string Title, string showMessage)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;//CENTER THE SCREEN

            InitializeComponent();
            TitMessage.Content = Title;
            // messageLabel.Content = showMessage;
            messageLabel.Text = showMessage;

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow pUc = new MainWindow();
            //pUc.Show();

            this.Close();


        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {//we can drag the window by a left click mouse
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                // your event handler here
                e.Handled = true;

                ok_Click(sender, e);
            }
            if (e.Key == Key.Escape)
               this.Close();

        }

        private void MessageLabel_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

