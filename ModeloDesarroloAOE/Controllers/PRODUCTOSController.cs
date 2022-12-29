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
    public class PRODUCTOSController : Controller
    {
        private SIS_GES_ALMEntities db = new SIS_GES_ALMEntities();

        // GET: PRODUCTOS
        public ActionResult Index()
        {
            var pRODUCTOS = db.PRODUCTOS.Include(p => p.CATEGORIAS).Include(p => p.PROVEEDORES);
            return View(pRODUCTOS.ToList());
        }

        // GET: PRODUCTOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            if (pRODUCTOS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTOS);
        }

        // GET: PRODUCTOS/Create
        public ActionResult Create()
        {
            ViewBag.IDCATEGORIAS = new SelectList(db.CATEGORIAS, "IDCATEGORIAS", "NOMBRE");
            ViewBag.IDPROVEEDORES = new SelectList(db.PROVEEDORES, "IDPROVEEDORES", "NOMBRE");
            return View();
        }

        // POST: PRODUCTOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPRODUCTOS,NOMBRE,DESCRIPCION,PR_UNIT,STOCK,IDPROVEEDORES,IDCATEGORIAS")] PRODUCTOS pRODUCTOS)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTOS.Add(pRODUCTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCATEGORIAS = new SelectList(db.CATEGORIAS, "IDCATEGORIAS", "NOMBRE", pRODUCTOS.IDCATEGORIAS);
            ViewBag.IDPROVEEDORES = new SelectList(db.PROVEEDORES, "IDPROVEEDORES", "NOMBRE", pRODUCTOS.IDPROVEEDORES);
            return View(pRODUCTOS);
        }

        // GET: PRODUCTOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            if (pRODUCTOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCATEGORIAS = new SelectList(db.CATEGORIAS, "IDCATEGORIAS", "NOMBRE", pRODUCTOS.IDCATEGORIAS);
            ViewBag.IDPROVEEDORES = new SelectList(db.PROVEEDORES, "IDPROVEEDORES", "NOMBRE", pRODUCTOS.IDPROVEEDORES);
            return View(pRODUCTOS);
        }

        // POST: PRODUCTOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPRODUCTOS,NOMBRE,DESCRIPCION,PR_UNIT,STOCK,IDPROVEEDORES,IDCATEGORIAS")] PRODUCTOS pRODUCTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCATEGORIAS = new SelectList(db.CATEGORIAS, "IDCATEGORIAS", "NOMBRE", pRODUCTOS.IDCATEGORIAS);
            ViewBag.IDPROVEEDORES = new SelectList(db.PROVEEDORES, "IDPROVEEDORES", "NOMBRE", pRODUCTOS.IDPROVEEDORES);
            return View(pRODUCTOS);
        }

        // GET: PRODUCTOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            if (pRODUCTOS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTOS);
        }

        // POST: PRODUCTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            db.PRODUCTOS.Remove(pRODUCTOS);
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
