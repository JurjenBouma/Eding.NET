<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainControlUI.ascx.cs" Inherits="LANCNC.MainControlUI" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="PanelButtons" runat="server" style="top: 0%; left: 0px; position: absolute; height: 50%; width: 100%">
            <asp:ImageButton ID="ImageButtonRunJob" runat="server" style="height: 99%; width: auto;" ImageUrl="~/Images/Buttons/Eding/run.bmp" OnClick="ImageButtonRunJob_Click" AutoPostBack="true" />
            <asp:ImageButton ID="ImageButtonPauseJob" runat="server" style="height: 99%; width: auto;" ImageUrl="~/Images/Buttons/Eding/pause.bmp" AutoPostBack="true" OnClick="ImageButtonRunJob_Click" Visible="false" />
            <asp:ImageButton ID="ImageButtonTurnOffDrives" runat="server" ImageUrl="~/Images/Buttons/Eding/machon_box_off.bmp" style="height: 99%; width: auto; " OnClick="ImageButtonTurnOffDrives_Click" AutoPostBack="true"/>
            <asp:ImageButton ID="ImageButtonReset1" runat="server" ImageUrl="~/Images/Buttons/Eding/reset.bmp" style="height: 99%; width: auto; " OnClick="ImageButtonReset1_Click" AutoPostBack="true" />   
            <asp:ImageButton ID="ImageButtonRedraw" runat="server" ImageUrl="~/Images/Buttons/Eding/render.bmp" style="height: 99%; width: auto; " AutoPostBack="true" OnClick="ImageButtonRedraw_Click" />
            <asp:ImageButton ID="ImageButtonToggleView" runat="server" ImageUrl="~/Images/Buttons/Eding/zoom_fit.bmp" style="height: 99%; width: auto; " AutoPostBack="true" OnClick="ImageButtonToggleView_Click" /> 
            <asp:Timer ID="TimerMainControls" runat="server" Interval="500" OnTick="TimerMainControls_Tick"></asp:Timer>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
        <asp:Panel ID="PanelButtonsBottom" runat="server" style="top: 50%; left: 0px; position: absolute; height: 50%; width: 100%">
        <asp:ImageButton ID="ImageButtonHomeAll" runat="server" ImageUrl="~/Images/Buttons/Eding/home.bmp" style="height: 99%; width: auto; " OnClick="ImageButtonHomeAll_Click" AutoPostBack="true" />
        <asp:ImageButton ID="ImageButtonSpindle" runat="server" ImageUrl="~/Images/Buttons/Eding/tool_green_led.bmp" style="height: 99%; width: auto; " OnClick="ImageButtonSpindle_Click" AutoPostBack="true"/>
        <asp:ImageButton ID="ImageButtonG28" runat="server" style="height: 99%; width: auto;" ImageUrl="~/Images/Buttons/Eding/g28_home.bmp" OnClick="ImageButtonG28_Click" />
            <asp:ImageButton ID="ImageButtonZoomMin" runat="server" ImageUrl="~/Images/Buttons/Eding/zoom_min.bmp" style="height: 99%; width: auto; " AutoPostBack="true" OnClick="ImageButtonZoomMin_Click"  />
            <asp:ImageButton ID="ImageButtonZoomPlus" runat="server" ImageUrl="~/Images/Buttons/Eding/zoom_plus.bmp" style="height: 99%; width: auto; " AutoPostBack="true" OnClick="ImageButtonZoomPlus_Click"  />
    </asp:Panel>
<asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel  ID="PanelMessages" runat="server" style="position: absolute; height:100%; width:30%; left:70%">
            <asp:ListBox ID="ListBoxServerMessages" runat="server" style="position:absolute; height: 99%; width: 100%;" ReadOnly="True" AutoPostBack="True" SelectionMode="Multiple" ></asp:ListBox>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

    