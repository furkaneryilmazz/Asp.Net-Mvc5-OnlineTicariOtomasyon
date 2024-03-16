using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index(string p)
        {

            var k = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(y => y.TakipKodu.Contains(p));
            }
            return View(k.ToList());
        }

        [HttpGet]
        public ActionResult YeniKargo()
        {
            string takipKodu = Guid.NewGuid().ToString().Substring(0, 10).ToUpper();
            ViewBag.takipkod = takipKodu;
            return View();
        }

        [HttpPost]
        public ActionResult YeniKargo(KargoDetay d)
        {
            c.KargoDetays.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KargoTakip(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }
    }
}