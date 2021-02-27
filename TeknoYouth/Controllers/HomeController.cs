using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknoYouth.Models;
using PagedList;
using PagedList.Mvc;
using System.Web.Helpers;

namespace TeknoYouth.Controllers
{
    public class HomeController : Controller
    {

        public DBTYouthEntities db = new DBTYouthEntities();

        public ActionResult Index(int sayfa = 1)
        {

            ViewBag.sonB = db.Blog.ToList().Where(x=>x.KategoriID==1).OrderByDescending(x=>x.id).Take(1);
            ViewBag.sonY = db.Blog.ToList().Where(x=>x.KategoriID==2).OrderByDescending(x => x.id).Take(1);
            return View(db.Blog.Include("KategoriT").OrderByDescending(x => x.id).ToPagedList(sayfa, 5));
        }

        public ActionResult MenuPartial()
        {
            ViewBag.menuKtg = db.KategoriT.ToList();
            return View();
        }

        public ActionResult KtgBlog(int id, int sayfa=1)
        {
            var b = db.Blog.Include("KategoriT").OrderByDescending(x=>x.id).Where(x => x.KategoriID == id).ToPagedList(sayfa, 5);
            return View(b);
        }

        public ActionResult SonBloglar()
        {
            return View(db.Blog.ToList().OrderByDescending(x => x.id));
            
        }

        public ActionResult KtgTek()
        {
            return View(db.Blog.ToList().OrderByDescending(x => x.id));
        }

        public ActionResult KtgYaz()
        {
            return View(db.Blog.ToList().OrderByDescending(x => x.id));
        }

        public ActionResult KtgPc()
        {
            return View(db.Blog.ToList().OrderByDescending(x=>x.id));
        }

        public ActionResult BlogDetay(int id)
        {
            var b=db.Blog.Include("KategoriT").Include("Yorum").Where(x => x.id == id).SingleOrDefault();
            return View(b);
        }

        public JsonResult YorumYap(string adsoyad, string eposta, string icerikz, int blogid)
        {
            if (icerikz == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            db.Yorum.Add(new Yorum { AdSoyad = adsoyad, EPosta = eposta, İcerik = icerikz, id = blogid, onay=false, });
            db.SaveChanges();

            return Json(false, JsonRequestBehavior.AllowGet);
        }


        public ActionResult KtglerPartial()
        {
            return View(db.KategoriT.ToList().OrderByDescending(x => x.KategoriID));
        }

        public ActionResult Projeler()
        {
            return View(db.Projeler.ToList().OrderByDescending(x=>x.id));
        }

        public ActionResult Hakkimizda()
        {

            return View(db.CvBilgi.ToList().SingleOrDefault());
        }

        public ActionResult İletisim()
        {
            return View(db.İletisim.SingleOrDefault());
        }


        [HttpPost]
        public ActionResult İletisim(string adsoyad = null, string email = null,  string konu = null, string mesaj = null)
        {
            if (adsoyad != null && email != null)
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "teknoyouth@gmail.com";
                WebMail.Password = "1244Cihat++";
                WebMail.SmtpPort = 587;
                WebMail.Send("teknoyouth@gmail.com", konu, email + " - " + mesaj);
                ViewBag.Uyari = "Mesajınız başarı ile gönderilmiştir.";

            }
            else
            {
                ViewBag.Uyari = "Hata Oluştu.Tekrar deneyiniz";
            }
            return View();
        }


    }
}