using FlightSimulator.Model;
using FlightSimulator.Model.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class FlightControlsViewModel : BaseNotify
    {
        //private JoystickViewModel joystickVM;
        //private TCPClient client;
        #region AutoPilotProperties

        private string color;
        public string Color
        {
            get
            {
                if (text == null || text == "")
                    color = "White";
                else
                    color = "rosyBrown";
                return color;
            }
            set { }
        }

        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                NotifyPropertyChanged("Text");
                NotifyPropertyChanged("Color");
            }
        }

        #endregion AutoPilotProperties

        #region ManualProperties

        private double aileron;
        public double Aileron//this works. the property changes when joystick moves.
        {
            get
            {
                return aileron;
            }
            set
            {
                aileron = value;
                NotifyPropertyChanged("Aileron");
            }
        }

        private double elevator;
        public double Elevator
        {
            get
            {
                return elevator;
            }
            set
            {
                elevator = value;
                NotifyPropertyChanged("Elevator");
            }
        }

        private double throttle;
        public double Throttle
        {
            get
            {
                return throttle;
            }
            set
            {
                throttle = value;
                NotifyPropertyChanged("Throttle");
            }
        }
        private double rudder;
        public double Rudder
        {
            get
            {
                return rudder;
            }
            set
            {
                rudder = value;
                NotifyPropertyChanged("Rudder");
            }
        }

        #endregion ManualProperties

        #region Commands

        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => OnClick()));
            }
        }
        private void OnClick()
        {
            //pass text to client

            //clear the window
            OnClear();
        }

        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new CommandHandler(() => OnClear()));
            }
        }
        private void OnClear()
        {
            Text = string.Empty;
        }

        #endregion Commands
    }
}
