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
    public class EmpreController : Controller
    {
        private ProyectoPatronusWebEntities db = new ProyectoPatronusWebEntities();

        // GET: Empre
        public ActionResult Index()
        {
            var Trabajo = db.Trabajoes.Include(t => t.Categoria).Include(t => t.EstadoTrabajo).Include(t => t.RegistroUsuario);
            return View(Trabajo.ToList());
        }

        // GET: Empre/Details/5
        public ActionResult Details(int? id)
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

        // GET: Empre/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.Categorias, "idCategoria", "categoria1");
            ViewBag.idEstado = new SelectList(db.EstadoTrabajoes, "idEstado", "estadoTrabajo1");
            ViewBag.idUsuario = new SelectList(db.RegistroUsuarios, "idUsuario", "correo");
            return View();
        }

        // POST: Empre/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTrabajo,titulo,descripcion,idCategoria,fechaInicial,fechaAsignada,fechaFinal,idEstado,idUsuario")] Trabajo trabajo)
        {
            if (ModelState.IsValid)
            {
                db.Trabajoes.Add(trabajo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.Categorias, "idCategoria", "categoria1", trabajo.idCategoria);
            ViewBag.idEstado = new SelectList(db.EstadoTrabajoes, "idEstado", "estadoTrabajo1", trabajo.idEstado);
            ViewBag.idUsuario = new SelectList(db.RegistroUsuarios, "idUsuario", "correo", trabajo.idUsuario);
            return View(trabajo);
        }

        // GET: Empre/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Empre/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTrabajo,titulo,descripcion,idCategoria,fechaInicial,fechaAsignada,fechaFinal,idEstado,idUsuario")] Trabajo trabajo)
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

        // GET: Empre/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Empre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trabajo trabajo = db.Trabajoes.Find(id);
            db.Trabajoes.Remove(trabajo);
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
