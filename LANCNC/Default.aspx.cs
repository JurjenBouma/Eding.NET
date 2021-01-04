using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace LANCNC
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CNCGlobals.Initialize("C:\\CNC\\CNCLAN\\User.dat",Server.MapPath("~/"));
                Rendering.Initialize();
                User currentUser = CNCGlobals.Users.SignInUser(CNCGlobals.GetIPAdress());
                if (currentUser.AccessLevel > UserAccessLevel.None)
                    Response.Redirect("~/MainForm.aspx");
                CNCGlobals.Users.Save();
            }
        }
    }
}