using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AppLogic;

namespace ProjectoAgroIvanRojas.Controllers
{
    public class InitController : ApiController
    {
        [HttpPost]
        public string Init()
        {
            SINPAGManager sm = new SINPAGManager();
            return sm.SubscribeClient();
            
        }

        [HttpGet]
        public string CheckAvailability()
        {
            return "OK";
        }


    }
}
