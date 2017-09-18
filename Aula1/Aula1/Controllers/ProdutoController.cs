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
    public class ProdutoController : Controller
    {
        private readonly EFContext _context = new EFContext();
        // GET: 
        public ActionResult Index()
        {
            return View(_context.Produtos.OrderBy(p => p.Name));
        }

        #region Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            _context.Produtos.Add(produto);
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

            var produto = _context.Produtos.Find(id.Value);

            if (produto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(produto).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);

        }
        #endregion


        #region Details
        public ActionResult Details(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var produto = _context.Produtos.Find(id.Value);

            if (produto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(produto);
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

            var produto = _context.Produtos.Find(id.Value);

            if (produto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var p = _context.Produtos.Find(produto.ProdutoId);
                _context.Produtos.Remove(p);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);

        }
        #endregion

    }
}
