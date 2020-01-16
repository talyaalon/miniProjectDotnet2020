using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Order
    {
        public static long order = Configuration.OrderKey;
        public long Order_key
        {
            get
            {
                return order;
            }
            set
            {
                order = value;
            }
        }
        public long HostingUnitKey;
        public long GuestRequestKey;
        public My_enum.Status Status;
        public DateTime CreateDate; //תאריך יציאת ההזמנה 
        public DateTime OrderDate; //תאריך משלוח המייל ללקוח
        //סכום לתשלום
        public double Amount_to_pay;
       
        
        
        public override string ToString()
        {
            return "OrderKey: " + order + "\n" +
                   "HostingUnitKey: " + HostingUnitKey + "\n" +
                   "GuestRequestKey: " + GuestRequestKey + "\n" +
                   "Status: " + Status + "\n" +
                   "CreateDate: " + CreateDate + "\n" +
                   "OrderDate: " + OrderDate + "\n" +
                   "Amount_to_pay: " + Amount_to_pay + "\n";
        }
        //diffult constractor:
        public Order()
        { 

        }
        //constractor:
        public Order(long  My_HostingUnitKey,long  my_GuestRequestKey, My_enum.Status my_Status=0,
            DateTime my_CreateDate= new DateTime(), DateTime my_OrderDate = new DateTime(), double my_Amount_to_pay=0)
        { 
            Status = my_Status;
            CreateDate = my_CreateDate;
            OrderDate = my_OrderDate;
            Amount_to_pay = my_Amount_to_pay;
        }
    }
}
