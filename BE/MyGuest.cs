using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class MyGuest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate =DateTime.Now;

        public override string ToString()
        {
            return "FirstName: " + FirstName + "\n" +
                "LastName: " + LastName + "\n" +
                "Id: " + Id + "\n" +
                "Password: " + Password + "\n";
        }
        //diffult constractor:
        public MyGuest()
        {

        }
        //constractor:
        public MyGuest(string My_FirstName = " ", string My_LastName = " ", string My_Id = " ", string My_password = " ")

        {
            FirstName = My_FirstName;
            LastName = My_LastName;
            Id = My_Id;
            Password = My_password;


        }
    }
}
