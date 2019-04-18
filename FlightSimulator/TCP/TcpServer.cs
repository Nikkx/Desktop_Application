using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class TcpServer
{
    private TcpListener server;
    private Boolean isRunning;

    public TcpServer(int port)
    {
        server = new TcpListener(IPAddress.Any, port);
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
            Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
            t.Start(newClient);
        }
    }

    public void HandleClient(object obj)
    {
        // retrieve client from parameter passed to thread
        TcpClient client = (TcpClient)obj;

        // sets two streams
        StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);
        StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);
        // you could use the NetworkStream to read and write, 
        // but there is no forcing flush, even when requested

        Boolean bClientConnected = true;
        String sData = null;

        while (bClientConnected)
        {
            // reads from stream
            sData = sReader.ReadLine();

            // shows content on the console.
            Console.WriteLine("Client &gt; " + sData);

            // to write something back.
            // sWriter.WriteLine("Meaningfull things here");
            // sWriter.Flush();
        }
    }
}