using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Buya.App.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Contacto()
        {
            ViewBag.Message = "Fale Connosco";

            return View();
        }

        public ViewResult Sobre()
        {
            return View();
        }

        public ActionResult Alojamento()
        {
            ViewBag.Message = "Alojamento";

            return View();
        }
        public ActionResult Galeria()
        {
            ViewBag.Message = "Galeria";

            return View();
        }
    }
}