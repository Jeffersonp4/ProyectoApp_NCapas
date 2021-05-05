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
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        public ActionResult Index()
        {
            var Dptos = DepartamentoNC.ListarDepartamentos();
            return View(Dptos);
        }
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Departamentos Dptos)
        {
            try
            {
                if (Dptos.NombreDepa == null)
                {
                    return Json(new { ok = false, msg = "Debe ingresas el nombre del Departamento" }, JsonRequestBehavior.AllowGet);
                }

                System.Threading.Thread.Sleep(5000);
                DepartamentoNC.AgregarDpto(Dptos);
                return Json(new { ok = true, toRedirect = "Index" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception err)
            {
                return Json(new { ok = false, msg = "Debe ingresas el nombre del Departamento", err.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult ConsigueDpto(int id)
        {

            var dpto = DepartamentoNC.consigueDpto(id);
            return View(dpto);
        }

        public JsonResult ListarSiglas()
        {
            var lista = DepartamentoNC.ListarDepartamentos();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarUsuario()
        {
            var lista = DepartamentoNC.ListarDepartamentos();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var dpto = DepartamentoNC.consigueDpto(id);
            return View(dpto);
        }

        [HttpPost]
        public ActionResult Editar(Departamentos Dptos)
        {
            try
            {
                if (Dptos.NombreDepa == null)
                {
                    ModelState.AddModelError("", "Debe ingresar un nombre de departamento!");
                    return View(Dptos);
                }

                DepartamentoNC.Editar(Dptos);
                return RedirectToAction("Index");

            }
            catch (Exception error)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al Editar El Departamento!");
                return View(Dptos);
            }

        }


        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            var dpto = DepartamentoNC.consigueDpto(id.Value);
            return View(dpto);
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                DepartamentoNC.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al Eliminar El Departamento!");
                return View();
            }
        }


    }
}