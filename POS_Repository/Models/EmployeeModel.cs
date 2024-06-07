using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace POS_Folders.Models
{
    internal class EmployeeModel
    {
        public int employee_id { get; set; }
        public string employee_firstname { get; set; }
        public string employee_lastname { get; set; }
        public string employee_email { get; set; }
        public string employee_password { get; set; }
    }

}
