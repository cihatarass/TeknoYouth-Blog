using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeknoYouth.Models;

namespace TeknoYouth.Controllers
{
    public class ProjelersController : Controller
    {
        private DBTYouthEntities db = new DBTYouthEntities();

        // GET: Projelers
        public ActionResult Index()
        {
            return View(db.Projeler.ToList());
        }

        // GET: Projelers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projeler projeler = db.Projeler.Find(id);
            if (projeler == null)
            {
                return HttpNotFound();
            }
            return View(projeler);
        }

        // GET: Projelers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projelers/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id,ProjeBaslik,ProjeAciklama,ProjeResim")] Projeler projeler)
        {
            if (ModelState.IsValid)
            {
                db.Projeler.Add(projeler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projeler);
        }

        // GET: Projelers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projeler projeler = db.Projeler.Find(id);
            if (projeler == null)
            {
                return HttpNotFound();
            }
            return View(projeler);
        }

        // POST: Projelers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,ProjeBaslik,ProjeAciklama,ProjeResim")] Projeler projeler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projeler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projeler);
        }

        // GET: Projelers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projeler projeler = db.Projeler.Find(id);
            if (projeler == null)
            {
                return HttpNotFound();
            }
            return View(projeler);
        }

        // POST: Projelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projeler projeler = db.Projeler.Find(id);
            db.Projeler.Remove(projeler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
