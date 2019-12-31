using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class My_enum
    {
        public enum Status { close ,Open, Close_By_Site, Close_By_NotValid,invitation_is_confirmed }
        public enum Area { All,North,South,Center,Jerusalem }
        public enum Type { Zimmer, Hotel, Camping, Tent }
        public enum Areaoptions { Necessary, Possible, Not_Interested }
        public enum Yes_Or_No { Yes, No }

    }
}
