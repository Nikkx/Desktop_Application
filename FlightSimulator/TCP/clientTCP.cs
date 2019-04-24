using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;


class clientTCP
{
    private TcpClient client;

    private StreamReader streamReader;
    private StreamWriter streamWriter;

    private Boolean isConnected;

    public clientTCP(String ipAddress, int portNum)
    {
        client = new TcpClient();
        client.Connect(ipAddress, portNum);

        HandleCommunication();
    }

    public void HandleCommunication()
    {
        streamReader = new StreamReader(client.GetStream(), Encoding.ASCII);
        streamWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);

        isConnected = true;
        String sData = null;
        while (isConnected)
        {
            Console.Write("&gt; ");
            sData = Console.ReadLine();

            // write data and make sure to flush, or the buffer will continue to 
            // grow, and your data might not be sent when you want it, and will
            // only be sent once the buffer is filled.
            streamWriter.WriteLine(sData);
            streamWriter.Flush();

            // if you want to receive anything
            // String sDataIncomming = _sReader.ReadLine();
        }
    }
}
