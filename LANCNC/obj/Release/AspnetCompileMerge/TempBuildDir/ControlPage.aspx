<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ControlPage.aspx.cs" Inherits="LANCNC.WebForm1" %>
<asp:Content ID="ControlContent" ContentPlaceHolderID="MainPanel" runat="server">
   
    <asp:Button ID="ButtonConnect" runat="server" Height="113px" Text="Connect" Width="138px" BackColor="#0066CC" Font-Names="Calibri" Font-Size="20pt" ForeColor="White" OnClick="Button1_Click" />
    <asp:Button ID="ButtonDisconnect" runat="server" Height="113px" Text="Disconnect" Width="138px" BackColor="#0066CC" Font-Names="Calibri" Font-Size="20pt" ForeColor="#CC3300" OnClick="ButtonDisconnect_Click" />
    <asp:Button ID="ButtonReset" runat="server" Height="113px" Text="Reset" Width="138px" BackColor="#0066CC" Font-Names="Calibri" Font-Size="20pt" ForeColor="White" OnClick="ButtonReset_Click" />
    <asp:Button ID="ButtonHomeAll" runat="server" Height="113px" Text="HomeAll" Width="138px" BackColor="#0066CC" Font-Names="Calibri" Font-Size="20pt" ForeColor="White" OnClick="ButtonHomeAll_Click" />
    <asp:Button ID="ButtonZeroAll" runat="server" Height="113px" Text="ZeroAll" Width="138px" BackColor="#0066CC" Font-Names="Calibri" Font-Size="20pt" ForeColor="White" OnClick="ButtonZeroAll_Click" />
   
    <asp:Panel ID="Panel1" runat="server">
         <asp:TextBox ID="TextBox1" runat="server" Height="354px" Width="683px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
         <asp:Button ID="ButtonMoveXPositive" runat="server" BackColor="#0066CC" Font-Names="Calibri" Font-Size="20pt" ForeColor="White" Height="113px" OnClick="ButtonXMovePos_Click" Text="MoveX+" Width="138px" />
         <asp:Button ID="ButtonMoveXNegative" runat="server" BackColor="#0066CC" Font-Names="Calibri" Font-Size="20pt" ForeColor="White" Height="113px" OnClick="ButtonMoveXNegative_Click" Text="MoveX-" Width="138px" />
         <asp:Button ID="ButtonMoveYPositive" runat="server" BackColor="#0066CC" Font-Names="Calibri" Font-Size="20pt" ForeColor="White" Height="113px" OnClick="ButtonMoveYPositive_Click" Text="MoveY+" Width="138px" />
         <asp:Button ID="ButtonMoveYNegative" runat="server" BackColor="#0066CC" Font-Names="Calibri" Font-Size="20pt" ForeColor="White" Height="113px" OnClick="ButtonMoveYNegative_Click" Text="MoveY-" Width="138px" />
    </asp:Panel>
        <asp:ScriptManager ID="script1" runat="server"> </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <asp:Timer ID="timer1" runat ="server" Enabled="False" Interval="100" OnTick="timer1_Tick"></asp:Timer>
             <asp:Label ID="LabelXwork" runat="server" Text="X : 000.000" BackColor="Red" Font-Size="20pt" ForeColor="White"></asp:Label>
             <asp:Label ID="LabelYwork" runat="server" BackColor="Lime" Font-Size="20pt" ForeColor="White" Text="Y : 000.000"></asp:Label>
             <asp:Label ID="LabelZwork" runat="server" BackColor="Blue" Font-Size="20pt" ForeColor="White" Text="Z : 000.000"></asp:Label>
            </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>
