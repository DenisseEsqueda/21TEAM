using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CapaDatos;
using CapaNegocio;
using CapaEntidades;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {

        RepositorioRegistro _repo = new RepositorioRegistro();
        //Proyecto_patronusWebEntities1
        ProyectoPatronusWebEntities db = new ProyectoPatronusWebEntities();

        public ActionResult dasboardAdmin()
        {
            //var registroUsuarios = db.RegistroUsuarios.Include(r => r.TipoUsuario);
            //return View(registroUsuarios.ToList());
            return View();
        }

        /*-------------------------------------------------------trabajos------------------------------------------------------------------------------------------------*/
        public ActionResult IndexTrabajos()
        {
            var Trabajo = db.Trabajoes.Include(t => t.Categoria).Include(t => t.EstadoTrabajo).Include(t => t.RegistroUsuario);
            return View(Trabajo.ToList());
        }

        // GET: Empresa/Details/5
        public ActionResult DetailsTrab(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajo trabajo = db.Trabajoes.Find(id);
            if (trabajo == null)
            {
                return HttpNotFound();
            }
            return View(trabajo);
        }

        // GET: Empresa/Create
        public ActionResult CreateTrab()
        {
            ViewBag.idCategoria = new SelectList(db.Categorias, "idCategoria", "categoria1");                   //
            ViewBag.idEstado = new SelectList(db.EstadoTrabajoes, "idEstado", "estadoTrabajo1");         // Mostrara una lista con los datos de la base de datos
            ViewBag.idUsuario = new SelectList(db.RegistroUsuarios.Include(r => r.TipoUsuario).             //  
                Where(p => p.idTipoUsuario == 2 || p.idTipoUsuario == 4), "idUsuario", "nombreUsuario");  // Condiciona el llistado, solo mostrara los datos que sea de tipo Freelancer y no asignado.
            return View();
        }

        // POST: Empresa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTrab([Bind(Include = "idTrabajo,titulo,descripcion,idCategoria,fechaInicial,fechaAsignada,fechaFinal,idEstado,idUsuario,costoTrabajo")] Trabajo trabajo)
        {
            if (ModelState.IsValid)
            {
                db.Trabajoes.Add(trabajo);
                db.SaveChanges();
                return RedirectToAction("dasboardAdmin");
            }

            ViewBag.idCategoria = new SelectList(db.Categorias, "idCategoria", "categoria1", trabajo.idCategoria);
            ViewBag.idEstado = new SelectList(db.EstadoTrabajoes, "idEstado", "estadoTrabajo1", trabajo.idEstado);
            ViewBag.idUsuario = new SelectList(db.RegistroUsuarios, "idUsuario", "correo", trabajo.idUsuario);
            return View(trabajo);
        }

        // GET: Empresa/Edit/5
        public ActionResult EditTrab(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajo trabajo = db.Trabajoes.Find(id);
            if (trabajo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.Categorias, "idCategoria", "categoria1", trabajo.idCategoria);
            ViewBag.idEstado = new SelectList(db.EstadoTrabajoes, "idEstado", "estadoTrabajo1", trabajo.idEstado);
            ViewBag.idUsuario = new SelectList(db.RegistroUsuarios, "idUsuario", "correo", trabajo.idUsuario);
            return View(trabajo);
        }

        // POST: Empresa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTrab([Bind(Include = "idTrabajo,titulo,descripcion,idCategoria,fechaInicial,fechaAsignada,fechaFinal,idEstado,idUsuario,costoTrabajo")] Trabajo trabajo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.Categorias, "idCategoria", "categoria1", trabajo.idCategoria);
            ViewBag.idEstado = new SelectList(db.EstadoTrabajoes, "idEstado", "estadoTrabajo1", trabajo.idEstado);
            ViewBag.idUsuario = new SelectList(db.RegistroUsuarios, "idUsuario", "correo", trabajo.idUsuario);
            return View(trabajo);
        }

        // GET: Empresa/Delete/5
        public ActionResult DeleteTrab(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajo trabajo = db.Trabajoes.Find(id);
            if (trabajo == null)
            {
                return HttpNotFound();
            }
            return View(trabajo);
        }

        // POST: Empresa/Delete/5
        [HttpPost, ActionName("DeleteTrab")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedTrab(int id)
        {
            Trabajo trabajo = db.Trabajoes.Find(id);
            db.Trabajoes.Remove(trabajo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        


        /*-------------------------------------------------------trabajos------------------------------------------------------------------------------------------------*/

        /*-------------------------------------------------------USUARIOS------------------------------------------------------------------------------------------------*/
        public ActionResult IndexUsuariosFreelancers(RegistroUsuario user)
        {
            //Lista SOLAMENTE los usuarios Freelancer y muestra los datos relacionados.
            var registroUsuarios = db.RegistroUsuarios.Include(r => r.TipoUsuario).Where(w=>w.idTipoUsuario.ToString()=="2");
            return View(registroUsuarios.ToList());
        }

        public ActionResult IndexUsuariosEmpresa(RegistroUsuario user)
        {
            //Lista SOLAMENTE los usuarios Freelancer y muestra los datos relacionados.
            var registroUsuarios = db.RegistroUsuarios.Include(r => r.TipoUsuario).Where(w => w.idTipoUsuario.ToString() == "3");
            return View(registroUsuarios.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroUsuario registroUsuario = db.RegistroUsuarios.Find(id);
            if (registroUsuario == null)
            {
                return HttpNotFound();
            }
            return View(registroUsuario);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            ViewBag.idTipoUsuario = new SelectList(db.TipoUsuarios, "idTipoUsuario", "tipoUsuario1");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuario,correo,nombreUsuario,contrasena,ConfirmarContrasena,idTipoUsuario")] RegistroUsuario registroUsuario)
        {
            if (ModelState.IsValid)
            {
                _repo.Crear(registroUsuario);
                db.SaveChanges();
                return RedirectToAction("dasboardAdmin");
            }

            ViewBag.idTipoUsuario = new SelectList(db.TipoUsuarios, "idTipoUsuario", "tipoUsuario1", registroUsuario.idTipoUsuario);
            return View(registroUsuario);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroUsuario registroUsuario = db.RegistroUsuarios.Find(id);
            if (registroUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipoUsuario = new SelectList(db.TipoUsuarios, "idTipoUsuario", "tipoUsuario1", registroUsuario.idTipoUsuario);
            return View(registroUsuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario,correo,nombreUsuario,contrasena,ConfirmarContrasena,idTipoUsuario")] RegistroUsuario registroUsuario)
        {
            if (ModelState.IsValid)
            {
                _repo.Actualizar(registroUsuario);
                //db.Entry(registroUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("dasboardAdmin");
            }
            ViewBag.idTipoUsuario = new SelectList(db.TipoUsuarios, "idTipoUsuario", "tipoUsuario1", registroUsuario.idTipoUsuario);
            return View(registroUsuario);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroUsuario registroUsuario = db.RegistroUsuarios.Find(id);
            if (registroUsuario == null)
            {
                return HttpNotFound();
            }
            return View(registroUsuario);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroUsuario registroUsuario = db.RegistroUsuarios.Find(id);
            db.RegistroUsuarios.Remove(registroUsuario);
            db.SaveChanges();
            return RedirectToAction("dasboardAdmin");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
