using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeProfile.Models
{
    public class AssignClientToEmpModel
    {

        public List<ClientMaster> clientMasters { get; set; }
        public List<EmployeeDetail> employeeMaster { get; set; }

        public int ID { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int EID { get; set; }
        public DateTime POS { get; set; }
        public DateTime POE { get; set; }
        public decimal ClientSalary { get; set; }
        public int CTenure { get; set; }
    }
}