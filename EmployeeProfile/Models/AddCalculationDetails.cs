using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeProfile.Models
{
    public class AddCalculationDetails
    {
        
            
        public int EID { get; set; }
        public int Billid { get; set; }
        public int? BenchTenure { get; set; }
    
        public decimal? CubicleCost { get; set; }
        public decimal? FoodCost { get; set; }
        public decimal ProfitOrLoss { get; set; }
        public decimal bench_expenes { get; set; }
        public decimal TotalSalaryTillNow { get; set; }
        public decimal? TransportationCost { get; set; }
        public decimal Amount { get; set; }
        public decimal Salary { get; set; }
        public DateTime? Joiningdate { get; set; }
        public DateTime? POS { get; set; }
        public DateTime? POE { get; set; }
        public decimal ClientBilling { get; set; }
        public int Tenure { get; set; }
        public int CTenure { get; set; }
        public decimal Leadprofit { set; get; }
        public Nullable<decimal> Salary1 { get; set; }
        public decimal Salary2 { get; set; }
        public Nullable<System.DateTime> Update_At { get; set; }
        public int nowdays { set; get; }


    }

}
