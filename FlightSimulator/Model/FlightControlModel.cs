using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
   public class FlightControlModel
    {
        
        /// <summary>
        /// gets line of text and passes it as commands to flight simulator
        /// </summary>
        /// <param name="text"></param>
        public void autoPilot(string text)
        {
         TCPClient client = TCPClient.Instance;
                client.Write(text);
        }

        private double rudder = 0;
        public double Rudder
        {
            set
            {
                rudder = value;
                if (!FlightBoardModel.Is_connect)
                {
                    return;
                }
                TCPClient client = TCPClient.Instance;
                string command = "set controls/flight/rudder " + rudder + "\r\n";
                client.Write(command);
            }
            get
            { return rudder; }
        }
        private double throttle = 0;

        public double Throttle
        {
            set
            {
                throttle = value;
                if (!FlightBoardModel.Is_connect)
                {
                    return;
                }
                TCPClient client = TCPClient.Instance;
                string command = "set controls/engines/current-engine/throttle " + rudder + "\r\n";
                client.Write(command);
            }
            get
            {
                return throttle;

            }
        }

        private double aileron = 0;

        public double Aileron
        {
            set
            {
                aileron = value;
                if (!FlightBoardModel.Is_connect)
                {
                    return;
                }
                TCPClient client = TCPClient.Instance;
                string command = "set controls/flight/aileron " + rudder + "\r\n";
                client.Write(command);
            }
            get
            {
                return aileron;
            }
        }

        private double elevator = 0;

        public double Elevator
        {
            set
            {
                elevator = value;
                if (!FlightBoardModel.Is_connect)
                {
                    return;
                }
                TCPClient client = TCPClient.Instance;
                string command = "set controls/flight/elevator " + rudder + "\r\n";
                client.Write(command);
            }
            get
            {
                return elevator;
            }
        }
    }


}
