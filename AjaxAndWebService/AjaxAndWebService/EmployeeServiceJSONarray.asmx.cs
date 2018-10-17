using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.OleDb;
using System.Web.Script.Serialization;

namespace AjaxAndWebService
{
    /// <summary>
    /// Summary description for EmployeeServiceJSONarray
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class EmployeeServiceJSONarray : System.Web.Services.WebService
    {


        [WebMethod]
        public void GetEmployees()
        {
            List<Employee> employeeList = new List<Employee>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            OleDbConnection connection = new OleDbConnection(cs);
            connection.Open();
            OleDbCommand command = new OleDbCommand("select * from tblEmployee", connection);
            OleDbDataReader reader = command.ExecuteReader();
          
            
            while (reader.Read())
            {
                Employee employee = new Employee();
                employee.ID = Convert.ToInt32(reader["ID"]);
                employee.Name = reader["EmpName"].ToString();
                employee.Gender = reader["Gender"].ToString();
                employee.Salary = Convert.ToInt32(reader["Salary"]);
                employeeList.Add(employee);
            }

            //GridView1.DataSource = reader;
            //GridView1.DataBind();

            connection.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(employeeList));

        }

        [WebMethod]
        public void AddEmployee(Employee employee)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            OleDbConnection connection = new OleDbConnection(cs);
            connection.Open();
          
            OleDbCommand command = new OleDbCommand("INSERT into tblEmployee ([EmpName],[Gender],[Salary]) values ('"+employee.Name+"','"+employee.Gender + "'," +employee.Salary+")", connection);
            command.ExecuteNonQuery();
        
            connection.Close();
            
        }
    }
}
