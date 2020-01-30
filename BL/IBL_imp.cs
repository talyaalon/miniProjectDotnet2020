using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using BE;
using DAL;
using DS;
using System.IO;
using System.Net;

namespace BL
{
    public delegate bool some_delegate(GuestRequest My_GuestRequest);
    public class IBL_imp : IBL
    {
        //Access to the data Files
        DAL.IDAL dal;
        public IBL_imp()
        {
            dal = DAL.Factory_DAL.getDal();
        }

        public void AddGuest(MyGuest My_Guest)
        {
            dal.AddGuest(My_Guest);
        }

        public int FindMyGuest(string id)
        {
            return dal.FindMyGuest(id);

        }

        public MyGuest getMyGuest(int Location_list)
        {
            return dal.getMyGuest(Location_list);
        }


        public void AddHost(MyHost My_Host)
        {

            dal.AddHost(My_Host);
        }

        public int FindMyHost(string id)
        {
            return dal.FindMyHost(id);
        }

        public MyHost getMyHost(int Location_list)
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

        public void AddGuestRequest(GuestRequest My_GuestRequest)
        {
            //נקודה 1
            int days = (My_GuestRequest.ReleaseDate - My_GuestRequest.EntryDate).Days;
            if (days < 1)
            {
                throw new NotImplementedException("תאריך הכניסה שהכנסת אינו תקין בבקשה הכנס תאריך חדש");
            }
            dal.AddGuestRequest(My_GuestRequest);
            //List_of_available_units(My_GuestRequest.EntryDate, days);
        }


        public void update_GuestRequest(GuestRequest My_GuestRequest)
        {
            dal.update_GuestRequest(My_GuestRequest);
        }

        public int FindGuestRequest(long key)
        {
            int Location = 0;
            bool help = false;
            foreach (var item in Dal_XML_imp.GetGuestRequestFromXml())
            {
                if (item.guest_request_key == key)
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
            return -1;
        }



        public GuestRequest getGuestRequest(int Location_list) //מקבל מיקום של דרישת לקוח מחזיר את הדרישה
        {
            if (Location_list >= 0)
            {
                return Dal_XML_imp.GetGuestRequestFromXml(Location_list);

            }
            else
            {
                throw new NotImplementedException("דרישת הלקוח  לא נמצאה במערכת");
            }

        }

        public GuestRequest Getid_GiveGuestRequest(string ID_of_Guest) //מחזיר אובייקט
        {
            foreach (var item in Dal_XML_imp.GetGuestRequestFromXml())
            {
                if (item.ID_of_Guest == ID_of_Guest)
                {
                    return item;
                }
            }
            return null; //המפתח לא נמצא ברשימה
        }

        public void AddHostingUnit(HostingUnit My_HostingUnit)
        {

            dal.AddHostingUnit(My_HostingUnit);
        }

        public void deleteHostingUnit(HostingUnit My_HostingUnit)
        {
            //נקודה 8:
            foreach (var item in Dal_XML_imp.GetOrderFromXml())
            {
                if (item.HostingUnitKey == My_HostingUnit.hosting_unit_key)
                {
                    if (item.Status == My_enum.Status.טרם_טופל)
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
        public void UpdateHostingUnit(HostingUnit My_HostingUnit)
        {
            dal.UpdateHostingUnit(My_HostingUnit);

        }

        public int FindHostingUnit(long key)
        {
            int Location = 0;
            bool help = false;
            foreach (var item in Dal_XML_imp.GetHostingUnitFromXml())
            {
                if (item.hosting_unit_key == key)
                {
                    help = true;
                    return Location;

                }
                Location++;
            }
            if (help == false)
            {
                throw new NotImplementedException("יחידת האירוח לא נמצאה במערכת");
            }
            return -1;
        }


        public HostingUnit getHostingUnit(int Location_list)
        {
            if (Location_list >= 0)
            {
                return Dal_XML_imp.GetHostingUnitFromXml(Location_list);
            }
            else
            {
                throw new NotImplementedException("יחידת האירוח לא נמצאה במערכת");

            }

        }

        public HostingUnit GetName_GiveHostingUnit(string My_Name)
        {
            return dal.GetName_GiveHostingUnit(My_Name);
        }
        //נקודה 3:
        public List<HostingUnit> GetHostingUnitList()
        {
            return Dal_XML_imp.GetHostingUnitFromXml();
        }
        public void AddOrder(Order My_Order)
        {
            HostingUnit temp1 = getHostingUnit(FindHostingUnit(My_Order.HostingUnitKey)); // קבלת  יחידת אירוח המדוברת בהזמנה 
            if (temp1.Owner.CollectionClearance == My_enum.Yes_Or_No.לא)
            {
                throw new NotImplementedException(" המארח לא חתם על הרשאת חשבון הבנק ולכן לא יכול לשלוח מייל ללקוחות");
            }
            else //המארח כן חתם על ההרשאה לחיוב החשבון
            {
                My_Order.Status = My_enum.Status.נשלח_מייל;
                Sent_Mail(My_Order);
            }
            
           //נקודה 6:
           GuestRequest temp2 = getGuestRequest(FindGuestRequest(My_Order.GuestRequestKey)); // קבלת דרישת לקוח המדוברת בהזמנה 
            temp2.Status = My_enum.Status.ההזמנה_אושרה;
            foreach (var item2 in Dal_XML_imp.GetOrderFromXml())
            {
                if (temp2.guest_request_key == item2.GuestRequestKey)
                {
                    item2.Status = My_enum.Status.ההזמנה_אושרה;
                }
            }
            //המשך נקודה 6:
            int days = (temp2.ReleaseDate - temp2.EntryDate).Days;
            for (int index = 0; index < days - 1; index++, temp2.EntryDate = temp2.EntryDate.AddDays(1))
            {
                temp1.Diary[temp2.EntryDate.Month, temp2.EntryDate.Day] = true; //שינוי במטריצה
            }
            dal.AddOrder(My_Order);
        }
        public void UpdateOrder(Order My_Order)
        {
            //נקודה 4:
            foreach (var item in Dal_XML_imp.GetOrderFromXml())
            {
                if (item.Order_key == My_Order.Order_key)
                {
                    if (item.Status == My_enum.Status.ההזמנה_אושרה)
                    {
                        throw new NotImplementedException("לא ניתן לשנות את סטטוס ההזמנה");
                    }
                }
            }
            dal.UpdateOrder(My_Order);
        }




        //נקודה 10:
        public void Sent_Mail(Order My_Order)
        {
            GuestRequest temp_GuestRequest = getGuestRequest(FindGuestRequest(My_Order.GuestRequestKey));
            HostingUnit temp_HostingUnit = getHostingUnit(FindHostingUnit(My_Order.HostingUnitKey));



            //  if everything is ok, send the mail:
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(temp_GuestRequest.MailAddress);
            mail.From = new System.Net.Mail.MailAddress("talyaandefrat@gmail.com");
            //Subject of the messege
            mail.Subject = "פרטי הזמנה";
            mail.Body = "  שלום רב, הזמנתך אושרה במערכת" + "\n"; 
            mail.Body = mail.Body + ":פרטי ההזמנה הם" + "\n";
            mail.Body = mail.Body + "תאריך כניסה:  ";
            mail.Body = mail.Body + temp_GuestRequest.EntryDate + "\n";
            mail.Body = mail.Body + "תאריך יציאה:  ";
            mail.Body = mail.Body + temp_GuestRequest.ReleaseDate + "\n";
           

            mail.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            NetworkCredential basicCredential = new NetworkCredential("talyaandefrat@gmail.com", "tel1234*");
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = basicCredential;
            smtp.Send(mail);


        }
      
        public HostingUnit one_of_available_units(DateTime d1, int days)
        {
            return dal.one_of_available_units(d1, days);

        }
        public List<HostingUnit> List_of_available_units(DateTime d1, int days)
        {
            List<HostingUnit> ReturnList = new List<HostingUnit>();

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
                    ReturnList.Add(item);

                }
            }
            return ReturnList;
        }

        public int Two_or_one_date(params DateTime[] array)
        {
            if (array.Length == 1) // קיבלנו תאריך אחד 
            {
                DateTime dateNow = DateTime.Now; //התאריך של היום
                if (dateNow > array[0]) //התאריך של היום יותר מאוחר
                {
                    return (dateNow - array[0]).Days;//מחזיר את מספר הימים
                }
                if (dateNow < array[0]) //התאריך שקיבלנו בפונקציה יותר מאוחר
                {
                    return (array[0] - dateNow).Days;

                }
                else
                {
                    return 0;
                }

            }
            else //קיבלנו 2 תאריכים
            {
                if (array[0] > array[1])
                {
                    return (array[0] - array[1]).Days;
                }
                if (array[0] < array[1])
                {
                    return (array[1] - array[0]).Days;
                }
                else //במידה והתאריכים שווים
                {
                    return 0;
                }

            }

        }

        public List<Order> Large_list_of_time_orders(int days)
        {
            List<Order> returnList = new List<Order>();
            DateTime dateNow = DateTime.Now; //התאריך של היום
            int difference1;
            int difference2;
            foreach (var item in Dal_XML_imp.GetOrderFromXml())
            {
                difference1 = (dateNow - item.CreateDate).Days; //ההפרש בין התאריך של היום ליצירת ההזמנה
                difference2 = (dateNow - item.OrderDate).Days; // ההפרש בין התאריך של היום לתאריך שליחת המייל
                if (difference1 >= days || difference2 >= days)
                {
                    returnList.Add(item);
                }
            }
            return returnList;
        }

        public int Number_of_orders(GuestRequest My_GuestRequest)
        {
            int count = 0;
            foreach (var item in Dal_XML_imp.GetOrderFromXml())
            {
                if (item.GuestRequestKey == My_GuestRequest.guest_request_key)
                {
                    count++;
                }
            }
            return count;
        }
        public int Number_of_orders_accepted(HostingUnit My_HostingUnit)
        {
            int count = 0;
            foreach (var item in Dal_XML_imp.GetOrderFromXml())
            {
                if (item.HostingUnitKey == My_HostingUnit.hosting_unit_key)
                {
                    if (item.Status == My_enum.Status.נשלח_מייל || item.Status == My_enum.Status.ההזמנה_אושרה)
                    {
                        count++;
                    }
                }

            }
            return count;
        }
        public List<Order> GetOrderList()
        {
            return Dal_XML_imp.GetOrderFromXml();
        }
        public List<GuestRequest> use_delegate(some_delegate delegete)
        {
            List<GuestRequest> returnList = new List<GuestRequest>();
            foreach (var item in Dal_XML_imp.GetGuestRequestFromXml())
            {
                if (delegete(item))
                {
                    returnList.Add(item);
                }
            }
            return returnList;

        }
        public HostingUnit GetGuestRequest_RrtrunHostingUnit(GuestRequest g)
        {
            return dal.GetGuestRequest_RrtrunHostingUnit(g);

        }
        public double Calculation_amount_to_pay(GuestRequest my_guest, HostingUnit my_hostunit) //פונקציה שמחשבת סכום לתשלום, פונקציה חדשה שלנו 
        {
            int days = (my_guest.ReleaseDate - my_guest.EntryDate).Days;
            double sum_of_Adults = days * my_guest.Adults * my_hostunit.price_Of_Night_To_Adult;
            double sum_of_chilrens = days * my_guest.Children * my_hostunit.price_Of_Night_To_Child;
            return (sum_of_Adults + sum_of_chilrens) + (days * Configuration.sum_of_fees);
        }

        //Grouping 
        public IEnumerable<IGrouping<My_enum.Area, GuestRequest>> GetGuestRequestsByArea()
        {
            return from item in dal.My_GuestRequestList()
                   group item by item.Area into List
                   select List;
        }
        public IEnumerable<IGrouping<int, GuestRequest>> GetGuestRequestsByPoeple()
        {
            return from item in dal.My_GuestRequestList()
                   group item by (item.Adults + item.Children) into List
                   select List;
        }
        public IEnumerable<IGrouping<string, HostingUnit>> NumOfHostUnit()
        {
            return from item in dal.My_HostingUnitList()
                   group item by item.Owner.Id_host
                   into List
                   select List;
        }
        public IEnumerable<IGrouping<My_enum.Area, GuestRequest>> GetHostingUnitByArea()
        {
            return from item in dal.My_GuestRequestList()
                   group item by item.Area
                   into List
                   select List;
        }



        public List<HostingUnit> My_HostingUnitList()
        {
            throw new NotImplementedException();
        }

        public List<GuestRequest> My_guestRequestsList()
        {
            throw new NotImplementedException();
        }

        public List<Order> My_OrdersList()
        {
            throw new NotImplementedException();
        }

        public List<BankBranch> My_BankBranchList()
        {
            throw new NotImplementedException();
        }
    }
}






