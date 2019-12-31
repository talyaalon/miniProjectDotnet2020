using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Cloning
    {
        public static GuestRequest Clone(this GuestRequest original)
        {
            GuestRequest target = new GuestRequest();
            target.id = original.id;
 
            return target;
        }
        public static Lecture Clone(this Lecture original)
        {
            Lecture target = new Lecture();
            target.id = original.id;
 ...
 return target;
        }

    }
