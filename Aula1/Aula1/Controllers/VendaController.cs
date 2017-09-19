using System;
using Aula1.Context;
using Aula1.Models;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula1.Controllers
{
    public class VendaController : Controller
    {
        private readonly EFContext _context = new EFContext();
        // GET: 
        public ActionResult Index()
        {
            return View(_context.Vendas.OrderBy(v => v.DescricaoVenda));
        }

        #region Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Venda venda)
        {
            _context.Vendas.Add(venda);
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

            var venda = _context.Vendas.Find(id.Value);

            if (venda == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(venda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Venda venda)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(venda).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venda);

        }
        #endregion


        #region Details
        public ActionResult Details(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var venda = _context.Vendas.Find(id.Value);

            if (venda == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(venda);
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

            var venda = _context.Produtos.Find(id.Value);

            if (venda == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(venda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(Venda venda)
        {
            if (ModelState.IsValid)
            {
                var v = _context.Vendas.Find(venda.VendaId);
                _context.Vendas.Remove(v);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venda);

        }
        #endregion

    }
}
    