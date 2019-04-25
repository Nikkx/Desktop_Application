using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlightSimulator.Model
{

    class FlightBoardModel
    {


        //this function is used when someone clicks the "Connect" button
        void ClickConnect()
        {
            TcpServer myServer = new TcpServer();
            TcpClient myClient = new TcpClient();
        }

        void updateMapLocation(string input)
        {
            /*
             * Insert parsing code for Latitude/Longitude
             */
             //need to add:
            //Vm_PropertyChanged(newLocation, info);
        }
    }
}
