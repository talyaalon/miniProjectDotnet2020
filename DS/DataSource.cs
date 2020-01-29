using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;


namespace DS
{
    public class DataSource
    {
        public static List<MyHost> MyHost_List;//רשימה של מארחים
        public DataSource()
        {
            MyHost_List = new List<MyHost>();
            MyHost_List.Add(new MyHost()
            {
                FirstName_host = "אבישג",
                LastName_host = "אלון",
                Id_host = "123456789",
                Password_host = "000000000",
                FhoneNumber = "0000000000",
                MailAddress = "t0505154143@gmail.com",
                BankAccountNumber = 480686,
                CollectionClearance = My_enum.Yes_Or_No.כן,
                BankAccuont = new BankBranch
                {
                    BankNumber = 12,
                    BankName = " בנק פועלים ",
                    BranchNumber = 123,
                    BranchAddress = " הפרח 12",
                    BranchCity = "מעלה אדומים",
                },
            });
            MyHost_List.Add(new MyHost()
            {
                FirstName_host = "אליה",
                LastName_host = "אלון",
                Id_host = "111111111",
                Password_host = "222222222",
                FhoneNumber = "11111111",
                MailAddress = "t0505154143@gmail.com",
                BankAccountNumber = 345678,
                CollectionClearance = My_enum.Yes_Or_No.כן,
                BankAccuont = new BankBranch
                {
                    BankNumber = 12,
                    BankName = " בנק פועלים ",
                    BranchNumber = 123,
                    BranchAddress = "גיבעתי 5",
                    BranchCity = "ירושלים",
                },
            });
            
        }
        public static List<HostingUnit> My_HostingUnitList = new List<HostingUnit>
        {
            new HostingUnit()
            {
                Owner = new MyHost
                {
                    FirstName_host = "אבישג",
                    LastName_host = "אלון",
                    Id_host = "123456789",
                    Password_host = "000000000",
                    FhoneNumber = "0000000000",
                    MailAddress = "t0505154143@gmail.com",
                    BankAccountNumber = 480686,
                    CollectionClearance = My_enum.Yes_Or_No.כן,
                    BankAccuont = new BankBranch
                    {
                        BankNumber = 12,
                        BankName = " בנק פועלים ",
                        BranchNumber = 123,
                        BranchAddress = " הפרח 12",
                        BranchCity = "מעלה אדומים",
                    },
                },
                HostingUnitName = "הצימר של אפרת",
                price_Of_Night_To_Adult =500,
                price_Of_Night_To_Child =300,
                Type= My_enum.Type.צימר,
                Adults =6,
                Children =4,
                Area = My_enum.Area.מרכז,
                SubArea = "ירושלים",
                ChildrensAttractions = My_enum.Yes_Or_No.לא,
                Garden = My_enum.Yes_Or_No.לא,
                Pool = My_enum.Yes_Or_No.לא,
                Jacuzzi = My_enum.Yes_Or_No.כן
            }
        };
        public static List<GuestRequest> My_GuestRequestsList = new List<GuestRequest>
        {
            new GuestRequest()
            {
                guest_request_key= 10000000,
                firstName= "אפרת",
                FamilyName= "מזרחי",
                MailAddress= "efrat192@gmail.com",
                FhoneNumber= "0542971391",
                ID_of_Guest= "207590225",
                Status =My_enum.Status.טרם_טופל,
                RegistrationDate=new DateTime(2020, 1,1),
                EntryDate=new DateTime(2020, 11, 22),
                ReleaseDate=new DateTime(2020, 11, 27),
                Area=My_enum.Area.מרכז,
                SubArea="אשדוד",
                Type=My_enum.Type.מלון,
                Adults=3,
                Children=4,
                Pool=My_enum.Yes_Or_No.כן,
                Jacuzzi=My_enum.Yes_Or_No.כן,
                Garden=My_enum.Yes_Or_No.לא,
                ChildrensAttractions=My_enum.Yes_Or_No.לא

            }
            
        };
        public static List<Order> My_OrdersList = new List<Order>
        {
            new Order()
            {
               Status=My_enum.Status.טרם_טופל,
               CreateDate=new DateTime(14/12/2020),
               OrderDate=new DateTime(18/12/2020),
               Amount_to_pay= 1023
            }
        };

        public static List<MyGuest> MyGuest_List = new List<MyGuest>()//רשימה של אורחים
        {
            new MyGuest()
            {
                FirstName= "גאולה",
                LastName= "אלון" ,
                Id= "333333333" ,
                Password= "333333333"
            },
            new MyGuest()
            {
                FirstName= "דוד",
                LastName= "אלון" ,
                Id= "444444444" ,
                Password= "444444444"
            }
        };



    }

}
