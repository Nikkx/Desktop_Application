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
        private FlightControlModel model;

        public FlightControlsViewModel(FlightControlModel model)
        {
            this.model = model;
        }

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

        public double Aileron//this works. the property changes when joystick moves.
        {
            set
            { 
                if(TCPClient.Instance.client.Connected)
                model.Send("set /controls/flight/aileron " + Convert.ToString(value));
            }
        }

        public double Elevator
        {
            set
            {
                if(TCPClient.Instance.client.Connected)
                model.Send("set /controls/flight/elevator " + Convert.ToString(value));
            }
        }

        public double Throttle
        {
            set
            {
                if(TCPClient.Instance.client.Connected)
                model.Send("set /controls/engines/current-engine/throttle " + Convert.ToString(value));
            }
        }

        public double Rudder
        {
            set
            {
                if(TCPClient.Instance.client.Connected)
                model.Send("set /controls/flight/rudder " + Convert.ToString(value));
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
            model.autoPilot(Text);
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
