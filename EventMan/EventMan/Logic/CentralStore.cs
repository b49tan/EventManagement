using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventMan.Logic
{
    public static  class CentralStore
    {
        public static EventMan.EventManDbEntities db = new EventManDbEntities();
        public static EventMan.EventManDbEntities getDb(){
            return db;
        }

    }
}