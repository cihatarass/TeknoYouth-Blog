using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TeknoYouth.Models;

namespace TeknoYouth.Controllers
{
    public class BlogController : Controller
    {
        private DBTYouthEntities db = new DBTYouthEntities();

        // GET: Blog
        public ActionResult Index()
        {
            var blog = db.Blog.Include(b => b.KategoriT);
            return View(blog.ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewBag.KategoriID = new SelectList(db.KategoriT, "KategoriID", "KategoriAD");
            return View();
        }

        // POST: Blog/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id,Baslik,İcerik,ResimURL,tarih,KategoriID")] Blog blog , HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {

                if (ResimURL != null)
                {

                    WebImage ımg = new WebImage(ResimURL.InputStream);
                    FileInfo Imginfo = new FileInfo(ResimURL.FileName);

                    string iconimg = Guid.NewGuid().ToString() + Imginfo.Extension;
                    ımg.Resize(1900, 600);
                    ımg.Save("~/Uploads/Blog/" + iconimg);

                    blog.ResimURL = "/Uploads/Blog/" + iconimg;
                }

                db.Blog.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriID = new SelectList(db.KategoriT, "KategoriID", "KategoriAD", blog.KategoriID);
            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriID = new SelectList(db.KategoriT, "KategoriID", "KategoriAD", blog.KategoriID);
            return View(blog);
        }

        // POST: Blog/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int? id,Blog blog, HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                var h = db.Blog.Where(x => x.id == id).SingleOrDefault();
                if (ResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(h.ResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(h.ResimURL));
                    }

                    WebImage ımg = new WebImage(ResimURL.InputStream);
                    FileInfo Imginfo = new FileInfo(ResimURL.FileName);

                    string urunımg = Guid.NewGuid().ToString() + Imginfo.Extension;
                    ımg.Resize(1900, 600);
                    ımg.Save("~/Uploads/Blog/" + urunımg);

                    h.ResimURL = "/Uploads/Blog/" + urunımg;
                }

                h.Baslik = blog.Baslik;
                h.İcerik = blog.İcerik;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriID = new SelectList(db.KategoriT, "KategoriID", "KategoriAD", blog.KategoriID);
            return View(blog);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blog.Find(id);
            db.Blog.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
