using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.OleDb;
using System.Web.Script.Serialization;

namespace SuggestingUserName
{
    /// <summary>
    /// Summary description for RegistrationService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RegistrationService : System.Web.Services.WebService
    {
        [WebMethod]
        public bool UserNameExists(string userName)
        {
  

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            OleDbConnection connection = new OleDbConnection(cs);
            connection.Open();
            OleDbCommand command = new OleDbCommand("select * from tblRegistration where Username='" + userName + "'", connection);

            return Convert.ToBoolean(command.ExecuteScalar());
            
        }

        [WebMethod]
        public void GetAvailableUserName(string userName)
        {
            Registration regsitration = new Registration();
            regsitration.UserNameInUse = false;

            while (UserNameExists(userName))
            {
                Random random = new Random();
                int randomNumber = random.Next(1, 100);
                userName = userName + randomNumber.ToString();
                regsitration.UserNameInUse = true;
            }

            regsitration.UserName = userName;
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(regsitration));
        }
    }
}
