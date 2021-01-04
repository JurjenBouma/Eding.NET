<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminUI.ascx.cs" Inherits="LANCNC.AdminUI" %>
    <asp:Panel ID="PanelAdminMain" runat="server" style="top: 0px; left: 0px; position: absolute; height: 100%; width: 100%">
        <asp:Panel ID="PanelUserData" runat="server" style="top: 20%; left: 0px; position: absolute; height: 25%; width: 100%">
            <asp:DropDownList ID="DropDownListUsers" runat="server" Height="21px" Width="200px" OnSelectedIndexChanged="DropDownListUsers_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownListUserAccess" runat="server" Width="120px" OnSelectedIndexChanged="DropDownListUserAccess_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            <asp:TextBox ID="TextBoxUserDate" runat="server" Width="200px" ReadOnly="True" AutoPostBack="true"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="PanelUserTitles" runat="server" style="top: 0px; left: 0px; position: absolute; height: 20%; width: 100%">
            <asp:Label ID="LabelUser" runat="server" Font-Names="Calibri" Font-Size="12pt" Text="User :" Width="200px"></asp:Label>
            <asp:Label ID="LabelUserAccessLevel" runat="server" Font-Names="Calibri" Font-Size="12pt" Text="Acces Level" Width="120px"></asp:Label>
            <asp:Label ID="LabelUserLastDate" runat="server" Font-Names="Calibri" Font-Size="12pt" Text="Last Active Date :" Width="200px"></asp:Label>
        </asp:Panel>
    </asp:Panel>