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
        private bool connectYet=false;
        
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
        private IPEndPoint ep;
        public BinaryWriter writer;
        //private IPEndPoint ep;

        public TCPClient()
        {
            client = new TcpClient();
            ep = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP), ApplicationSettingsModel.Instance.FlightCommandPort);

        }

        //This function is called whenever we need to connect to the simulator
        //Note: It WILL continuesly throw "NULL Socket Exceptions" until it finds a Server (this will not stop the code running)
        public void TCPConnect(){
                        new Task(() =>
            {
                try
                {
                    while (!client.Connected)
                    {
                        try{
                                client.Connect(ep);
                            }
                        catch(Exception e){
                             continue;
                            }
                    }
                    writer=new BinaryWriter(client.GetStream());
                }
                catch (Exception e) { }
            }).Start();
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