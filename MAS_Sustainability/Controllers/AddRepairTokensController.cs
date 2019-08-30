using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MAS_Sustainability.Models;

namespace MAS_Sustainability.Controllers
{
    public class AddRepairTokensController : Controller
    {
        private AddRepairTokenModel db = new AddRepairTokenModel();

        // GET: AddRepairTokens
        public ActionResult Index()
        {
            return View(db.AddRepairTokens.ToList());
        }

        // GET: AddRepairTokens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddRepairToken addRepairToken = db.AddRepairTokens.Find(id);
            if (addRepairToken == null)
            {
                return HttpNotFound();
            }
            return View(addRepairToken);
        }

        // GET: AddRepairTokens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddRepairTokens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RepairId,UserId,RecievedDate,Deadline")] AddRepairToken addRepairToken)
        {
            if (ModelState.IsValid)
            {
                db.AddRepairTokens.Add(addRepairToken);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addRepairToken);
        }

        // GET: AddRepairTokens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddRepairToken addRepairToken = db.AddRepairTokens.Find(id);
            if (addRepairToken == null)
            {
                return HttpNotFound();
            }
            return View(addRepairToken);
        }

        // POST: AddRepairTokens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RepairId,UserId,RecievedDate,Deadline")] AddRepairToken addRepairToken)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addRepairToken).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addRepairToken);
        }

        // GET: AddRepairTokens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddRepairToken addRepairToken = db.AddRepairTokens.Find(id);
            if (addRepairToken == null)
            {
                return HttpNotFound();
            }
            return View(addRepairToken);
        }

        // POST: AddRepairTokens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AddRepairToken addRepairToken = db.AddRepairTokens.Find(id);
            db.AddRepairTokens.Remove(addRepairToken);
            db.SaveChanges();
            return RedirectToAction("Index");
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
