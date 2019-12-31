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
        void addGuestRequest(GuestRequest My_GuestRequest);//הוספת דרישת לקוח
        void Requirement_update(GuestRequest My_GuestRequest); //עידכון דרישת לקוח

        void addHostingUnit(HostingUnit My_HostingUnit); //הוספת יחידת אירוח
        void deleteHostingUnit(HostingUnit My_HostingUnit); //מחיקת יחידת אירוח
        void UpdateHostingUnit(HostingUnit My_HostingUnit);

        void addOrder(Order My_Order);
        void UpdateOrder(Order My_Order);
        
        //functions which returns access to the lists:
        List<HostingUnit> My_HostingUnitList();
        List<GuestRequest> My_GuestRequestList();
        List<Order> My_OrdersList();
        List<BankBranch> My_BankBranchList();
    }
}

