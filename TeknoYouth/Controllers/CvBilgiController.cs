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
    public class CvBilgiController : Controller
    {
        private DBTYouthEntities db = new DBTYouthEntities();

        // GET: CvBilgi
        public ActionResult Index()
        {
            return View(db.CvBilgi.ToList());
        }

        // GET: CvBilgi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CvBilgi cvBilgi = db.CvBilgi.Find(id);
            if (cvBilgi == null)
            {
                return HttpNotFound();
            }
            return View(cvBilgi);
        }

        // POST: CvBilgi/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,Baslik,Aciklama,Yazi")] CvBilgi cvBilgi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cvBilgi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cvBilgi);
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
