using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Front.Controllers
{
    public class CompaniaController : Controller
    {
        Servicio1.ServicioCompania servicioc = new Servicio1.ServicioCompania();
        Infraestructura.InfraestructuraCompania infracomp = new Infraestructura.InfraestructuraCompania();

        // GET: Compania
        public ActionResult Index()
        {
             var lista = servicioc.TraerTodasCompanias();
            return View(lista);
        }

        // GET: Compania/Details/5
        public ActionResult Details(int id)
        {
            var objeto = servicioc.Traercompania(id);
            return View(objeto);
        }

        // GET: Compania/Create
        public ActionResult Create()
        {
        
            return View();
        }

        // POST: Compania/Create
        [HttpPost]
        public ActionResult Create(Infraestructura.InfraestructuraCompania compania)
        {
            try
            
            {
               
                servicioc.RegistrarCompania(compania);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compania/Edit/5
        public ActionResult Edit(int id)
        {
            var objeto = servicioc.Traercompania(id);
            return View(objeto);
        }

        // POST: Compania/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Infraestructura.InfraestructuraCompania compania)
        {
            try
            {
                servicioc.ModificarCompania(id, compania);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compania/Delete/5
        public ActionResult Delete(int id)
        {
            var objeto = servicioc.Traercompania(id);
            return View(objeto);
        }

        // POST: Compania/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                servicioc.ElimarCompania(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
