using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


namespace LANCNC
{
    public partial class JobUI : System.Web.UI.UserControl
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
                    ImageButtonLoadJob.Visible = false;
                    break;
            }

            ListBoxJobs.Items.Clear();
            foreach (string folder in Directory.GetDirectories(Server.MapPath("~/Jobs/")))
            {
                foreach (string file in Directory.GetFiles(folder))
                {
                    AddFileToListBox(file);
                }
            }

            LabelActiveFile.Text = "Active job : " + Path.GetFileName(CNCGlobals.CNC.CNCGetJobStatus().jobName);

            this.Visible = true;
        }

        public void Hide()
        {
            this.Visible = false;
        }

        protected void ButtonUploadFile_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    string fileName = FileUpload1.FileName;
                    FileType fileType = GetFileType(fileName);
                    string savePath;
                    if (fileType == FileType.Job)
                    {
                        savePath = Server.MapPath("~/Jobs/" + ((MainForm)this.Page).GetCurrentUser.Name.Replace(":",""));
                        if (!Directory.Exists(savePath))
                            Directory.CreateDirectory(savePath);
                        FileUpload1.SaveAs(savePath + "\\" + Path.GetFileName(fileName));
                        AddFileToListBox(fileName);
                    }
                    else
                    {
                        savePath = Server.MapPath("~/Other Files/" + ((MainForm)this.Page).GetCurrentUser.Name.Replace(":", ""));
                        if (!Directory.Exists(savePath))
                            Directory.CreateDirectory(savePath);
                        FileUpload1.SaveAs(savePath + "\\" + Path.GetFileName(fileName));
                    }
                    LabelUpload.Text = "File has been uploaded";
                }
                catch (Exception ex)
                { LabelUpload.Text = "Cannot upload file to server " + ex.ToString(); }
            }
        }

        private enum FileType
        {
            Job,
            Other
        }

        private FileType GetFileType(string fileName)
        {
            string fileExtension = new FileInfo(FileUpload1.FileName).Extension;
            if (fileExtension.ToLower() == ".nc" ||
                fileExtension.ToLower() == ".cnc" ||
                fileExtension.ToLower() == ".ngc" ||
                fileExtension.ToLower() == ".gc" ||
                fileExtension.ToLower() == ".gcode" ||
                fileExtension.ToLower() == ".tab" ||
                fileExtension.ToLower() == ".ncf" ||
                fileExtension.ToLower() == ".anc" ||
                fileExtension.ToLower() == ".mpf")
            {
                return FileType.Job;
            }
            else
                return FileType.Other;
        }

        private void AddFileToListBox(string fileName)
        {
            string fileTitle = Path.GetFileName(fileName);
            if (ListBoxJobs.Items.FindByText(fileTitle) == null)
            {
                ListBoxJobs.Items.Add(fileTitle);
            }
        }

        private void RemoveFileToListBox(string fileName)
        {
            string fileTitle = Path.GetFileName(fileName);
            ListBoxJobs.Items.Remove(fileTitle);
        }

        private string GetListBoxFile()
        {
            string fileName = "";
            foreach (string folder in Directory.GetDirectories(Server.MapPath("~/Jobs/")))
            {
                foreach (string file in Directory.GetFiles(folder))
                {
                    if (Path.GetFileName(file) == ListBoxJobs.SelectedValue)
                        fileName = file;
                }
            }
            return fileName;
        }

        protected void ImageButtonDeleteJob_Click(object sender, ImageClickEventArgs e)
        {
            User currentUser = ((MainForm)this.Page).GetCurrentUser;
            string fileName = GetListBoxFile();

            if (currentUser.AccessLevel == UserAccessLevel.Admin || Path.GetDirectoryName(fileName).Contains(currentUser.Name.Replace(":", "")))
            {
                string deletePath = Server.MapPath("~/Deleted/") + currentUser.Name.Replace(":", "");
                if (!Directory.Exists(deletePath))
                    Directory.CreateDirectory(deletePath);


                string moveFile = deletePath + "\\" + Path.GetFileName(fileName);
                int i = 2;
                while (File.Exists(moveFile))
                {
                    moveFile = deletePath + "\\" + i.ToString() + Path.GetFileName(fileName);
                    i++;
                }

                File.Move(fileName, moveFile);
                RemoveFileToListBox(fileName);
            }
        }

        protected void ImageButtonLoadJob_Click(object sender, ImageClickEventArgs e)
        {
            if (CNCGlobals.CNC.CNCGetState() == EdingDotNET.Types.CNCState.CNC_IE_READY_STATE)
            {
                CNCGlobals.CNC.CNCResetPauseStatus();
                string fileName = GetListBoxFile();
                CNCGlobals.CNC.CNCLoadJob(fileName);
                Rendering.RenderJobGraph();
                CNCGlobals.CNC.CNCStartRenderGraph(0, 0);
                LabelActiveFile.Text = "Active job : " + Path.GetFileName(CNCGlobals.CNC.CNCGetJobStatus().jobName);
                Rendering.FitJob();
                Response.Redirect(".");
            }
        }
    }
}