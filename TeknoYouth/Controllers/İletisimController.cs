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
    public class İletisimController : Controller
    {
        private DBTYouthEntities db = new DBTYouthEntities();

        // GET: İletisim
        public ActionResult Index()
        {
            return View(db.İletisim.ToList());
        }

        // GET: İletisim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            İletisim İletisim = db.İletisim.Find(id);
            if (İletisim == null)
            {
                return HttpNotFound();
            }
            return View(İletisim);
        }

        // POST: İletisim/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,email,email1")] İletisim İletisim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(İletisim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(İletisim);
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
