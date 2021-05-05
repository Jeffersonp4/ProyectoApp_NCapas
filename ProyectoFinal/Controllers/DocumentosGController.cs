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
    public class DocumentosGController : Controller
    {
        // GET: DocumentosG
        public ActionResult Index()
        {
            var lista = DocumentosGNC.listarDocumento();
            return View(lista);
        }

        public ActionResult GenerarDoc()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GenerarDoc(DocumentosG DG)
        {
            try
            {
                if (DG.Departamento_Origen == null)
                {
                    return Json(new { ok = false, msg = "Debe ingresas el nombre del Departamento" }, JsonRequestBehavior.AllowGet);
                }

                System.Threading.Thread.Sleep(5000);
                DocumentosGNC.GeneraDoc(DG);
                return Json(new { ok = true, toRedirect = "Index" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception err)
            {
                return Json(new { ok = false, msg = "Debe ingresas el Origen del Departamento", err.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult ConsigueDoc(int id)
        {
            var doc = DocumentosGNC.ConsigueDoc(id);

            return View(doc);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var doc = DocumentosGNC.ConsigueDoc(id);
            return View(doc);

        }

        [HttpPost]
        public ActionResult Editar(DocumentosG doc)
        {
            try
            {
                if (doc.Secuencia == null)
                {
                    ModelState.AddModelError("", "Debe dar click al boton para generar una secuencia!");
                }
                DocumentosGNC.Editar(doc);
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al Editar El Usuario!");
                return View(doc);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var doc = DocumentosGNC.ConsigueDoc(id.Value);
            return View(doc);
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            var doc = DocumentosGNC.ConsigueDoc(id);
            try
            {
                DocumentosGNC.Eliminar(id);
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