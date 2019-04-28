using FlightSimulator.Model;
using FlightSimulator.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class FullFlightBoardViewModel
    {
        private FullFlightBoardModel model;

        public FullFlightBoardViewModel(FullFlightBoardModel model)
        {
            this.model = model;
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
