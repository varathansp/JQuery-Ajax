using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.OleDb;
using System.Web.Script.Services;

namespace AjaxAndWebService
{
    /// <summary>
    /// Summary description for EmployeeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class EmployeeService : System.Web.Services.WebService
    {
        
        [WebMethod]
        public Employee GetEmployeeById(int employeeId)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            OleDbConnection connection = new OleDbConnection(cs);
            connection.Open();
            OleDbCommand command = new OleDbCommand("select * from tblEmployee where ID=" + employeeId, connection);
            OleDbDataReader reader = command.ExecuteReader();
            Employee employee = new Employee();
            employee.ID = employeeId;
            while (reader.Read())
            {
                employee.Name = reader.GetString(1);
                employee.Gender = reader.GetString(2);
                employee.Salary = Convert.ToInt32(reader.GetValue(3));
            }

            //GridView1.DataSource = reader;
            //GridView1.DataBind();

            connection.Close();
            return employee;
        }
    }
}
