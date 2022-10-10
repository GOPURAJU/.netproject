using EmployeeProfile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeProfile.Controllers
{
    public class GetAllEployeeDetailsController : Controller
    {
        // GET: GetAllEployeeDetails
        public Employee_portalEntities db = new Employee_portalEntities();
        public ActionResult Index(int EmpId)
        {
        //    GetAllEployeedetails model = new GetAllEployeedetails();
        //    model.eployeeDetails = db.EmployeeDetails.Where(x => x.EmpId == EmpId).FirstOrDefault();
        //    model.clientDetails = db.AsignClienttoEmps.Where(x => x.EmpId == EmpId).ToList();
        //    model.billDetails = db.Bills.Where(x => x.EmpId == EmpId).ToList();
        //    return View(model);
        //}
    
        //public ActionResult Details(int id, AddEmployee addEmployeeDetails)
        //{
        //    AddEmployee obj = new AddEmployee();
        //    var employee_details = db.EmployeeDetails.Where(x => x.EmpId == id).FirstOrDefault();
        //    if (employee_details != null)
        //    {
        //        obj.Firstname = employee_details.Firstname;
        //        obj.Lastname = employee_details.Lastname;
        //        obj.Email = employee_details.Email;
        //        obj.Phoneno = employee_details.Phoneno;
        //        obj.Dateofbirth = employee_details.Dateofbirth;
        //        obj.EmployeeTypeId = employee_details.EmployeeTypeId;
        //        obj.Employee_Designation_FK = employee_details.Employee_Designation_FK;
        //        obj.Joiningdate = employee_details.Joiningdate;
        //        obj.GenderList = employee_details.Gender;
        //        obj.Salary = employee_details.Salary;
                
        //        obj.Worklocation = employee_details.Worklocation;
                

        //        obj.SubDepartmentId = employee_details.SubDepartmentId;
               
        //        obj.Vertical = employee_details.Vertical;
                

        //        //obj.master_emp_detail2 = employee_details.master_emp_detail2;
        //        //obj.master_emp_detail3 = employee_details.master_emp_detail3;





        //    }
        //    Bill _empbills = employee_details.Bills.FirstOrDefault();
        //    //AddEmployee empsal =empsal.Salary.Value()/*Where(x => x.emp_id == id).*/FirstOrDefault();


        //    AsignClienttoEmp asign = employee_details.AsignClienttoEmps.Where(x => x.EmpId == id).FirstOrDefault();
        //    DateTime Jd = DateTime.Parse(obj.Joiningdate.ToString());
        //    decimal Salary = (employee_details.Salary.Value);

        //    int tenure = (DateTime.Parse(DateTime.Now.ToString()) - Jd).Days / 30;
        //    decimal paidtillnow = (Salary * tenure);
        //    DateTime p1 = (asign != null ? asign.POS.Value : DateTime.Now);
        //    DateTime p2 = (asign != null ? asign.POE.Value : DateTime.Now);
        //    int Ctenure = ((p2.Year - p1.Year) * 12) + p2.Month - p1.Month;
        //    int btenure = tenure - Ctenure;
        //    decimal bench_exp = Salary;
        //    decimal bench_expenes = 0;
        //    if (_empbills != null)
        //    {
        //        bench_expenes = btenure * (_empbills.FoodCost.Value + _empbills.TransportationCost.Value + _empbills.CubicleCost.Value);
        //    }
        //    decimal Clientsal = Ctenure * (asign != null ? asign.ClientBilling.Value : 0);
        //    if (obj.Salary != null && obj.Salary > 0 && tenure > 0)
        //    {
        //        decimal Total = paidtillnow;
        //    }
        //    employee_details.Tenure = tenure;
        //    _empbills.BenchTenure = btenure;
        //    //employee_details.Totalexpences = bench_expenes; //employee salary on bench including expenes
        //    _empbills.TotalSalaryTillNow = paidtillnow + bench_expenes;
        //    decimal Profit_loss = Clientsal - (paidtillnow + bench_expenes);
        //    _empbills.ProfitOrLoss = Profit_loss;


        //    //if (obj.Salary != null && obj.Salary > 0 && tenure > 0)
        //    //{
        //    //    decimal leadTotal = (obj.Salary != null ? obj.Salary.Value : 0) * (obj.EmpId = 6);
        //    //    obj.Lead_p_l = leadTotal - (obj.supervisor_fk = 6);


        //    //}


        //    //if (empsal.salary1 != null && empsal.salary1 > 0 && tenure > 0)
        //    //{
        //    //    decimal ManagerTotal = (empsal.salary1 != null ? empsal.salary1.Value : 0) * (obj.desg_fk = 6);
        //    //    decimal ManagerTol = (empsal.salary1 != null ? empsal.salary1.Value : 0) * (obj.desg_fk = 5);
        //    //    obj.Manager_P_L = ManagerTol + ManagerTotal;
        //    //    obj.Manager_p_l = (ManagerTol + ManagerTotal) - (obj.desg_fk = 4);
        //    //}
        //if (obj.Salary != null && obj.Salary > 0 && tenure > 0)
        //    //{
        //    //    decimal leadTotal = (obj.Salary != null ? obj.Salary.Value : 0) * (obj.EmpId = 6);
        //    //    obj.Lead_p_l = leadTotal - (obj.supervisor_fk = 6);


        //    //}


        //    //if (empsal.salary1 != null && empsal.salary1 > 0 && tenure > 0)
        //    //{
        //    //    decimal ManagerTotal = (empsal.salary1 != null ? empsal.salary1.Value : 0) * (obj.desg_fk = 6);
        //    //    decimal ManagerTol = (empsal.salary1 != null ? empsal.salary1.Value : 0) * (obj.desg_fk = 5);
        //    //    obj.Manager_P_L = ManagerTol + ManagerTotal;
        //    //    obj.Manager_p_l = (ManagerTol + ManagerTotal) - (obj.desg_fk = 4);
        //    //}
            return View();


        }
    }
}