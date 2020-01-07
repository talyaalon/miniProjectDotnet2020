using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class HostingUnit
    {
        public static long hosting_unit = Configuration.HostingUnitKey;
        public long hosting_unit_key
        {
            get
            {
                return hosting_unit;
            }
            set
            {
                hosting_unit = value;
            }

        }
        public Host Owner { get; set; }
        public string HostingUnitName
        {
            get
            {
                return HostingUnitName;

            }
            set //בדיקת תקינות לשם יחידת אירוח 
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (((value[i] < 65) || (value[i] > 90)) && ((value[i] > 122) || (value[i] < 97)))//if the char is not between the ascii code of the characters
                        throw new ArgumentException("יש להכניס רק אותיות!");
                }
                HostingUnitName = value;
            }
        }
        public bool[,] Diary = new bool[12, 31];  //מטריצה 

        public string ezerToString()
        {
            int day = 0, month = 0;
            bool flag = false;
            int year = 2020;
            int daysMonth;
            string str = "UnitKey: " + hosting_unit + "\n";
            for (int i = 0; i < this.Diary.GetLength(0); i++)
            {
                daysMonth = DateTime.DaysInMonth(year, i + 1);
                for (int j = 0; j < daysMonth; j++)
                {
                    month = i + 1;
                    day = j + 1;
                    if (this.Diary[i, j] == true && flag == false)
                    {
                        str += "begin: " + day + "/" + month;
                        flag = true;
                    }
                    else if (this.Diary[i, j] == false && flag == true)
                    {
                        str += "\tend: " + day + "/" + month + "\n";
                        flag = false;
                    }
                }
            }

            if (flag == true)
                str += "\tend: " + day + "/" + month + "\n";
            return str;
        }
            public override string ToString()
        {
            return "hosting_unit: " + hosting_unit + "/n" +
                "Owner: " + Owner + "/n" +
                "HostingUnitName: " + HostingUnitName + "/n" +
                "The busy days are: " + "/n" + ezerToString();
        }

        //diffult constractor
        public HostingUnit()
        {
          
        }


        //constractor:
        public HostingUnit(Host Owner, bool[,] Diary, string my_HostingUnitName = " ")
        {
            HostingUnitName = my_HostingUnitName;

        }
    
    }
        

}
