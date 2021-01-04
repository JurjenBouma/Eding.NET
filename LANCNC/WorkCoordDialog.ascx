<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WorkCoordDialog.ascx.cs" Inherits="LANCNC.WorkCoordDialog" %>
    <asp:Panel ID="PanelWorkCoordDialog" runat="server" style="height: 100%; width: 100%; background-color: #003399;">
        <asp:Label ID="LabelPos" runat="server" Text="Set Work Position : " Font-Names="Trebuchet MS" Font-Size="12pt"></asp:Label>
        <asp:TextBox ID="TextBoxWorkPos" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" Style="position:absolute; Top:25%; left:25%; width:50%;"></asp:TextBox>
        <asp:ImageButton ID="ImageButtonX" runat="server" ImageUrl="~/Images/Buttons/Eding/delete.bmp" style="position:absolute; left:76%; top:25%; height: 25px; width: 25px" OnClick="ImageButtonX_Click" />
        <asp:Button ID="ButtonWorkCoordOK" runat="server" Text="OK" Style="position:absolute; Top:70%; left:35%; width:30%;" OnClick="ButtonWorkCoordOK_Click" />
    </asp:Panel>

