using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EdingDotNET.Remote;
using EdingDotNET.Types;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Web.Script.Serialization;
using System.Globalization;

namespace LANCNC
{
    public partial class MainForm : System.Web.UI.Page
    {
        private User m_currentUser;

        public User GetCurrentUser
        {
            get
            {
                if (m_currentUser.Name != null)
                {

                    return m_currentUser;
                }
                m_currentUser = CNCGlobals.Users.SignInUser(CNCGlobals.GetIPAdress());
                return m_currentUser;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!Page.IsPostBack)
            {
                //rendering calls
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Init3D", "Init3D();", true);

                m_currentUser = CNCGlobals.Users.SignInUser(CNCGlobals.GetIPAdress());
                CNCGlobals.Users.Save();
                switch (GetCurrentUser.AccessLevel)
                {
                    case UserAccessLevel.None:
                        ImageButtonMain.Visible = false;
                        ImageButtonJog.Visible = false;
                        ImageButtonAuto.Visible = false;
                        ImageButtonTool.Visible = false;
                        ImageButtonSettings.Visible = false;
                        ImageButtonAdmin.Visible = false;
                        PanelHomeButtons.Visible = false;
                        PanelZeroButtons.Visible = false;
                        SetActiveControl(UserControl.None);
                        Response.Redirect("~/Default.aspx");
                        break;
                    case UserAccessLevel.Watch:
                        ImageButtonMain.Visible = false;
                        ImageButtonJog.Visible = false;
                        ImageButtonAuto.Visible = false;
                        ImageButtonTool.Visible = false;
                        ImageButtonSettings.Visible = false;
                        ImageButtonAdmin.Visible = false;
                        PanelHomeButtons.Visible = false;
                        PanelZeroButtons.Visible = false;
                        SetActiveControl(UserControl.None);
                        break;
                    case UserAccessLevel.Upload:
                        ImageButtonMain.Visible = false;
                        ImageButtonJog.Visible = false;
                        ImageButtonAuto.Visible = true;
                        ImageButtonTool.Visible = false;
                        ImageButtonSettings.Visible = false;
                        ImageButtonAdmin.Visible = false;
                        PanelHomeButtons.Visible = false;
                        PanelZeroButtons.Visible = false;
                        SetActiveControl(UserControl.JobControls);
                        break;
                    case UserAccessLevel.Control:
                        ImageButtonMain.Visible = true;
                        ImageButtonJog.Visible = true;
                        ImageButtonAuto.Visible = true;
                        ImageButtonTool.Visible = false;
                        ImageButtonSettings.Visible = false;
                        ImageButtonAdmin.Visible = false;
                        PanelHomeButtons.Visible = true;
                        PanelZeroButtons.Visible = true;
                        SetActiveControl(UserControl.MainControls);
                        break;

                    case UserAccessLevel.Admin:
                        ImageButtonMain.Visible = true;
                        ImageButtonJog.Visible = true;
                        ImageButtonAuto.Visible = true;
                        ImageButtonTool.Visible = true;
                        ImageButtonSettings.Visible = true;
                        ImageButtonAdmin.Visible = true;
                        PanelHomeButtons.Visible = true;
                        PanelZeroButtons.Visible = true;
                        SetActiveControl(UserControl.MainControls);
                        break;
                }
            }
        }

        public enum UserControl {
            MainControls,
            JobControls,
            JogControls,
            ToolSettings,
            GeneralSettings,
            AdminControls,
            ToolMeasurement,
            None
        }
        public void SetActiveControl(UserControl control)
        {
            switch(control)
            {
                case UserControl.MainControls:
                    MainControlUI.Show();
                    JobUI.Hide();
                    JogUI.Hide();
                    AdminUI.Hide();
                    ToolUI.Hide();
                    SettingsUI.Hide();
                    ToolMeasurementUI.Hide();
                    break;
                case UserControl.JobControls:
                    MainControlUI.Hide();
                    JobUI.Show();
                    JogUI.Hide();
                    AdminUI.Hide();
                    ToolUI.Hide();
                    SettingsUI.Hide();
                    ToolMeasurementUI.Hide();
                    break;
                case UserControl.JogControls:
                    MainControlUI.Hide();
                    JobUI.Hide();
                    JogUI.Show();
                    AdminUI.Hide();
                    ToolUI.Hide();
                    SettingsUI.Hide();
                    ToolMeasurementUI.Hide();
                    break;
                case UserControl.ToolSettings:
                    MainControlUI.Hide();
                    JobUI.Hide();
                    JogUI.Hide();
                    AdminUI.Hide();
                    ToolUI.Show();
                    SettingsUI.Hide();
                    ToolMeasurementUI.Hide();
                    break;
                case UserControl.GeneralSettings:
                    MainControlUI.Hide();
                    JobUI.Hide();
                    JogUI.Hide();
                    AdminUI.Hide();
                    ToolUI.Hide();
                    SettingsUI.Show();
                    ToolMeasurementUI.Hide();
                    break;
                case UserControl.AdminControls:
                    MainControlUI.Hide();
                    JobUI.Hide();
                    JogUI.Hide();
                    AdminUI.Show();
                    ToolUI.Hide();
                    SettingsUI.Hide();
                    ToolMeasurementUI.Hide();
                    break;
                case UserControl.ToolMeasurement:
                    MainControlUI.Hide();
                    JobUI.Hide();
                    JogUI.Hide();
                    AdminUI.Hide();
                    ToolUI.Hide();
                    SettingsUI.Hide();
                    ToolMeasurementUI.Show();
                    break;
                case UserControl.None:
                    MainControlUI.Hide();
                    JobUI.Hide();
                    JogUI.Hide();
                    AdminUI.Hide();
                    ToolUI.Hide();
                    SettingsUI.Hide();
                    ToolMeasurementUI.Hide();
                    break;
            }
        }

        protected void ImageButtonMain_Click(object sender, ImageClickEventArgs e)
        {
            SetActiveControl(UserControl.MainControls);
        }

        protected void ImageButtonJog_Click(object sender, ImageClickEventArgs e)
        {
            SetActiveControl(UserControl.JogControls);
        }

        protected void ImageButtonAuto_Click(object sender, ImageClickEventArgs e)
        {
            SetActiveControl(UserControl.JobControls);
        }

        protected void ImageButtonToolMeasurement_Click(object sender, ImageClickEventArgs e)
        {
            SetActiveControl(UserControl.ToolMeasurement);
        }

        protected void ImageButtonTool_Click(object sender, ImageClickEventArgs e)
        {
            SetActiveControl(UserControl.ToolSettings);
        }

        protected void ImageButtonSettings_Click(object sender, ImageClickEventArgs e)
        {
            SetActiveControl(UserControl.GeneralSettings);
        }

        protected void ImageButtonAdmin_Click(object sender, ImageClickEventArgs e)
        {
            SetActiveControl(UserControl.AdminControls);
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //update status labels

            //update work coords
            CNCPositions workPos = CNCGlobals.CNC.CNCGetWorkPosition();
            LabelXwork.Text = "X : " + workPos.x.ToString("000.000", CultureInfo.InvariantCulture);
            LabelYwork.Text = "Y : " + workPos.y.ToString("000.000", CultureInfo.InvariantCulture);
            LabelZwork.Text = "Z : " + workPos.z.ToString("000.000", CultureInfo.InvariantCulture);

            //update machine coords
            CNCPositions machPos = CNCGlobals.CNC.CNCGetMachinePosition();
            LabelXmach.Text = "X : " + machPos.x.ToString("000.000",CultureInfo.InvariantCulture);
            LabelYmach.Text = "Y : " + machPos.y.ToString("000.000", CultureInfo.InvariantCulture);
            LabelZmach.Text = "Z : " + machPos.z.ToString("000.000", CultureInfo.InvariantCulture);

            UpdateInfoLabel();

            UpdateRenderFields();

            IsSpindleSpinning.Value = Rendering.serializer.Serialize(CNCGlobals.CNC.CNCGetSpindleStatus().spindleIsOn);

            ReadCNCMessages();

            CNCGlobals.WatchEmergencyStop();
        }

        private void ReadCNCMessages()
        {
            if (CNCGlobals.GetCNCMessages())
            {
                for (int i = MainControlUI.ListBoxServerMessages.Items.Count; i < CNCGlobals.MessageBuffer.Count; i++)
                {
                    MainControlUI.ListBoxServerMessages.Items.Insert(0, CNCGlobals.MessageBuffer[i].text);
                }
                UpdatePanel4.Update();
            }
        }

        private void UpdateRenderFields()
        {
            CNCPositions machPos = CNCGlobals.CNC.CNCGetMachinePosition();
            CNCPositions zeroPos = CNCGlobals.CNC.CNCGetMachineZeroWorkPoint();

            float[] zeroXYZ = new float[] { (float)(zeroPos.x), (float)(zeroPos.y), (float)(zeroPos.z) };
            ZeroPosition.Value = Rendering.serializer.Serialize(zeroXYZ);

            float[] machXYZ = new float[] { (float)machPos.x, (float)machPos.y, (float)machPos.z };
            MachinePosition.Value = Rendering.serializer.Serialize(machXYZ);

            CameraPosition.Value = Rendering.serializer.Serialize(Rendering.camPos);
            CameraLookAt.Value = Rendering.serializer.Serialize(Rendering.lookAt);
        }

        private void UpdateInfoLabel()
        {
            LabelStatusInfo.Text = "Feed : " + (CNCGlobals.VelocityFactor >= 0.04?  Math.Round(CNCGlobals.VelocityFactor * 100, 0).ToString() + "%" : "Precise Jog") + " | " + "RPM : " + Math.Round(CNCGlobals.CNC.CNCGetActualSpeed()).ToString() +
                " | Drives : " + CNCGlobals.CNC.CNCGetOutput(CNCIOID.CNC_IOID_DRIVE_ENABLE_OUT).ToString();
            if ((Path.GetFileName(CNCGlobals.CNC.CNCGetJobStatus().jobName).Length > 0))
                LabelStatusInfo.Text += "\n Running time : " + TimeSpan.FromSeconds((int)CNCGlobals.CNC.CNCGetJobStatus().jobActualRunningTime).ToString() +
                    " | Total time : " + TimeSpan.FromSeconds((int)CNCGlobals.CNC.CNCGetJobStatus().jobEstimatedTime).ToString();
            LabelStatusInfo.Text += " | Tool: " + CNCGlobals.CNC.CNCGetToolData(CNCGlobals.CNC.CNCGetCurrentToolNumber()).description;
            if (CNCGlobals.CNC.CNCGetSimulationMode() != 0)
                LabelStatusInfo.Text += " | Simulation";
       
        }

        protected void ImageButtonZeroX_Click(object sender, ImageClickEventArgs e)
        {
            CNCGlobals.CNC.CNCZero(CNCAxis.X_AXIS);
            Rendering.RenderZero();
        }

        protected void ImageButtonZeroY_Click(object sender, ImageClickEventArgs e)
        {
            CNCGlobals.CNC.CNCZero(CNCAxis.Y_AXIS);
            Rendering.RenderZero();
        }

        protected void ImageButtonZeroZ_Click(object sender, ImageClickEventArgs e)
        {
            CNCGlobals.CNC.CNCZero(CNCAxis.Z_AXIS);
            Rendering.RenderZero();
        }

        protected void ImageButtonHomeX_Click(object sender, ImageClickEventArgs e)
        {
            CNCGlobals.CNC.CNCHome(CNCAxis.X_AXIS);
        }

        protected void ImageButtonHomeY_Click(object sender, ImageClickEventArgs e)
        {
            CNCGlobals.CNC.CNCHome(CNCAxis.Y_AXIS);
        }

        protected void ImageButtonHomeZ_Click(object sender, ImageClickEventArgs e)
        {
            CNCGlobals.CNC.CNCHome(CNCAxis.Z_AXIS);
        }

        protected void ImageButtonXWorkDialog_Click(object sender, ImageClickEventArgs e)
        {
            WorkCoordDialogX.Show();
        }

        protected void ImageButtonYWorkDialog_Click(object sender, ImageClickEventArgs e)
        {
            WorkCoordDialogY.Show();
        }

        protected void ImageButtonZWorkDialog_Click(object sender, ImageClickEventArgs e)
        {
            WorkCoordDialogZ.Show();
        }

        protected void ButtonMDI_Click(object sender, EventArgs e)
        {
            CNCGlobals.CNC.CNCRunSingleLine(TextBoxMDI.Text);
        }
    }
}