using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlightSimulator.Model;


public class TCPServer
{
    private System.Net.Sockets.TcpListener server;
    private Boolean isRunning;
    

    public TCPServer()
    {
        ApplicationSettingsModel currentSettings = new ApplicationSettingsModel();
        IPAddress currentIP = IPAddress.Parse(currentSettings.FlightServerIP);
        int port = System.Convert.ToInt32(currentSettings.FlightInfoPort);
        server = new System.Net.Sockets.TcpListener(currentIP, port);
        server.Start();

        isRunning = true;
        LoopClients();
    }

    public void LoopClients()
    {

        new Task(() =>
        {
        while (isRunning)
        {

            //we wait for client connection
            System.Net.Sockets.TcpClient newClient = server.AcceptTcpClient();
            // once the client is found we create a thread to handle communication
            Thread newThread = new Thread(new ParameterizedThreadStart(HandleClient));
            newThread.Start(newClient);

        }
        });
     }
    public double Lon { get; set; }
    public double Lat { get; set; }

    /*
     * Note to future self: contains code for writing back to the client, this isn't relevant
     * for Milestone3 but will likely be needed later on. I left it in-just remove the relavant //
     */
    public void HandleClient(object obj)
    {
        // retrieve client from parameter passed to thread
        System.Net.Sockets.TcpClient client = (System.Net.Sockets.TcpClient)obj;

        StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);

        Boolean bClientConnected = true;
        String sData = null;
        //once we have a server we declare our singleton use of the FlightBoard (note: this WILL cause problems if we have more
        //than one client thread)
        
        while (bClientConnected)
        {
            // reads from stream
            sData = sReader.ReadLine();
            //makes sure we have a string to work with
            string oneLine = Convert.ToString(sData);
            double temp_lon, temp_lat;
            double[] numbers;
            //if we received any inputs from the simulator/client we implement them
            if (sData != null)
            {
                //we parse the input data into our Latitude and Longitude
                numbers = oneLine.Split(',').Select(n => double.Parse(n)).ToArray();
                temp_lon = numbers[0];
                temp_lat = numbers[1];
                //we set our current location to our (singleton) location
                Lon = temp_lon;
                Lat = temp_lat;
            }

            //after implementing the inputs we reset sReader to null
            sData = null;
        }
    }

            public void Stop()
        {
            server.Stop();
        }
}
