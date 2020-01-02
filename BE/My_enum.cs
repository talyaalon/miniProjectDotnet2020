using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class My_enum
    {
        public enum Status { טרם_טופל, נשלח_מייל, נסגר_מחוסר_הענות_של_הלקוח, ההזמנה_אושרה }
        public enum Area { הכל, צפון, דרום, מרכז, ירושלים }
        public enum Type { צימר, מלון, קמפינג, אוהל }
        public enum Areaoptions { הכרחי, אפשרי, לא_מעוניין }
        public enum Yes_Or_No { כן, לא }

    }
}
