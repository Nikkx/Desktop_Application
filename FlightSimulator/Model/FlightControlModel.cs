using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class FlightControlModel
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

        public void manualPilot(){

           }



    }
}
