using System;
using System.Linq;
using EasyNetQ.Management.Client;
using EasyNetQ.Management.Client.Model;

namespace Management
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var initial = new ManagementClient("DEV-SERVER01", "admin", "onlineAG01"))
            {
                var exchanges = initial.GetExchanges();

                foreach (Exchange exchange in exchanges.Where(x => (x.Name.StartsWith("No") || x.Name.StartsWith("OM") || x.Name.StartsWith("IS") || x.Name.StartsWith("PrestigeEnterprise")) && !x.Name.Contains("-")))
                {
                    Console.Out.WriteLine("Delete exchange = {0} ...", exchange.Name);
                    initial.DeleteExchange(exchange);
                }
                //foreach (Exchange exchange in exchanges.Where(x => (x.Name.StartsWith("NS") || x.Name.StartsWith("OM") || x.Name.StartsWith("IS") || x.Name.StartsWith("PrestigeEnterprise"))))
                //{
                //    Console.Out.WriteLine("Delete exchange = {0} ...", exchange.Name);
                //    initial.DeleteExchange(exchange);
                //}

                var queues = initial.GetQueues();

                foreach (Queue queue in queues.Where(x => (x.Name.StartsWith("NoS") || x.Name.StartsWith("OM") || x.Name.StartsWith("IS") || x.Name.StartsWith("PrestigeEnterprise")) && !x.Name.Contains("-")))
                {
                    Console.Out.WriteLine("Delete queue = {0} ...", queue.Name);
                    initial.DeleteQueue(queue);
                }
                //foreach (Queue queue in queues.Where(x => (x.Name.StartsWith("NS") || x.Name.StartsWith("OM") || x.Name.StartsWith("IS") || x.Name.StartsWith("PrestigeEnterprise"))))
                //{
                //    Console.Out.WriteLine("Delete queue = {0} ...", queue.Name);
                //    initial.DeleteQueue(queue);
                //}
                Console.WriteLine("Cleaning transient exchanges and queues. Hit <return> to quit.");
                Console.ReadLine();
            }
        }
    }
}