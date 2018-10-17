using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Data.OleDb;
using System.Configuration;

namespace WCFserviceUsingAjax
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class EmployeeService
    {
        [OperationContract]
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
                employee.ID = Convert.ToInt32(reader.GetValue(0));
                employee.Name = reader.GetString(1);
                employee.Gender = reader.GetString(2);
                employee.Salary = Convert.ToInt32(reader.GetValue(3));
            }

            //GridView1.DataSource = reader;
            //GridView1.DataBind();

            connection.Close();
            return employee;
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
