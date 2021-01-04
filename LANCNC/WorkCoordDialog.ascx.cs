using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EdingDotNET.Types;
using System.Globalization;
using System.Data;

namespace LANCNC
{
    public partial class WorkCoordDialog : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void Show()
        {
            if (CNCGlobals.CNC.CNCGetState() != CNCState.CNC_IE_RUNNING_JOB_STATE)
            {
                CNCPositions workPos = CNCGlobals.CNC.CNCGetWorkPosition();
                if (ClientID == "WorkCoordDialogX")
                    TextBoxWorkPos.Text = workPos.x.ToString("0.000", CultureInfo.InvariantCulture);
                else if (ClientID == "WorkCoordDialogY")
                    TextBoxWorkPos.Text =  workPos.y.ToString("0.000", CultureInfo.InvariantCulture);
                else if (ClientID == "WorkCoordDialogZ")
                    TextBoxWorkPos.Text = workPos.z.ToString("0.000", CultureInfo.InvariantCulture);

                MainForm master = (MainForm)this.Page;
                //Manage access
                if (master.GetCurrentUser.AccessLevel >= UserAccessLevel.Control)
                    this.Visible = true;
                else
                    this.Visible = false;
            }
            else
                this.Visible = false;
        }

        public void Hide()
        {
            this.Visible = false;
        }

        protected void ButtonWorkCoordOK_Click(object sender, EventArgs e)
        {
            //double value = 0;
            DataTable dt = new DataTable();
            double value;
            try //if textbox valid zero axis
            {
                value = Convert.ToDouble(dt.Compute(TextBoxWorkPos.Text, ""));
                if (ClientID == "WorkCoordDialogX")
                    CNCGlobals.CNC.CNCRunSingleLine("G10 L20 P1 X" + value.ToString(CultureInfo.InvariantCulture));
                else if (ClientID == "WorkCoordDialogY")
                    CNCGlobals.CNC.CNCRunSingleLine("G10 L20 P1 Y" + value.ToString(CultureInfo.InvariantCulture));
                else if (ClientID == "WorkCoordDialogZ")
                    CNCGlobals.CNC.CNCRunSingleLine("G10 L20 P1 Z" + value.ToString(CultureInfo.InvariantCulture));
            }
            catch { }
            this.Hide();
        }

        protected void ImageButtonX_Click(object sender, ImageClickEventArgs e)
        {
            CNCPositions workPos = CNCGlobals.CNC.CNCGetWorkPosition();
            if (ClientID == "WorkCoordDialogX")
                TextBoxWorkPos.Text = workPos.x.ToString("0.000", CultureInfo.InvariantCulture);
            else if (ClientID == "WorkCoordDialogY")
                TextBoxWorkPos.Text = workPos.y.ToString("0.000", CultureInfo.InvariantCulture);
            else if (ClientID == "WorkCoordDialogZ")
                TextBoxWorkPos.Text = workPos.z.ToString("0.000", CultureInfo.InvariantCulture);
        }
    }
}