using System;
using System.Data.SqlClient;


namespace ClientServerApp
{
    public class AppClient
    {
        SqlConnection con;
        static string fN = "First Name", lN = "Last Name", add = "Address", ph = "Phone", sid = "Service ID", mS = "Message Spend", cS = "Call Spend";
        Program p = new Program();
        string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ozlem\source\repos\ClientServerApp\Database.mdf;Integrated Security=True; MultipleActiveResultSets=true";
        bool flag = false;
        string[] details = new string[7] { fN, lN, add, ph, sid, mS, cS };

        public void getAllClients()
        {
            int counter = p.counterNumber();
            try
            {
                con = new SqlConnection(str);
                con.Open();

                string qc = "SELECT * " +
                            "FROM Clients";

                SqlCommand viewClient = new SqlCommand(qc, con);
                SqlDataReader drC = viewClient.ExecuteReader();

                Console.WriteLine("Client List:");
                Console.WriteLine("=================================");
                while (drC.Read())
                {
                    string id = drC.GetValue(0).ToString();
                    string firstName = drC.GetValue(1).ToString();
                    string lastName = drC.GetValue(2).ToString();
                    string address = drC.GetValue(3).ToString();
                    string phone = drC.GetValue(4).ToString();
                    string serviceid = drC.GetValue(5).ToString();

                    Console.WriteLine("ID=" + id
                         + " FIRSTNAME=" + firstName + " LASTNAME=" + lastName
                         + " PHONE=" + phone + " ADDRESS=" + address
                         + " SERVICEID=" + serviceid);
                }

            }
            catch (SqlException x)
            {
                Console.WriteLine(x.Message);
            }
        }

        public void setClientInfo()
        {
            int counter = p.counterNumber();
            try
            {
                con = new SqlConnection(str);
                con.Open();

                insertClientDashboard();

                string query = "INSERT INTO [Clients] (FirstName, LastName, Address, Phone, ServiceId) " +
                    "VALUES('" + details[0] + "','" + details[1] + "','" + details[2] + "','" + details[3] + "', '" + details[4] + "')";

                string qcId = "SELECT * " +
                                "FROM [Clients]";

                SqlCommand viewClient = new SqlCommand(qcId, con);
                SqlDataReader drC = viewClient.ExecuteReader();

                while (drC.Read())
                {

                    if (drC[1].ToString() == details[0] && drC[2].ToString() == details[1])
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag == true)
                {
                    Console.Clear();
                    Console.WriteLine("STATUS = " + 1 + " - Client name already exists. ");
                    Console.WriteLine("=================================");
                    p.returnToDashboard();
                }
                else
                {
                    qcId = "SELECT * " +
                        "FROM [Clients] ORDER BY 1 DESC";

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
                    Console.WriteLine("New Client Inserted Successfully:");
                    Console.WriteLine("=================================");
                    Console.WriteLine(6011 + " SET_CLIENT_INFO_REPLY ID=" + _id
                   + " COUNTER=" + counter + " STATUS =" + 0);

                    int intMesSpend = Convert.ToInt32(details[5]);
                    int intCallSpend = Convert.ToInt32(details[6]);
                    string qSpend = "INSERT INTO [Spends] (MessageSpend, CallSpend, ClientId) " +
                    "VALUES('" + details[5] + "','" + details[6] + "','" + _id + "')";
                    SqlCommand insSpend = new SqlCommand(qSpend, con);
                    insSpend.ExecuteNonQuery();

                }
            }
            catch (SqlException)
            {
                Console.WriteLine("Invalid entry. Please select an existing service id.");
            }
        }

        public void insertClientDashboard()
        {
            Console.WriteLine("Add Customer:");
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
                    else if (!details[i].Equals(""))
                    {
                        isEmpty = true;
                    }
                }

            }
        }

        public void getAllSpends()
        {
            int counter = p.counterNumber();
            try
            {
                con = new SqlConnection(str);
                con.Open();

                string qc = "SELECT * " +
                    "FROM Spends";

                SqlCommand viewClient = new SqlCommand(qc, con);
                SqlDataReader drC = viewClient.ExecuteReader();

                Console.WriteLine("Client Spends List:");
                Console.WriteLine("=================================");
                while (drC.Read())
                {
                    int id = (int)drC.GetValue(0);
                    int callSpend = (int)drC.GetValue(1);
                    int messageSpend = (int)drC.GetValue(2);
                    int clientId = (int)(drC.GetValue(3));
                    int totalSpend = (int)(drC.GetValue(4));

                    Console.WriteLine(
                        " ID=" + id
                        + " CALLSPEND=" + callSpend
                        + " MESSAGESPEND=" + messageSpend
                        + " TOTALSPEND=" + totalSpend
                        +" CLIENTID=" + id);
                }
            }
            catch (SqlException x)
            {

                Console.WriteLine(x.Message);
            }
        }

    }
}
