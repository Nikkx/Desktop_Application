using FlightSimulator.Model;
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
