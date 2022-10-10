using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeProfile.Models;
using PagedList;
using PagedList.Mvc;



namespace EmployeeProfile.Controllers
{
    [Authorize]
    public class EmployeeDetailsController : Controller
    {
         Employee_portalEntities db = new Employee_portalEntities();

        
       

        // GET: EmployeeDetails


        public ActionResult Index(string Search, int? i)
        {
           
            var employeeDetails = db.EmployeeDetails.Include(e => e.Department).Include(e => e.Designation).Include(e => e.Employee_Type).Include(e => e.Login).Include(e => e.SubDepartment);

            List<EmployeeDetail> empd = db.EmployeeDetails.ToList();

            return View(db.EmployeeDetails.Where(x => x.Firstname.StartsWith(Search) || Search == null).ToList().ToPagedList(i ?? 1, 5));

            return View(employeeDetails.ToList());
        }
    


        // GET: EmployeeDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }



        // GET: EmployeeDetails/Create
        public ActionResult Create()
        {

            var login =  db.Logins
                         .Select(s => new
                         {
                             Text = s.Name + "(" + s.LancesoftID +")",
                             Value = s.ID
                         }).ToList();
            ViewBag.ReportingManagerId = new SelectList(login, "Value", "Text");
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            ViewBag.Employee_Designation_FK = new SelectList(db.Designations, "DesignationId", "DesignationName");
            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "EmployeeTypeid", "EmployeeType");
           // ViewBag.ReportingManagerId = new SelectList(db.Logins.Where(x => x.Designation != "CONSULTANT"), "ID", "Email");
            ViewBag.SubDepartmentId = new SelectList(db.SubDepartments, "SDepartmentId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeDetail employeeDetail)
        {

            var user = TempData["UserId"] as Login;
            if (ModelState.IsValid)
            {
                Login lg = new Login();
                lg.Active_Status = 1;
                lg.CreateBy = employeeDetail.CreatedBy;
                var dd = db.Designations.Where(x => x.DesignationId == employeeDetail.Employee_Designation_FK).FirstOrDefault();
                lg.Designation = dd.DesignationName;
                lg.Email = employeeDetail.Email;
                lg.Mobileno = employeeDetail.Phoneno;
                lg.Name = employeeDetail.Firstname;
                lg.Password = employeeDetail.Firstname;
                lg.UserName = employeeDetail.Lastname;
                lg.Empid = employeeDetail.EmpId;
                lg.LancesoftID=employeeDetail.LancesoftID;
                lg.CreatedDate = DateTime.Now;
                lg.CreateBy= user.Name;
                db.Logins.Add(lg);
                db.SaveChanges();
                employeeDetail.EmpId = lg.ID;
                employeeDetail.CreatedDate = DateTime.Now;
                employeeDetail.CreatedBy = user.Name;
                db.EmployeeDetails.Add(employeeDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employeeDetail.DepartmentId);
            ViewBag.Employee_Designation_FK = new SelectList(db.Designations, "DesignationId", "DesignationName", employeeDetail.Employee_Designation_FK);
            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "EmployeeTypeid", "EmployeeType", employeeDetail.EmployeeTypeId);
            ViewBag.ReportingManagerId = new SelectList(db.Logins, "ID", "Email", employeeDetail.ReportingManagerId);
            ViewBag.SubDepartmentId = new SelectList(db.SubDepartments, "SDepartmentId", "Name", employeeDetail.SubDepartmentId);
            return View(employeeDetail);
        }

        // GET: EmployeeDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employeeDetail.DepartmentId);
            ViewBag.Employee_Designation_FK = new SelectList(db.Designations, "DesignationId", "DesignationName", employeeDetail.Employee_Designation_FK);
            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "EmployeeTypeid", "EmployeeType", employeeDetail.EmployeeTypeId);
            ViewBag.ReportingManagerId = new SelectList(db.Logins, "ID", "Name", employeeDetail.ReportingManagerId);
            ViewBag.SubDepartmentId = new SelectList(db.SubDepartments, "SDepartmentId", "Name", employeeDetail.SubDepartmentId);
            return View(employeeDetail);
        }



        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employeeDetail.DepartmentId);
            ViewBag.Employee_Designation_FK = new SelectList(db.Designations, "DesignationId", "DesignationName", employeeDetail.Employee_Designation_FK);
            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "EmployeeTypeid", "EmployeeType", employeeDetail.EmployeeTypeId);
            ViewBag.ReportingManagerId = new SelectList(db.Logins, "ID", "Name", employeeDetail.ReportingManagerId);
            ViewBag.SubDepartmentId = new SelectList(db.SubDepartments, "SDepartmentId", "Name", employeeDetail.SubDepartmentId);
            return View(employeeDetail);
        }



        // GET: EmployeeDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }



        // POST: EmployeeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            db.EmployeeDetails.Remove(employeeDetail);
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