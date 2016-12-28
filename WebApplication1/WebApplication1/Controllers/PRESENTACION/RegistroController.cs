using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaDatos;
using CapaNegocio;
using CapaEntidades;

namespace WebApplication1.Controllers
{
    public class RegistroController : Controller
    {
        RepositorioRegistro _repo = new RepositorioRegistro();
        RepoF _repoF = new RepoF();
        //Proyecto_patronusWebEntities1
        ProyectoPatronusWebEntities db = new ProyectoPatronusWebEntities();
        // GET: Registro
        public ActionResult Registro()
        {
            //ViewBag.idTipoUsuario = new SelectList(db.TipoUsuarios, "idTipoUsuario", "TipoUsuario", 1);
            return View();
        }

        [HttpPost]
        public ActionResult Registro(RegistroUsuario user)
        {
            _repo.Crear(user);
            ModelState.Clear();
            ViewBag.Message = user.nombreUsuario + " registrado satisfactoriamente";
            //ViewBag.idTipoUsuario = new SelectList(db.TipoUsuarios, "idTipoUsuario", "TipoUsuario", user.idTipoUsuario);
            return View();
        }
    }
}