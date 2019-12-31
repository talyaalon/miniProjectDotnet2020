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
        //public static List<HostingUnit> My_HostingUnitList = new List<HostingUnit>();
        //public static List<GuestRequest> My_guestRequestsList;//= new List<GuestRequest>();
        //public static List<Order> My_ordersList = new List<Order>(); 
        public Dal_imp()
        {

        }
        public void addGuestRequest(GuestRequest My_GuestRequest) //הוספת דרישת לקוח
        {
            bool ezer = false;
            foreach (var item in DataSource.My_GuestRequestsList)
            {
                if (item.n_guest_requestkey == My_GuestRequest.n_guest_requestkey)
                {
                    ezer = true;
                }
            }
            if (ezer == false) //אין את הלקוח ברשימה
            {
                DataSource.My_GuestRequestsList.Add(My_GuestRequest);
                Configuration.GuestRequestKey++;
            }
            else
            {
                throw new NotImplementedException("The customer is already on the list");
            }
        }
        void IDAL.Requirement_update(GuestRequest My_GuestRequest)// עידכון דרישת לקוח- עידכון סטטוס 
        {
            bool ezer = false;
            foreach (var item in DataSource.My_GuestRequestsList)
            {
                if (item.n_guest_requestkey == My_GuestRequest.n_guest_requestkey)
                {
                    ezer = true;
                    item.Status = My_GuestRequest.Status;
                }
            }
            if (ezer == false) //אין את הלקוח ברשימה
            {
                DataSource.My_GuestRequestsList.Add(My_GuestRequest);
                Configuration.GuestRequestKey++;
                throw new NotImplementedException("The customer is not on the list so add again");
            }
        }

        void IDAL.addHostingUnit(HostingUnit My_HostingUnit) //הוספת יחידת אירוח
        {
            bool ezer = false;
            foreach (var item in DataSource.My_HostingUnitList)
            {
                if (item.n_hosting_unit == My_HostingUnit.n_hosting_unit)
                {
                    ezer = true;
                }
            }
            if (ezer == false)
            {
                DataSource.My_HostingUnitList.Add(My_HostingUnit);
                Configuration.HostingUnitKey++;
            }
            else
            {
                throw new NotImplementedException("The unit is already on the list");
            }
        }

        public void deleteHostingUnit(HostingUnit My_HostingUnit)
        {
            bool ezer = false;
            foreach (var item in DataSource.My_HostingUnitList)
            {
                if (item.n_hosting_unit == My_HostingUnit.n_hosting_unit)
                {
                    ezer = true;
                    DataSource.My_HostingUnitList.Remove(My_HostingUnit);
                    Configuration.HostingUnitKey--;
                }
            }
            if (ezer == false)
            {
                throw new NotImplementedException("not found");
            }
        }
        public void UpdateHostingUnit(HostingUnit My_HostingUnit)
        {
            foreach (var item in DataSource.My_HostingUnitList)
            {
                if (item.n_hosting_unit == My_HostingUnit.n_hosting_unit)
                {
                    DataSource.My_HostingUnitList.Remove(item);
                    Configuration.HostingUnitKey--;
                }
            }
            DataSource.My_HostingUnitList.Add(My_HostingUnit);
            Configuration.HostingUnitKey++;
        }

        public void addOrder(Order My_Order)
        {
            bool ezer = false;
            foreach (var item in DataSource.My_OrdersList)
            {
                if (item.n_Order == My_Order.n_Order)
                {
                    ezer = true;
                }
            }
            if (ezer == false) // לא נמצא כבר ברשימה
            {
                DataSource.My_OrdersList.Add(My_Order);
                Configuration.OrderKey++;
            }
            else // ezer= true
            {
                throw new NotImplementedException("the order is already on the list");

            }
        }

        public void UpdateOrder(Order My_Order)
        {
            bool ezer = false;
            foreach (var item in DataSource.My_OrdersList)
            {
                if (item.n_Order == My_Order.n_Order)
                {
                    ezer = true;
                    item.Status = My_Order.Status;
                }
            }
            if (ezer == false) //אין את ההזמנה ברשימה
            {
                DataSource.My_OrdersList.Add(My_Order);
                Configuration.OrderKey++;
                throw new NotImplementedException("The order is not on the list so add again");
            }
        }

        public List<HostingUnit> My_HostingUnitList()
        {
            return DataSource.My_HostingUnitList;
        }

        public List<GuestRequest> My_GuestRequestList()
        {
            return DataSource.My_GuestRequestsList;
        }

        public List<Order> My_OrdersList()
        {
            return DataSource.My_OrdersList;
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
                    BranchCity="נתיבות",
                    BankAccountNumber ="480686"
                },
                 new BankBranch()
                {
                    BankNumber=10,
                    BankName="בנק לאומי",
                    BranchNumber=638,
                    BranchAddress="מבשרת ציון 154",
                    BranchCity="מבשרת ירושלים",
                    BankAccountNumber ="452286"
                },
                new BankBranch()
                {
                    BankNumber=11,
                    BankName="בנק דיסקונט",
                    BranchNumber=1,
                    BranchAddress="האצילים 7",
                    BranchCity="אשקלון",
                    BankAccountNumber ="223986"
                },
                new BankBranch()
                {
                    BankNumber=20,
                    BankName="בנק מזרחי טפחות בע'מ",
                    BranchNumber=401,
                    BranchAddress="יפו 101",
                    BranchCity="ירושלים ראשי",
                    BankAccountNumber ="772195"
                },
                new BankBranch()
                {
                    BankNumber=4,
                    BankName="בנק יהב בע'מ",
                    BranchNumber=114,
                    BranchAddress="יהודה הנשיא 34",
                    BranchCity="אשדוד",
                    BankAccountNumber ="854990"
                },
            };
            return My_BankBranches; 
        }
    }
}
    
