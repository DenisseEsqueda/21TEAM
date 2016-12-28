using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaDatos;
using CapaEntidades;
using CapaNegocio;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        RepositorioRegistro _repoRegis = new RepositorioRegistro();
        //Proyecto_patronusWebEntities1
        //ProyectoPatronusWebEntities1 db = new ProyectoPatronusWebEntities1();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult dashboard()
        {
            return View();
        }

        /*EXTRAS*/
        public ActionResult conocenos()
        {
            return View();
        }

        public ActionResult contacto()
        {
            return View();
        }

        public ActionResult Servicios()
        {
            return View();
        }
    }
}