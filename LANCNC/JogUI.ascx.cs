using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EdingDotNET.Types;
using System.Drawing;
using System.Globalization;
using System.Threading;


namespace LANCNC
{
    public partial class JogUI : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

            }
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
            }

            if (CNCGlobals.PreciseJogMode)
                CheckBoxSingleStep.Checked = true;
            else
                CheckBoxSingleStep.Checked = false;

            this.Visible = true;
        }

        public void Hide()
        {
            this.Visible = false;
        }

        protected void ImageButtonFeedDown_Click(object sender, ImageClickEventArgs e)
        {
            if (CNCGlobals.VelocityFactor != 0.005)
                CNCGlobals.VelocityFactor += 0.05;
            else
                CNCGlobals.VelocityFactor = 0.05;
        }

        protected void ImageButtonFeedUp_Click(object sender, ImageClickEventArgs e)
        {
            if (CNCGlobals.VelocityFactor != 0.05)
                CNCGlobals.VelocityFactor -= 0.05;
            else
                CNCGlobals.VelocityFactor = 0.005;


        }

        protected void EventTriggerStartMove_ValueChanged(object sender, EventArgs e)
        {
            if (EventTriggerStartMove.Value != (""))
            {
                if (!CNCGlobals.PreciseJogMode)
                {
                    //start jogging
                    if (EventTriggerStartMove.Value.Contains("X+!"))
                        CNCGlobals.CNC.CNCStartJog2(CNCAxis.X_AXIS, 1.0, CNCGlobals.VelocityFactor, 1);
                    if (EventTriggerStartMove.Value.Contains("X-!"))
                        CNCGlobals.CNC.CNCStartJog2(CNCAxis.X_AXIS, -1.0, CNCGlobals.VelocityFactor, 1);
                    if (EventTriggerStartMove.Value.Contains("Y+!"))
                        CNCGlobals.CNC.CNCStartJog2(CNCAxis.Y_AXIS, 1.0, CNCGlobals.VelocityFactor, 1);
                    if (EventTriggerStartMove.Value.Contains("Y-!"))
                        CNCGlobals.CNC.CNCStartJog2(CNCAxis.Y_AXIS, -1.0, CNCGlobals.VelocityFactor, 1);
                    if (EventTriggerStartMove.Value.Contains("Z+!"))
                        CNCGlobals.CNC.CNCStartJog2(CNCAxis.Z_AXIS, 1.0, CNCGlobals.VelocityFactor, 1);
                    if (EventTriggerStartMove.Value.Contains("Z-!"))
                        CNCGlobals.CNC.CNCStartJog2(CNCAxis.Z_AXIS, -1.0, CNCGlobals.VelocityFactor, 1);
                }
                else
                {
                    if (EventTriggerStartMove.Value.Contains("X+!"))
                        CNCGlobals.CNC.CNCStartJog2(CNCAxis.X_AXIS, 0.005, CNCGlobals.VelocityFactor, 0);
                    if (EventTriggerStartMove.Value.Contains("X-!"))
                        CNCGlobals.CNC.CNCStartJog2(CNCAxis.X_AXIS, -0.005, CNCGlobals.VelocityFactor, 0);
                    if (EventTriggerStartMove.Value.Contains("Y+!"))
                        CNCGlobals.CNC.CNCStartJog2(CNCAxis.Y_AXIS, 0.005, CNCGlobals.VelocityFactor, 0);
                    if (EventTriggerStartMove.Value.Contains("Y-!"))
                        CNCGlobals.CNC.CNCStartJog2(CNCAxis.Y_AXIS, -0.005, CNCGlobals.VelocityFactor, 0);
                    if (EventTriggerStartMove.Value.Contains("Z+!"))
                        CNCGlobals.CNC.CNCStartJog2(CNCAxis.Z_AXIS, 0.005, CNCGlobals.VelocityFactor, 0);
                    if (EventTriggerStartMove.Value.Contains("Z-!"))
                        CNCGlobals.CNC.CNCStartJog2(CNCAxis.Z_AXIS, -0.005, CNCGlobals.VelocityFactor, 0);
                }
            }
        }


        protected void EventTriggerStopMove_ValueChanged(object sender, EventArgs e)
        {
            if (EventTriggerStopMove.Value != (""))
            {
                //stop jogging
                CNCGlobals.CNC.CNCStopJog(CNCAxis.X_AXIS);
                CNCGlobals.CNC.CNCStopJog(CNCAxis.Y_AXIS);
                CNCGlobals.CNC.CNCStopJog(CNCAxis.Z_AXIS);
            }
        }

        protected void CheckBoxPreciseJog_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxSingleStep.Checked)
                CNCGlobals.PreciseJogMode = true;
            else
                CNCGlobals.PreciseJogMode = false;
        }
    }
}
