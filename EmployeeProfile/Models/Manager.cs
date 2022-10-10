using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeProfile.Models
{
    public class Manager
    {
        public EmployeeDetail employeeDetails { get; set; }
        public Login login { get; set; }
    }
}