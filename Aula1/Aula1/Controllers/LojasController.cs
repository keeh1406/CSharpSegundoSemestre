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
    public class LojasController : Controller
    {
        private readonly EFContext _context = new EFContext();
        // GET: 
        public ActionResult Index()
        {
            return View(_context.Lojas.OrderBy(l => l.Name));
        }

        #region Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Loja loja)
        {
            _context.Lojas.Add(loja);
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

            var loja = _context.Lojas.Find(id.Value);

            if (loja == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(loja);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Loja loja)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(loja).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loja); 
            
        }
        #endregion


        #region Details
        public ActionResult Details(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var loja = _context.Lojas.Find(id.Value);

            if (loja == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(loja);
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

            var loja = _context.Lojas.Find(id.Value);

            if (loja == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(loja);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(Loja loja)
        {
            if (ModelState.IsValid)
            {
                var l = _context.Lojas.Find(loja.LojaId);
                _context.Lojas.Remove(l);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loja); 

        } 
        #endregion

    }
}