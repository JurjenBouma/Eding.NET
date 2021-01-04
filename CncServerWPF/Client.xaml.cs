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
using System.Windows.Shapes;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using EdingDotNET.Types;
using EdingDotNET.Remote;

namespace CncServerController
{
    /// <summary>
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        System.Windows.Threading.DispatcherTimer timer;
        CNCRemote CNCRemote;
        public Client()
        {
            InitializeComponent();
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += Timer1_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            //TcpChannel channel = new TcpChannel();
            //ChannelServices.RegisterChannel(channel, false);
            CNCRemote = (CNCRemote)Activator.GetObject(typeof(CNCRemote), "tcp://localhost:5664/CncServerDotNet");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RCResult r = CNCRemote.CNCConnectServer("cnc.ini");
            richtextbox1.Document.Blocks.Add(new Paragraph(new Run(r.ToString())));
            if (r == RCResult.CNC_RC_OK)
                timer.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CNCRemote.CNCDisconnectServer();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CNCRemote.CNCReset();
            CNCRemote.CNCSetOutput(CNCIOID.CNC_IOID_DRIVE_ENABLE_OUT, 1);
            CNCRemote.CNCSetSpindleSpeed(10000);
            CNCRemote.CNCStartSpindle();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CNCRemote.CNCHomeAll();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            CNCRemote.CNCZeroAll();
           //CNCRemote.CNCZero(CNCAxis.ALL_AXES);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            CNCRemote.CNCStartJog2(CNCAxis.X_AXIS, 10.0, 1.0, 0);
            CNCRemote.CNCStartJog2(CNCAxis.Y_AXIS, 10.0, 1.0, 0);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            CNCPositions machPos = CNCRemote.CNCGetMachinePosition();
            LabelXmach.Content = "X : " + string.Format("{0:000.000}", machPos.x);
            LabelYmach.Content = "Y : " + string.Format("{0:000.000}", machPos.y);
            LabelZmach.Content = "Z : " + string.Format("{0:000.000}", machPos.z);

            CNCPositions workPos = CNCRemote.CNCGetWorkPosition();
            LabelXwork.Content = "X : " + string.Format("{0:000.000}", workPos.x);
            LabelYwork.Content = "Y : " + string.Format("{0:000.000}", workPos.y);
            LabelZwork.Content = "Z : " + string.Format("{0:000.000}", workPos.z);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                CNCRemote.CloseDotNetServer();
            }
            catch{ }
        }
    }
}
