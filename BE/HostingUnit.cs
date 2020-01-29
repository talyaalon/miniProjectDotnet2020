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

        public MyHost Owner { get; set; }
        public string HostingUnitName { get; set; }
        public bool[,] Diary = new bool[12, 31];  //מטריצה 
        public double price_Of_Night_To_Adult { get; set; }
        public double price_Of_Night_To_Child { get; set; }
        public My_enum.Type Type { get; set; } //סוג יחידת אירוח
        public int Adults { get; set; } //מספר מבוגרים
        public int  Children{ get; set; }
        public My_enum.Area Area { get; set; }
        public string SubArea { get; set; }
        public My_enum.Yes_Or_No ChildrensAttractions { get; set; }
        public My_enum.Yes_Or_No Garden { get; set; }
        public My_enum.Yes_Or_No Pool { get; set; }
        public My_enum.Yes_Or_No Jacuzzi { get; set; }


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
            hosting_unit_key = hosting_unit;
        }


        //constractor:
        public HostingUnit(MyHost My_Owner, bool[,] My_Diary, string my_HostingUnitName = " ", 
            My_enum.Type my_Type = 0  , int My_Adults=0, int my_Children = 0 , My_enum.Area my_Area =0 ,
            string my_SubArea = " ",  My_enum.Yes_Or_No my_ChildrensAttractions = 0 , My_enum.Yes_Or_No my_Garden = 0,
            My_enum.Yes_Or_No my_Pool = 0,My_enum.Yes_Or_No my_Jacuzzi = 0)
        {
            
            Owner = My_Owner;
            Diary = My_Diary;
            HostingUnitName = my_HostingUnitName;
            Type = my_Type;
            Adults = My_Adults;
            Children = my_Children;
            Area = my_Area;
            SubArea = my_SubArea;
            ChildrensAttractions = my_ChildrensAttractions;
            Garden = my_Garden;
            Pool = my_Pool;
            Jacuzzi = my_Jacuzzi;
        }

    }


}
