<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MainControls.aspx.cs" Inherits="LANCNC.MainControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Panel ID="PanelButtons" runat="server" style="top: 0%; left: 0px; position: absolute; height: 50%; width: 100%">
            <asp:ImageButton ID="ImageButtonTurnOffDrives" runat="server" ImageUrl="~/Images/Buttons/Eding/machon_box_off.bmp" style="height: 99%; width: auto; " OnClick="ImageButtonTurnOffDrives_Click" AutoPostBack="true"/>
            <asp:ImageButton ID="ImageButtonReset1" runat="server" ImageUrl="~/Images/Buttons/Eding/reset.bmp" style="height: 99%; width: auto; " OnClick="ImageButtonReset1_Click" AutoPostBack="true" />
          
        </asp:Panel>
         <asp:Panel ID="PanelButtonsBottom" runat="server" style="top: 50%; left: 0px; position: absolute; height: 50%; width: 100%">
             <asp:ImageButton ID="ImageButtonSpindle" runat="server" ImageUrl="~/Images/Buttons/Eding/tool_green_led.bmp" style="height: 99%; width: auto; " OnClick="ImageButtonSpindle_Click" AutoPostBack="true"/>
            <asp:ImageButton ID="ImageButtonG28" runat="server" style="height: 99%; width: auto;" ImageUrl="~/Images/Buttons/Eding/g28_home.bmp" OnClick="ImageButtonG28_Click" />
        </asp:Panel>
    </div>
</asp:Content>
