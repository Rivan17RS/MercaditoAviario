using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using AppLogic;

namespace ProjectoAgroIvanRojas.Controllers
{
    public class OperationsController : ApiController
    {
        [HttpGet]
        public List<Subscriptor> GetAllSINPAGSubscribers()
        {
            SINPAGManager sm = new SINPAGManager();
            return sm.GetAllSubscribers();
        }

        [HttpPost]
        public string ProcessPurchaseOrder(string OfferId) 
        {
            SINPAGManager sm = new SINPAGManager();
            var result = sm.GetOfferDetails(OfferId);

            PurchaseOrderManager pom = new PurchaseOrderManager();
            return pom.CreatePurchaseOrder(result);

            //Contactar al comprador
        
        }

        [HttpGet]

        public List<PurchaseOrder> GetAllPurchaseOrders() 
        {
            PurchaseOrderManager pom = new PurchaseOrderManager();
            return pom.GetAllPurchaseOrders();
        }

    }

    

}
