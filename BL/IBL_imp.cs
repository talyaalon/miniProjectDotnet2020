using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using DS;

namespace BL
{
    public class IBL_imp : IBL
    {
        //Access to the data Files
        DAL.IDAL dal;
        public IBL_imp()
        {
            dal = DAL.Factory_DAL.getDal();
        }
   
        public void addGuestRequest(GuestRequest My_GuestRequest)
        {
            //נקודה 1
            if(My_GuestRequest.EntryDate.Day - My_GuestRequest.ReleaseDate.Day < 1 )
            {
                throw new NotImplementedException("Invalid entry date" + "/n" + "Please select a different date");
                
            }
            dal.AddGuestRequest(My_GuestRequest);
        }

        //נקודה 2:
        public void UpdateOrder(Order My_Order)
        {
            from item in DataSource.My_HostingUnitList
            were
    
            foreach (var item in)
            {
                if (item.n_hosting_unit == My_Order.HostingUnitKey)
                {
                    if (item.Owner.CollectionClearance == My_enum.Yes_Or_No.No)
                        throw new NotImplementedException("The Host did not sign the bank account");
                    else
                        My_Order.Status = My_enum.Status.mail_sent;

                }
            }
        }

        public void addHostingUnit(HostingUnit My_HostingUnit)
        {
            throw new NotImplementedException();
        }

        public void addOrder(Order My_Order)
        {
            throw new NotImplementedException();
        }

        public void deleteHostingUnit(long hosting_unit)
        {
            throw new NotImplementedException();
        }

        public List<BankBranch> My_BankBranchList()
        {
            throw new NotImplementedException();
        }

        public List<GuestRequest> My_guestRequestsList()
        {
            throw new NotImplementedException();
        }

        public List<HostingUnit> My_HostingUnitList()
        {
            throw new NotImplementedException();
        }

        public List<Order> My_OrdersList()
        {
            throw new NotImplementedException();
        }

        public void Requirement_update(GuestRequest My_GuestRequest)
        {
            throw new NotImplementedException();
        }

        public void UpdateHostingUnit(HostingUnit My_HostingUnit)
        {
            throw new NotImplementedException();
        }

        
    }
}
