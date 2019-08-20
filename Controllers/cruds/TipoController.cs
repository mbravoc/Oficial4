﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Oficial3.Models;

namespace Oficial3.Controllers.cruds
{
    public class TipoController : Controller
    {
        private catalogoOficialEntities db = new catalogoOficialEntities();

        // GET: Tipo
        public ActionResult IndexTipo()
        {
            var tipo = db.Tipo.Include(t => t.Carro1);
            return View(tipo.ToList());
        }

        // GET: Tipo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo tipo = db.Tipo.Find(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            return View(tipo);
        }

        // GET: Tipo/Create
        public ActionResult Create()
        {
            ViewBag.carro = new SelectList(db.Carro, "id_carro", "nome_Carro");
            return View();
        }

        // POST: Tipo/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Tipo,descricao,carro")] Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                db.Tipo.Add(tipo);
                db.SaveChanges();
                return RedirectToAction("IndexTipo");
            }

            ViewBag.carro = new SelectList(db.Carro, "id_carro", "nome_Carro", tipo.carro);
            return View(tipo);
        }

        // GET: Tipo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo tipo = db.Tipo.Find(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.carro = new SelectList(db.Carro, "id_carro", "nome_Carro", tipo.carro);
            return View(tipo);
        }

        // POST: Tipo/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Tipo,descricao,carro")] Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexTipo");
            }
            ViewBag.carro = new SelectList(db.Carro, "id_carro", "nome_Carro", tipo.carro);
            return View(tipo);
        }

        // GET: Tipo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo tipo = db.Tipo.Find(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            return View(tipo);
        }

        // POST: Tipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo tipo = db.Tipo.Find(id);
            db.Tipo.Remove(tipo);
            db.SaveChanges();
            return RedirectToAction("IndexTipo");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
