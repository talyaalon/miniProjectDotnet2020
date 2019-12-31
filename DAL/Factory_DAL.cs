using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Factory_DAL
    {
        static IDAL dal = null;
        public static IDAL getDal()
        {
            if (dal == null)
                dal = new Dal_imp();
            return dal;
        }
    }
}
