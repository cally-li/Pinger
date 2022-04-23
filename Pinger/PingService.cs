using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Pinger
{
    public class PingService
    {
        //properties available to the class
        public Ping pingSender { get; set; }    
        public PingOptions pingOptions { get; set; }
        private string data;
        public string Data
        {
            get { return data; }
            set 
            { 
                if (value.Length<=32)
                {
                  data = value; 
                }
                else
                {
                    data = "aaaaaaaaaa";
                }
            }
        }
        public byte[] buffer { get; set; }
        public int timeout{ get; set; }
        public PingReply reply { get; set; }    

        //constructor
        public PingService(string pingdata)
        {
            //instantiate pingSender as a new ping object
            pingSender = new Ping();
            pingOptions = new PingOptions();
            //no fragmentation of transmitted data
            pingOptions.DontFragment= true; 
            Data = pingdata;
            buffer = Encoding.ASCII.GetBytes(Data);
            timeout = 120;
        }

        //class method for sending ping and displaying response
        public void sendPing(string hostName)
        {
            reply= pingSender.Send(hostName, timeout, buffer, pingOptions);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Pinging successful!");
                Console.WriteLine("Address: {0}", reply.Address.ToString());
                Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
            }
            else
            {
                Console.WriteLine("Pinging failed!");
            }

        }
    }
}
