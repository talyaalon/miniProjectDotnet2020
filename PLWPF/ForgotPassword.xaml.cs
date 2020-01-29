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
    /* <summary>
    Interaction logic for ForgotPassword.xaml
     </summary>*/
    public partial class ForgotPassword : Window
    {
        IBL bl = BL.Factory_BL.getBL();

        //MyGuest ThisMyGuest = new MyGuest();
        // MyHost ThisMyHost = new MyHost();
        
        public ForgotPassword()
        {

            //bl.AddGuest(null);


            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;//CENTER THE SCREEN
            InitializeComponent();
            // string UserId = Id;
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
            e.Handled = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").IsMatch(email.Text);
            if (e.Handled == false)
                this.email.BorderBrush = Brushes.Red;
            else
                this.email.BorderBrush = Brushes.LightSlateGray;
        }




        private void send_email_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").IsMatch(email.Text);
            //check if email and id valid:
            if ((e.Handled == false) || IDFill.Text.Count() < 9)
            {
                MessageBox_Project x = new MessageBox_Project(":שִׂים לֵב ", "אימייל לא יכול להישלח ללא כתובת מייל או מספר זיהוי חוקי");
                x.ShowDialog();
                return;
            }

            //  if everything is ok, send the mail:
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(email.Text);
            mail.From = new System.Net.Mail.MailAddress("talyaandefrat@gmail.com");
            //Subject of the messege
            mail.Subject = "שיחזור סיסמא";
            mail.Body = "סיסמתך היא:  ";


            //mail.Body = "";
            if (IDFill.Text == "207590225" || IDFill.Text == "318795093")//if it is the admin,efrat or talya
            {
                MessageBox_Project x = new MessageBox_Project(":שִׂים לֵב", " סיסמתך היא: 111111111");
                x.ShowDialog();
                return;
            }
            try
            {
                if (((ComboBoxItem)ComboBox_of_HostOrGuest.SelectedItem) != null)
                {
                    switch (((ComboBoxItem)ComboBox_of_HostOrGuest.SelectedItem).Content.ToString())
                    {
                        case " אורח ":
                        {

                                MyGuest temp = bl.getMyGuest(bl.FindMyGuest(IDFill.Text));
                                mail.Body = mail.Body + temp.Password;
                                break;
                        }
                        case " מארח ":
                        {


                                MyHost temp = bl.getMyHost(bl.FindMyHost(IDFill.Text));
                                mail.Body = mail.Body + temp.Password_host;
                                break;
                        }
                    }
                }
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(exp.Message);
            }

            //the body of message
            


            mail.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            NetworkCredential basicCredential = new NetworkCredential("talyaandefrat@gmail.com", "tel1234*");
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = basicCredential;

            try
            {
                smtp.Send(mail);
                MessageBox_Project sendMassege = new MessageBox_Project(":שִׂים לֵב", "המייל נשלח בהצלחה");
                sendMassege.ShowDialog();
                Close();

            }
            catch (Exception eo)
            {
                MessageBox.Show(eo.ToString());
                //MessageBox_Project sendMassege = new MessageBox_Project(":שִׂים לֵב", "המייל לא נשלח");
                // sendMassege.ShowDialog();
            }

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



        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void choiceCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void IDFill_TextChanged(object sender, TextChangedEventArgs e)
        {

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
            /* e.Handled = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").IsMatch(email.Text);
           //check if email and id valid:
           if ((e.Handled == false) || IDFill.Text.Count() < 9)
           {
               MessageBox_Project x = new MessageBox_Project(":שִׂים לֵב ", "אימייל לא יכול להישלח ללא כתובת מייל או מספר זיהוי חוקי");
               x.ShowDialog();
               return;
           }

           //  if everything is ok, send the mail:
           System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
           mail.To.Add(email.Text);
           mail.From = new System.Net.Mail.MailAddress("daniel.adiel1234@gmail.com");
           //Subject of the messege
           mail.Subject = "שיחזור סיסמא";
           //the body of message
           mail.Body = "talya sucssess";



           MailMessage mail = new MailMessage(from, to);


           //mail.Body = "";
           if (IDFill.Text == "207590225" || IDFill.Text == "318795093")//if it is the admin,efrat or talya
           {
               MessageBox_Project x = new MessageBox_Project(":שִׂים לֵב", " סיסמתך היא: 111111111");
               x.ShowDialog();
               return;
           }
           try
           {
               if (((ComboBoxItem)ComboBox_of_HostOrGuest.SelectedItem) != null)
               {
                   switch (((ComboBoxItem)ComboBox_of_HostOrGuest.SelectedItem).Content.ToString())
                   {
                       case " אורח ":
                           {

                               //MyGuest temp = bl.getMyGuest(bl.FindMyGuest(IDFill.Text));
                               //mailbody = mailbody.Replace("###,שלום רב###", " " + temp.FirstName + " " + temp.LastName + ":"); // his Name
                               //mailbody = mailbody.Replace("###:סיסמתך החדשה היא###", " " + temp.Password);// his new password
                               mail.Body = mail.Body + "555";
                               break;
                           }
                       case " מארח ":
                           {
                               mail.Body = mail.Body + "888";

                               /*MyHost temp = bl.getMyHost(bl.FindMyHost(IDFill.Text));


                               //  var temp2 = bl.getMyHost(0);
                               var temp2 = bl.FindMyHost("123456789");// IDFill.Text);
                               mail.Body = mail.Body + temp2.;
                               //mailbody = mailbody.Replace("###,שלום רב###", " " + temp.FirstName_host + " " + temp.LastName_host + ":"); // his Name
                               //mailbody = mailbody.Replace("###:סיסמתך החדשה היא###", " " + temp.Password_host);// his new password
                              
            break;
                            }
                    }
                }
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(exp.Message);
            }


            mail.IsBodyHtml = false;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            NetworkCredential basicCredential = new NetworkCredential("daniel.adiel1234@gmail.com", "daniel_adiel1234*");
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = basicCredential;

            try
            {
                smtp.Send(mail);
                MessageBox_Project sendMassege = new MessageBox_Project(":שִׂים לֵב", "המייל נשלח בהצלחה" + "/n" + "תוכל לגשת לבדוק את תיבת המייל שלך לקבלת הסיסמא החדשה שלך");
                sendMassege.ShowDialog();
                Close();


            }
            catch (Exception eo)
            {
                MessageBox.Show(eo.ToString());
                //MessageBox_Project sendMassege = new MessageBox_Project(":שִׂים לֵב", "המייל לא נשלח");
                // sendMassege.ShowDialog();
            }*/







/* //send mail to the Admin


//to make sure the mail will work on any other computers:
// string keep = System.Environment.CurrentDirectory;
// const string removeString = @"\bin\Debug";
//string read = keep.Remove(keep.IndexOf(removeString), removeString.Length) + @"\pictures\NewMail.html";
string mailbody = "סיסמתך היא: ";

// string mailbody = File.ReadAllText(read);


message.Subject = "שיחזור סיסמא";
message.Body = mailbody;
message.BodyEncoding = Encoding.UTF8;
message.SubjectEncoding= Encoding.UTF8;






}*/




