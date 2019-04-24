using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using FlightSimulator.Model;


class ClientTCP
{
    private TcpClient client;

    //note: code below only left for future implementations (i.e NOT Milestone3)
    //private StreamReader streamReader;
    private StreamWriter streamWriter;

    private Boolean isConnected;

    public ClientTCP()
    {
        ApplicationSettingsModel currentSettings = new ApplicationSettingsModel();
        client = new TcpClient();
        IPAddress currentIPAddress = IPAddress.Parse(currentSettings.FlightServerIP);
        int portNum = System.Convert.ToInt32(currentSettings.FlightCommandPort);
        client.Connect(currentIPAddress, portNum);

        HandleCommunication();
    }

    /*
     * note to future self: I left in the code implementations for reading (as well as writing) through the client
     * it will likely be needed in future code
     */
    public void HandleCommunication()
    {
        //streamReader = new StreamReader(client.GetStream(), Encoding.ASCII);
        streamWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);

        isConnected = true;
        String sData = null;
        while (isConnected)
        {
            //we input whatever command we wish to send to the simulator
            sData = Console.ReadLine();

            // write/send sData to the connected Server (the simulator)
            streamWriter.WriteLine(sData);

            //clean all the current buffers
            streamWriter.Flush();

            //code for if we want to receive anything (not needed for Milestone3)
            // String sDataIncomming = _sReader.ReadLine();
        }
    }
}
