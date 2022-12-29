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
    public class VENTASController : Controller
    {
        private SIS_GES_ALMEntities db = new SIS_GES_ALMEntities();

        // GET: VENTAS
        public ActionResult Index()
        {
            var vENTAS = db.VENTAS.Include(v => v.EMPLEADOS).Include(v => v.PRODUCTOS);
            return View(vENTAS.ToList());
        }

        // GET: VENTAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTAS vENTAS = db.VENTAS.Find(id);
            if (vENTAS == null)
            {
                return HttpNotFound();
            }
            return View(vENTAS);
        }

        // GET: VENTAS/Create
        public ActionResult Create()
        {
            ViewBag.IDEMPLEADOS = new SelectList(db.EMPLEADOS, "IDEMPLEADOS", "NOMBRES");
            ViewBag.IDPRODUCTOS = new SelectList(db.PRODUCTOS, "IDPRODUCTOS", "NOMBRE");
            return View();
        }

        // POST: VENTAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDVENTAS,FEC_VENT,TOTAL,IDPRODUCTOS,IDEMPLEADOS")] VENTAS vENTAS)
        {
            if (ModelState.IsValid)
            {
                db.VENTAS.Add(vENTAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDEMPLEADOS = new SelectList(db.EMPLEADOS, "IDEMPLEADOS", "NOMBRES", vENTAS.IDEMPLEADOS);
            ViewBag.IDPRODUCTOS = new SelectList(db.PRODUCTOS, "IDPRODUCTOS", "NOMBRE", vENTAS.IDPRODUCTOS);
            return View(vENTAS);
        }

        // GET: VENTAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTAS vENTAS = db.VENTAS.Find(id);
            if (vENTAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDEMPLEADOS = new SelectList(db.EMPLEADOS, "IDEMPLEADOS", "NOMBRES", vENTAS.IDEMPLEADOS);
            ViewBag.IDPRODUCTOS = new SelectList(db.PRODUCTOS, "IDPRODUCTOS", "NOMBRE", vENTAS.IDPRODUCTOS);
            return View(vENTAS);
        }

        // POST: VENTAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDVENTAS,FEC_VENT,TOTAL,IDPRODUCTOS,IDEMPLEADOS")] VENTAS vENTAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENTAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDEMPLEADOS = new SelectList(db.EMPLEADOS, "IDEMPLEADOS", "NOMBRES", vENTAS.IDEMPLEADOS);
            ViewBag.IDPRODUCTOS = new SelectList(db.PRODUCTOS, "IDPRODUCTOS", "NOMBRE", vENTAS.IDPRODUCTOS);
            return View(vENTAS);
        }

        // GET: VENTAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTAS vENTAS = db.VENTAS.Find(id);
            if (vENTAS == null)
            {
                return HttpNotFound();
            }
            return View(vENTAS);
        }

        // POST: VENTAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VENTAS vENTAS = db.VENTAS.Find(id);
            db.VENTAS.Remove(vENTAS);
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
