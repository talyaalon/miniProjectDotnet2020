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
            bool ezer = false;
            foreach (var item in DataSource.MyGuest_List)
            {
                if(item.Id== My_Guest.Id)
                {
                    ezer = true;
                }
            }
            if (ezer == false) //אין את הלקוח ברשימה
            {
                DataSource.MyGuest_List.Add(My_Guest);
            }
            else
            {
                throw new NotImplementedException("האורח כבר רשום במערכת");
            }
        }

        public void AddHost(MyHost My_Host)
       {

            bool ezer = false;
            foreach (var item in DataSource.MyHost_List)
            {
                if (item.Id == My_Host.Id)
                {
                    ezer = true;
                }
            }
            if (ezer == false) //אין את הלקוח ברשימה
            {
                DataSource.MyHost_List.Add(My_Host);
            }
            else
            {
                throw new NotImplementedException("המארח כבר רשום במערכת");
            }
       }

        public int FindMyGuest(string id)
        {
            int Location = 1;
            bool help = false;
            foreach (var item in DataSource.MyGuest_List)
            {
               if(item.Id== id)
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
            int Location = 1;
            bool help = false;
            foreach (var item in DataSource.MyHost_List)
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
                throw new NotImplementedException("המארח לא נמצא במערכת");
            }
            return 0;
        }

        public int FindGuestRequest(long key)
        {
            int Location = 1;
            bool help = false;
            foreach (var item in DataSource.My_GuestRequestsList)
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
            return 0;
        }

        public int FindHostingUnit(long key)
        {
            int Location = 1;
            bool help = false;
            foreach (var item in DataSource.My_HostingUnitList)
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
            return 0;
        }

        public MyGuest getMyGuest(int Location_list)
        {
            return DataSource.MyGuest_List[Location_list];
        }

        
        public MyHost getMyHost(int Location_list)
        {
            return DataSource.MyHost_List[Location_list];
        }


        public GuestRequest getGuestRequest(int Location_list)
        {
            return DataSource.My_GuestRequestsList[Location_list];
        }


        public HostingUnit getHostingUnit(int Location_list)
        {
            return DataSource.My_HostingUnitList[Location_list];
        }



        public void addGuestRequest(GuestRequest My_GuestRequest)
        {
            //נקודה 1
            if (My_GuestRequest.EntryDate.Day - My_GuestRequest.ReleaseDate.Day < 1)
            {
                throw new NotImplementedException("תאריך הכניסה שהכנסת אינו תקין" + "/n" + "בבקשה הכנס תאריך חדש");

            }
            dal.AddGuestRequest(My_GuestRequest);
        }


        public void UpdateOrder(Order My_Order)
        {
            //נקודה 4:
            foreach (var item in DataSource.My_OrdersList)
            {
                if (item.Order_key == My_Order.Order_key)
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
                if (item.Order_key == My_Order.Order_key)
                {
                    if (item.Status == My_enum.Status.ההזמנה_אושרה)
                    {
                        foreach (var item2 in DataSource.My_GuestRequestsList)
                        {
                            if (item2.guest_request_key == My_Order.GuestRequestKey)
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
                if (item.hosting_unit_key == My_Order.HostingUnitKey)
                {
                    if (item.Owner.CollectionClearance == My_enum.Yes_Or_No.לא)
                    {
                        throw new NotImplementedException("המארח לא חתם על הרשאת חשבון הבנק");
                    }
                    else //הלקוח כן חתם על ההרשאה לחיוב החשבון
                    {
                        My_Order.Status = My_enum.Status.נשלח_מייל;
                        //נקודה 10:
                       // MessageBox_Project(" שים לב", "נשלח אלייך מייל עם פרטי ההזמנה");

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
                if (item.guest_request_key == My_Order.GuestRequestKey)
                {
                    int days = item.ReleaseDate.Day - item.EntryDate.Day;
                    foreach (var item2 in DataSource.My_HostingUnitList)
                    {
                        if (item2.hosting_unit_key == My_Order.HostingUnitKey)
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
                    if (item.guest_request_key == My_Order.GuestRequestKey)
                    {
                        item.Status = My_enum.Status.ההזמנה_אושרה; //נקודה 7:
                        foreach (var item2 in DataSource.My_OrdersList)
                        {
                            if (item.guest_request_key == item2.GuestRequestKey)
                            {
                                item2.Status = My_enum.Status.ההזמנה_אושרה;
                            }
                        }
                        //המשךנקודה 6:
                        int days = item.ReleaseDate.Day - item.EntryDate.Day;
                        foreach (var item2 in DataSource.My_HostingUnitList)
                        {
                            if (item2.hosting_unit_key == My_Order.HostingUnitKey)
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
            GuestRequest temp_GuestRequest = getGuestRequest(FindGuestRequest(My_Order.GuestRequestKey));
            HostingUnit temp_HostingUnit = getHostingUnit(FindHostingUnit(My_Order.HostingUnitKey));

            string to = temp_GuestRequest.MailAddress; //send mail to the Admin


            //to make sure the mail will work on any other computers:
            string keep = System.Environment.CurrentDirectory;
            const string removeString = @"\bin\Debug";
            string read = keep.Remove(keep.IndexOf(removeString), removeString.Length) + @"\pictures\NewMail.html";

            string mailbody = File.ReadAllText(read);
           
            mailbody = mailbody.Replace(",שלום רב", " " + temp_GuestRequest.PrivateName + " " + temp_GuestRequest.FamilyName + ": " + "/n" + "הזמנתך הושלמה בהצלחה");
            mailbody = mailbody.Replace(":פרטי הזמנה", "/n");
            mailbody = mailbody.Replace(":תאריך כניסה" , " ");
           
                              
            string from = "talyaandefrat@gmail.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = ":פרטי הזמנה";
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.UTF8;
            message.Body = mailbody;


            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            NetworkCredential basicCredential = new NetworkCredential("talyaandefrat@gmail.com", "te50930225");
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = basicCredential;
        }
    
      /* mail.Body = ":שם לקוח" + item2.PrivateName + "/n" +
                                ":שם משפחה" + item2.FamilyName + ".n" +
                             ":תאריכי הנופש" + item2.EntryDate + "-" + item2.ReleaseDate + "/n" +
                              ":מספר הלילות" + ((item2.ReleaseDate.Day - item2.EntryDate.Day) - 1) + "/n" +
                               ":הרכב" + "  " + ":מספר מבוגרים" + item2.Adults + "  " + ":מספר ילדים" + item2.Children + "/n" +
                               item2.Type + ":" + " " +
                                name_hostingunit = item3.HostingUnitName
                            ":הרכב" + "  " + ":מספר מבוגרים" + item2.Adults + "  " + ":מספר ילדים" + item2.Children + "/n";
             
                            ;

                        }


                    }
                }
            }*/

           
       

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
            foreach(var item in DataSource.My_OrdersList)
            {
                if(item.HostingUnitKey== My_HostingUnit.hosting_unit_key)
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

        public double Calculation_amount_to_pay(Order My_Order)
        {
            throw new NotImplementedException();
        }
    }
}




