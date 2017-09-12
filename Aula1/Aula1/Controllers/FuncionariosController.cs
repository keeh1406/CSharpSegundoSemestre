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
    public class FuncionariosController : Controller
    {


        private readonly EFContext _context = new EFContext();

        public ActionResult Index()


        {
            return View(_context.Funcionarios.OrderBy(s => s.Name));
        }


        #region Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
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

            var funcionarios = _context.Funcionarios.Find(id.Value);

            if (funcionarios == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(funcionarios);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Funcionario funcionarios)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(funcionarios).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionarios);

        }
        #endregion


        #region Details
        public ActionResult Details(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var funcionarios = _context.Funcionarios.Find(id.Value);

            if (funcionarios == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(funcionarios);
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

            var funcionarios = _context.Funcionarios.Find(id.Value);

            if (funcionarios == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(funcionarios);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var s = _context.Funcionarios.Find(funcionario.FuncionarioId);
                _context.Funcionarios.Remove(s);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionario);

        }
        #endregion


    }

}

