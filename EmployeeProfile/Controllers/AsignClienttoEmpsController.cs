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
    public class AsignClienttoEmpsController : Controller
    {
        private Employee_portalEntities db = new Employee_portalEntities();

        // GET: AsignClienttoEmps
        public ActionResult Index()
        {
            var asignClienttoEmps = db.AsignClienttoEmps.Include(a => a.EmployeeDetail);
            return View(asignClienttoEmps.ToList());
        }

        // GET: AsignClienttoEmps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignClienttoEmp asignClienttoEmp = db.AsignClienttoEmps.Find(id);
            if (asignClienttoEmp == null)
            {
                return HttpNotFound();
            }
            return View(asignClienttoEmp);
        }

        // GET: AsignClienttoEmps/Create
        public ActionResult Create()
        {
            ViewBag.EID = new SelectList(db.EmployeeDetails, "EID", "Firstname");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AsignClienttoEmp asignClienttoEmp)
        {
            var user = TempData["UserId"] as Login;

            if (ModelState.IsValid)
            {
                asignClienttoEmp.CreatedBy = user.Name;
                asignClienttoEmp.CreatedDate = DateTime.Now;
                db.AsignClienttoEmps.Add(asignClienttoEmp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EID = new SelectList(db.EmployeeDetails, "EID", "Firstname", asignClienttoEmp.EID);
            return View(asignClienttoEmp);
        }

        // GET: AsignClienttoEmps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignClienttoEmp asignClienttoEmp = db.AsignClienttoEmps.Find(id);
            if (asignClienttoEmp == null)
            {
                return HttpNotFound();
            }
            ViewBag.EID = new SelectList(db.EmployeeDetails, "EID", "Firstname", asignClienttoEmp.EID);
            return View(asignClienttoEmp);
        }

        // POST: AsignClienttoEmps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ClientId,ClientName,EID,POS,POE,ClientBilling,CreatedDate,CreatedBy,ClientEmail,ClientManagerName,DesignationatClient")] AsignClienttoEmp asignClienttoEmp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignClienttoEmp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EID = new SelectList(db.EmployeeDetails, "EID", "Firstname", asignClienttoEmp.EID);
            return View(asignClienttoEmp);
        }

        // GET: AsignClienttoEmps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignClienttoEmp asignClienttoEmp = db.AsignClienttoEmps.Find(id);
            if (asignClienttoEmp == null)
            {
                return HttpNotFound();
            }
            return View(asignClienttoEmp);
        }

        // POST: AsignClienttoEmps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignClienttoEmp asignClienttoEmp = db.AsignClienttoEmps.Find(id);
            db.AsignClienttoEmps.Remove(asignClienttoEmp);
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
