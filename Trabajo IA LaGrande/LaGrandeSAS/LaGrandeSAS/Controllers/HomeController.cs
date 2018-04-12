using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaGrandeSAS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProducto(Inventarios productos, HttpPostedFileBase image1)
        {
            var db = new LagrandeBDEntities();
            
            if (image1 != null)
            {
                productos.ImagenProducto = new byte[image1.ContentLength];
                image1.InputStream.Read(productos.ImagenProducto, 0, image1.ContentLength);
            }

            db.Inventarios.Add(productos);
            db.SaveChanges();
            return View(productos);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}