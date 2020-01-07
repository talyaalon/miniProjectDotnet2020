using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE
{
    public class BankBranch
    {
        public int BankNumber; //להכניס את רשימת מספרי הבנקים בארץ
        public string BankName; //להכניס את רשימת הבנקים בארץ
        public int BranchNumber; //להכניס את רשימת מספרי הסניף של הבנק הנבחר בארץ
        public string BranchAddress;//להכניס לרשימת כתובת בארץ
        public string BranchCity;//להכניס לרשימת ערים בארץ
        public string BankAccountNumber;
        public override string ToString()
        {
            return "BankNumber: " + BankNumber + "\n" +
                "BankName: " + BankName + "\n" +
                "BranchNumber: " + BranchNumber + "\n" +
                "BranchAddress: " + BranchAddress + "\n" +
                 "BranchCity: " + BranchCity + "\n" +
                 "BankAccountNumber: " + BankAccountNumber + "\n";
        }
        //diffult constractor
        public BankBranch()
        {

        }
        //constractor
        public BankBranch(int My_BankNumber, string My_BankName, int My_BranchNumber,
            string My_BranchAddress, string My_BranchCity)
        {
            BankNumber = My_BankNumber;
            BankName = My_BankName;
            BranchNumber = My_BranchNumber;
            BranchAddress = My_BranchAddress;
            BranchCity = My_BranchCity;
        }
    }
}
