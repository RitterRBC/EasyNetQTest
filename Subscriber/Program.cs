using System;
using EasyNetQ;
using Messages;

namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var bus = RabbitHutch.CreateBus("amqp://admin:onlineAG01@thd-vostro-1500/"))
            using (var bus = RabbitHutch.CreateBus("host=thd-vostro-1500;virtualHost=/;username=admin;password=onlineAG01"))
            {
                bus.PubSub.Subscribe<TextMessage>("test", HandleTextMessage);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        static void HandleTextMessage(TextMessage textMessage)
        {
            Console.WriteLine("Got message: {0}", textMessage.Text);
        }
    }
}