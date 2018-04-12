using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaGrandeSAS.Controllers
{
    public class InventarioController : Controller
    {
        // GET: Inventario
        public ActionResult Index()
        {
            Usuario usu = (Usuario)Session["Usuario"];
            if (usu != null)
            {
                if (usu.Rol != "Administrador")
                {
                    return RedirectToAction("Index", "Negocio");
                }
            }
            else
            {
                return RedirectToAction("Index", "Negocio");
            }
            var db = new LagrandeBDEntities();
            return View(db.Inventarios.ToList());
        }

        // GET: Inventario/Details/5
        public ActionResult Details(int id)
        {
            var db = new LagrandeBDEntities();
            Inventarios pro = db.Inventarios.Find(id);
            return View(pro);
        }

        // GET: Inventario/Create
        public ActionResult Create()
        {           
            return View();
        }

        // POST: Inventario/Create
        [HttpPost]
        public ActionResult Create(Inventarios productos, HttpPostedFileBase image1)
        {
            var db = new LagrandeBDEntities();

            if (image1 != null)
            {
                productos.ImagenProducto = new byte[image1.ContentLength];
                image1.InputStream.Read(productos.ImagenProducto, 0, image1.ContentLength);
            }
            if (ModelState.IsValid)
            {
                db.Inventarios.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
               
            }
            return View(productos);        
        }

        // GET: Inventario/Edit/5
        public ActionResult Edit(int id)
        {
            var db = new LagrandeBDEntities();
            Inventarios pro = db.Inventarios.Find(id);
            return View();
        }

        // POST: Inventario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Inventarios productos, HttpPostedFileBase image1)
        {
            try
            {
                var db = new LagrandeBDEntities();
                if (image1 != null)
                {
                    productos.ImagenProducto = new byte[image1.ContentLength];
                    image1.InputStream.Read(productos.ImagenProducto, 0, image1.ContentLength);
                }
                if (ModelState.IsValid)
                {
                    db.Entry(productos).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(productos);
            }
            catch
            {
                return View(productos);
            }
        }

        // GET: Inventario/Delete/5
        public ActionResult Delete(int id)
        {
            var db = new LagrandeBDEntities();
            Inventarios pro = db.Inventarios.Find(id);
            return View(pro);
        }

        // POST: Inventario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Inventarios productos)
        {
            var db = new LagrandeBDEntities();
            try
            {
                productos = db.Inventarios.Find(id);
                db.Inventarios.Remove(productos);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }
    }
}
