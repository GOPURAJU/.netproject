using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeProfile.Models;

namespace EmployeeProfile.Controllers
{
    [Authorize]
    public class ClientMastersController : Controller
    {
        private Employee_portalEntities db = new Employee_portalEntities();

        // GET: ClientMasters
        public ActionResult Index()
        {
            return View(db.ClientMasters.ToList());
        }

        // GET: ClientMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientMaster clientMaster = db.ClientMasters.Find(id);
            if (clientMaster == null)
            {
                return HttpNotFound();
            }
            return View(clientMaster);
        }

        // GET: ClientMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,ClientName,CreatedDate,CreatedBy")] ClientMaster clientMaster)
        {
            if (ModelState.IsValid)
            {
                db.ClientMasters.Add(clientMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientMaster);
        }

        // GET: ClientMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientMaster clientMaster = db.ClientMasters.Find(id);
            if (clientMaster == null)
            {
                return HttpNotFound();
            }
            return View(clientMaster);
        }

        // POST: ClientMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,ClientName,CreatedDate,CreatedBy")] ClientMaster clientMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientMaster);
        }

        // GET: ClientMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientMaster clientMaster = db.ClientMasters.Find(id);
            if (clientMaster == null)
            {
                return HttpNotFound();
            }
            return View(clientMaster);
        }

        // POST: ClientMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientMaster clientMaster = db.ClientMasters.Find(id);
            db.ClientMasters.Remove(clientMaster);
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
