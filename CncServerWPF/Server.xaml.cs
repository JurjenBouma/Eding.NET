using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using EdingDotNET.Types;
using EdingDotNET.APIWrapper;
using EdingDotNET.Remote;
using EdingDotNET;

namespace CncServerController
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ServerHiddenWindow : Window
    {
        CNCController cncController;
        CNCRemote cncRemoteObj;
        System.Windows.Threading.DispatcherTimer controllerTimer;
        System.Windows.Forms.NotifyIcon notifyIcon;
        System.Windows.Forms.ContextMenuStrip notifyMenu;
       
        public ServerHiddenWindow()
        {
            InitializeComponent();

            //System tray icon
            notifyIcon = new System.Windows.Forms.NotifyIcon()
            {
                Icon = CncServerController.Properties.Resources.AOEICON,
                Text = "CncServer.Net",
                Visible = true
            };
            notifyMenu = new System.Windows.Forms.ContextMenuStrip();
            notifyMenu.Items.Add("Exit CncServer",null, EXITCncServerItem_Click);
            //notifyMenu.Items.Add("Show test client", null, ShowTest);
            notifyIcon.ContextMenuStrip = notifyMenu;

            //Registering RemoteObj
            cncRemoteObj = new CNCRemote(5664);
            cncController = new CNCController(cncRemoteObj);  //Create CNCController
            controllerTimer = new System.Windows.Threading.DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };//Timer to check for close request
            controllerTimer.Tick += Timer_Tick;
            controllerTimer.Start();
            Application.Current.Exit += new ExitEventHandler(CloseServer);
        }

        private void Timer_Tick(object sender,EventArgs e)
        {
            if (!cncController.IsActive)
                Application.Current.Shutdown();
        }

        private void ShowTest(object sender, EventArgs e)
        {
            //Temp client for testing
            Client  c = new Client();
            c.Show();
        }

        private void EXITCncServerItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Closing this process will close connection with CNC. Are you sure you want to Exit?","Exiting CncServer",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            Application.Current.Shutdown();
        }

        private void CloseServer(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            cncController.CNCDisconnectServer();
            RemotingServices.Disconnect(cncRemoteObj);
        }
    }
}
