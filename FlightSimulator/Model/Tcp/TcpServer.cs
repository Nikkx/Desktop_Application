using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using FlightSimulator.Model;


class TcpServer
{
    private System.Net.Sockets.TcpListener server;
    private Boolean isRunning;

    public TcpServer()
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
        while (isRunning)
        {
            //we wait for client connection
            TcpClient newClient = server.AcceptTcpClient();

            // once the client is found we create a thread to handle communication
            Thread newThread = new Thread(new ParameterizedThreadStart(HandleClient));
            newThread.Start(newClient);
        }
    }


    /*
     * Note to future self: contains code for writing back to the client, this isn't relevant
     * for Milestone3 but will likely be needed later on. I left it in-just remove the relavant //
     */
    public void HandleClient(object obj)
    {
        // retrieve client from parameter passed to thread
        TcpClient client = (TcpClient)obj;

        // sets two streams one for reading (relevant) and one for writing (not relevant)
        // StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);


        StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);

        Boolean bClientConnected = true;
        String sData = null;

        while (bClientConnected)
        {
            // reads from stream
            sData = sReader.ReadLine();

            //if we received any inputs from the simulator/client we implement them
            if (sData != null)
            {

                //implement "input event" here
            }

            //after implementing the inputs we reset sReader to null
            sData = null;



            //Note:again not relvant for Milestone3-for later use
            // shows content on the console.
            // Console.WriteLine("Client &gt; " + sData);

            // to write something back.
            // sWriter.WriteLine("This isnt relevant for Milestone3");
            // sWriter.Flush();
        }
    }
}
