using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using EdingDotNET;
using EdingDotNET.Remote;
using EdingDotNET.APIWrapper;

namespace EdingDotNET.CncServerDotNet
{
    class CncServerDotNet
    {
        public static void Main(string[] args)
        {
            TcpChannel channel = new TcpChannel(5664);
            ChannelServices.RegisterChannel(channel,false);
            CNCRemoteObj cncRemoteObj = new CNCRemoteObj();
            ObjRef objRefCNCRemoteObj = RemotingServices.Marshal(cncRemoteObj, "CncServerDotNet");

            while (cncRemoteObj.IsActive)
            {

            }
            
            RemotingServices.Disconnect(cncRemoteObj);
        }
    }
}
