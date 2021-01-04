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
    public partial class ToolUI : System.Web.UI.UserControl
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

            //Fill lisbox with tools
            CNCToolData toolData;
            ListBoxTools.Items.Clear();
            for (int t = 1; t<100;t++)
            {
                toolData = CNCGlobals.CNC.CNCGetToolData(t);
                ListBoxTools.Items.Add(t.ToString() + ". " + toolData.description);
            }
            ListBoxTools.SelectedIndex = 0;

            toolData = CNCGlobals.CNC.CNCGetToolData(ListBoxTools.SelectedIndex+1);
            TextBoxToolDescription.Text = toolData.description;
            TextBoxToolLenght.Text = toolData.zOffset.ToString(CultureInfo.InvariantCulture);
            TextBoxToolzDelta.Text = toolData.zDelta.ToString(CultureInfo.InvariantCulture);
            TextBoxToolDiameter.Text = toolData.diameter.ToString(CultureInfo.InvariantCulture);

            this.Visible = true;
        }

        public void Hide()
        {
            ListBoxTools.Items.Clear();
            this.Visible = false;
        }

        protected void ListBoxTools_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNCToolData toolData = CNCGlobals.CNC.CNCGetToolData(ListBoxTools.SelectedIndex + 1);
            TextBoxToolDescription.Text = toolData.description;
            TextBoxToolLenght.Text = toolData.zOffset.ToString(CultureInfo.InvariantCulture);
            TextBoxToolzDelta.Text = toolData.zDelta.ToString(CultureInfo.InvariantCulture);
            TextBoxToolDiameter.Text = toolData.diameter.ToString(CultureInfo.InvariantCulture);
        }


        protected void ButtonSaveTool_Click(object sender, EventArgs e)
        {
            CNCToolData toolData = CNCGlobals.CNC.CNCGetToolData(ListBoxTools.SelectedIndex + 1);
            toolData.description = TextBoxToolDescription.Text;
            double data;
            if (double.TryParse(TextBoxToolDiameter.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                toolData.diameter = data;
            if (double.TryParse(TextBoxToolLenght.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                toolData.zOffset = data;
            if (double.TryParse(TextBoxToolzDelta.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out data))
                toolData.zDelta = data;
            CNCGlobals.CNC.CNCUpdateToolData(toolData, ListBoxTools.SelectedIndex + 1);
            ListBoxTools.Items[ListBoxTools.SelectedIndex].Text = toolData.description;

            CNCGlobals.CNC.CNCStoreIniFile();
            CNCGlobals.CNC.CNCReInitialize();
        }

        protected void ButtonSetActiveTool_Click(object sender, EventArgs e)
        {
            CNCToolData toolData = CNCGlobals.CNC.CNCGetToolData(ListBoxTools.SelectedIndex + 1);
           CNCGlobals.CNC.CNCRunSingleLine("#5011 = " + toolData.id);
            CNCGlobals.CNC.CNCRunSingleLine("M6 T#5011");
        }
    }
}