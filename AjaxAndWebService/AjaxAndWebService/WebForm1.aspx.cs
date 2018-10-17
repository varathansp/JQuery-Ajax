using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;

namespace AjaxAndWebService
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                OleDbConnection connection = new OleDbConnection(cs);
                connection.Open();
                Employee employee = new Employee();
                employee.Name = "Sathisjh";
                employee.Gender = "male";
                employee.Salary = 13000;
                OleDbCommand command = new OleDbCommand("INSERT into tblEmployee ([EmpName],[Gender],[Salary]) values ('" + employee.Name + "','" + employee.Gender + "'," + employee.Salary + ")", connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

       

       
    }
}