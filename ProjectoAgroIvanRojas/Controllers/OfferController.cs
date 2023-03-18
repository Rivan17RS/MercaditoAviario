using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectoAgroIvanRojas.Controllers
{
    public class OfferController : ApiController
    {
        [HttpGet]
        public List<Offer> GetallOffers() 
        {
            SINPAGManager sm = new SINPAGManager();
            return sm.GetAllOffers();
        }

        [HttpPost]
        public APIData CreateOffer(Offer ofr) 
        {
            var apiResult = new APIData();

            try 
            { 
            SINPAGManager sm = new SINPAGManager();
            sm.CreateOffer(ofr);
                apiResult.Result = "OK";
                apiResult.Message = "La oferta fue creada correctamente";
                return apiResult;
            }
            catch(Exception ex) 
            {
                apiResult.Result = "ERROR";
                apiResult.Message = "Se presento un error al crear la oferta " + ex.Message;
                return apiResult;
            }

        }
    }
}
