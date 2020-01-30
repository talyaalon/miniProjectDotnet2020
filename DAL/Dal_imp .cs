    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BE;
    using DS;

namespace DAL
{
    public class Dal_imp : IDAL
    {
        /*public static List<HostingUnit> My_HostingUnitList = new List<HostingUnit>();
        public static List<GuestRequest> My_guestRequestsList;//= new List<GuestRequest>();
        public static List<Order> My_ordersList = new List<Order>();
        public static List<MyGuest> MyGuest_List = new List<MyGuest>();
        public static List<MyHost> MyHost_List = new List<MyHost>();*/
        public Dal_imp()
        {

        }
        public void AddGuestRequest(GuestRequest My_GuestRequest) //הוספת דרישת לקוח
        {

            My_GuestRequest.guest_request_key = ++Configuration.GuestRequestKey;

            Dal_XML_imp.AddGuestRequestToXml(My_GuestRequest.Clone());
        }

        public void AddGuest(MyGuest My_Guest)
        {
            bool ezer = false;
            foreach (var item in Dal_XML_imp.GetGuestFromXml())
            {
                if (item.Id == My_Guest.Id)
                {
                    ezer = true;
                }
            }
            if (ezer == false) //אין את הלקוח ברשימה
            {
                Dal_XML_imp.AddGuestToXml(My_Guest.Clone());
            }
            else
            {
                throw new NotImplementedException("האורח כבר רשום במערכת");
            }
        }

        public void AddHost(MyHost My_Host)
        {

            bool ezer = false;
            foreach (var item in Dal_XML_imp.GetMyHostFromXml())
            {
                if (item.Id_host == My_Host.Id_host)
                {
                    ezer = true;
                }
            }
            if (ezer == false) //אין את הלקוח ברשימה
            {
                Dal_XML_imp.AddMyHostToXml(My_Host.Clone());
            }
            else
            {
                throw new NotImplementedException("המארח כבר רשום במערכת");
            }
        }

        public int FindGuestRequest(long key)
        {
            int Location = 0;
            bool help = false;
            foreach (var item in Dal_XML_imp.GetGuestRequestFromXml())
            {
                if (item.guest_request_key == key && Configuration.GuestRequestKey != 10000000)
                {
                    help = true;
                    return Location;
                }
                Location++;
            }
            if (help == false)
            {
                throw new NotImplementedException("דרישת הלקוח לא נמצאה במערכת");
            }
            return 0;
        }

        public int FindMyGuest(string id)
        {
            int Location = 0;
            bool help = false;
            foreach (var item in Dal_XML_imp.GetGuestFromXml())
            {
                if (item.Id == id)
                {
                    help = true;
                    return Location;

                }
                Location++;
            }
            if (help == false)
            {
                throw new NotImplementedException("האורח לא נמצא במערכת");
            }
            return 0;
        }

        public int FindMyHost(string id)
        {
            int Location = 0;
            bool help = false;
            foreach (var item in Dal_XML_imp.GetMyHostFromXml())
            {
                if (item.Id_host == id)
                {
                    help = true;
                    return Location;

                }
                Location++;
            }
            if (help == false)
            {
                throw new NotImplementedException("המארח לא נמצא במערכת");
            }
            return -1;
        }

        GuestRequest IDAL.getMyGuestRequest(int Location_list)
        {

            if (Location_list >= 0)

            {
                return Dal_XML_imp.GetGuestRequestFromXml(Location_list);
            }
            else
            {
                throw new NotImplementedException("האורח לא נמצא במערכת");
            }
        }

        MyGuest IDAL.getMyGuest(int Location_list)
        {
            if (Location_list >= 0)

            {
                return Dal_XML_imp.GetGuestFromXml(Location_list);
            }
            else
            {
                throw new NotImplementedException("האורח לא נמצא במערכת");
            }
        }

        MyHost IDAL.getMyHost(int Location_list)
        {

            if (Location_list >= 0)

            {
                return Dal_XML_imp.GetMyHostFromXml(Location_list);
            }
            else
            {
                throw new NotImplementedException("האורח לא נמצא במערכת");
            }
        }

        void IDAL.update_GuestRequest(GuestRequest My_GuestRequest)// עידכון דרישת לקוח- עידכון סטטוס 
        {
            bool ezer = false;
            foreach (var item in Dal_XML_imp.GetGuestRequestFromXml())
            {
                if (item.guest_request_key == My_GuestRequest.guest_request_key)
                {
                    ezer = true;
                    item.Status = My_GuestRequest.Status;
                }
            }
            if (ezer == false) //אין את הלקוח ברשימה
            {
                Dal_XML_imp.AddGuestRequestToXml(My_GuestRequest.Clone());
                ++Configuration.GuestRequestKey;
                throw new NotImplementedException("The customer is not on the list so add again");
            }
        }


        public void AddHostingUnit(HostingUnit My_HostingUnit)
        {

            My_HostingUnit.hosting_unit_key = ++Configuration.HostingUnitKey;
            Dal_XML_imp.AddHostingUnitToXml(My_HostingUnit.Clone());
        }
        public void deleteHostingUnit(HostingUnit My_HostingUnit)
        {
            var L = from item in Dal_XML_imp.GetHostingUnitFromXml()
                    where My_HostingUnit.hosting_unit_key == item.hosting_unit_key
                    select item;
            if (L == null)
            {
                throw new NotImplementedException("not found");
            }
            else
            {
                Dal_XML_imp.RemoveHostingUnitToXml(My_HostingUnit.hosting_unit_key);
                --Configuration.HostingUnitKey;
            }
        }
        public void UpdateHostingUnit(HostingUnit My_HostingUnit)
        {
            foreach (var item in DataSource.My_HostingUnitList)
            {
                if (item.hosting_unit_key == My_HostingUnit.hosting_unit_key)
                {
                    Dal_XML_imp.RemoveHostingUnitToXml(item.hosting_unit_key);
                    --Configuration.HostingUnitKey;
                }
            }
            Dal_XML_imp.AddHostingUnitToXml(My_HostingUnit.Clone());
            ++Configuration.HostingUnitKey;
        }
        public HostingUnit GetName_GiveHostingUnit(string My_Name)
        {

            foreach (var item in Dal_XML_imp.GetHostingUnitFromXml())
            {
                if (item.HostingUnitName == My_Name)
                {
                    return item;
                }
            }
            return null; //השם של היחידה לא נמצא ברשימה
        }

        public void AddOrder(Order My_Order)
        {
            bool ezer = false;
            foreach (var item in Dal_XML_imp.GetOrderFromXml())
            {
                if (item.Order_key == My_Order.Order_key)
                {
                    ezer = true;
                }
            }
            if (ezer == false) // לא נמצא כבר ברשימה
            {
                Dal_XML_imp.AddOrderToXml(My_Order.Clone());
                ++Configuration.OrderKey;
            }
            else // ezer= true
            {
                throw new NotImplementedException("ההזמנה נמצאת כבר ברשימה");

            }
        }

        public void UpdateOrder(Order My_Order)
        {
            bool ezer = false;
            foreach (var item in Dal_XML_imp.GetOrderFromXml())

            {
                if (item.Order_key == My_Order.Order_key)
                {
                    ezer = true;
                    item.Status = My_Order.Status;
                }
            }
            if (ezer == false) //אין את ההזמנה ברשימה
            {
                Dal_XML_imp.AddOrderToXml(My_Order.Clone());
                Configuration.OrderKey++;
                throw new NotImplementedException("The order is not on the list so add again");
            }
        }

        public HostingUnit one_of_available_units(DateTime d1, int days)
        {
            bool Approved = true;
            foreach (var item in Dal_XML_imp.GetHostingUnitFromXml())
            {

                for (int index = 0; index < days; index++, d1 = d1.AddDays(1))
                {

                    if (item.Diary[d1.Month - 1, d1.Day - 1] == true)
                    {
                        Approved = false;
                    }
                }
                if (Approved)// היחידה פנויה
                {
                    return item;

                }
            }
            return null;

        }


        public HostingUnit GetGuestRequest_RrtrunHostingUnit(GuestRequest g)
        {

            foreach (var item in Dal_XML_imp.GetHostingUnitFromXml())
            {
                if (g.Adults == item.Adults && g.Area == item.Area && g.Children == item.Children &&
                g.ChildrensAttractions == item.ChildrensAttractions && g.Pool == item.Pool &&
                g.Jacuzzi == item.Jacuzzi && g.Garden == item.Garden && g.SubArea == item.SubArea &&
                g.Type == item.Type)
                {
                    if (one_of_available_units(g.EntryDate, (g.ReleaseDate - g.EntryDate).Days) != null)
                    {
                        return item;
                    }
                    else
                    {
                        throw new NotImplementedException("התאריכים שבחרת תפוסים אנא בחר תאריכים אחרים ");

                    }
                }
                else
                {
                    throw new NotImplementedException("אין יחידת אירוח שמתאימה לדרישה המבוקשת");
                }
            }
            return null; //לא נימצאה יחידת אירוח שתואמת לדרישות של הלקוח 
        }
        public IEnumerable<HostingUnit> GetHostingUnitList(Func<HostingUnit, bool> predicate = null)
        {
            var v = from item in DataSource.My_HostingUnitList
                    select new HostingUnit();//default constructor!!

            if (predicate == null)
                return v.AsEnumerable().OrderByDescending(s => s.HostingUnitName);

            return v.Where(predicate).OrderByDescending(s => s.HostingUnitName);
        }

        public List<HostingUnit> My_HostingUnitList()
        {
            if (Dal_XML_imp.GetHostingUnitFromXml() == null)
            {
                throw new Exception("רשימת יחידות האירוח ריקה");
            }
            return Dal_XML_imp.GetHostingUnitFromXml().Select(hu => (HostingUnit)hu.Clone()).ToList();
        }

        public List<GuestRequest> My_GuestRequestList()
        {
            if (Dal_XML_imp.GetGuestRequestFromXml() == null)
            {
                throw new NotImplementedException("רשימת דרישות לקוח ריקה");
            }
            return Dal_XML_imp.GetGuestRequestFromXml().Select(hu => (GuestRequest)hu.Clone()).ToList();
        }

        public List<Order> My_OrdersList()
        {
            if (Dal_XML_imp.GetOrderFromXml() == null)
            {
                throw new NotImplementedException("רשימת הזמנות ריקה");
            }
            return Dal_XML_imp.GetOrderFromXml().Select(hu => (Order)hu.Clone()).ToList();
        }

        public List<MyHost> MyHost_List()
        {
            if (Dal_XML_imp.GetMyHostFromXml() == null)
            {
                throw new NotImplementedException("רשימת מארחים ריקה");
            }
            return Dal_XML_imp.GetMyHostFromXml().Select(hu => (MyHost)hu.Clone()).ToList();
        }

        public List<MyGuest> MyGest_List()
        {
            if (Dal_XML_imp.GetGuestFromXml() == null)
            {
                throw new NotImplementedException("רשימת אורחים ריקה");
            }
            return Dal_XML_imp.GetGuestFromXml().Select(hu => (MyGuest)hu.Clone()).ToList();
        }

        public List<BankBranch> My_BankBranchList()
        {
            List<BankBranch> My_BankBranches = new List<BankBranch>()
            {
                new BankBranch()
                {
                    BankNumber=12,
                    BankName="בנק הפועלים",
                    BranchNumber=556,
                    BranchAddress="שדרות ירושלים 11",
                    BranchCity="נתיבות"
                },
                 new BankBranch()
                {
                    BankNumber=10,
                    BankName="בנק לאומי",
                    BranchNumber=638,
                    BranchAddress="מבשרת ציון 154",
                    BranchCity="מבשרת ירושלים"
                },
                new BankBranch()
                {
                    BankNumber=11,
                    BankName="בנק דיסקונט",
                    BranchNumber=1,
                    BranchAddress="האצילים 7",
                    BranchCity="אשקלון"
                },
                new BankBranch()
                {
                    BankNumber=20,
                    BankName="בנק מזרחי טפחות בע'מ",
                    BranchNumber=401,
                    BranchAddress="יפו 101",
                    BranchCity="ירושלים ראשי"
                },
                new BankBranch()
                {
                    BankNumber=4,
                    BankName="בנק יהב בע'מ",
                    BranchNumber=114,
                    BranchAddress="יהודה הנשיא 34",
                    BranchCity="אשדוד"
                },
            };
            return My_BankBranches;
        }
    }
}
