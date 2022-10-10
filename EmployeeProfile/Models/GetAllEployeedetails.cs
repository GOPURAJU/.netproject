using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeProfile.Models
{
    public class GetAllEployeedetails
    {
        public EmployeeDetail eployeeDetails { get; set; }
        public List<AsignClienttoEmp> clientDetails { get; set; }
        public List<AddCalculationDetails> billDetails { get; set; }
       
    }
}