using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
     class Factory_BL
    {
        static IBL bl = null;
        public static IBL getBL()
        {
            if (bl == null)
                bl = new IBL_imp();
            return bl;
        }
    }
}
