using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EdingDotNET.Remote;
using EdingDotNET.Types;
using System.IO;

namespace LANCNC
{
    public static class CNCGlobals
    {
        public static CNCRemote CNC;
        public static UserFile Users;
        private static bool m_isInitialized = false;
        public static bool IsInitialized { get { return m_isInitialized; } }
        private static string m_serverPath;
        private static long lastTimeChecked;
        public static List<CNCLogMessage> MessageBuffer;
        public static bool PreciseJogMode = false;
        private static double m_velocityFactor = 0.25;
        public static double VelocityFactor { get { return m_velocityFactor; }
            set {
                if (value > 1)
                    m_velocityFactor = 1;
                else if (value < 0.005)
                    m_velocityFactor = 0.005;
                else
                    m_velocityFactor = value;
            } }

        public static void Initialize(string UserFile,string ServerPath)
        {
            //Call on first load every server run only
            if (!m_isInitialized)
            {
                m_serverPath = ServerPath;
                Directory.CreateDirectory(m_serverPath + "Jobs");
                Directory.CreateDirectory(m_serverPath + "Deleted");
                Directory.CreateDirectory(m_serverPath + "Other Files");

                if (CNC == null)
                    CNC = CNCRemote.ConnectRemote(5664);
                if (CNC.CNCIsServerConnected() != 1)
                {
                    CNC.CNCConnectServer("CNCLAN.ini").ToString();
                    CNCSafetyConfig safetyConfig = CNC.CNCGetSafetyConfig();
                    safetyConfig.allowJoggingBeforeHoming = 1;
                    CNC.CNCSetSafetyConfig(safetyConfig);
                    CNC.CNCSetSimulationMode(0);
                }

                Users = new UserFile(UserFile);
                MessageBuffer = new List<CNCLogMessage>();

                lastTimeChecked = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;//set time for message buffer
                m_isInitialized = true;
            }
        }

        public static bool GetCNCMessages()
        {
            bool receivedMessage = false;
            long timeNow = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            if (timeNow - lastTimeChecked > 500)
            {
                CNCLogMessage message = CNC.CNCGetLogFifo();
                while(message.getMessageFifoRC != RCResult.CNC_RC_BUF_EMPTY)
                {
                    MessageBuffer.Add(message);
                    receivedMessage = true;
                    message = CNC.CNCGetLogFifo();//read next message
                }
                lastTimeChecked = timeNow;
            }
            return receivedMessage;
        }

        public static string GetIPAdress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAdress = context.Request.UserHostAddress;
            if(!string.IsNullOrEmpty(ipAdress)&& ipAdress.Trim() != "::1")
            {
                string[] addresses = ipAdress.Split(',');
                if(addresses.Length !=0)
                {
                    return addresses[0];
                }
            }
            else if(ipAdress.Trim() == "::1")
            {
                string hostName = Dns.GetHostName();
                IPHostEntry ipHostEntries = Dns.GetHostEntry(hostName);
                IPAddress[] ipAdresses = ipHostEntries.AddressList;
                try {ipAdress = ipAdresses[ipAdresses.Length - 2].ToString();}
                catch
                {
                    try
                    {
                        ipAdress = ipAdresses[0].ToString();
                    }
                    catch
                    {
                        try
                        {
                            ipAdresses = Dns.GetHostAddresses(hostName);
                            ipAdress = ipAdresses[0].ToString();
                        }
                        catch
                        {
                            ipAdress = hostName;
                        }
                    }
                }
            }

            return ipAdress;
        }

        public static void WatchEmergencyStop()
        {
            int EMValue = CNC.CNCGetEMStopActive();
            if (EMValue == 1)
            {
                CNC.CNCAbortJob();
            }
        }
    }
}