using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.OleDb;
using System.Web.Script.Services;

namespace Accordion
{
    /// <summary>
    /// Summary description for CountryService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class CountryService : System.Web.Services.WebService
    {

        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        
        public List<Country> GetCountries()
        {
            List<Country> listCountries = new List<Country>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            OleDbConnection connection = new OleDbConnection(cs);
            connection.Open();
            OleDbCommand command = new OleDbCommand("select * from tblCountries", connection);
            OleDbDataReader reader = command.ExecuteReader();
           
            while (reader.Read())
            {
                Country country = new Country();
                country.ID = Convert.ToInt32(reader["ID"]);
                country.Name = reader["Name"].ToString();
                country.CountryDescription = reader["CountryDescription"].ToString();
                listCountries.Add(country);
            }

            //GridView1.DataSource = reader;
            //GridView1.DataBind();

            connection.Close();

            return listCountries;
        }
    }
}
