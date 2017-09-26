﻿using System;
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


        private readonly EFContext _contexts = new EFContext();

        public ActionResult Index()


        {
            return View(_contexts.Clientes.OrderBy(c => c.Name));
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
            _contexts.Clientes.Add(cliente);
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

            var clientes = _contexts.Clientes.Find(id.Value);

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
                _contexts.Entry(clientes).State = EntityState.Modified;
                _contexts.SaveChanges();
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

            var clientes = _contexts.Clientes.Find(id.Value);

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

            var clientes = _contexts.Clientes.Find(id.Value);

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
                var c = _contexts.Clientes.Find(cliente.ClienteId);
                _contexts.Clientes.Remove(c);
                _contexts.SaveChanges();
                TempData["Message"] = "Cliente " +cliente.Name.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            return View(cliente);

        }
        #endregion


    }
}
