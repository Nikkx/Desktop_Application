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
        
        public double Lon
        {
            get;
        }

        public double Lat
        {
            get;
        }

        #region Commands

        private ICommand _openSettings;
        public ICommand OpenSettings {
            get {
                return _openSettings ?? (_openSettings=new CommandHandler(() => OnClick()));
            }
        }

        private void OnClick()
        {
            var settingsWin = new Settings();
            settingsWin.Show();
        }

        #endregion Commands
    }
}
