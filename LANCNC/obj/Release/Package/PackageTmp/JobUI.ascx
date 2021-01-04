<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JobUI.ascx.cs" Inherits="LANCNC.JobUI" %>
    <div id="PanelJob" style="top: 0px; left: 0px; position: absolute; height: 100%; width: 100%">      
        <asp:ListBox ID="ListBoxJobs" runat="server" style="top: 0px; left: 0px; height: 101%; width: 50%; position: absolute;" Width="237px"></asp:ListBox>
        <div id="PanelUpload" style="top: 0%; left: 50%; position: absolute; height: 44px; width: 450px">
              <asp:FileUpload ID="FileUpload1" runat="server" style="top: 50%; left: 0%; position: absolute; height: 22px; width: 383px; right: 98px;" Font-Names="Trebuchet MS" ForeColor="White" />
              <asp:Button ID="ButtonUploadFile" runat="server" Font-Names="Trebuchet MS" OnClick="ButtonUploadFile_Click" style="top: 48%; left: 386px; position: absolute; height: 22px; width: 59px" Text="Upload" />
              <asp:Label ID="LabelUpload" runat="server" Font-Names="Trebuchet MS" style="top: 0px; left: 1px; position: absolute; height: 22px; width: 201px" Text="Upload a job file or model :" ForeColor="White"></asp:Label>
        </div>
        <div id="PanelJobButtons" style="top: 50%; left: 50%; position: absolute; height: 50%; width: 50%">
             <asp:ImageButton ID="ImageButtonDeleteJob" runat="server" style="height: 99%; width: auto;" ImageUrl="~/Images/Buttons/Eding/delete.bmp" OnClick="ImageButtonDeleteJob_Click"  />
             <asp:ImageButton ID="ImageButtonLoadJob" runat="server" style="height: 99%; width: auto;" ImageUrl="~/Images/Buttons/Eding/load_gcode.bmp" OnClick="ImageButtonLoadJob_Click"  />
            <asp:Label ID="LabelActiveFile" runat="server" Font-Names="Trebuchet MS" style="position: absolute; height: 98%; width: 360px;" Text="Active job :" ForeColor="White"></asp:Label>
        </div>
    </div>