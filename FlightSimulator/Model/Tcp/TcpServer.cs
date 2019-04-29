using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlightSimulator.Model;
using FlightSimulator.ViewModels;


public class TCPServer
{
    #region Singleton
    private static TCPServer singleInstance = null;
    public static TCPServer Instance
    {
        get
        {
            if (singleInstance == null)
            {
                singleInstance = new TCPServer();
            }
            return singleInstance;
        }

    }
    #endregion
    private System.Net.Sockets.TcpListener server;
    private Boolean isRunning=false;


    public TCPServer()
    {
        System.Diagnostics.Debug.WriteLine("TCP");

        ApplicationSettingsModel currentSettings = new ApplicationSettingsModel();
        IPAddress currentIP = IPAddress.Parse(currentSettings.FlightServerIP);
        int port = System.Convert.ToInt32(currentSettings.FlightInfoPort);
        server = new System.Net.Sockets.TcpListener(currentIP, port);
        server.Start();
        isRunning = true;

        System.Diagnostics.Debug.WriteLine("Loop");
        LoopClients();
    }

    public void LoopClients()
    {
        System.Diagnostics.Debug.WriteLine("Pre-Task");
        new Task(() =>
        {
            while (isRunning)
            {
                System.Diagnostics.Debug.WriteLine("running");
                //we wait for client connection
                System.Net.Sockets.TcpClient newClient = server.AcceptTcpClient();
                System.Diagnostics.Debug.WriteLine("We Passed!");
                // once the client is found we create a thread to handle communication
                Thread newThread = new Thread(new ParameterizedThreadStart(HandleClient));
                newThread.Start(newClient);

            }
        }).Start();
        System.Diagnostics.Debug.WriteLine("Post-Task");
    }
    //Keep the current PLane location-this will always be updated to the PLane's
    //current location
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
               FlightBoardModel.Instance.Lon = temp_lon;
                FlightBoardModel.Instance.Lat = temp_lat;
            }

            //after implementing the inputs we reset sReader to null
            sData = null;
        }
    }

    public void Stop()
    {
        server.Stop();
    }

    ~TCPServer(){
        Stop();
    }

}