using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventMan.Controllers
{
    public class EventController : ApiController
    {

        static EventMan.Logic.CentralLogic logic = new Logic.CentralLogic();

        public IEnumerable<EventMan.Event> Get()
        {
            return logic.GetEvent();
        }

        public IEnumerable<int> Get(int stakeHolderId)
        {
            return logic.GetEventRegistrationByStakeHolderId( stakeHolderId);
        }
    }
}
