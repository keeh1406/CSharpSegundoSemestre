using System;
using Aula1.Context;
using Aula1.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aula1.Controllers
{
    public class ClientesController : Controller
    {


        private readonly EFContext _context = new EFContext();

        public ActionResult Index()


        {
            return View(_context.Clientes.OrderBy(c => c.Name));
        }


        #region Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion


        #region Edit
        public ActionResult Edit(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clientes = _context.Clientes.Find(id.Value);

            if (clientes == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(clientes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Cliente clientes)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(clientes).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);

        }
        #endregion


        #region Details
        public ActionResult Details(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clientes = _context.Clientes.Find(id.Value);

            if (clientes == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(clientes);
        }
        #endregion


        #region Delete
        [HttpGet]
        public ActionResult Delete(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clientes = _context.Clientes.Find(id.Value);

            if (clientes == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(clientes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var c = _context.Clientes.Find(cliente.ClienteId);
                _context.Clientes.Remove(c);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);

        }
        #endregion


    }
}
