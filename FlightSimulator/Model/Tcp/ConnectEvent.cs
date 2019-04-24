using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;

namespace FlightSimulator.Model.Tcp
{
    /*
     * This class is meant to be triggered every time we click the "Connect" button
     */
    class ConnectEvent
    {
        private TcpServer myServer;
        private ClientTCP myClient;
        public ConnectEvent()
        {
            this.myServer = new TcpServer();
            this.myClient = new ClientTCP();
        }
    }
}
