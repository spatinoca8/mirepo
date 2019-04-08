using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Front.Controllers
{
    public class ProductosController : Controller
    {
        Servicio1.ServicioProducto serviProducto = new Servicio1.ServicioProducto();
        Servicio1.ServicioCompania serviCompa = new Servicio1.ServicioCompania();
      
        // GET: Productos
        public ActionResult Index()
        {
            IList<Infraestructura.InfraestructuraCompania> companias = serviCompa.TraerTodasCompanias();
            ViewBag.Compania = companias;
           var lista= serviProducto.TraerTodosProductos();
            return View(lista);
        }

        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            IList<Infraestructura.InfraestructuraCompania> companias = serviCompa.TraerTodasCompanias();
            ViewBag.Compania = companias;
            var objeto =serviProducto.TraerProducto(id);
            return View(objeto);
        }
        
        // GET: Productos/Create
        public ActionResult Create()
        {
            IList<Infraestructura.InfraestructuraCompania> companias = serviCompa.TraerTodasCompanias();
            ViewBag.Compania = companias;
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        public ActionResult Create(Infraestructura.InfraestructuraProductos producto)
        {
            try
            {

                serviProducto.RegistrarProducto(producto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            IList<Infraestructura.InfraestructuraCompania> companias = serviCompa.TraerTodasCompanias();
            ViewBag.Compania = companias;
            var objeto = serviProducto.TraerProducto(id);
            return View(objeto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Infraestructura.InfraestructuraProductos producto)
        {
            try
            {
                // TODO: Add update logic here
                serviProducto.ModificarProducto(id, producto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            IList<Infraestructura.InfraestructuraCompania> companias = serviCompa.TraerTodasCompanias();
            ViewBag.Compania = companias;
            var objeto =serviProducto.TraerProducto(id);
            return View(objeto);
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {              
                serviProducto.ElimarProducto(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
