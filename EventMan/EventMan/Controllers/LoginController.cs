using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventMan.Controllers
{
    public class LoginController : ApiController
    {
        static EventMan.Logic.CentralLogic logic = new Logic.CentralLogic();

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public IQueryable<StakeHolder> Post([FromBody] LoginData login)
        {
            return logic.GetStakeHolderByLogin(login.Username, login.Password, login.Mobile, login.Email);
        }

        public class LoginData
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
