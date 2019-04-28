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

        #region Commands

        private ICommand _openSettings;
        public ICommand OpenSettings
        {
            get
            {
                return _openSettings ?? (_openSettings = new CommandHandler(() => OnSettingsClick()));
            }
        }

        private void OnSettingsClick()
        {
            var settingsWin = new Settings();
            settingsWin.Show();
        }


        private ICommand _connect;
        public ICommand Connect
        {
            get
            {
                return _connect ?? (_connect = new CommandHandler(() => OnConnectClick()));
            }
        }

        private void OnConnectClick()
        {
            model.Connect();
        }
        #endregion Commands
    }
}
