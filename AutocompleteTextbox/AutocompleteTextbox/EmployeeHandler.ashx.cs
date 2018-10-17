using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.OleDb;
using System.Web.Script.Serialization;

namespace AutocompleteTextbox
{
    /// <summary>
    /// Summary description for EmployeeHandler
    /// </summary>
    public class EmployeeHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string term = context.Request["term"] ??"";
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<string> EmpList = new List<string>();
                OleDbConnection connection = new OleDbConnection(cs);
                connection.Open();
                OleDbCommand command = new OleDbCommand("select EmpName from tblEmployee where EmpName LIKE '%"+term+"%'", connection);
                OleDbDataReader reader = command.ExecuteReader();

        
                while (reader.Read())
                {
                   
                    EmpList.Add(reader["EmpName"].ToString());
                }

                //GridView1.DataSource = reader;
                //GridView1.DataBind();

                connection.Close();
                JavaScriptSerializer js = new JavaScriptSerializer();
                context.Response.Write(js.Serialize(EmpList));
                
            }
            catch (Exception ex)
            { 
            JavaScriptSerializer js = new JavaScriptSerializer();
                context.Response.Write(js.Serialize(ex));
            
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}