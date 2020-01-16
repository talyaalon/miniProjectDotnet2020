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
        void addGuestRequest(GuestRequest My_GuestRequest);//הוספת דרישת לקוח
        void Requirement_update(GuestRequest My_GuestRequest); //עידכון דרישת לקוח

        void AddHostingUnit(HostingUnit My_HostingUnit); //הוספת יחידת אירוח
        void deleteHostingUnit(long hosting_unit); //מחיקת יחידת אירוח
        void UpdateHostingUnit(HostingUnit My_HostingUnit);

        void AddGuest(MyGuest My_Guest); //פונקציה שמוסיפה לרשימה של האורחים שרשומים למערכת עוד איבר
        void AddHost(MyHost My_Host);// פונקציה שמוסיפה לרשימה של המארחים שרשומים למערכת עוד איבר
        MyGuest getMyGuest(int Location_list);//מחזיר (נואד) מתוך הרשימה לפי התז שהתקבל
        MyHost getMyHost(int Location_list);//    "
        int FindMyGuest(string id);//מחזיר מיקום ברשימה של התז המבוקשת
        int FindMyHost(string id);//מחזיר מיקום ברשימה של התז המבוקשת


        double Calculation_amount_to_pay(Order My_Order);
        void addOrder(Order My_Order);
        void UpdateOrder(Order My_Order);

        List<HostingUnit> List_of_available_units(DateTime d1, int days); //פונקציה 1
        int Two_or_one_date(params DateTime[] array); // פונקציה 2
        List<Order> Large_list_of_time_orders(int days); //פונקציה 3
        List<GuestRequest> use_delegate(some_delegate delegete); //פונקציה 4
        int Number_of_orders(GuestRequest My_GuestRequest); //פונקציה 5
        int Number_of_orders_accepted(HostingUnit My_HostingUnit);//פונקציה 6
       
        //functions which returns access to the lists:
        List<HostingUnit> My_HostingUnitList();
        List<GuestRequest> My_guestRequestsList();
        List<Order> My_OrdersList();
        List<BankBranch> My_BankBranchList();
    }
}
