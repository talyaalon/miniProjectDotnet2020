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
        public int BankAccountNumber { get; set; }
        public BankBranch BankAccuont { get; set; }//פרטי סניף הבנק
        public My_enum.Yes_Or_No CollectionClearance { get; set; }// אישור גבייה מחשבון בנק
        public override string ToString()
        {
            return "HostKey: " + HostKey + "/n" +
                "PrivateName: " + PrivateName + "/n" +
                "FamilyName: " + FamilyName + "/n" +
                "FhoneNumber: " + FhoneNumber + "/n" +
                "MailAddress: " + MailAddress + "/n" +
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
            string my_MailAddress = " ", int my_BankAccountNumber = 00000, My_enum.Yes_Or_No my_CollectionClearance = 0) 
        {
           PrivateName = my_PrivateName;
           FamilyName = my_FamilyName;
           FhoneNumber = my_FhoneNumber;
           MailAddress = my_MailAddress;
           BankAccountNumber = my_BankAccountNumber;
           BankAccuont = my_BankAccuont;
           CollectionClearance = my_CollectionClearance;
        }
    }
}
