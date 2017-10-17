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
    public class VendasController : Controller
    {
        private readonly EFContext _contexts = new EFContext();
        // GET: 
        public ActionResult Index()
        {
            return View(_contexts.Vendas.Include(p => p.Produtos).OrderBy(v => v.DescricaoVenda));
        }

        #region Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(_contexts.Produtos.OrderBy(n => n.Name), "ProdutoId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Venda venda)
        {
            _contexts.Vendas.Add(venda);
            _contexts.SaveChanges();

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

            var vendas = _contexts.Vendas.Find(id.Value);

            if (vendas == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(vendas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Venda venda)
        {
            if (ModelState.IsValid)
            {
                _contexts.Entry(venda).State = EntityState.Modified;
                _contexts.SaveChanges();
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

            var vendas = _contexts.Vendas.Find(id.Value);

            if (vendas == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(vendas);
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

            Venda venda = _contexts.Vendas.Where(f => f.VendaId == id).Include(p => p.Produtos).First();

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
                var v = _contexts.Vendas.Find(venda.VendaId);
                _contexts.Vendas.Remove(v);
                _contexts.SaveChanges();
                TempData["Message"] = "Venda " + venda.DescricaoVenda.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            return View(venda);

        }
        #endregion

    }
}
    