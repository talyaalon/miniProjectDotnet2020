using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
   public interface IBL
   {
        void AddGuest(MyGuest My_Guest); //פונקציה שמוסיפה לרשימה של האורחים שרשומים למערכת עוד איבר
        int FindMyGuest(string id);//מחזיר מיקום ברשימה של התז המבוקשת
        MyGuest getMyGuest(int Location_list);//מחזיר (נואד) מתוך הרשימה לפי התז שהתקבל

        void AddHost(MyHost My_Host);// פונקציה שמוסיפה לרשימה של המארחים שרשומים למערכת עוד איבר
        int FindMyHost(string id);//מחזיר מיקום ברשימה של התז המבוקשת
        MyHost getMyHost(int Location_list);//    "

        void AddGuestRequest(GuestRequest My_GuestRequest);//הוספת דרישת לקוח
        void update_GuestRequest(GuestRequest My_GuestRequest); //עידכון דרישת לקוח
        int FindGuestRequest(long key);
        GuestRequest getGuestRequest(int Location_list);
        GuestRequest Getid_GiveGuestRequest(string ID_of_Guest);


        void AddHostingUnit(HostingUnit My_HostingUnit); //הוספת יחידת אירוח
        void deleteHostingUnit(HostingUnit My_HostingUnit); //מחיקת יחידת אירוח
        void UpdateHostingUnit(HostingUnit My_HostingUnit);
        int FindHostingUnit(long key);
        HostingUnit getHostingUnit(int Location_list);
        HostingUnit GetName_GiveHostingUnit(string My_Name);
        List<HostingUnit> GetHostingUnitList();

        void AddOrder(Order My_Order);
        void UpdateOrder(Order My_Order);

        void Sent_Mail(Order My_Order);
        double Calculation_amount_to_pay(GuestRequest my_guest, HostingUnit my_hostunit); //פונקציה שמחשבת סכום לתשלום, פונקציה חדשה שלנו 
        

        HostingUnit one_of_available_units(DateTime d1, int days); //מחזיר איבר בודד 
        List<HostingUnit> List_of_available_units(DateTime d1, int days); // מחזיר רשימה 
        int Two_or_one_date(params DateTime[] array); // פונקציה 2
        List<Order> Large_list_of_time_orders(int days); //פונקציה 3
        int Number_of_orders(GuestRequest My_GuestRequest); //פונקציה 5
        int Number_of_orders_accepted(HostingUnit My_HostingUnit);//פונקציה 6
        List<GuestRequest> use_delegate(some_delegate delegete); //פונקציה 4

        HostingUnit GetGuestRequest_RrtrunHostingUnit(GuestRequest g);


        //functions which returns access to the lists:
        List<HostingUnit> My_HostingUnitList();
        List<GuestRequest> My_guestRequestsList();
        List<Order> My_OrdersList();
        List<BankBranch> My_BankBranchList();
    }
}
