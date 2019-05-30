using Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;

namespace BankServer
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpServerChannel channel = new HttpServerChannel(12345);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(BankLogic), "Bank", WellKnownObjectMode.SingleCall);
            Console.ReadLine();
        }
    }
}
