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
    public partial class ToolMeasurementUI : System.Web.UI.UserControl
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
            }

            //Fill Dropdown with tools
            CNCToolData toolData;
            DropDownListTools.Items.Clear();
            for (int t = 1; t < 100; t++)
            {
                toolData = CNCGlobals.CNC.CNCGetToolData(t);
                DropDownListTools.Items.Add(t.ToString() + ". " + toolData.description);
            }
            DropDownListTools.SelectedIndex = CNCGlobals.CNC.CNCGetCurrentToolNumber() -1;

            toolData = CNCGlobals.CNC.CNCGetToolData(DropDownListTools.SelectedIndex + 1);
            TextBoxLenght.Text = toolData.zOffset.ToString(CultureInfo.InvariantCulture);
            TextBoxHeight.Text = (CNCGlobals.CNC.CNCGetVariable(3991)*2).ToString(CultureInfo.InvariantCulture);
            TextBoxWidth.Text = (CNCGlobals.CNC.CNCGetVariable(3990)*2).ToString(CultureInfo.InvariantCulture);
            TextBoxProbeDist.Text = CNCGlobals.CNC.CNCGetVariable(4982).ToString(CultureInfo.InvariantCulture);
            this.Visible = true;
        }

        public void Hide()
        {
            this.Visible = false;
        }

        protected void DropDownListTools_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNCToolData toolData;
            toolData = CNCGlobals.CNC.CNCGetToolData(DropDownListTools.SelectedIndex + 1);
            TextBoxLenght.Text = toolData.zOffset.ToString(CultureInfo.InvariantCulture);
        }

        protected void ButtonMeasure_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            double value;
            try //if textboxLenght valid number
            {
                value = Convert.ToDouble(dt.Compute(TextBoxLenght.Text, ""));
                CNCGlobals.CNC.CNCSetVariable(3998, value);//Set #3998 to aprox tool lenght
                CNCGlobals.CNC.CNCSetVariable(3999, DropDownListTools.SelectedIndex + 1);//Set #3999 to tool number
                CNCGlobals.CNC.CNCSetVariable(4971, 50);//Set #4971 to probe feed rate
            }
            catch(Exception ex) { TextBoxHeight.Text = ex.ToString(); }
            CNCGlobals.CNC.CNCRunSingleLine("gosub measure_tool");
        }

        protected void ButtonProbeOutside_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            double value;
            try //if textboxheight/width have valid numbers
            {
                value = Convert.ToDouble(dt.Compute(TextBoxHeight.Text, ""));
                CNCGlobals.CNC.CNCSetVariable(3991, value / 2);//Set #3990 to probe Height
                value = Convert.ToDouble(dt.Compute(TextBoxWidth.Text, ""));
                CNCGlobals.CNC.CNCSetVariable(3990, value / 2);//Set #3991 to probe Width
                CNCGlobals.CNC.CNCSetVariable(4970, 60);//Set #4970 to probe feed rate
            }
            catch { }
            CNCGlobals.CNC.CNCRunSingleLine("gosub probe_outside");
        }

        protected void ButtonProbeInside_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            double value;
            try //if textboxheight/width have valid numbers
            {
                value = Convert.ToDouble(dt.Compute(TextBoxHeight.Text, ""));
                CNCGlobals.CNC.CNCSetVariable(3991, value/2);//Set #3990 to probe Height
                value = Convert.ToDouble(dt.Compute(TextBoxWidth.Text, ""));
                CNCGlobals.CNC.CNCSetVariable(3990, value/2);//Set #3991 to probe Width
                CNCGlobals.CNC.CNCSetVariable(4970, 60);//Set #4970 to probe feed rate
            }
            catch { }
            CNCGlobals.CNC.CNCRunSingleLine("gosub probe_inside");
        }

        protected void ButtonMeasrureAngle_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            double value;
            try //if textboxporbedist has valid number
            {
                value = Convert.ToDouble(dt.Compute(TextBoxProbeDist.Text, ""));
                CNCGlobals.CNC.CNCSetVariable(4982, value);//Set #4982 to probeDistX
                CNCGlobals.CNC.CNCSetVariable(4983, 20);//Set #3991 to probeDistY
                CNCGlobals.CNC.CNCSetVariable(4972, 60);//Set #4972 to probe feed rate
            }
            catch { }
            CNCGlobals.CNC.CNCRunSingleLine("gosub probe_angle");
        }

        protected void ButtonG68_Click(object sender, EventArgs e)
        {
            CNCGlobals.CNC.CNCRunSingleLine("G68 R#4980");
        }

        protected void ButtonG69_Click(object sender, EventArgs e)
        {
            CNCGlobals.CNC.CNCRunSingleLine("G69");
        }
    }
}