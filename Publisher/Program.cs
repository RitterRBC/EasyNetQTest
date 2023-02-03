using System;
using EasyNetQ;
using Messages;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var bus = RabbitHutch.CreateBus("amqp://admin:onlineAG01@thd-vostro-1500/"))
            using (var bus = RabbitHutch.CreateBus("host=thd-vostro-1500;virtualHost=/;username=admin;password=onlineAG01"))
            {

                var input = "";
                Console.WriteLine("Enter a message. 'q' to quit.");
                while ((input = Console.ReadLine()) != "q")
                {
                    bus.PubSub.Publish(new TextMessage
                        {
                            Text = input
                        });
                    Console.WriteLine("Message [{0}] published!", input);
                }
            }
        }
    }
}