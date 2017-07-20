using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiUsuario.Models;

namespace MiUsuario.Controllers
{
    public class TMiUsuariosController : Controller
    {
        private dbMiUsuarioEntities db = new dbMiUsuarioEntities();

        // GET: TMiUsuarios
        public ActionResult Index()
        {
            return View(db.TMiUsuario.ToList());
        }

        // GET: TMiUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TMiUsuario tMiUsuario = db.TMiUsuario.Find(id);
            if (tMiUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tMiUsuario);
        }

        // GET: TMiUsuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TMiUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Referencia,Usuario,Contrasena,DireccionPagina,Imagen")] TMiUsuario tMiUsuario)
        {
            if (ModelState.IsValid)
            {
                db.TMiUsuario.Add(tMiUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tMiUsuario);
        }

        // GET: TMiUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TMiUsuario tMiUsuario = db.TMiUsuario.Find(id);
            if (tMiUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tMiUsuario);
        }

        // POST: TMiUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Referencia,Usuario,Contrasena,DireccionPagina,Imagen")] TMiUsuario tMiUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tMiUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tMiUsuario);
        }

        // GET: TMiUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TMiUsuario tMiUsuario = db.TMiUsuario.Find(id);
            if (tMiUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tMiUsuario);
        }

        // POST: TMiUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TMiUsuario tMiUsuario = db.TMiUsuario.Find(id);
            db.TMiUsuario.Remove(tMiUsuario);
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
