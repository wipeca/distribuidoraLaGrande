using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaGrandeSAS.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        // GET: Acceso/Details/5
        public ActionResult Details()
        {
            Usuario usu = (Usuario)Session["Usuario"];
            if (usu != null)
            {
                var db = new LagrandeBDEntities();
                Usuario pro = usu;
                return View(pro);
            }
            else
            {
                return RedirectToAction("Index", "Negocio");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

       [HttpPost]
        public ActionResult Login(string usuario1, string Contraseña)
        {
            var db = new LagrandeBDEntities();
            List<Usuario> pro = db.Usuario.ToList();
            var result = from dato in pro where dato.contraseña == Contraseña && dato.usuario1 == usuario1 select dato;
            Usuario User = new Usuario();
            if (result.Count() > 0)
            {
                foreach (var item in result)
                {
                    User.Id = item.Id; User.Nombres = item.Nombres; User.Apellidos = item.Apellidos; User.Barrio = item.Barrio;
                    User.email = item.email;
                    User.usuario1 = usuario1;
                    User.contraseña = item.contraseña; User.Rol = item.Rol;
                }
                Session["Usuario"] = User;
                return RedirectToAction("Index", "Negocio");
            }
            else
            {
                ViewBag.Error = "El usuario o la contraseña no existe, favor verifique!";
                return View();
            }            
            
        }

        public ActionResult Salir()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Index", "Negocio");
        }

        [HttpPost]
        public ActionResult Salir( int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Acceso/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                var db = new LagrandeBDEntities();
                usuario.Rol = "Usuario";
                usuario.FechaCreacion = DateTime.Now.ToShortDateString();
                if (ModelState.IsValid)
                {
                    db.Usuario.Add(usuario);
                    db.SaveChanges();
                    Session["Usuario"] = usuario;
                    return RedirectToAction("Index", "Negocio");
                }

                return View(usuario);
            }
            catch
            {
                return View(usuario);
            }
        }

        // GET: Acceso/Edit/5
        public ActionResult Edit(string usuario1)
        {
            var db = new LagrandeBDEntities();
            List<Usuario> pro = db.Usuario.ToList();
            var result = from dato in pro where dato.usuario1 == usuario1 select dato;
            Usuario User = new Usuario();
            if (result.Count() > 0)
            {
                foreach (var item in result)
                {
                    User.Id = item.Id; User.Nombres = item.Nombres; User.Apellidos = item.Apellidos; User.Barrio = item.Barrio;
                    User.email = item.email;
                    User.usuario1 = item.usuario1;
                    User.contraseña = item.contraseña; User.Rol = item.Rol;
                    
                }
                
            }
            return View(User);
        }

        // POST: Acceso/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                var db = new LagrandeBDEntities();
                usuario.Rol = "Usuario";
                usuario.FechaCreacion = DateTime.Now.ToShortDateString();
                if (ModelState.IsValid)
                {
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    Session["Usuario"] = usuario;
                    return RedirectToAction("Index", "Negocio");
                }

                return RedirectToAction("Index", "Negocio");
            }
            catch
            {
                return View();
            }
        }

        // GET: Acceso/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Acceso/Delete/5
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
