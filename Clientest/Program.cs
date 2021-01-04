using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using EdingDotNET.Remote;

namespace testclient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get RemoteObj
            TcpChannel channel = new TcpChannel();
            ChannelServices.RegisterChannel(channel,false);
            CNCRemoteObj CNCRemote = (CNCRemoteObj)Activator.GetObject(typeof(CNCRemoteObj), "tcp://localhost:5664/CncServerDotNet");


            Console.WriteLine(CNCRemote.CNCConnectServer("cnc.ini").ToString());
            Console.WriteLine(CNCRemote.CNCReset().ToString());
            Console.WriteLine(CNCRemote.CNCSetOutput(CNCIOID.CNC_IOID_DRIVE_ENABLE_OUT, 1).ToString());
            Console.WriteLine(CNCRemote.CNCStartJog2(CNCAxis.Y_AXIS,5,1,0).ToString());
            Console.ReadKey();

            CNCPositions pos = CNCRemote.CNCGetWorkPosition();
            Console.WriteLine(pos.x.ToString() + " " + pos.y.ToString());

            Console.ReadKey();
            Console.WriteLine(CNCRemote.CNCStartJog2(CNCAxis.Y_AXIS, 12, 1, 0).ToString());

            Console.ReadKey();
            Console.WriteLine(CNCRemote.CNCZeroAll());
            pos = CNCRemote.CNCGetWorkPosition();
            Console.WriteLine(pos.x.ToString() + " " + pos.y.ToString());
            CNCRemote.CNCDisconnectServer();

            Console.ReadKey();
            try { CNCRemote.CloseServerDotNet(); }
            catch { }
        }
    }
}
