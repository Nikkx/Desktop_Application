using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class FullFlightBoardModel
    {
                
        #region Singleton
        private static FullFlightBoardModel oneInstance = null;
        public static FullFlightBoardModel Instance
        {
            get
            {
                if (oneInstance == null)
                {
                    oneInstance = new FullFlightBoardModel();
                }
                return oneInstance;
            }
        }
        #endregion

        //this is used to determine if we are already connected or not
        static private bool is_connect = false;
        static public bool Is_connect
        {
            get { return is_connect; }
            set
            {
                is_connect = value;
            }
        }

        /*
         * This will create the new "Client" and "Server" threads
         */
        private TCPServer server;
        private TCPClient client;
        public void Connect()
        {
            is_connect = true;
            //TCPClient client = new TCPClient();
            //server = new TCPServer();
            client=TCPClient.Instance;
            client.TCPConnect();
            server = TCPServer.Instance;
        }

        private void DisConnect()
        {
            TCPClient client = new TCPClient();
            client.Close();
            server.Stop();
            is_connect = false;
        }
    }
}
