using System;
using System.Data.SqlClient;

namespace ClientServerApp
{
    public class AppService
    {
        SqlConnection con;
        static string sN = "Service Name", sD = "Service Description", serviceid;
        Program p = new Program();
        int status = 1;
        int number;
        string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ozlem\source\repos\ClientServerApp\Database.mdf;Integrated Security=True; MultipleActiveResultSets=true";
        bool flag, isEmpty = false;
        string[] details = new string[2] { sN, sD };


        public void getClientInfoReply()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Please enter the Client ID");
            string clientid = Console.ReadLine();

            while (!isEmpty)
            {
                bool isNumeric = int.TryParse(clientid, out number);
                if (clientid.Equals("") || isNumeric == false)
                {
                    Console.WriteLine("Please enter a number.");
                    clientid = Console.ReadLine();
                }
                else if (!clientid.Equals(""))
                {
                    isEmpty = true;
                }
            }

            int counter = p.counterNumber();
            try
            {
                con = new SqlConnection(str);
                con.Open();

                string qc = "SELECT " +
                    "c.Id, " +
                    "c.FirstName, " +
                    "c.LastName, " +
                    "c.Phone, " +
                    "c.Address, " +
                    "s.ServiceName, " +
                    "s.ServiceDescription, " +
                    "sp.TotalSpend, " +
                    "sp.MessageSpend, " +
                    "sp.CallSpend " +
                    "FROM Clients c " +
                    "inner join Services s on c.ServiceId = s.Id " +
                    "left outer join Spends sp on sp.ClientId = c.Id " +
                    "WHERE c.Id = " + clientid;

                SqlCommand viewClient = new SqlCommand(qc, con);
                SqlDataReader drC = viewClient.ExecuteReader();

                while (drC.Read())
                {
                    string id = drC.GetValue(0).ToString();
                    string firstName = drC.GetValue(1).ToString();
                    string lastName = drC.GetValue(2).ToString();
                    string phone = drC.GetValue(3).ToString();
                    string address = drC.GetValue(4).ToString();
                    string serviceName = drC.GetValue(5).ToString();
                    string serviceDescription = drC.GetValue(6).ToString();
                    string totalSpend = drC.GetValue(7).ToString();
                    string messageSpend = drC.GetValue(8).ToString();
                    string callSpend = drC.GetValue(9).ToString();
                    status = 0;
                    Console.WriteLine(6001
                        + " GET_CLIENT_INFO_REPLY STATUS=" + status
                        + " ID=" + id
                        + " FIRSTNAME=" + firstName
                        + " LASTNAME=" + lastName
                        + " PHONE=" + phone + " ADDRESS=" + address
                        + " SERVICENAME=" + serviceName
                        + " SERVICEDESCR=" + serviceDescription
                        + " TOTALSPEND=" + totalSpend
                        + " CALLSPEND=" + callSpend
                        + " MESSAGESPEND=" + messageSpend
                        + " COUNTER=" + counter);

                }

                if (status == 1)
                {
                    Console.WriteLine("No Client found.");
                    Console.WriteLine("=================================");
                    Console.WriteLine(6001 + " GET_CLIENT_INFO_REPLY STATUS=" + status
                        + " ID="
                        + " FIRSTNAME="
                        + " LASTNAME="
                        + " PHONE="
                        + " ADDRESS="
                        + " SERVICENAME="
                        + " SERVICEDESC="
                        + " TOTALSPEND="
                        + " CALLSPEND="
                        + " MESSAGESPEND="
                        + " COUNTER=" + counter);
                }
            }
            catch (SqlException x)
            {

                Console.WriteLine(x.Message);
            }
        }

        public void getServiceInfoReply()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Please enter the Service ID");
            serviceid = Console.ReadLine();

            while (!isEmpty)
            {
                bool isNumeric = int.TryParse(serviceid, out number);
                if (serviceid.Equals("") || isNumeric == false)
                {
                    Console.WriteLine("Please enter a number.");
                    serviceid = Console.ReadLine();
                }
                else if (!serviceid.Equals(""))
                {
                    isEmpty = true;
                }
            }

            int counter = p.counterNumber();
            try
            {
                str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ozlem\source\repos\ClientServerApp\Database.mdf;Integrated Security=True";
                con = new SqlConnection(str);
                con.Open();

                string qc = "SELECT * " +
                    "FROM Services s " +
                    "where s.Id = " + serviceid;

                SqlCommand viewClient = new SqlCommand(qc, con);
                SqlDataReader drC = viewClient.ExecuteReader();

                while (drC.Read())
                {
                    string id = drC.GetValue(0).ToString();
                    string serviceName = drC.GetValue(1).ToString();
                    string serviceDesc = drC.GetValue(2).ToString();
                    status = 0;

                    Console.WriteLine(6001 + " GET_SERVICE_INFO_REPLY STATUS=" + status
                        + " ID=" + id
                        + " SERVICENAME=" + serviceName
                        + " SERVICEDESCRIPTION=" + serviceDesc
                        + " COUNTER=" + counter);

                }

                if (status == 1)
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine("No Service found.");
                    Console.WriteLine(6001 + " GET_SERVICE_INFO_REPLY STATUS=" + status
                            + " ID="
                            + " SERVICENAME="
                            + " SERVICEDESCRIPTION="
                            + " COUNTER=" + counter);
                }
            }
            catch (SqlException x)
            {

                Console.WriteLine(x.Message);
            }
        }

        public void getAllServices()
        {
            int counter = p.counterNumber();
            try
            {
                con = new SqlConnection(str);
                con.Open();

                string qc = "SELECT * " +
                    "FROM Services";

                SqlCommand viewClient = new SqlCommand(qc, con);
                SqlDataReader drC = viewClient.ExecuteReader();
                Console.WriteLine("=================================");
                Console.WriteLine("Service List:");
                Console.WriteLine("=================================");
                while (drC.Read())
                {
                    string id = drC.GetValue(0).ToString();
                    string serviceName = drC.GetValue(1).ToString();
                    string serviceDesc = drC.GetValue(2).ToString();

                    Console.WriteLine(
                        " ID=" + id
                        + " SERVICENAME=" + serviceName
                        + " SERVICEDESCRIPTION=" + serviceName);

                }
            }
            catch (SqlException x)
            {

                Console.WriteLine(x.Message);
            }
        }

        public void setServiceInfo()
        {
            int counter = p.counterNumber();
            try
            {
                con = new SqlConnection(str);
                con.Open();

                insertServiceDashboard();
                string query = "INSERT INTO Services (ServiceName, ServiceDescription) VALUES('" + details[0] + "','" + details[1] + "')";

                string qcId = "SELECT * " +
                                "FROM [Services]";

                SqlCommand viewClient = new SqlCommand(qcId, con);
                SqlDataReader drC = viewClient.ExecuteReader();

                while (drC.Read())
                {
                    if (drC[1].ToString() == details[0])
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag == true)
                {
                    Console.Clear();
                    Console.WriteLine("STATUS = " + 1 + " - Service name already exists. ");
                    p.returnToDashboard();
                }
                else
                {
                    qcId = "SELECT * " +
                        "FROM [Services] ORDER BY 1 DESC";

                    SqlCommand ins = new SqlCommand(query, con);
                    ins.ExecuteNonQuery();
                    viewClient = new SqlCommand(qcId, con);
                    drC = viewClient.ExecuteReader();

                    string _id = "";
                    while (drC.Read())
                    {
                        _id = drC.GetValue(0).ToString();
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("New Service Inserted Successfully:");
                    Console.WriteLine("=================================");
                    Console.WriteLine(6031 + " SET_SERVICE_INFO_REPLY ID=" + _id
                   + " COUNTER=" + counter + " STATUS=" + 0);
                }
            }
            catch (SqlException)
            {

                Console.WriteLine("Invalid entry.");
            }
        }

        public void insertServiceDashboard()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Add Service - You can return to dashboard in any step you enter 'exit'");
            Console.WriteLine("=================================");
            for (int i = 0; i < details.Length; i++)
            {
                Console.WriteLine("Please enter your " + details[i]);
                details[i] = Console.ReadLine();
                bool isEmpty = false;
                while (!isEmpty)
                {
                    if (details[i].Equals(""))
                    {
                        Console.WriteLine("Value cannot be empty, please enter again.");
                        details[i] = Console.ReadLine();
                    }
                    else if (details[i].Equals("exit"))
                    {
                        p.dashboardSelection();
                    }
                    else if (!details[i].Equals(""))
                    {
                        isEmpty = true;
                    }
                }

            }
        }
    }
}
