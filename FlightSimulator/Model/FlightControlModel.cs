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
            /*TCPClient client = TCPClient.Instance;
            client.Write(line);
                }*/
                TCPClient.Instance.Write(line);
                }
        }

        /*
         * Receives a command (as a string) and sends the command
         * to the active TCPClient (to be sent onwwards to the simulator)
         */
        public void Send(string command){
            if (TCPClient.Instance.client.Connected)
            {
                TCPClient client = TCPClient.Instance;
                client.Write(command);
            }
        
        }


    }


}
