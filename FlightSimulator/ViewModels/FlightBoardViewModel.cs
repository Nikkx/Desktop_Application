using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {

        private FlightBoardModel model;

        public FlightBoardViewModel(FlightBoardModel model)
        {
            this.model = model;
        }

        private double lon;
        public double Lon
        {
            get { return lon; }
            set
            {
                lon = model.Lon;
                NotifyPropertyChanged("Lon");
            }
        }

        private double lat;
        public double Lat
        {
            get { return lat; }
            set
            {
                lat = model.Lat;
                NotifyPropertyChanged("Lat");
            }
        }

    }
}
