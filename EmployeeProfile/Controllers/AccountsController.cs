using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EmployeeProfile.Models;


namespace EmployeeProfile.Controllers
{

    public class AccountsController : Controller 
    {
         
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            using (Employee_portalEntities context = new Employee_portalEntities())
            {
                bool IsValidUser = context.Logins.Any(user => user.UserName.ToLower() ==
                     model.UserName.ToLower() && user.Password == model.UserPassword);
                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    var data = context.Logins.Where(x => x.UserName == model.UserName && x.Password == model.UserPassword).FirstOrDefault();
                    TempData["UserId"] = data;

                    if (data.Designation == "Lead")
                    { return RedirectToAction("Index", "LeadDashboard"); }

                    else if (data.Designation == "Manager")
                    { return RedirectToAction("Index", "Manager"); }

                    else if (data.Designation == "GM")
                    { return RedirectToAction("Index", "GM"); }
                    else if (data.Designation == "CH")
                    { return RedirectToAction("Index", "CH"); }

                    else if (data.Designation == "MD")
                    {
                        return RedirectToAction("Index", "MD");
                    }
                    else if (data.Designation == "HR")
                    {
                        return RedirectToAction("Index", "EmployeeDetails");
                    }
                    else
                    { 
                    }

                }

                ModelState.AddModelError("", "invalid Username or Password");
                return View();
            }
        }
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User model)
        {
            using (Employee_portalEntities context = new Employee_portalEntities())
            {
                context.Users.Add(model);
                context.SaveChanges();
            }

            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
