using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventMan.Controllers
{
    public class StakeHolderController : ApiController
    {

        static EventMan.Logic.CentralLogic logic = new Logic.CentralLogic();

        public IEnumerable<EventMan.StakeHolder> Get()
        {
            return logic.GetStakeHolder();
        }

        public IEnumerable<EventMan.StakeHolder> Get(int type)
        {
            return logic.GetStakeHolderByType( type );
        }
        
        // POST api/values
        public void Post( [FromBody]StakeHolderData  stdata)
        {
            StakeHolder st = new StakeHolder();

            st.Name = stdata.Name;
            st.Username = stdata.Username;
            st.Email = stdata.Email;
            st.Password = stdata.Password;
            st.Type = stdata.Type;
            st.Mobile = Convert.ToInt64(stdata.Mobile);

            logic.InsertStakeHolder( st );
        }
        
        public class StakeHolderData
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Nullable<long> Mobile { get; set; }
            public string Email { get; set; }
            public Nullable<short> Type { get; set; }
            public byte[] Pic { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
