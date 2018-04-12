using LaGrandeSAS.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaGrandeSAS.Controllers
{
    public class NegocioController : Controller
    {
        // GET: Negocio
        public ActionResult Index()
        {            
            var db = new LagrandeBDEntities();
            Usuario Usu = (Usuario)Session["Usuario"];
            if (Usu != null)
            {
                ViewBag.Usuario = Usu.Nombres + " " + Usu.Apellidos;
            }
            List<object> ModeloListas = new List<object>();
            ModeloListas.Add(db.Inventarios.ToList());
            ModeloListas.Add(db.Compras.ToList());
            ModeloListas.Add(db.Usuario.ToList());
            return View(ModeloListas);
        }

        // GET: Negocio/Details/5
        public ActionResult Details(int id)
        {            
            return View();
        }

        public ActionResult UsuarioIndex()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    using (ApplicationDbContext db = new ApplicationDbContext())
            //    {
            //        var idUsuario = User.Identity.GetUserId();
            //        var UserManager = new UserManager<ApplicationUser>(
            //            new UserStore<ApplicationUser>(db));

            //        var usuario = UserManager.FindById(idUsuario);
            //        var Nombre = usuario.Nombres;
            //        ViewBag.Nombres = Nombre;
            //    }
            //}

            return View();
        }

        // GET: Negocio/Create
        public ActionResult Create()
        {
            

            //var modelo = new Negocio();
            //List<Inventarios> Invent = modelo.ListaInventarios();
            //ViewBag.Inventarios = Invent;
            return View();
        }

        // POST: Negocio/Create
        [HttpPost]
        public JsonResult Consulta(string Id)
        {
            var db = new LagrandeBDEntities();
            var resultado = db.Inventarios.Find(Id);
            return Json(resultado);
        }

        // GET: Negocio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Negocio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Negocio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Negocio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
