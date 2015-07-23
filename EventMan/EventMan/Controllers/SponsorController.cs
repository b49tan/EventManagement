using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventMan.Controllers
{
    public class SponsorController : ApiController
    {

        static EventMan.Logic.CentralLogic logic = new Logic.CentralLogic();

        public IEnumerable<Sponsor> Get()
        {
            return logic.GetSponsor();
        }
    }
}
