using System;
using System.ServiceModel;
using TheContracts;

namespace TheClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new FaultyService.FaultyServiceClient("httpBinding");

            Console.WriteLine("Test 1: Sum with Fault");
            client.Open();

            try
            {
                var result = client.SumWithFault(int.MaxValue, 2);
            }
            catch (FaultException<UnhandledError> ex)
            {
                // System.ServiceModel.Channels.ServiceChannel
                Console.WriteLine($"Error: {ex.Message}\nType: {ex.GetType()}");
            }

            Console.ReadLine();

            client.Close();

            client = new FaultyService.FaultyServiceClient("httpBinding");

            Console.WriteLine("Test 2: Sum with global error handler");
            client.Open();

            try
            {
                var result = client.Sum(int.MaxValue, 2);
            }
            catch (FaultException<UnhandledError> ex)
            {
                Console.WriteLine($"Error: {ex.Message}\nType: {ex.GetType()}");
            }

            Console.ReadLine();

            client.Close();
        }
    }
}
