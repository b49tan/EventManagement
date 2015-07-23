using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace EventMan.Logic
{
    public class CentralLogic
    {
        public EventManDbEntities db = CentralStore.getDb();

        public IEnumerable<EventMan.Event> GetEvent()
        {
            //var evt = from even in db.Events
            //          select even;
            var evt = db.Events.AsEnumerable();
            return evt;            
        }

        public IQueryable<EventMan.Event> GetEvent(int Id)
        {
            //var evt = from even in db.Events
              //        where even.Id == Id
                //      select even;
            var evt = db.Events.Where( e => e.Id.Equals(Id));
            return evt;
        }
        public IEnumerable<EventMan.StakeHolder> GetStakeHolder()
        {
            //var evt = from even in db.StakeHolders
              //        select even;
            var evt = db.StakeHolders.AsEnumerable();
            return evt;
        }
        public IQueryable<EventMan.StakeHolder> GetStakeHolder(int Id)
        {
            //var evt = from even in db.StakeHolders
              //        where even.Id == Id
                //      select even;

            var evt = db.StakeHolders.Where(e => e.Id.Equals(Id));
            return evt;
        }
        public IEnumerable<EventMan.StakeHolder> GetStakeHolderByType(int type)
        {
            //var evt = from even in db.StakeHolders
              //        where even.Type == type
                //      select even;

            var evt = db.StakeHolders.Where(e => e.Type.Equals(type));
            return evt;
        }
        internal IQueryable<StakeHolder> GetStakeHolderByLogin(string username, string password, long? mobile, string email)
        {
            if (username == null) username = "";
            if (mobile == null) mobile = 0;
            if (email == null) email = "";
                 
            string pass = password.Trim().ToLower();
            string usern = username.Trim().ToLower();
            string emailr = email.Trim().ToLower();
            //var stakeholder = from guy in db.StakeHolders
              //                where guy.Password.Trim().ToLower() == (pass) &&
                //                    (guy.Username.Trim().ToLower() == (usern) ||
                  //                  guy.Email.Trim().ToLower() == (emailr) ||
                     //               guy.Mobile == (mobile))
                       //       select guy;

            var stakeholder = db.StakeHolders.Where(guy => 
                (guy.Password.Trim().ToLower() == (pass) &&
                (guy.Username.Trim().ToLower() == (usern) ||
                                    guy.Email.Trim().ToLower() == (emailr) ||
                                    guy.Mobile == (mobile)) ));
            return stakeholder;
        }
        public IEnumerable<EventMan.Registration> GetRegistration()
        {
            //var evt = from even in db.Registrations
              //        select even;
            var evt = db.Registrations.AsEnumerable();
            return evt;
        }

        public IEnumerable<int> GetEventRegistrationByStakeHolderId(int Id)
        {
            //var evt = from even in db.Registrations
              //        where even.StakeHolderId == Id
                //      select even.EventId;

            var evt = db.Registrations.Where(e => e.StakeHolderId.Equals(Id)).Select( e=> e.EventId);
        
            return evt;
        }
        public IQueryable<EventMan.Registration> GetRegistrationByEventId(int Id)
        {
            //var evt = from even in db.Registrations
              //        where even.EventId == Id
                //      select even;
            var evt = db.Registrations.Where(e => e.EventId.Equals(Id));
        
            return evt;
        }


        public void InsertStakeHolder(StakeHolder st)
        {
            db.StakeHolders.Add(st);
            db.SaveChanges();
            SMSSender.sendMessage(st.Mobile);
        }

        public IEnumerable<Sponsor> GetSponsor()
        {
            //var spnsr = from spns in db.Sponsors
              //          select spns;
            var spnsr = db.Sponsors.AsEnumerable();
            return spnsr;
        }


       
    }
}