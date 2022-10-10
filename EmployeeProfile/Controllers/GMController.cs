using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeProfile.Models;

namespace EmployeeProfile.Controllers
{
    public class GMController : Controller
    {
        // GET: GeneralManager
        public Employee_portalEntities db = new Employee_portalEntities();
        Calculation _cal = new Calculation();

        public ActionResult Index()

        {

            var user = TempData["UserId"] as Login;


            var employeeDetails = db.EmployeeDetails.Where(x => x.EmpId == user.ID).FirstOrDefault();

            var data = db.EmployeeDetails.Where(x => x.ReportingManagerId == user.ID).ToList();

            //decimal leadprofit = 0;
            //int GMtenure = 0;
            decimal GMprofit = 0;
            decimal GM_p_l = 0;
            decimal Manager_p_l = 0;


            AddCalculationDetails obj1 = new AddCalculationDetails();
            GetAllEployeedetails model = new GetAllEployeedetails();

            var employeeDetail = db.EmployeeDetails.Where(x => x.EmpId == user.ID).ToList();
            if (user.ID == employeeDetails.EmpId)
            {


                foreach (var item in employeeDetail)
                {
                    GMprofit += _cal.calculation(item.EmpId);
                          
                }


            }
            foreach (var item in data)
            {

                Manager_p_l += Managercalculation(item.EmpId);
                item.ManagerProfit = Managercalculation(item.EmpId);
                var salary = db.Salaries.Where(x => x.EID == item.EID).Sum(i => i.Salary1);

                if (salary == null)
                {
                    item.Salary = Convert.ToDecimal(item.Salary);

                }

                else
                {
                    item.Salary = (Convert.ToDecimal(item.Salary + salary));
                }




            }

            GM_p_l = Manager_p_l - GMprofit;

            ViewBag.GManagerprofit = GM_p_l;


            return View(data);

        }
        public decimal Managercalculation(int id)
        {
            var employeeDetails = db.EmployeeDetails.Where(x => x.EmpId == id).FirstOrDefault();
            var employeeDetail = db.EmployeeDetails.Where(x => x.EmpId == id).ToList();

            var data = db.EmployeeDetails.Where(x => x.ReportingManagerId == id).ToList();

            decimal Managerprofit = 0;
            decimal Manager_p_l = 0;
            decimal lead_p_l = 0;

            AddCalculationDetails obj1 = new AddCalculationDetails();
            if (employeeDetails.EmpId == id)
            {
                foreach (var item in employeeDetail)
                {
                    Managerprofit += _cal.calculation(item.EmpId);
                   
                }


            }
            if (employeeDetails.EmpId == id)
            {
                foreach (var item in data)
                {

                    lead_p_l += leadCalculation(item.EmpId);
                    Manager_p_l = lead_p_l - Managerprofit;

                }
            }
            return Manager_p_l;


        }
        public decimal leadCalculation(int id)
        {
            var employeeDetails = db.EmployeeDetails.Where(x => x.EmpId == id).FirstOrDefault();
            var employeeDetail = db.EmployeeDetails.Where(x => x.EmpId == id).ToList();

            var data = db.EmployeeDetails.Where(x => x.ReportingManagerId == id).ToList();

            decimal leadprofit = 0;
            decimal lead_p_l = 0;
            decimal profitdata = 0;

            AddCalculationDetails obj1 = new AddCalculationDetails();
            if (employeeDetails.EmpId == id)
            {
                foreach (var item in employeeDetail)
                {
                    leadprofit += _cal.calculation(item.EID);

                   

                }

            }
            if (employeeDetails.EmpId == id)
            {
                foreach (var item in data)
                {

                    profitdata += _cal.calculation(item.EID);
                    
                }
                lead_p_l = profitdata - leadprofit;

            }
            return lead_p_l;


        }



        public ActionResult ManagerDetails(int id)
        {
            var data = db.EmployeeDetails.Where(x => x.ReportingManagerId == id).ToList();
            decimal lead_p_l = 0;
            var employeeDetails = db.EmployeeDetails.Where(x => x.EmpId == id).FirstOrDefault();
            var employeeDetail = db.EmployeeDetails.Where(x => x.EmpId == id).ToList();

            if (employeeDetails.EmpId == id)
            {
                foreach (var item in data)
                {

                    var Sal = db.Salaries.Where(x => x.EID == id).ToList();
                    

                        var salary = db.Salaries.Where(x => x.EID == item.EID).Sum(i => i.Salary1);

                        if (salary == null)
                        {
                            item.Salary = Convert.ToDecimal(item.Salary);

                        }

                        else
                        {
                            item.Salary = (Convert.ToDecimal(item.Salary + salary));
                        }




                        lead_p_l += leadCalculation(item.EmpId);
                    item.Leadprofit = leadCalculation(item.EmpId);

                }
            }
            return View(data);


        }

        public ActionResult LeadDetails(int id)
        {
            var data = db.EmployeeDetails.Where(x => x.ReportingManagerId == id).ToList();

            var Sal = db.Salaries.Where(x => x.EID == id).ToList();
            foreach (var item in data)
            {


                var salary = db.Salaries.Where(x => x.EID == item.EID).Sum(i => i.Salary1);

                if (salary == null)
                {
                    item.Salary = Convert.ToDecimal(item.Salary);

                }

                else
                {
                    item.Salary = (Convert.ToDecimal(item.Salary + salary));
                }
            }

                return View(data);
        }
        public ActionResult Details(int Id)
        {
            AsignClienttoEmp obj1 = new AsignClienttoEmp();
            GetAllEployeedetails model = new GetAllEployeedetails();
            List<AsignClienttoEmp> lObj = new List<AsignClienttoEmp>();
            List<Bill> lObj1 = new List<Bill>();
            model.eployeeDetails = db.EmployeeDetails.Where(x => x.EID == Id).FirstOrDefault();
            var clientDetails = db.AsignClienttoEmps.Where(x => x.EID == Id).ToList();
            lObj = clientDetails;
            var billDetails = db.Bills.Where(x => x.EID == Id).ToList();
            lObj1 = billDetails;
            model.clientDetails = lObj;
            var salary = db.Salaries.Where(x => x.EID == Id).FirstOrDefault();
            var sal = db.Salaries.Where(x => x.EID == Id).ToList();
            List<AddCalculationDetails> obj = new List<AddCalculationDetails>();
            var Bill_details = db.Bills.Where(x => x.EID == Id).FirstOrDefault();
            var employeeDetails = db.EmployeeDetails.Where(x => x.EID == Id).FirstOrDefault();
            var AsignClienttoEmp = db.AsignClienttoEmps.Where(x => x.EID == Id).FirstOrDefault();
            var salary1 = db.Salaries.Where(x => x.EID == Id).ToList();
            int btenure = 0;
            int tenure = 0;
            int Ctenure = 0;
            int TotalCtenure = 0;
            int totalcdays = 0;
            decimal paidtillnow = 0;
            decimal ClientBilling = 0;

            int tenure1 = 0;
            decimal update_tillnow = 0;
            DateTime Update = DateTime.Now;
            DateTime JD = DateTime.Now;
            decimal jd_updatedate = 0;
            int Tenure2 = 0;
            decimal Clientsalary = 0;
            decimal totalsalryat_client = 0;
            int cdays = 0;
            int nowdays = 0;
            int daysdiff = 0;
            int jd_days = 0;
            int date_nowdays = 0;
            int p1days = 0;
            int p2days = 0;
            JD = DateTime.Parse(employeeDetails.Joiningdate.Value.ToString());
            if (salary == null)
            {
                if (JD.Day > 1)
                {
                    jd_days = (30 - JD.Day);
                    tenure = (DateTime.Now.Year - JD.Year) * 12 + (DateTime.Now.Month - (JD.Month + 1));
                }
                else
                {
                    tenure = (DateTime.Now.Year - JD.Year) * 12 + (DateTime.Now.Month - (JD.Month));
                }
                date_nowdays = DateTime.Now.Day;
                nowdays = jd_days + date_nowdays;
                int convert_days_month = 0;
                if (nowdays >= 30)
                {
                    convert_days_month = nowdays / 30;
                    nowdays = nowdays % 30;
                }

                tenure = tenure + convert_days_month;



                paidtillnow = Convert.ToDecimal((employeeDetails.Salary / 30) * jd_days + (employeeDetails.Salary) * tenure + (employeeDetails.Salary) / 30 * date_nowdays);

            }
            else
            {
                Update = DateTime.Parse(salary.Update_At.Value.ToString());
                // JD = DateTime.Parse(employeeDetails.Joiningdate.Value.ToString());
                if (JD.Day > 1)
                {
                    jd_days = (30 - JD.Day);
                    tenure1 = (Update.Year - JD.Year) * 12 + (Update.Month - (JD.Month + 1));
                }
                else
                {
                    tenure1 = (Update.Year - JD.Year) * 12 + (Update.Month - JD.Month);

                }
                date_nowdays = Update.Day;
                int up_days = Update.Day;
                jd_updatedate = Convert.ToDecimal((employeeDetails.Salary) / 30 * jd_days + (employeeDetails.Salary) * tenure1 + (employeeDetails.Salary / 30) * up_days);
                int up_days2 = 30 - Update.Day;
                date_nowdays = DateTime.Now.Day;

                Tenure2 = (DateTime.Now.Year - Update.Year) * 12 + (DateTime.Now.Month - (Update.Month));
                decimal updatedsalary = Convert.ToDecimal(employeeDetails.Salary + salary.Salary1);

                update_tillnow = Convert.ToDecimal((updatedsalary) / 30 * up_days2 + (updatedsalary) * Tenure2 + (updatedsalary / 30) * date_nowdays);

                paidtillnow = jd_updatedate + update_tillnow;
                nowdays = jd_days + date_nowdays;
                int convert_days_month = 0;
                //int days = 0;
                if (nowdays > 30)
                {
                    convert_days_month = nowdays / 30;
                    nowdays = nowdays % 30;
                }
                tenure = tenure1 + Tenure2 + convert_days_month;
            }
            if (clientDetails != null && clientDetails.Count() > 0 && billDetails != null && billDetails.Count() > 0)
            {

                foreach (var item in clientDetails)
                {
                    DateTime p1 = (clientDetails != null ? item.POS.Value : DateTime.Now);
                    DateTime p2 = (clientDetails != null ? item.POE.Value : DateTime.Now);
                    ClientBilling = Convert.ToDecimal(item.ClientBilling);

                    if (employeeDetails.EID == AsignClienttoEmp.EID)
                    {
                        if (p1.Day > 1)
                        {
                            p1days = (30 - p1.Day);
                            Ctenure = (p2.Year - p1.Year) * 12 + (p2.Month - (p1.Month + 1));
                        }
                        else
                        {
                            Ctenure = (p2.Year - p1.Year) * 12 + (p2.Month - (p1.Month));
                        }
                        p2days = p2.Day;
                        if (p1days > 1 && p2days >= 1)
                        {
                            cdays = p1days + p2days;
                        }
                        else if (p1days == 1 && p2days > 1)
                        {
                            cdays = p2days;
                        }
                        else if (p2days == 1 && p1days > 1)
                        {
                            cdays = p1days;
                        }

                        Clientsalary = (ClientBilling / 30) * p1days + ClientBilling * Ctenure + ClientBilling / 30 * p2days;

                        totalsalryat_client += Clientsalary;
                        totalcdays = totalcdays + cdays;

                        TotalCtenure = TotalCtenure + Ctenure + totalcdays / 30;

                        daysdiff = nowdays - (totalcdays % 30);
                        if (daysdiff < 0)
                        {
                            daysdiff = -daysdiff;
                        }


                    }

                }

                btenure = tenure - TotalCtenure;

                decimal Total = 0;

                decimal bench_exp = Convert.ToDecimal(employeeDetails.Salary);
                decimal bench_expenes = 0;
                decimal Salary = 0;
                if (Bill_details != null)
                {
                    decimal total = (Bill_details.FoodCost.Value + Bill_details.TransportationCost.Value + Bill_details.CubicleCost.Value);
                    bench_expenes = btenure * total + daysdiff * (total / 30);
                }
                if (employeeDetails.Salary != null && employeeDetails.Salary > 0 && tenure > 0)
                {
                    //Total = Convert.ToDecimal(paidtillnow + totaldays/30 *(employeeDetails.Salary));
                    Total = paidtillnow;

                }

                decimal Profit_loss = totalsalryat_client - (paidtillnow + bench_expenes);

                foreach (var item in salary1)
                {
                    if (salary == null)
                    {
                        Salary = Convert.ToDecimal(employeeDetails.Salary);
                    }
                    else
                    {

                    }
                }

                obj.Add(new AddCalculationDetails
                {
                    CubicleCost = Bill_details.CubicleCost,
                    FoodCost = Bill_details.FoodCost,
                    TransportationCost = Bill_details.TransportationCost,
                    Salary = Convert.ToDecimal(Salary),
                    Joiningdate = employeeDetails.Joiningdate,

                    bench_expenes = bench_expenes,
                    Tenure = tenure,
                    nowdays = nowdays,
                    BenchTenure = btenure,
                    CTenure = TotalCtenure,
                    TotalSalaryTillNow = paidtillnow + bench_expenes,
                    ProfitOrLoss = Profit_loss,


                });
                ViewBag.tenure = tenure;
                ViewBag.days = nowdays;
                ViewBag.btenure = btenure;
                ViewBag.benchdays = daysdiff;

            }
            else if (billDetails != null && billDetails.Count() > 0)
            {

                decimal Salary = 0;
                
                paidtillnow = Convert.ToDecimal((employeeDetails.Salary / 30) * jd_days + (employeeDetails.Salary) * tenure + (employeeDetails.Salary) / 30 * date_nowdays);

                TotalCtenure = 0;
                btenure = tenure - TotalCtenure;

                decimal bench_exp = Convert.ToDecimal(employeeDetails.Salary);
                decimal bench_expenes = 0;


                if (Bill_details != null)
                {
                    decimal bill = (Bill_details.FoodCost.Value + Bill_details.TransportationCost.Value + Bill_details.CubicleCost.Value);
                    bench_expenes = bill / 30 * jd_days + btenure * bill + (bill / 30) * date_nowdays;
                }
                decimal Profit_loss = 0 - (paidtillnow + bench_expenes);

                foreach (var item in salary1)
                {
                    if (salary == null)
                    {
                        Salary = Convert.ToDecimal(employeeDetails.Salary);
                    }
                    else
                    {
                        Salary = (Convert.ToDecimal(employeeDetails.Salary + salary.Salary1));
                    }

                }
                obj.Add(new AddCalculationDetails
                {
                    CubicleCost = Bill_details.CubicleCost,
                    FoodCost = Bill_details.FoodCost,
                    TransportationCost = Bill_details.TransportationCost,
                    Salary = Convert.ToDecimal(Salary),
                    Joiningdate = employeeDetails.Joiningdate,

                    bench_expenes = bench_expenes,
                    Tenure = tenure,
                    BenchTenure = btenure,

                    //employee_details.Totalexpences = bench_expenes; //employee salary on bench including expenes
                    TotalSalaryTillNow = paidtillnow + bench_expenes,
                    ProfitOrLoss = Profit_loss,

                });

                ViewBag.tenure = tenure;
                ViewBag.days = nowdays;
                ViewBag.btenure = tenure;
                ViewBag.benchdays = nowdays;
            }
            else
            {

                decimal Salary = 0;
                JD = DateTime.Parse(employeeDetails.Joiningdate.Value.ToString());
                jd_days = (30 - JD.Day);
                tenure = (DateTime.Now.Year - JD.Year) * 12 + (DateTime.Now.Month - (JD.Month + 1));
                date_nowdays = DateTime.Now.Day;

                if (nowdays >= 30)
                {
                    tenure = tenure + nowdays / 30;
                }

                paidtillnow = Convert.ToDecimal((employeeDetails.Salary / 30) * jd_days + (employeeDetails.Salary) * tenure + (employeeDetails.Salary) / 30 * date_nowdays);
                TotalCtenure = 0;

                btenure = tenure - TotalCtenure;

                decimal bench_exp = Convert.ToDecimal(employeeDetails.Salary);

                decimal Profit_loss = 0-paidtillnow;


                foreach (var item in salary1)
                {

                    if (salary == null)
                    {
                        Salary = Convert.ToDecimal(employeeDetails.Salary);
                    }
                    else
                    {
                        Salary = (Convert.ToDecimal(employeeDetails.Salary + salary.Salary1));
                    }
                }
                obj.Add(new AddCalculationDetails
                {

                    Salary = Convert.ToDecimal(Salary),
                    Joiningdate = employeeDetails.Joiningdate,

                    Tenure = tenure,
                    BenchTenure = btenure,

                    TotalSalaryTillNow = paidtillnow,
                    ProfitOrLoss = Profit_loss,

                });
                ViewBag.tenure = tenure;
                ViewBag.days = nowdays;
                ViewBag.btenure = tenure;
                ViewBag.benchdays = nowdays;


            }

            model.billDetails = obj;
            return View(model);

        }

        
    }
}

