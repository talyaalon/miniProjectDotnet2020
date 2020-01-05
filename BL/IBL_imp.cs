using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using BE;
using DAL;
using DS;

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

        public void addGuestRequest(GuestRequest My_GuestRequest)
        {
            //נקודה 1
            if (My_GuestRequest.EntryDate.Day - My_GuestRequest.ReleaseDate.Day < 1)
            {
                throw new NotImplementedException("תאריך הכניסה שהכנסצ אינו תקין" + "/n" + "בבקשה הכנס תאריך חדש");

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
                    if (item.Status == My_enum.Status.ההזמנה_אושרה)
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
                    if (item.Status == My_enum.Status.ההזמנה_אושרה)
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
                    if (item.Owner.CollectionClearance == My_enum.Yes_Or_No.לא)
                    {
                        throw new NotImplementedException("המארח לא חתם על הרשאת חשבון הבנק");
                    }
                    else //הלקוח כן חתם על ההרשאה לחיוב החשבון
                    {
                        My_Order.Status = My_enum.Status.נשלח_מייל;
                        //נקודה 10:
                        Console.WriteLine("נשלח אלייך מייל עם פרטי ההזמנה");


                        //נקודה 9:
                        throw new NotImplementedException("לא ניתן לשנות את ההרשאה לחיוב החשבון");
                    }
                }
            }
            dal.UpdateOrder(My_Order);
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
                throw new NotImplementedException("מצטערים, התאריכים שהכנסת תפוסים אנא בחר תאריכים אחרים");
            }
            else
            {
                My_Order.Status = My_enum.Status.ההזמנה_אושרה;
                //נקודה 6:
                foreach (var item in DataSource.My_GuestRequestsList)
                {
                    if (item.n_guest_requestkey == My_Order.GuestRequestKey)
                    {
                        item.Status = My_enum.Status.ההזמנה_אושרה; //נקודה 7:
                        foreach (var item2 in DataSource.My_OrdersList)
                        {
                            if (item.n_guest_requestkey == item2.GuestRequestKey)
                            {
                                item2.Status = My_enum.Status.ההזמנה_אושרה;
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

        //נקודה 10:
        public void Sent_Mail(Order My_Order)
        {
            string name_hostingunit;
            MailMessage mail = new MailMessage();
            mail.Subject = "פרטי הזמנה";
            foreach (var item in DataSource.My_OrdersList)
            {
                if (item.GuestRequestKey == My_Order.GuestRequestKey)
                {
                    foreach (var item2 in DataSource.My_GuestRequestsList)
                    {
                        if (item2.n_guest_requestkey == My_Order.GuestRequestKey)
                        {
                            mail.To.Add(item2.MailAddress); //כתובת המייל של הלקוח
                            foreach (var item3 in DataSource.My_HostingUnitList)
                            {
                                if (item3.n_hosting_unit == My_Order.GuestRequestKey)
                                {
                                    mail.From = new MailAddress(item3.Owner.MailAddress);
                                }
                                name_hostingunit = item3.HostingUnitName;
                            }
                            mail.Body = ":שם לקוח" + item2.PrivateName + "/n" +
                                ":שם משפחה" + item2.FamilyName + ".n" +
                             ":תאריכי הנופש" + item2.EntryDate + "-" + item2.ReleaseDate + "/n" +
                              ":מספר הלילות" + ((item2.ReleaseDate.Day - item2.EntryDate.Day) - 1) + "/n" +
                               ":הרכב" + "  " + ":מספר מבוגרים" + item2.Adults + "  " + ":מספר ילדים" + item2.Children + "/n" +
                               item2.Type + ":" + " " +

                            ":הרכב" + "  " + ":מספר מבוגרים" + item2.Adults + "  " + ":מספר ילדים" + item2.Children + "/n";
             
                            ;

                        }


                    }
                }
            }

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("myGmailEmailAddress@gmail.com", "myGmailPassword");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                txtMessage.Text = ex.ToString();
            }
        }


        public void Requirement_update(GuestRequest My_GuestRequest)
        {
            throw new NotImplementedException();
        }

        public void AddHostingUnit(HostingUnit My_HostingUnit)
        {
            throw new NotImplementedException();
        }

        public void deleteHostingUnit(long hosting_unit)
        {
            throw new NotImplementedException();
        }

        public void UpdateHostingUnit(HostingUnit My_HostingUnit)
        {
            throw new NotImplementedException();
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
        public void deleteHostingUnit(HostingUnit My_HostingUnit)
        {
            //נקודה 8:
            foreach (var item in DataSource.My_OrdersList)
            {
                if (item.HostingUnitKey == My_HostingUnit.n_hosting_unit)
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


        public List<HostingUnit> List_of_available_units(DateTime d1, int days)
        {
            List<HostingUnit> returnList = new List<HostingUnit>();
            bool Approved = true;
            foreach (var item in DataSource.My_HostingUnitList)
            {
                for (int index = 0; index < days - 1; index++, d1 = d1.AddDays(1))
                {

                    if (item.Diary[d1.Month, d1.Day] == true)
                    {
                        Approved = false;
                    }
                }
                if (Approved)// היחידה פנויה
                {
                    returnList.Add(item);

                }
            }
            return returnList;
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
            foreach (var item in DataSource.My_OrdersList)
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
            foreach (var item in DataSource.My_OrdersList)
            {
                if (item.GuestRequestKey == My_GuestRequest.n_guest_requestkey)
                {
                    count++;
                }
            }
            return count;
        }
        public int Number_of_orders_accepted(HostingUnit My_HostingUnit)
        {
            int count = 0;
            foreach(var item in DataSource.My_OrdersList)
            {
                if(item.HostingUnitKey== My_HostingUnit.n_hosting_unit)
                {
                    if (item.Status == My_enum.Status.נשלח_מייל || item.Status == My_enum.Status.ההזמנה_אושרה)
                    {
                        count++;
                    }
                }
               
            }
            return count;
        }
        public List<GuestRequest> use_delegate(some_delegate delegete)
        {
            List<GuestRequest> returnList = new List<GuestRequest>();
            foreach (var item in DataSource.My_GuestRequestsList)
            {
                if (delegete(item))
                {
                    returnList.Add(item);
                }
            }
            return returnList;

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
                   group item by (item.Adults+item.Children) into List
                   select List;
        }
        public IEnumerable<IGrouping<string , HostingUnit>> NumOfHostUnit()
        {
            return from item in dal.My_HostingUnitList()
                   group item by (item.Owner.HostKey)
                   into List
                   select List;
        }
        public IEnumerable<IGrouping<My_enum.Area, GuestRequest>> GetHostingUnitByArea()
        {
            return from item in dal.My_GuestRequestList()
                   group item by (item.Area)
                   into List
                   select List;
        }
       

    }
}




