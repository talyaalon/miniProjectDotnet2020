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
            if (My_GuestRequest.EntryDate.Day - My_GuestRequest.ReleaseDate.Day < 1)
            {
                throw new NotImplementedException("Invalid entry date" + "/n" + "Please select a different date");

            }
            dal.AddGuestRequest(My_GuestRequest);
        }


        public void UpdateOrder(Order My_Order)
        {
            //נקודה 4:
            foreach (var item in DataSource.My_OrdersList)
            {
                if (item.n_Order == My_Order.n_Order)
                {
                    if (item.Status == My_enum.Status.invitation_is_confirmed)
                    {
                        throw new NotImplementedException("לא ניתן לשנות את סטטוס ההזמנה");
                    }
                }
            }
            

            //נקודה 5:
            foreach (var item in DataSource.My_OrdersList)
            {
                if (item.n_Order == My_Order.n_Order)
                { 
                    if (item.Status == My_enum.Status.invitation_is_confirmed)
                    {
                        foreach (var item2 in DataSource.My_GuestRequestsList)
                        {
                            if (item2.n_guest_requestkey == My_Order.GuestRequestKey)
                            {
                                int days = item2.ReleaseDate.Day - item2.EntryDate.Day;
                                Configuration.sum_of_fees = 10 * days;
                            }
                        }
                    }
                }
            }

            //נקודה 2:
            foreach (var item in DataSource.My_HostingUnitList)
            {
                if (item.n_hosting_unit == My_Order.HostingUnitKey)
                {
                    if (item.Owner.CollectionClearance == My_enum.Yes_Or_No.No)
                    {
                        throw new NotImplementedException("The Host did not sign the bank account");
                    }
                    else
                    {
                        My_Order.Status = My_enum.Status.mail_sent;
                        dal.UpdateOrder(My_Order);
                    }
                }
            }
        }

        //נקודה 3:
        public void addOrder(Order My_Order)
        {
            bool approved = true;
            foreach (var item in DataSource.My_GuestRequestsList)
            {
                if (item.n_guest_requestkey == My_Order.GuestRequestKey)
                {
                    int days = item.ReleaseDate.Day - item.EntryDate.Day;
                    foreach (var item2 in DataSource.My_HostingUnitList)
                    {
                        if (item2.n_hosting_unit == My_Order.HostingUnitKey)
                        {
                            for (int index = 0; index < days - 1; index++, item.EntryDate = item.EntryDate.AddDays(1))
                            {
                                if (item2.Diary[item.EntryDate.Month, item.EntryDate.Day] == true)
                                {
                                    approved = false;

                                }
                            }
                        }
                    }

                }
            }
            if (!approved)
            {
                throw new NotImplementedException("Sorry, the dates you chose are busy, please select different dates");
            }
            else
            {
                My_Order.Status=My_enum.Status.invitation_is_confirmed;
                //נקודה 6:
                foreach (var item in DataSource.My_GuestRequestsList)
                {
                    if (item.n_guest_requestkey == My_Order.GuestRequestKey)
                    {
                        item.Status = My_enum.Status.invitation_is_confirmed; //נקודה 7:
                        foreach (var item2 in DataSource.My_OrdersList)
                        {
                            if (item.n_guest_requestkey == item2.GuestRequestKey)
                            {
                                item2.Status = My_enum.Status.invitation_is_confirmed;
                            }
                        }
                        //המשךנקודה 6:
                        int days = item.ReleaseDate.Day - item.EntryDate.Day;
                        foreach (var item2 in DataSource.My_HostingUnitList)
                        {
                            if (item2.n_hosting_unit == My_Order.HostingUnitKey)
                            {
                                for (int index = 0; index < days - 1; index++, item.EntryDate = item.EntryDate.AddDays(1))
                                {
                                    item2.Diary[item.EntryDate.Month, item.EntryDate.Day] = true;
                                }
                            }
                        }
                    }
                }
                dal.addOrder(My_Order);
            }
        }


        public void deleteHostingUnit(HostingUnit My_HostingUnit)
        {
          //נקודה 8:
            foreach(var item in DataSource.My_OrdersList)
            {
                if (item.HostingUnitKey == My_HostingUnit.n_hosting_unit)
                {
                    if (item.Status == My_enum.Status.Open)
                    {
                        throw new NotImplementedException("לא ניתן למחוק את יחידת האירוח");
                    }
                    else
                    {
                        dal.deleteHostingUnit(My_HostingUnit);
                    }
                }
            }
            
        }





        public void addHostingUnit(HostingUnit My_HostingUnit)
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

        public void deleteHostingUnit(long hosting_unit)
        {
            throw new NotImplementedException();
        }
    }
}
