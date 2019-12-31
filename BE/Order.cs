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
        public long n_Order
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
        public static long HostingUnitKey;
        public static long GuestRequestKey;
        public My_enum.Status Status;
        public DateTime CreateDate; //תאריך יציאת ההזמנה 
        public DateTime OrderDate; //תאריך משלוח המייל ללקוח
        public double Amount_to_pay;//סכום לתשלום
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
        //constractor:
        public Order()
        {
            order++;
          

        }
    }
}
