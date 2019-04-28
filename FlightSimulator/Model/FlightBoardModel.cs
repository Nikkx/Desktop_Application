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
                lat = value;//until here all good
                NotifyPropertyChanged("Lat");
            }
        }

        //make de3legade and event, invoke event in set,VM subscribed to event

        
    }
}