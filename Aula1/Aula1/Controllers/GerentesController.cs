using Aula1.Context;
using Aula1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aula1.Controllers
{
    public class GerentesController : Controller
    {
        private readonly EFContext _context = new EFContext();
        // GET: 
        public ActionResult Index()
        {
            return View(_context.Gerentes.OrderBy(s => s.Name));
        }

        #region Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gerente gerente)
        {
            _context.Gerentes.Add(gerente);
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

            var gerente = _context.Gerentes.Find(id.Value);

            if (gerente == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(gerente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Gerente gerente)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(gerente).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gerente); 
            
        }
        #endregion


        #region Details
        public ActionResult Details(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var gerente = _context.Gerentes.Find(id.Value);

            if (gerente == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(gerente);
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

            var gerente = _context.Gerentes.Find(id.Value);

            if (gerente == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(gerente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(Gerente gerente)
        {
            if (ModelState.IsValid)
            {
                var s = _context.Gerentes.Find(gerente.GerenteId);
                _context.Gerentes.Remove(s);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gerente);

        } 
        #endregion

    }
}