using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface IDAL
    {
        void AddGuestRequest(GuestRequest My_GuestRequest);//הוספת דרישת לקוח
        void update_GuestRequest(GuestRequest My_GuestRequest); //עידכון דרישת לקוח

        void AddHostingUnit(HostingUnit My_HostingUnit); //הוספת יחידת אירוח
        void deleteHostingUnit(HostingUnit My_HostingUnit); //מחיקת יחידת אירוח
        void UpdateHostingUnit(HostingUnit My_HostingUnit);
        HostingUnit GetName_GiveHostingUnit(string My_Name);
        

        void AddGuest(MyGuest My_Guest); //פונקציה שמוסיפה לרשימה של האורחים שרשומים למערכת עוד איבר
        void AddHost(MyHost My_Host);// פונקציה שמוסיפה לרשימה של המארחים שרשומים למערכת עוד איבר
        int FindMyGuest(string id);//מחזיר מיקום ברשימה של התז המבוקשת
        int FindGuestRequest(long key);
        int FindMyHost(string id);//מחזיר מיקום ברשימה של התז המבוקשת
        GuestRequest getMyGuestRequest(int Location_list);
        MyGuest getMyGuest(int Location_list);//מחזיר (נואד) מתוך הרשימה לפי התז שהתקבל
        MyHost getMyHost(int Location_list);//   
        void AddOrder(Order My_Order);
        void UpdateOrder(Order My_Order);
        HostingUnit GetGuestRequest_RrtrunHostingUnit(GuestRequest g);
        HostingUnit one_of_available_units(DateTime d1, int days);
        //functions which returns access to the lists:
        List<HostingUnit> My_HostingUnitList();
        List<GuestRequest> My_GuestRequestList();
        List<Order> My_OrdersList();
        List<BankBranch> My_BankBranchList();
        
    }
}

