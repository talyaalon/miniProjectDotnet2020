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
        public static List<HostingUnit> My_HostingUnitList = new List<HostingUnit>
        {
            new HostingUnit()
            {
                Owner = new Host
                {
                    HostKey = "207590225",
                    PrivateName = "Efrat",
                    FamilyName = " Mizrachi",
                    FhoneNumber = "0542971391",
                    MailAddress = " efrat192@gmail.com",
                    BankAccuont = new BankBranch
                    {
                        BankNumber = 12,
                        BankName = " בנק פועלים ",
                        BranchNumber = 123,
                        BranchAddress = " הפרח 12",
                        BranchCity = "מעלה אדומים",
                        BankAccountNumber= "480686",
                    },
                    CollectionClearance= My_enum.Yes_Or_No.No
                },
                HostingUnitName = "הצימר של אפרת"
            }
        };

        public static List<GuestRequest> My_GuestRequestsList = new List<GuestRequest>
        {
            new GuestRequest()
            {
                Status=My_enum.Status.Open,
                RegistrationDate=new DateTime(12/12/2020),
                EntryDate=new DateTime(14/12/2020),
                ReleaseDate=new DateTime(18/12/2020),
                Area=My_enum.Area.Center,
                SubArea="Ashdod",
                Type=My_enum.Type.Hotel,
                Adults=3,
                Children=4,
                Pool=My_enum.Areaoptions.Possible,
                Jacuzzi=My_enum.Areaoptions.Not_Interested,
                Garden=My_enum.Areaoptions.Necessary,
                ChildrensAttractions=My_enum.Areaoptions.Possible,

            }

        };
        public static List<Order> My_OrdersList = new List<Order>
        {
            new Order()
            {
               Status=My_enum.Status.Open,
               CreateDate=new DateTime(14/12/2020),
               OrderDate=new DateTime(18/12/2020),
               Amount_to_pay= 1023,
            }
        };


    }
    
}
    
 
    
