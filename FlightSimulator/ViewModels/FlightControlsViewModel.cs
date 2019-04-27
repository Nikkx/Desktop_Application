using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class FlightControlsViewModel : BaseNotify
    {
        private string color;
        public string Color
        {
            set { }
            get
            {
                if (text == null || text == "")
                    color = "White";
                else
                    color = "rosyBrown";
                return color;
            }
        }

        TextBox textBox = new TextBox();
        private string text;
        public string Text
        {
            get { return text; }
            set
            { 
                text = value;
                NotifyPropertyChanged("Color");
                NotifyPropertyChanged("TextBox");
            }
        }

        //public static readonly DependencyProperty MyPropertyProperty = DependencyProperty.Register("MyProperty", typeof(string), typeof(FlightControlsViewModel), new PropertyMetadata(0));

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
            //todo: pass text to server/client/whatever

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
            Text = "";//todo: doesn't erase text WHYYYY change in code doesn't change GUI
            text = "";
            textBox.Text = "";
        }

        #endregion Commands
    }
}
