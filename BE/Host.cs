using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
namespace BE
{
    public class Host
    {
        public string HostKey //ID
        {
            get { return HostKey; }
            set //בדיקת תקינות לתעודת זהות 
            {

                if (value.Length != 9)
                    throw new ArgumentException("מספר הספרות אינו תואם את הנדרש!");
                for (int i = 0; i < value.Length; i++)
                {
                    if ((value[i] < 48) || (value[i] > 57))//if the char is not between the ascii code of the digits
                        throw new ArgumentException("יש להכניס רק ספרות!");
                }
                HostKey = value;
            }

        }
        public string PrivateName
        {
            get
            {
                return PrivateName;

            }
            set //בדיקת תקינות לשם פרטי
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (((value[i] < 65) || (value[i] > 90)) && ((value[i] > 122) || (value[i] < 97)))//if the char is not between the ascii code of the characters
                        throw new ArgumentException("יש להכניס רק אותיות!");
                }
                PrivateName = value;
            }
        }
        public string FamilyName
        {
            get
            {
                return FamilyName;

            }
            set //בדיקת תקינות לשם משפחה
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (((value[i] < 65) || (value[i] > 90)) && ((value[i] > 122) || (value[i] < 97)))//if the char is not between the ascii code of the characters
                        throw new ArgumentException("יש להכניס רק אותיות!");
                }
                FamilyName = value;
            }
        }
        public string FhoneNumber
        {
            get { return FhoneNumber; }
            set       //בדיקת תקינות למספר טלפון
            {
                if (value.Length != 10)
                    throw new ArgumentException("מספר הספרות אינו תואם את הנדרש!");
                for (int i = 0; i < value.Length; i++)
                {
                    if ((value[i] < 48) || (value[i] > 57))//if the char is not between the ascii code of the digits
                        throw new ArgumentException("יש להכניס רק ספרות!");
                }
                FhoneNumber = value;
            }
        }

        public string MailAddress
        {
            get
            {
                return MailAddress;
            }
            set
            {
                EmailVerify(MailAddress);
            }
        }
        public double Adult_price_per_night { get; set; }
        public double Child_price_per_night { get; set; }
        public int BankAccountNumber { get; set; }
        public BankBranch BankAccuont { get; set; }//פרטי סניף הבנק
        public My_enum.Yes_Or_No CollectionClearance { get; set; }// אישור גבייה מחשבון בנק
        public string Password { get; set; }
        public override string ToString()
        {
            return "HostKey: " + HostKey + "/n" +
                "PrivateName: " + PrivateName + "/n" +
                "FamilyName: " + FamilyName + "/n" +
                "FhoneNumber: " + FhoneNumber + "/n" +
                "MailAddress: " + MailAddress + "/n" +
                "Adult_price_per_night" + Adult_price_per_night + "/n"+
                "Child_price_per_night" + Child_price_per_night + "/n" +
                "BankAccuont: " + BankAccuont + "/n" +
                "CollectionClearance: " + CollectionClearance + "/n";
        }
        public static bool EmailVerify(string mailAddress) //בדיקת תקינות למייל 
        {
            try
            {
                var mail = new MailAddress(mailAddress);

                return mail.Host.Contains(".");
            }
            catch
            {
                return false;
            }
        }

 
        //diffult constractor
        public Host()
        {

        }


        // constractor
        public Host(BankBranch my_BankAccuont, string my_PrivateName = " ",
            string my_FamilyName = " ", string my_FhoneNumber = " ",
            string my_MailAddress = " ", double My_Adult_price_per_night = 100,
            double My_Child_price_per_night=60, int my_BankAccountNumber = 00000, 
            My_enum.Yes_Or_No my_CollectionClearance = 0, string My_Password = " ") 
        {
           PrivateName = my_PrivateName;
           FamilyName = my_FamilyName;
           FhoneNumber = my_FhoneNumber;
           MailAddress = my_MailAddress;
           Adult_price_per_night = My_Adult_price_per_night;
           Child_price_per_night = My_Child_price_per_night;
           BankAccountNumber = my_BankAccountNumber;
           BankAccuont = my_BankAccuont;
           CollectionClearance = my_CollectionClearance;
           Password = My_Password;
        }
    }
}
