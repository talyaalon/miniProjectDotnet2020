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
        public string firstName { get; set; } 
        public string FamilyName { get; set; }
        public string MailAddress { get; set; }
        public string FhoneNumber { get; set; }//מספר טלפון של הלקוח
        public My_enum.Status Status { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public My_enum.Area Area { get; set; }
        public string SubArea { get; set; }
        public My_enum.Type Type { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public My_enum.Yes_Or_No Pool { get; set; }
        public My_enum.Yes_Or_No Jacuzzi { get; set; }
        public My_enum.Yes_Or_No Garden { get; set; }
        public My_enum.Yes_Or_No ChildrensAttractions { get; set; }
        public string ID_of_Guest { get; set; } //ID
        public override string ToString()
        {
            return "guest_request_key" + guest_request_key +"/n" +
                "PrivateName " + firstName + "/n" +
                "FamilyName " + FamilyName + "/n" +
                "MailAddress " + MailAddress + "/n" +
                "FhoneNumber " + FhoneNumber + "/n" +
                "Status " + Status + "/n" +
                 "RegistrationDate " + RegistrationDate + "/n" +
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
            guest_request_key = guest_requestKey;
        }
        // constractor
        public GuestRequest(My_enum.Status my_status=0, DateTime my_RegistrationDate = new DateTime(),
            string my_PrivateName=" ", string my_FamilyName=" ",
            string my_MailAddress=" ", string my_FhoneNumber= " " , DateTime my_EntryDate= new DateTime() ,
            DateTime my_ReleaseDate= new DateTime(), My_enum.Area my_Area=0, string my_SubArea=" ", 
            My_enum.Type my_Type=0,int my_Adults=0, int my_Children=0, My_enum.Yes_Or_No my_Pool = 0,
            My_enum.Yes_Or_No my_Jacuzzi =0, My_enum.Yes_Or_No my_Garden =0, 
            My_enum.Yes_Or_No my_ChildrensAttractions =0) 
        {
            Status = my_status; 
            RegistrationDate = my_RegistrationDate;
            firstName = my_PrivateName;
            FamilyName= my_FamilyName;
            MailAddress = my_MailAddress;
            FhoneNumber = my_FhoneNumber;
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
    }
}