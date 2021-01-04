using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LANCNC
{
    public partial class AdminUI : System.Web.UI.UserControl
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
                case UserAccessLevel.Control:
                    Response.Redirect("~/Default.aspx");
                    break;
            }
            //Initialize ui
            FillUserList();
            FillUserAccessList();

            DropDownListUserAccess.ClearSelection();
            DropDownListUserAccess.Items.FindByText(master.GetCurrentUser.AccessLevel.ToString()).Selected = true;
            TextBoxUserDate.Text = master.GetCurrentUser.LastConnect.ToString();

            this.Visible = true;
        }

        public void Hide()
        {
            this.Visible = false;
        }

        protected void DropDownListUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            User selectedUser = CNCGlobals.Users.GetUser(DropDownListUsers.SelectedItem.Text);
            DropDownListUserAccess.ClearSelection();
            DropDownListUserAccess.Items.FindByText(selectedUser.AccessLevel.ToString()).Selected = true;
            TextBoxUserDate.Text = selectedUser.LastConnect.ToString();
        }

        private void FillUserList()
        {
            DropDownListUsers.Items.Clear();
            string[] users = CNCGlobals.Users.GetUsers();
            foreach (string user in users)
            {
                DropDownListUsers.Items.Add(user);
            }
        }

        private void FillUserAccessList()
        {
            DropDownListUserAccess.Items.Clear();
            foreach (UserAccessLevel level in Enum.GetValues(typeof(UserAccessLevel)))
            {
                DropDownListUserAccess.Items.Add(level.ToString());
            }
        }

        protected void DropDownListUserAccess_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListUsers.SelectedItem.Text != ((MainForm)this.Page).GetCurrentUser.Name)
            {
                string name = DropDownListUsers.SelectedItem.Text;
                User updatedUser = CNCGlobals.Users.GetUser(name);
                updatedUser.AccessLevel = (UserAccessLevel)Enum.Parse(typeof(UserAccessLevel), DropDownListUserAccess.SelectedItem.Text);
                CNCGlobals.Users.UpdateUserData(updatedUser);
            }
        }
    }
}