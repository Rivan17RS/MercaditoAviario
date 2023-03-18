using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mercadito_UI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User usr)
        {
            if(usr.UserId == null | usr.Password == null) 
            {
                ViewBag.Message = "Usuario y/o Password incorrecto(s)";
                return View();
            }


            //UI -> API(ValidarLogin) --->
            //                          LoginManager(user = GetUserByName) --> crud --> SQLDao -->DB
            //                           //Validar (usuario y password)
            //                           // <--

            //Mostrar resultado
            //Llenar session con los datos del usuario

            //Ir al API, leer datos de la DB y validar el usuario
            //Controller
            //Manager/App Logic
            //Crud
            //Mapper/DAO
            //Stored Procedure

            //var userValidated = APIData.Result;

            //Crear las variables de sesion que vamos a utilizar en la app
            Session["user"] = "IvanR"; //userValidated.Name;
            Session["Role"] = "Admin";

            return RedirectToAction("../Home/Index");
        }

        public ActionResult Logout() 
        {
            Session.Clear();
            return RedirectToAction("../Home/Index");
        }

        public ActionResult Cancel()
        {
            Session.Clear();
            return RedirectToAction("../Home/Index");
        }

    }
}