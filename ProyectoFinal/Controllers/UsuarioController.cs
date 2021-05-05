using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            var Usuario = UsuariosNC.ListarUsuarios();
            return View(Usuario);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Usuarios usuario)
        {
            try
            {
                if (usuario.Nombre == null)
                {
                    return Json(new { ok = false, msg = "Debe ingresas el nombre de Usuario" }, JsonRequestBehavior.AllowGet);
                }

                System.Threading.Thread.Sleep(5000);
                UsuariosNC.AgregarUsuario(usuario);
                return Json(new { ok = true, toRedirect = "Index" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception err)
            {
                return Json(new { ok = false, msg = "Debe ingresas el nombre de Usuario", err.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ConsigueUsuario(int id)
        {
            var usuario = UsuariosNC.ConsigueUsuario(id);
            return View(usuario);
        }

        public JsonResult ListarUsuario()
        {
            var lista = UsuariosNC.ListarUsuarios();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var usuario = UsuariosNC.ConsigueUsuario(id);
            return View(usuario);

        }

        [HttpPost]

        public ActionResult Editar(Usuarios user)
        {
            try
            {
                if (user.Nombre == null)
                {
                    ModelState.AddModelError("", "Debe ingresar un nombre de Usuario!");
                }
                UsuariosNC.Editar(user);
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al Editar El Usuario!");
                return View(user);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var usuario = UsuariosNC.ConsigueUsuario(id.Value);
            return View(usuario);
        }

        [HttpPost]

        public ActionResult Eliminar(int id)
        {
            var Usuario = UsuariosNC.ConsigueUsuario(id);
            try
            {
                UsuariosNC.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al Eliminar El Departamento!");
                return View(User);
            }
        }


    }
}