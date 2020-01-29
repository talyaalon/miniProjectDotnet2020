using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class MyHost
    {

        
        public string FirstName_host { get; set; }
        public string LastName_host { get; set; }
        public string Id_host { get; set; }
        public string Password_host { get; set; }
        public string FhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public int BankAccountNumber { get; set; }
        public BankBranch BankAccuont { get; set; }//פרטי סניף הבנק
        public My_enum.Yes_Or_No CollectionClearance { get; set; }// אישור גבייה מחשבון בנק
        public override string ToString()
        {
            return "FirstName: " + FirstName_host + "\n" +
             "LastName: " + LastName_host + "\n" +
              "Id: " + Id_host + "\n" +
             "Password: " + Password_host + "\n" +
            "FhoneNumber: " + FhoneNumber + "\n" +
             "MailAddress: " + MailAddress + "\n" +
             "BankAccountNumber" + BankAccountNumber + "\n" +
             
             "BankAccuont: " + BankAccuont + "\n" +
             "CollectionClearance: " + CollectionClearance + "\n";
        }



        //diffult constractor:
        public MyHost()
        {

        }



        // constractor
        public MyHost(BankBranch my_BankAccuont, string My_FirstName = " ", string My_LastName = " ",
            string My_Id = " ", string My_password = " ", string my_FhoneNumber = " ",
             string my_MailAddress = " ", int my_BankAccountNumber = 00000,
              My_enum.Yes_Or_No my_CollectionClearance = 0)
        {
            BankAccuont = my_BankAccuont;
            FirstName_host = My_FirstName;
            LastName_host = My_LastName;
            Id_host = My_Id;
            Password_host = My_password;
            FhoneNumber = my_FhoneNumber;
            MailAddress = my_MailAddress;
            BankAccountNumber = my_BankAccountNumber;
            CollectionClearance = my_CollectionClearance;

        }
    }
}


   