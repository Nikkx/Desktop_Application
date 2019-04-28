using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using FlightSimulator.Model;

namespace FlightSimulator.Model
{
   public class FlightControlModel
    {
        
        /// <summary>
        /// gets text and passes it as commands to flight simulator
        /// </summary>
        /// <param name="text"></param>
        public void autoPilot(string text)
        {
            //splits the text into strings for each individual line
            string[] lines = text.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines){
            TCPClient client = TCPClient.Instance;
            client.Write(line);
                }
        }

        /*
         * Receives a command (as a string) and sends the command
         * to the active TCPClient (to be sent onwwards to the simulator)
         */
        public void Send(string command){
        TCPClient client = TCPClient.Instance;
            client.Write(command);
        }


        private double rudder = 0;
        public double Rudder
        {
            set
            {
                rudder = value;
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
