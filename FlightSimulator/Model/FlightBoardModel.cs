using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlightSimulator.Model
{

    public class FlightBoardModel
    {

        #region Singleton
        private FlightBoardModel m_Instance = null;
        //private FlightBoardModel() { }
        public FlightBoardModel Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new FlightBoardModel();
                }
                return m_Instance;
            }
        }
        #endregion

        private double lon;
        public double Lon
        {
            get
            {
                return lon;
            }
            set
            {
                //get the value from flight simulator - first value that comes from server??
                
            }
        }

        private double lat;
        public double Lat
        {
            get
            {
                return lat;
            }
            set
            {
                
            }
        }

        //this function connects to the server and client.
        public void connect()
        {
            TcpServer myServer = new TcpServer();
            TcpClient myClient = new TcpClient();
        }

        public void updateMapLocation(string input)
        {
            /*
             * Insert parsing code for Latitude/Longitude
             */
             //need to add:
            //Vm_PropertyChanged(newLocation, info);
        }
    }
}
