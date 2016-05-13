using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using IMNS.ServiceModel.Service.BL;

namespace IMNS.ServiceModel.Service
{
    //// Define a service contract.
    //[ServiceContract(Namespace = "http://IMNS.ServiceModel.Service")]
    //public interface ICalculator
    //{
    //    [OperationContract]
    //    double Add(double n1, double n2);
    //    [OperationContract]
    //    double Subtract(double n1, double n2);
    //    [OperationContract]
    //    double Multiply(double n1, double n2);
    //    [OperationContract]
    //    double Divide(double n1, double n2);
    //}

    //// Step 1: Create service class that implements the service contract.
    //public class CalculatorService : ICalculator
    //{
    //    // Step 2: Implement functionality for the service operations.
    //    public double Add(double n1, double n2)
    //    {
    //        double result = n1 + n2;
    //        Console.WriteLine("Received Add({0},{1})", n1, n2);
    //        // Code added to write output to the console window.
    //        Console.WriteLine("Return: {0}", result);
    //        return result;
    //    }

    //    public double Subtract(double n1, double n2)
    //    {
    //        double result = n1 - n2;
    //        Console.WriteLine("Received Subtract({0},{1})", n1, n2);
    //        Console.WriteLine("Return: {0}", result);
    //        return result;
    //    }

    //    public double Multiply(double n1, double n2)
    //    {
    //        double result = n1 * n2;
    //        Console.WriteLine("Received Multiply({0},{1})", n1, n2);
    //        Console.WriteLine("Return: {0}", result);
    //        return result;
    //    }

    //    public double Divide(double n1, double n2)
    //    {
    //        double result = n1 / n2;
    //        Console.WriteLine("Received Divide({0},{1})", n1, n2);
    //        Console.WriteLine("Return: {0}", result);
    //        return result;
    //    }        
    //}

    class Program
    {
        static void Main(string[] args)
        {
            // Step 1 of the address configuration procedure: Create a URI to serve as the base address.
            //Uri baseAddress = new Uri("http://localhost:8000/IMNS.ServiceModel.Service.BL");

            //Uri baseAddress = new Uri("http://192.168.0.100/ServiceModelSamples/Service"); 
            //Uri baseAddress = new Uri("http://LOCHUYNH-THINK/IMNS.ServiceModel.Service");
            Uri baseAddress = new Uri("http://lenovo-pc/IMNS.ServiceModel.Service.BL");

            // Step 2 of the hosting procedure: Create ServiceHost
            ServiceHost selfHost = new ServiceHost(typeof(NailSupplyService), baseAddress);

            try
            {


                // Step 3 of the hosting procedure: Add a service endpoint.
                //selfHost.AddServiceEndpoint(
                //    typeof(ICalculator),
                //    new WSHttpBinding(),
                //    "CalculatorService");

                selfHost.AddServiceEndpoint(
                   typeof(INailSupplyService),
                   new BasicHttpBinding(),
                   "NailSupplyService");



                // lht added - add another service endpoint
                //selfHost.AddServiceEndpoint(typeof(ISalonHome), new WSHttpBinding(), "SalonHomeService");


                // Step 4 of the hosting procedure: Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Step 5 of the hosting procedure: Start (and then stop) the service.
                selfHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}
