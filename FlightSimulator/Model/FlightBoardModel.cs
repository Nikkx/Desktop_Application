using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardModel : BaseNotify
    {
        #region Singleton
        private static FlightBoardModel oneInstance = null;
        public static FlightBoardModel Instance
        {
            get
            {
                if (oneInstance == null)
                {
                    oneInstance = new FlightBoardModel();
                }
                return oneInstance;
            }
        }
        #endregion

        private double lon;
        public double Lon
        {
            get { return lon; }
            set
            {
                lon = value;
                NotifyPropertyChanged("Lon");
            }
        }

        private double lat;
        public double Lat
        {
            get { return lat; }
            set
            {
                lat = value;
                NotifyPropertyChanged("Lat");
            }
        }

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
         public void Connect(){
            is_connect = true;
            server = new TCPServer();
            TCPClient client = new TCPClient();

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