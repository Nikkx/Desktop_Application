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

        //private TCPServer server;
        private double lon;
        public double Lon
        {
            get { return lon; }
            set
            {
                lon = TCPServer.Instance.Lon;
                NotifyPropertyChanged("Lon");
            }
        }

        private double lat;
        public double Lat
        {
            get { return lat; }
            set
            {
                lat = TCPServer.Instance.Lat;
                NotifyPropertyChanged("Lat");
            }
        }



        
    }
}