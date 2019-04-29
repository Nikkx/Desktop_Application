using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class TCPClient
    {
        #region Singleton
        private static TCPClient m_Instance = null;
        public static TCPClient Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new TCPClient();
                }
                return m_Instance;
            }
        }
        #endregion
        public TcpClient client;
       // private ApplicationSettingsModel app;
        private IPEndPoint ep;
        public BinaryWriter writer;

        public TCPClient()
        {
            client = new TcpClient();
            ep = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP), ApplicationSettingsModel.Instance.FlightCommandPort);
            try
            {
                    while (!client.Connected)
                    {
                        client.Connect(ep);
                    }
                    writer=new BinaryWriter(client.GetStream());
                }
                catch (Exception e) { }
        }

        public void Write(string command)
        {
           // using (StreamWriter writer = new StreamWriter(stream))
                //writer.Write(command);
                //writer.Flush();
                writer.Write(Encoding.ASCII.GetBytes(command+"\r\n"));
        }

        public void Close()
        {
            client.Close();
        }
        
        ~TCPClient(){
            Close();
        }

       
    }
}