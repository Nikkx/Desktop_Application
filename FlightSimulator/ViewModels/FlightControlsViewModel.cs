using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class FlightControlsViewModel : BaseNotify
    {
        private string color;
        public string Color
        {
            get
            {
                if (textBox == null || textBox=="")
                    color = "White";
                else
                    color = "rosyBrown";
                return color;
            }
        }
        private string textBox;
        public string TextBox
        {
            get { return textBox; }
            set
            {
                textBox = value;
                NotifyPropertyChanged("Color");
                NotifyPropertyChanged("TextBox");
            }
        }
    }
}
