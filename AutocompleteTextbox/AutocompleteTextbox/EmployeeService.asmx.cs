using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.OleDb;
using System.Web.Script.Serialization;

namespace AutocompleteTextbox
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
        public List<string> GetEmployeeNames(string term)
        {
            
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            List<string> EmpList = new List<string>();
            OleDbConnection connection = new OleDbConnection(cs);
            connection.Open();
            OleDbCommand command = new OleDbCommand("select EmpName from tblEmployee where EmpName LIKE '%" + term + "%'", connection);
            OleDbDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {

                EmpList.Add(reader["EmpName"].ToString());
            }

            //GridView1.DataSource = reader;
            //GridView1.DataBind();

            connection.Close();
            return EmpList;
           
        }
    }
}
