using System.Reflection.Emit;
using System.Net.NetworkInformation;
using System;

namespace TestHostAlive
{
    class Program
    {
        static void Main(string[] args)
        {
            var testOper = TestHostAlive("www.google.com");
            if (testOper == true)
            {
                Console.WriteLine($"www.google.com is alive.");
            }
            else
            {
                Console.WriteLine($"www.google.com is down!");
            }
            //Console.WriteLine(testOper);
        }

        private static bool TestHostAlive(string server)
        {
            var hostIsAlive = false;
            try
            {
                var ping = new Ping();
                var pingreply = ping.Send(server, 2000);
                if (pingreply.Status == IPStatus.Success)
                {
                    hostIsAlive = true;
                }
            }
            catch (System.Exception ex)
            {
                hostIsAlive = false;
            }
            return (hostIsAlive);
        }
    }
}
