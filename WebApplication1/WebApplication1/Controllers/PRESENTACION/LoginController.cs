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
    public class LoginController : Controller
    {
        RepositorioRegistro _repoRegis = new RepositorioRegistro();
        //Proyecto_patronusWebEntities1
        ProyectoPatronusWebEntities db = new ProyectoPatronusWebEntities();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(RegistroUsuario user)
        {
            using (db)
            {
                var usr = db.RegistroUsuarios.Where(u => u.nombreUsuario == user.nombreUsuario 
                && u.contrasena == user.contrasena).FirstOrDefault();
                if (usr != null)
                {
                    Session["idUsuario"] = user.idUsuario;
                    Session["nombreUsuario"] = user.nombreUsuario.ToString();
                    Session["idTipoUsuario"] = user.idTipoUsuario;
                    CrearUsuarioCookie();
                    Response.SetCookie(CrearUsuarioCookie());
                    if (usr.idTipoUsuario.ToString() == "1")
                    {
                        return RedirectToAction("dasboardAdmin", "Admin");
                    }
                    else if (usr.idTipoUsuario.ToString() == "2")
                    {
                        return RedirectToAction("Index", "Freelancer");
                    }   
                    else if (usr.idTipoUsuario.ToString() == "3")
                    {
                        return RedirectToAction("Index", "Empresa");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Usuario or Password incorrecta");
                }
            }
            return View();
        }

        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        
        /*Prueba de Cookies desde asp.net*/
        public HttpCookie CrearUsuarioCookie()
        {
            HttpCookie UsuarioCookie = new HttpCookie("UsuarioCookie");
            UsuarioCookie.Value = Session["idTipoUsuario"].ToString();
            //UsuarioCookie.Expires = DateTime.Now.AddHours(1);
            return UsuarioCookie;
        }

    }
}