using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mercadito_UI.Controllers
{
    public class OfferController : Controller
    {
        // GET: Offer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Offers()
        {
            //Controlar si existe el usuario en la sesion
            //y en caso de que no, enviarlo a hacer Login
            if (Session["user"] == null) 
            {
                return RedirectToAction("../Login/Login");
            }
            return View();
        }

        public ActionResult CreateOffer() 
        {
            return View();
        }
    }
}