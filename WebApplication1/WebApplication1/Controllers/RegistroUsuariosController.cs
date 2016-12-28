using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;

namespace WebApplication1.Controllers
{
    public class RegistroUsuarioController : Controller
    {
        private ProyectoPatronusWebEntities db = new ProyectoPatronusWebEntities();

        // GET: RegistroUsuario
        public ActionResult Index()
        {
            var RegistroUsuario = db.RegistroUsuarios.Include(r => r.TipoUsuario);
            return View(RegistroUsuario.ToList());
        }

        // GET: RegistroUsuario/Details/5
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

        // GET: RegistroUsuario/Create
        public ActionResult Create()
        {
            ViewBag.idTipoUsuario = new SelectList(db.TipoUsuarios, "idTipoUsuario", "tipoUsuario1");
            return View();
        }

        // POST: RegistroUsuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuario,correo,nombreUsuario,contrasena,ConfirmarContrasena,idTipoUsuario")] RegistroUsuario registroUsuario)
        {
            if (ModelState.IsValid)
            {
                db.RegistroUsuarios.Add(registroUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipoUsuario = new SelectList(db.TipoUsuarios, "idTipoUsuario", "tipoUsuario1", registroUsuario.idTipoUsuario);
            return View(registroUsuario);
        }

        // GET: RegistroUsuario/Edit/5
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

        // POST: RegistroUsuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario,correo,nombreUsuario,contrasena,ConfirmarContrasena,idTipoUsuario")] RegistroUsuario registroUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipoUsuario = new SelectList(db.TipoUsuarios, "idTipoUsuario", "tipoUsuario1", registroUsuario.idTipoUsuario);
            return View(registroUsuario);
        }

        // GET: RegistroUsuario/Delete/5
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

        // POST: RegistroUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroUsuario registroUsuario = db.RegistroUsuarios.Find(id);
            db.RegistroUsuarios.Remove(registroUsuario);
            db.SaveChanges();
            return RedirectToAction("Index");
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
