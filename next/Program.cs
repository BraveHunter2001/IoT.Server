using RestSharp;
using System;
using System.IO.Ports;
using System.Threading;

namespace next
{
    internal class Program
    {
        static bool _continue;
        static SerialPort _serialPort;
        static RestClient client = new RestClient("https://localhost:7254/api/Measurment");
       

        static void Main(string[] args)
        {
            string name;
            string message;
  
            // Create a new SerialPort object with default settings.
            _serialPort = new SerialPort();
            

            // Allow the user to set the appropriate properties.
            _serialPort.PortName = "COM4";
            _serialPort.BaudRate = 9600;
         
            // Set the read/write timeouts
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;

            _serialPort.Open();
            _continue = true;
            Thread readThread = new Thread(Read);

            readThread.Start();
            readThread.Join();
        }


        public static void Send(string msg)
        {
            var request = new RestRequest("Add", Method.Post);

            request.AddBody(msg);
            request.RequestFormat = DataFormat.Json;
            var respose = client.Execute(request);
            Console.WriteLine(respose.ResponseStatus);
            Thread.Sleep(200);
        }



        public static void Read()
        {
            while (_continue)
            {
                try
                {
                    string message = _serialPort.ReadLine();
                    Send(message);
                    Console.WriteLine(message);
                }
                catch (TimeoutException) { }
            }
        }
    }
}
