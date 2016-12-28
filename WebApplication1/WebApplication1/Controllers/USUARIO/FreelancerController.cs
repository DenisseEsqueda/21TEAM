using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;

namespace WebApplication1.Controllers.USUARIO
{
    public class FreelancerController : Controller
    {
        private ProyectoPatronusWebEntities db = new ProyectoPatronusWebEntities();

        // GET: Freelancer
        public ActionResult Index()
        {
            var Trabajo = db.Trabajoes.Include(t => t.Categoria).Include(t => t.EstadoTrabajo).Include(t => t.RegistroUsuario).       // Sol mostrara los trabajos que tengan
                Where(a => a.idEstado == 1);                                                                                                                                            // un estado de no disponible (No asignado por empresa)
            return View(Trabajo.ToList());
        }

             // GET: Empresa/Edit/5
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

        // POST: Empresa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTrabajo,titulo,descripcion,idCategoria,fechaInicial,fechaAsignada,fechaFinal,idEstado,idUsuario,costoTrabajo")] Trabajo trabajo)
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
