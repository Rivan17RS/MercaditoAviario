using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mercadito_UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var url = "https://localhost:44396";
            var url = ConfigurationManager.AppSettings["app_api_url"];
            var method = "/api/Init/Init";

            var client = new HttpClient();
            client.BaseAddress = new Uri(url + method);

            var result = client.PostAsync(url + method, null).Result;

            if(!result.IsSuccessStatusCode) { 
                throw new Exception(result.Content.ReadAsStringAsync().Result);
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}