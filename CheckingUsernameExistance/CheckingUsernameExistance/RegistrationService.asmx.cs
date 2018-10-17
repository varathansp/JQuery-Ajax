using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Data.OleDb;

namespace CheckingUsernameExistance
{
    /// <summary>
    /// Summary description for RegistrationService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class RegistrationService : System.Web.Services.WebService
    {

        [WebMethod]
        public void UserNameExists(string userName)
        {
            bool userNameInUse = false;

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            OleDbConnection connection = new OleDbConnection(cs);
            connection.Open();
            OleDbCommand command = new OleDbCommand("select * from tblRegistration where Username='" + userName +"'", connection);

            userNameInUse = Convert.ToBoolean(command.ExecuteScalar());
           
            Registration regsitration = new Registration();
            regsitration.UserName = userName;
            regsitration.UserNameInUse = userNameInUse;

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(regsitration));
        }
    }
}
