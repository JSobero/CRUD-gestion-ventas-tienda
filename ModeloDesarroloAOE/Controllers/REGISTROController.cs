using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModeloDesarroloAOE;

namespace ModeloDesarroloAOE.Controllers
{
    public class REGISTROController : Controller
    {
        private SIS_GES_ALMEntities db = new SIS_GES_ALMEntities();

        // GET: REGISTRO
        public ActionResult Index()
        {
            var rEGISTRO = db.REGISTRO.Include(r => r.VENTAS);
            return View(rEGISTRO.ToList());
        }

        // GET: REGISTRO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGISTRO rEGISTRO = db.REGISTRO.Find(id);
            if (rEGISTRO == null)
            {
                return HttpNotFound();
            }
            return View(rEGISTRO);
        }

        // GET: REGISTRO/Create
        public ActionResult Create()
        {
            ViewBag.IDVENTAS = new SelectList(db.VENTAS, "IDVENTAS", "IDVENTAS");
            return View();
        }

        // POST: REGISTRO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDREGISTRO,FEC_INGR,IDVENTAS")] REGISTRO rEGISTRO)
        {
            if (ModelState.IsValid)
            {
                db.REGISTRO.Add(rEGISTRO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDVENTAS = new SelectList(db.VENTAS, "IDVENTAS", "IDVENTAS", rEGISTRO.IDVENTAS);
            return View(rEGISTRO);
        }

        // GET: REGISTRO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGISTRO rEGISTRO = db.REGISTRO.Find(id);
            if (rEGISTRO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDVENTAS = new SelectList(db.VENTAS, "IDVENTAS", "IDVENTAS", rEGISTRO.IDVENTAS);
            return View(rEGISTRO);
        }

        // POST: REGISTRO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDREGISTRO,FEC_INGR,IDVENTAS")] REGISTRO rEGISTRO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEGISTRO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDVENTAS = new SelectList(db.VENTAS, "IDVENTAS", "IDVENTAS", rEGISTRO.IDVENTAS);
            return View(rEGISTRO);
        }

        // GET: REGISTRO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGISTRO rEGISTRO = db.REGISTRO.Find(id);
            if (rEGISTRO == null)
            {
                return HttpNotFound();
            }
            return View(rEGISTRO);
        }

        // POST: REGISTRO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            REGISTRO rEGISTRO = db.REGISTRO.Find(id);
            db.REGISTRO.Remove(rEGISTRO);
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
