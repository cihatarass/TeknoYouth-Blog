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
    public class KategoriTsController : Controller
    {
        private DBTYouthEntities db = new DBTYouthEntities();

        // GET: KategoriTs
        public ActionResult Index()
        {
            return View(db.KategoriT.ToList());
        }


        // GET: KategoriTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KategoriTs/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "KategoriID,KategoriAD,Aciklama")] KategoriT kategoriT)
        {
            if (ModelState.IsValid)
            {
                db.KategoriT.Add(kategoriT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategoriT);
        }

        // GET: KategoriTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategoriT kategoriT = db.KategoriT.Find(id);
            if (kategoriT == null)
            {
                return HttpNotFound();
            }
            return View(kategoriT);
        }

        // POST: KategoriTs/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "KategoriID,KategoriAD,Aciklama")] KategoriT kategoriT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategoriT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategoriT);
        }

        // GET: KategoriTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategoriT kategoriT = db.KategoriT.Find(id);
            if (kategoriT == null)
            {
                return HttpNotFound();
            }
            return View(kategoriT);
        }

        // POST: KategoriTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KategoriT kategoriT = db.KategoriT.Find(id);
            db.KategoriT.Remove(kategoriT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
