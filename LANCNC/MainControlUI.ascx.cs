using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EdingDotNET.Types;
using System.Threading;

namespace LANCNC
{
    public partial class MainControlUI : System.Web.UI.UserControl
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
            if (master.GetCurrentUser.AccessLevel < UserAccessLevel.Control)
            {
                Response.Redirect("~/Default.aspx");
            }

            //Check if spindle is running for button toggle
            if (CNCGlobals.CNC.CNCGetSpindleStatus().spindleIsOn == 1)
                ImageButtonSpindle.ImageUrl = "~/Images/Buttons/Eding/tool_red_led.bmp";
            else
                ImageButtonSpindle.ImageUrl = "~/Images/Buttons/Eding/tool_green_led.bmp";

            //Check if drives are on for turn off buttton
            if (CNCGlobals.CNC.CNCGetOutput(CNCIOID.CNC_IOID_DRIVE_ENABLE_OUT) == 1)//check if drive are on
                ImageButtonTurnOffDrives.ImageUrl = "~/Images/Buttons/Eding/machon_box_yellow.bmp";
            else
                ImageButtonTurnOffDrives.ImageUrl = "~/Images/Buttons/Eding/machon_box_off.bmp";

            //check runnig job for job button
            ToggleRunButton();

            for (int i = ListBoxServerMessages.Items.Count; i < CNCGlobals.MessageBuffer.Count; i++)
            {
                ListBoxServerMessages.Items.Insert(0,CNCGlobals.MessageBuffer[i].text);
            }
            this.Visible = true;
        }

        public void Hide()
        {
            this.Visible = false;
        }

        protected void TimerMainControls_Tick(object sender, EventArgs e)
        {
            ToggleRunButton();
        }

        protected void ImageButtonTurnOffDrives_Click(object sender, ImageClickEventArgs e)
        {
            //Turn of drives and spindle
            CNCGlobals.CNC.CNCStopSpindle();
            CNCGlobals.CNC.CNCSetOutput(CNCIOID.CNC_IOID_DRIVE_ENABLE_OUT, 0);
            ImageButtonTurnOffDrives.ImageUrl = "~/Images/Buttons/Eding/machon_box_off.bmp";
            ImageButtonSpindle.ImageUrl = "~/Images/Buttons/Eding/tool_green_led.bmp";
        }

        protected void ImageButtonReset1_Click(object sender, ImageClickEventArgs e)
        {
            //reset and tonr on drives;
            CNCGlobals.CNC.CNCAbortJob();
            CNCGlobals.CNC.CNCReset();
            CNCGlobals.CNC.CNCSetOutput(CNCIOID.CNC_IOID_DRIVE_ENABLE_OUT, 1);
            ImageButtonTurnOffDrives.ImageUrl = "~/Images/Buttons/Eding/machon_box_yellow.bmp";
            ImageButtonSpindle.ImageUrl = "~/Images/Buttons/Eding/tool_green_led.bmp";
            CNCGlobals.CNC.CNCRewindJob();
            CNCGlobals.CNC.CNCResetPauseStatus();
        }

        protected void ImageButtonSpindle_Click(object sender, ImageClickEventArgs e)
        {
            CNCSpindleStatus status = CNCGlobals.CNC.CNCGetSpindleStatus();
            if (CNCGlobals.CNC.CNCGetOutput(CNCIOID.CNC_IOID_DRIVE_ENABLE_OUT) == 1)//check if Spindle is ready
            {
                //Check is spindle is running
                if (status.spindleIsOn == 0)
                {
                    CNCGlobals.CNC.CNCStartSpindle();//activate spindle
                    ImageButtonSpindle.ImageUrl = "~/Images/Buttons/Eding/tool_red_led.bmp";
                }
                else
                {
                    CNCGlobals.CNC.CNCStopSpindle();//Deactivate spindle
                    ImageButtonSpindle.ImageUrl = "~/Images/Buttons/Eding/tool_green_led.bmp";
                }
            }
        }

        protected void ImageButtonG28_Click(object sender, ImageClickEventArgs e)
        {
            CNCGlobals.CNC.CNCRunSingleLine("g28");
        }

        protected void ImageButtonHomeAll_Click(object sender, ImageClickEventArgs e)
        {
            CNCGlobals.CNC.CNCHomeAll();
        }

        protected void ImageButtonRunJob_Click(object sender, ImageClickEventArgs e)
        {
            if (CNCGlobals.CNC.CNCGetState() == EdingDotNET.Types.CNCState.CNC_IE_RUNNING_JOB_STATE)
            {
                CNCGlobals.CNC.CNCPauseJob();
                ToggleRunButton();
            }
            else if (CNCGlobals.CNC.CNCGetState() == EdingDotNET.Types.CNCState.CNC_IE_READY_STATE)
            {
                if (CNCGlobals.CNC.CNCGetJobStatus().jobName.Length > 0)
                {
                    RCResult rc = CNCGlobals.CNC.CNCRunOrResumeJob();
                    ToggleRunButton();
                }
            }
            else if (CNCGlobals.CNC.CNCGetState() == EdingDotNET.Types.CNCState.CNC_IE_PAUSED_JOB_STATE)
            { 
                if (CNCGlobals.CNC.CNCGetJobStatus().jobName.Length > 0)
                {
                    Thread resumeThread = new Thread(ResumeJob);//start resume thread
                    resumeThread.Start();
                }
            }
        }

        private void ToggleRunButton()
        {
            if (CNCGlobals.CNC.CNCGetState() == EdingDotNET.Types.CNCState.CNC_IE_RUNNING_JOB_STATE)
            { 
                ImageButtonRunJob.Visible = false;
                ImageButtonPauseJob.Visible = true;
            }
            else
            {
                ImageButtonRunJob.Visible = true;
                ImageButtonPauseJob.Visible = false;
            }

        }

        private void ResumeJob()
        {
            CNCPauseStatus pauseStatus = CNCGlobals.CNC.CNCGetPauseSatus();
            CNCPositions curPos = CNCGlobals.CNC.CNCGetMachinePosition();
            if (pauseStatus.spindleInSync == 0)
            {
                if(pauseStatus.pauseSpindleIOValue == 1)
                    CNCGlobals.CNC.SetSpindleOutput(1,-1,-1);//start spindle
                else
                    CNCGlobals.CNC.CNCStopSpindle();
            }
            while (CNCGlobals.CNC.CNCGetSpindleStatus().isRampingUp == 1) { Thread.Sleep(100); }//wait for spindle to rampup

            CNCAxisBools axis;
            if (pauseStatus.pausePosition.x != curPos.x || pauseStatus.pausePosition.y != curPos.y)
            {
                if (curPos.z != 0)
                {
                    axis = new CNCAxisBools() { x = 0, y = 0, z = 1, a = 0, b = 0, c = 0 };
                    CNCGlobals.CNC.CNCMoveTo(new CNCPositions() { z = 0 }, axis, 0.25f);//move Z axis Up
                    while (CNCGlobals.CNC.CNCGetState() == CNCState.CNC_IE_RUNNING_AXISJOG_STATE) { Thread.Sleep(100); }//wait for z to be up
                }
                axis = new CNCAxisBools() { x = 1, y = 1, z = 0, a = 0, b = 0, c = 0 };
                CNCGlobals.CNC.CNCMoveTo(pauseStatus.pausePosition, axis, 0.25f);//move x and y axis
            }
            while (CNCGlobals.CNC.CNCGetState() == CNCState.CNC_IE_RUNNING_AXISJOG_STATE) { Thread.Sleep(100); }//wait for x and y to be in resume pos

            /* if (pauseStatus.pauseFloodIOValue == 0)
                 CNCGlobals.CNC.CNCMistAndFloodOff();
             if (pauseStatus.pauseMistIOValue == 0)
                 CNCGlobals.CNC.CNCMistAndFloodOff();
             if (pauseStatus.pauseFloodIOValue == 1)
                 CNCGlobals.CNC.CNCFloodOn();
             if (pauseStatus.pauseMistIOValue == 1)
                 CNCGlobals.CNC.CNCMistOn();*/

            curPos = CNCGlobals.CNC.CNCGetMachinePosition();//update curPos
            if (pauseStatus.pausePosition.z != curPos.z)
            {
                axis = new CNCAxisBools() { x = 0, y = 0, z = 1, a = 0, b = 0, c = 0 };
                CNCGlobals.CNC.CNCMoveTo(pauseStatus.pausePosition, axis, 0.25f);//move Z axis
            }
            while (CNCGlobals.CNC.CNCGetState() == CNCState.CNC_IE_RUNNING_AXISJOG_STATE) { Thread.Sleep(100); }//wait for z to be in resume pos

            CNCGlobals.CNC.CNCRunOrResumeJob();//resume
            CNCGlobals.CNC.CNCResetPausePosition();
        }

        protected void ImageButtonRedraw_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(".");
        }

        protected void ImageButtonZoomMin_Click(object sender, ImageClickEventArgs e)
        {
            Rendering.Zoom(0.6666f);
        }

        protected void ImageButtonZoomPlus_Click(object sender, ImageClickEventArgs e)
        {
            Rendering.Zoom(1.5f);
        }

        protected void ImageButtonToggleView_Click(object sender, ImageClickEventArgs e)
        {
            Rendering.ToggleFit();
        }


    }
}