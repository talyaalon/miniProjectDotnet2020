using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLWPF
{
   class CheckEnums
   { 
      public static My_enum.Area CheckArea(string a)
      {
            if (a == My_enum.Area.צפון.ToString())
            {
                return My_enum.Area.צפון;
            }
            if (a == My_enum.Area.דרום.ToString())
            {
           return My_enum.Area.דרום;
            }
            if (a == My_enum.Area.מרכז.ToString())
            {
                return My_enum.Area.מרכז;
            }
            if (a == My_enum.Area.ירושלים.ToString())
            {
                return My_enum.Area.ירושלים;
            }
            return My_enum.Area.הכל;
      }

        public static My_enum.Status CheckStatus(string a)
        {
            if (a == My_enum.Status.ההזמנה_אושרה.ToString())
            {
                return My_enum.Status.ההזמנה_אושרה;
            }
            if (a == My_enum.Status.טרם_טופל.ToString())
            {
                return My_enum.Status.טרם_טופל;
            }
            if (a == My_enum.Status.נסגר_מחוסר_הענות_של_הלקוח.ToString())
            {
                return My_enum.Status.נסגר_מחוסר_הענות_של_הלקוח;
            }
            if (a == My_enum.Status.נשלח_מייל.ToString())
            {
                return My_enum.Status.נשלח_מייל;
            }
            return My_enum.Status.טרם_טופל;
        }
        public static My_enum.Type CheckType(string a)
        {
            if (a == My_enum.Type.אוהל.ToString())
            {
                return My_enum.Type.אוהל;
            }
            if (a == My_enum.Type.מלון.ToString())
            {
                return My_enum.Type.מלון;
            }
            if (a == My_enum.Type.צימר.ToString())
            {
                return My_enum.Type.צימר;
            }
            if (a == My_enum.Type.קמפינג.ToString())
            {
                return My_enum.Type.קמפינג;
            }
            return My_enum.Type.הכל;
        }

   
        public static My_enum.Yes_Or_No CheckYes_Or_No(string a)
        {
            if (a == My_enum.Yes_Or_No.כן.ToString())
            {
                return My_enum.Yes_Or_No.כן;
            }
            if (a == My_enum.Yes_Or_No.לא.ToString())
            {
                return My_enum.Yes_Or_No.לא;
            }
            return My_enum.Yes_Or_No.לא;
        }

        /*public static My_enum.TypePersone CheckTypePersone(string a)
        {
            if (a == My_enum.TypePersone.אורח.ToString())
            {
                return My_enum.TypePersone.אורח;
            }
            if (a == My_enum.TypePersone.מארח.ToString())
            {
                return My_enum.TypePersone.מארח;
            }
            return My_enum.TypePersone.;*/
        

    }
}
