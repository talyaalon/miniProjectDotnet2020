using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;



namespace BE
{
    public class GuestRequest
    {
        public static long guest_requestKey = Configuration.GuestRequestKey;
        public long guest_request_key
        {
            get
            {
                return guest_requestKey;
            }
            set
            {
                guest_requestKey = value;
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
        public string MailAddress
        {
            get
            {
                return MailAddress;
            }
            set
            {
                EmailVerify(MailAddress); //קריאה לפונקצית עזר שנמצאת למטה
            }
        }
        public My_enum.Status Status { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public My_enum.Area Area { get; set; }
        public string SubArea { get; set; }
        public My_enum.Type Type { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public My_enum.Areaoptions Pool { get; set; }
        public My_enum.Areaoptions Jacuzzi { get; set; }
        public My_enum.Areaoptions Garden { get; set; }
        public My_enum.Areaoptions ChildrensAttractions { get; set; }
        public override string ToString()
        {
            return "Status" + Status + "/n" +
                 "RegistrationDate" + RegistrationDate + "/n" +
                 "EntryDate" + EntryDate + "/n" +
                 "ReleaseDate" + ReleaseDate + "/n" +
                 "Area" + Area + "/n" +
                 "SubArea" + SubArea + "/n" +
                 "Type" + Type + "/n" +
                 "Adults" + Adults + "/n" +
                 "Children" + Children + "/n" +
                 "Pool" + Pool + "/n" +
                 "Jacuzzi" + Jacuzzi + "/n" +
                 "Garden" + Garden + "/n" +
                 "ChildrensAttractions" + ChildrensAttractions + "/n";

        }
        public GuestRequest() // defult constactor
        {

        }
        // constractor
        public GuestRequest(My_enum.Status my_status=0, DateTime my_RegistrationDate = new DateTime(),
            string my_PrivateName=" ", string my_FamilyName=" ",
            string my_MailAddress=" ",DateTime my_EntryDate= new DateTime() ,
            DateTime my_ReleaseDate= new DateTime(), My_enum.Area my_Area=0, string my_SubArea=" ", 
            My_enum.Type my_Type=0,int my_Adults=0, int my_Children=0, My_enum.Areaoptions my_Pool= 0,
            My_enum.Areaoptions my_Jacuzzi=0, My_enum.Areaoptions my_Garden=0, 
            My_enum.Areaoptions my_ChildrensAttractions=0) 
        {
            Status = my_status; 
            RegistrationDate = my_RegistrationDate;
            PrivateName = my_PrivateName;
            FamilyName= my_FamilyName;
            MailAddress= my_MailAddress;
            EntryDate = my_EntryDate;
            ReleaseDate = my_ReleaseDate;
            Area = my_Area;
            SubArea = my_SubArea;
            Type = my_Type;
            Adults = my_Adults;
            Children = my_Children;
            Pool = my_Pool;
            Jacuzzi = my_Jacuzzi;
            Garden = my_Garden;
            ChildrensAttractions = my_ChildrensAttractions;
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
    }
}