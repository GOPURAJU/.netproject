using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EmployeeProfile.Models;

namespace EmployeeProfile.Models
{
    public class AddEmployee
    {
    


     public int? EID { get; set; }
        public string Firstname { get; set; }
       
        public string Lastname { get; set; }
        
        public string Email { get; set; }
        
        public long? Phoneno { get; set; }
        public string Worklocation { get; set; }
        public int? Employee_Designation_FK { get; set; }
       
        public int? SubDepartmentId { get; set; }
        
        public int? EmployeeTypeId { get; set; }
        
        
       
        public string Vertical { get; set; }
        public   string GenderList  { get; set; }
        public enum Gender
        {
            Male = 1,
            Female = 2
            
        }

        
        public System.DateTime Joiningdate { get; set; }
        public System.DateTime? Dateofbirth { get; set; }
        public decimal? Salary { get; set; }

       public int Tenure { get; set; }
      
        public string Department { get; set; }
        public string Designation { get; set; }
        public string  Employee_Type { get; set; }
        
        public string SubDepartment { get; set; }
        
       
     

        public int? BenchTenure { get; set; }
      
        public decimal? CubicleCost { get; set; }
        public decimal? FoodCost { get; set; }
        public decimal? ProfitOrLoss { get; set; }
        public decimal? TotalExpenses { get; set; }
        public decimal? TotalSalaryTillNow { get; set; }
        public decimal? TransportationCost { get; set; }
        
        public string ClientName { get; set; }
        
        public Nullable<System.DateTime> POS { get; set; }
        public Nullable<System.DateTime> POE { get; set; }
        public decimal TotalBillingATClient { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ClientEmail { get; set; }
       
        public string ClientManagerName { get; set; }
       
    }
}
