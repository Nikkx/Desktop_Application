using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySettings
{
    class TcpSettings
    {
        private string flightServerIP;
        private string flightInfoPort;
        private string flightCommandPort;

        //constructors
        public TcpSettings()
        {
            flightServerIP = "127.0.0.1";
            flightInfoPort = "5400";
            flightCommandPort = "5402";
        }

        public TcpSettings(string flightServerIP, string flightInfoPort, string flightCommandPort)
        {
            this.flightServerIP = flightServerIP;
            this.flightInfoPort = flightInfoPort;
            this.flightCommandPort = flightCommandPort;
        }

        //getters and setters
        public string getFlightIP()
        {
            return flightServerIP;
        }

        public void setFlightServerIP(string newInput)
        {
            flightServerIP = newInput;
        }

        public string getInfoPort()
        {
            return flightInfoPort;
        }

        public void setInfoPort(string newInput)
        {
            flightInfoPort = newInput;
        }


        public string getCommandPort()
        {
            return flightCommandPort;
        }

        public void getCommandPort(string newInput)
        {
            flightCommandPort = newInput;
        }
    }
}
