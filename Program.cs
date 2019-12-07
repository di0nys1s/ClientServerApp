using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClientServerApp
{
    public class Program
    {
        static int counter;
        static string choice;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.dashboardSelection();
        }

        public int counterNumber()
        {
            int counter2 = counter;
            return counter2;
        }

        public void returnToDashboard()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Please enter b to return dashboard");
            string back = Console.ReadLine();

            bool isB = false;
            if (back.Equals("b"))
            {
                dashboardSelection();
            }
            else if (!back.Equals("b"))
            {
                while (!isB)
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine("Incorrect! Please enter b to return dashboard");
                    string backAgain = Console.ReadLine();
                    if (backAgain.Equals("b"))
                    {
                        isB = true;
                    }
                }
                dashboardSelection();
            }
        }

        public void exitDashboard()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("You are closing ClientServer App. Are you sure?");
            Console.WriteLine("=================================");
            Console.WriteLine("Please enter q to exit application. You can turn back to dashboard by entering b");
            string exit = Console.ReadLine();
            bool isQ = false;
            if (exit.Equals("q"))
            {
                Environment.Exit(0);
            }

            else if (!exit.Equals("q") && !exit.Equals("b"))
            {
                while (!isQ)
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine("Incorrect! Please enter q to exit application or enter b to return dashboard");
                    string exitAgain = Console.ReadLine();
                    if (exitAgain.Equals("q") || exitAgain.Equals("b"))
                    {
                        isQ = true;
                    }
                    if (exitAgain.Equals("q"))
                    {
                        Environment.Exit(0);
                    }
                    else if (exitAgain.Equals("b"))
                    {
                        dashboardSelection();
                    }
                }

            }

            else if (exit.Equals("b"))
            {
                bool isB = false;
                if (exit.Equals("b"))
                {
                    dashboardSelection();
                }
                else if (!exit.Equals("b"))
                {
                    while (!isB)
                    {
                        Console.WriteLine("Incorrect! Please enter b to return dashboard");
                        string exitAgain = Console.ReadLine();
                        if (exitAgain.Equals("b"))
                        {
                            isB = true;
                        }
                    }
                    dashboardSelection();
                }
            }

        }

        public void dashboardSelection()
        {
            Program p = new Program();
            Random random = new Random();
            AppClient appClient = new AppClient();
            AppService appService = new AppService();

            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("Welcome to ClientServer Application");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Please select one of the options below:");
            Console.WriteLine("=================================");
            Console.WriteLine("(1) Get all clients");
            Console.WriteLine("(2) Get client details");
            Console.WriteLine("(3) Add new client");
            Console.WriteLine("(4) Get all services");
            Console.WriteLine("(5) Get service details");
            Console.WriteLine("(6) Add new service");
            Console.WriteLine("(7) Get all spends");
            Console.WriteLine("(8) Exit application");
            Console.WriteLine("=================================");
            choice = Console.ReadLine();
            counter = random.Next(1, 999999999);

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    appClient.getAllClients();
                    p.returnToDashboard();
                    break;
                case "2":
                    Console.Clear();
                    Console.Clear();
                    Console.WriteLine("=================================");
                    Console.WriteLine("Client Details:");
                    appService.getClientInfoReply();
                    p.returnToDashboard();
                    break;
                case "3":
                    Console.Clear();
                    appClient.setClientInfo();
                    p.returnToDashboard();
                    break;
                case "4":
                    Console.Clear();
                    appService.getAllServices();
                    p.returnToDashboard();
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("=================================");
                    Console.WriteLine("Service Details:");
                    appService.getServiceInfoReply();
                    p.returnToDashboard();
                    break;
                case "6":
                    Console.Clear();
                    appService.setServiceInfo();

                    p.returnToDashboard();
                    break;
                case "7":
                    Console.Clear();
                    appClient.getAllSpends();
                    p.returnToDashboard();
                    break;
                case "8":
                    Console.Clear();
                    p.exitDashboard();
                    break;
                default:
                    dashboardSelection();
                    break;
            }
        }


    }
}
