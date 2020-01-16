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
    /// Interaction logic for ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : Window
    {
        IBL bl = BL.Factory_BL.getBL();

        public ForgotPassword(string Id)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;//CENTER THE SCREEN

            InitializeComponent();

            string UserId = Id;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {//we can drag the window by a left click mouse
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Email_LostFocus(object sender, RoutedEventArgs e)
        {
            e.Handled = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").IsMatch(emailFill.Text);
            if (e.Handled == false)
                this.emailFill.BorderBrush = Brushes.Red;
            else
                this.emailFill.BorderBrush = Brushes.LightSlateGray;
        }
        

        //text input-->only numbers
        private void LettersBlock_Textinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void email_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;

            // your event handler here
            e.Handled = true;

            send_email_Click(sender, e);

        }

        private void send_email_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").IsMatch(emailFill.Text);
            //check if email and id valid:
            if ((e.Handled == false) || IDFill.Text.Count() < 9)
            {
                MessageBox_Project x = new MessageBox_Project(":שִׂים לֵב ", "אימייל לא יכול להישלח ללא כתובת מייל או מספר זיהוי חוקי");
                x.ShowDialog();
                return;
            }

            //  if everything is ok, send the mail:
            string to = emailFill.Text; //send mail to the Admin


            //to make sure the mail will work on any other computers:
            string keep = System.Environment.CurrentDirectory;
            const string removeString = @"\bin\Debug";
            string read = keep.Remove(keep.IndexOf(removeString), removeString.Length) + @"\pictures\NewMail.html";

            string mailbody = File.ReadAllText(read);
            if ((IDFill.Text == "207590225" || IDFill.Text == "318795093"))//if it is the admin,efrat or talya
            {
                MessageBox_Project x = new MessageBox_Project(":שִׂים לֵב", " סיסמתך היא: 111111111");
                x.ShowDialog();
                return;
            }
            try
            {
                if (((ComboBoxItem)ComboBox_of_HostOrGuest.SelectedItem).Content.ToString() != "")
                {
                    switch (((ComboBoxItem)ComboBox_of_HostOrGuest.SelectedItem).Content.ToString())
                    {
                        case "אורח":
                            {
                                MyGuest temp = bl.getMyGuest(bl.FindMyGuest(IDFill.Text));
                                mailbody = mailbody.Replace("###,שלום רב###", " " + temp.FirstName + " " + temp.LastName + ":"); // his Name
                                mailbody = mailbody.Replace("###:סיסמתך החדשה היא###", " " + temp.Password);// his new password
                                break;
                            }
                        case "מארח":
                            {
                                MyHost temp = bl.getMyHost(bl.FindMyHost(IDFill.Text));
                                mailbody = mailbody.Replace("###,שלום רב###", " " + temp.FirstName + " " + temp.LastName + ":"); // his Name
                                mailbody = mailbody.Replace("###:סיסמתך החדשה היא###", " " + temp.Password);// his new password
                                break;
                            }
                    }
                }
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(exp.Message);
            }

            string from = "talyaandefrat@gmail.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "שיחזור סיסמא";
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.UTF8;
            message.Body = mailbody;


            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            NetworkCredential basicCredential = new NetworkCredential("talyaandefrat@gmail.com", "te50930225");
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = basicCredential;

            try
            {
                client.Send(message);
                MessageBox_Project sendMassege = new MessageBox_Project(":שִׂים לֵב", "המייל נשלח בהצלחה" + "/n" + "תוכל לגשת לבדוק את תיבת המייל שלך לקבלת הסיסמא החדשה שלך");
                sendMassege.ShowDialog();
                Close();


            }
            catch (Exception)
            {
                MessageBox_Project sendMassege = new MessageBox_Project(":שִׂים לֵב", "המייל לא נשלח");
                sendMassege.ShowDialog();
            }
        }

        private void choiceCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }
}

