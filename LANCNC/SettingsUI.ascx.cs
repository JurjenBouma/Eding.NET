using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EdingDotNET.Types;
using System.Globalization;

namespace LANCNC
{
    public partial class SettingsUI : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Show()
        {
            MainForm master = (MainForm)this.Page;

            //Manage access
            switch (master.GetCurrentUser.AccessLevel)
            {
                case UserAccessLevel.None:
                    Response.Redirect("~/Default.aspx");
                    break;
                case UserAccessLevel.Watch:
                    Response.Redirect("~/Default.aspx");
                    break;
                case UserAccessLevel.Upload:
                    Response.Redirect("~/Default.aspx");
                    break;
                case UserAccessLevel.Control:
                    Response.Redirect("~/Default.aspx");
                    break;
            }

            CNCJointConfig xConfig = CNCGlobals.CNC.CNCGetJointConfig(CNCAxis.X_AXIS);
            TextXBoxAcc.Text =  xConfig.maxAcceleration.ToString("0.00", CultureInfo.InvariantCulture);
            TextXBoxBacklash.Text =  xConfig.backLash.ToString("0.000",CultureInfo.InvariantCulture);
            TextXBoxHomePos.Text = xConfig.homePosition.ToString("0.000", CultureInfo.InvariantCulture);
            TextXBoxHomeVelDir.Text = xConfig.homeVelocity.ToString("0.00", CultureInfo.InvariantCulture);
            TextXBoxNegLimit.Text = xConfig.negativeLimit.ToString("0.000", CultureInfo.InvariantCulture);
            TextXBoxPort.Text = (xConfig .cpuPortIndex + 1).ToString(CultureInfo.InvariantCulture);
            TextXBoxPosLimit.Text = xConfig.positiveLimit.ToString("0.000", CultureInfo.InvariantCulture);
            TextXBoxRes.Text = xConfig.resolution.ToString(CultureInfo.InvariantCulture);
            TextXBoxVel.Text = xConfig.maxVelocity.ToString("0.00", CultureInfo.InvariantCulture);

            CNCJointConfig yConfig = CNCGlobals.CNC.CNCGetJointConfig(CNCAxis.Y_AXIS);
            TextYBoxAcc.Text = yConfig.maxAcceleration.ToString("0.00", CultureInfo.InvariantCulture);
            TextYBoxBacklash.Text = yConfig.backLash.ToString("0.000", CultureInfo.InvariantCulture);
            TextYBoxHomePos.Text = yConfig.homePosition.ToString("0.000", CultureInfo.InvariantCulture);
            TextYBoxHomeVelDir.Text = yConfig.homeVelocity.ToString("0.00", CultureInfo.InvariantCulture);
            TextYBoxNegLimit.Text = yConfig.negativeLimit.ToString("0.000", CultureInfo.InvariantCulture);
            TextYBoxPort.Text = (yConfig.cpuPortIndex + 1).ToString(CultureInfo.InvariantCulture);
            TextYBoxPosLimit.Text = yConfig.positiveLimit.ToString("0.000", CultureInfo.InvariantCulture);
            TextYBoxRes.Text = yConfig.resolution.ToString(CultureInfo.InvariantCulture);
            TextYBoxVel.Text = yConfig.maxVelocity.ToString("0.00", CultureInfo.InvariantCulture);

            CNCJointConfig zConfig = CNCGlobals.CNC.CNCGetJointConfig(CNCAxis.Z_AXIS);
            TextZBoxAcc.Text = zConfig.maxAcceleration.ToString("0.00", CultureInfo.InvariantCulture);
            TextZBoxBacklash.Text = zConfig.backLash.ToString("0.000",CultureInfo.InvariantCulture);
            TextZBoxHomePos.Text = zConfig.homePosition.ToString("0.000", CultureInfo.InvariantCulture);
            TextZBoxHomeVelDir.Text = zConfig.homeVelocity.ToString("0.00", CultureInfo.InvariantCulture);
            TextZBoxNegLimit.Text = zConfig.negativeLimit.ToString("0.000",CultureInfo.InvariantCulture);
            TextZBoxPort.Text = (zConfig.cpuPortIndex + 1).ToString(CultureInfo.InvariantCulture);
            TextZBoxPosLimit.Text = zConfig.positiveLimit.ToString("0.000", CultureInfo.InvariantCulture);
            TextZBoxRes.Text = zConfig.resolution.ToString(CultureInfo.InvariantCulture);
            TextZBoxVel.Text = zConfig.maxVelocity.ToString("0.00", CultureInfo.InvariantCulture);

            this.Visible = true;
        }

        public void Hide()
        {
            this.Visible = false;
        }

        protected void ButtonSaveSettings_Click(object sender, EventArgs e)
        {
            double data;
            //get and set XConfig
            CNCJointConfig xConfig = CNCGlobals.CNC.CNCGetJointConfig(CNCAxis.X_AXIS);
            if (double.TryParse(TextXBoxAcc.Text,NumberStyles.Any,CultureInfo.InvariantCulture,out data))
                xConfig.maxAcceleration = data;
            if (double.TryParse(TextXBoxBacklash.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                xConfig.backLash = data;
            if (double.TryParse(TextXBoxHomePos.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                xConfig.homePosition = data;
            if (double.TryParse(TextXBoxHomeVelDir.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                xConfig.homeVelocity = data;
            if (double.TryParse(TextXBoxNegLimit.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                xConfig.negativeLimit = data;
            if (double.TryParse(TextXBoxPort.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data) && data >=1 && data <=6)
                xConfig.cpuPortIndex = (int)(data -1);
            if (double.TryParse(TextXBoxPosLimit.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                xConfig.positiveLimit = data;
            if (double.TryParse(TextXBoxRes.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                xConfig.resolution = data;
            if (double.TryParse(TextXBoxVel.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                xConfig.maxVelocity = data;
            CNCGlobals.CNC.CNCSetJointConfig(xConfig, CNCAxis.X_AXIS);

            //get and set YConfig
            CNCJointConfig yConfig = CNCGlobals.CNC.CNCGetJointConfig(CNCAxis.Y_AXIS);
            if (double.TryParse(TextYBoxAcc.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                yConfig.maxAcceleration = data;
            if (double.TryParse(TextYBoxBacklash.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                yConfig.backLash = data;
            if (double.TryParse(TextYBoxHomePos.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                yConfig.homePosition = data;
            if (double.TryParse(TextYBoxHomeVelDir.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                yConfig.homeVelocity = data;
            if (double.TryParse(TextYBoxNegLimit.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                yConfig.negativeLimit = data;
            if (double.TryParse(TextYBoxPort.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data) && data >= 1 && data <= 6)
                yConfig.cpuPortIndex = (int)(data - 1);
            if (double.TryParse(TextYBoxPosLimit.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                yConfig.positiveLimit = data;
            if (double.TryParse(TextYBoxRes.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                yConfig.resolution = data;
            if (double.TryParse(TextYBoxVel.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                yConfig.maxVelocity = data;
            CNCGlobals.CNC.CNCSetJointConfig(yConfig, CNCAxis.Y_AXIS);

            //get and set ZConfig
            CNCJointConfig zConfig = CNCGlobals.CNC.CNCGetJointConfig(CNCAxis.Z_AXIS);
            if (double.TryParse(TextZBoxAcc.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                zConfig.maxAcceleration = data;
            if (double.TryParse(TextZBoxBacklash.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                zConfig.backLash = data;
            if (double.TryParse(TextZBoxHomePos.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                zConfig.homePosition = data;
            if (double.TryParse(TextZBoxHomeVelDir.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                zConfig.homeVelocity = data;
            if (double.TryParse(TextZBoxNegLimit.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                zConfig.negativeLimit = data;
            if (double.TryParse(TextZBoxPort.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data) && data >= 1 && data <= 6)
                zConfig.cpuPortIndex = (int)(data - 1);
            if (double.TryParse(TextZBoxPosLimit.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                zConfig.positiveLimit = data;
            if (double.TryParse(TextZBoxRes.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                zConfig.resolution = data;
            if (double.TryParse(TextZBoxVel.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                zConfig.maxVelocity = data;
            CNCGlobals.CNC.CNCSetJointConfig(zConfig, CNCAxis.Z_AXIS);

            CNCGlobals.CNC.CNCStoreIniFile();
            CNCGlobals.CNC.CNCReInitialize();
            Rendering.ReRenderGrid();
            Response.Redirect(".");
        }
    }
}