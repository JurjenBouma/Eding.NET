<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingsUI.ascx.cs" Inherits="LANCNC.SettingsUI" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="PanelTexts" runat="server" style="top: 0%; left: 0%; position: absolute; height: 14%; width: 100%; background-color: #003399;">
            <asp:Label ID="LabelPort" runat="server" Text="Port :" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 2%; position: absolute; width: 8%;"></asp:Label>
            <asp:Label ID="LabelRes" runat="server" Text="Steps/mm :" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 8%; position: absolute;"></asp:Label>
            <asp:Label ID="LabelPosLimit" runat="server" Text="Positive Limit :" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 22%; position: absolute; "></asp:Label>
            <asp:Label ID="LabelNegLimit" runat="server" Text="Negative Limit :" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 36%; position: absolute; "></asp:Label>
            <asp:Label ID="LabelVel" runat="server" Text="Velocity :" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 50%; position: absolute; "></asp:Label>
            <asp:Label ID="LabelAcc" runat="server" Text="Acc :" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 60%; position: absolute; "></asp:Label>
            <asp:Label ID="LabelHomeVelDir" runat="server" Text="Home Vel/Dir :" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 70%; position: absolute;"></asp:Label>
            <asp:Label ID="LabelHomePos" runat="server" Text="Home Pos:" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 82%; position: absolute;"></asp:Label>
             <asp:Label ID="LabelBacklash" runat="server" Text="Backlash :" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 92%; position: absolute;"></asp:Label>
        </asp:Panel>
          <asp:Panel ID="PanelXValues" runat="server" style="top: 14%; left: 0%; position: absolute; height: 22%; width: 100%; background-color: #003399;">
               <asp:Label ID="LabelXAxisName" runat="server" Text="X :" Font-Names="Trebuchet MS" Font-Size="12pt" Width="2%"></asp:Label>
               <asp:TextBox ID="TextXBoxPort" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" Width="4%"></asp:TextBox>
               <asp:TextBox ID="TextXBoxRes" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 8%; position: absolute; width: 12%;"></asp:TextBox>
               <asp:TextBox ID="TextXBoxPosLimit" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 22%; position: absolute; width: 12%;"></asp:TextBox>
               <asp:TextBox ID="TextXBoxNegLimit" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 36%; position: absolute; width: 12%;"></asp:TextBox>
                <asp:TextBox ID="TextXBoxVel" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 50%; position: absolute; width: 8%;"></asp:TextBox>
                <asp:TextBox ID="TextXBoxAcc" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 60%; position: absolute; width: 8%;"></asp:TextBox>
                <asp:TextBox ID="TextXBoxHomeVelDir" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 70%; position: absolute; width: 10%;"></asp:TextBox>
                <asp:TextBox ID="TextXBoxHomePos" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 82%; position: absolute; width: 8%;"></asp:TextBox>
                <asp:TextBox ID="TextXBoxBacklash" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 92%; position: absolute; width: 7%;"></asp:TextBox>
          </asp:Panel>
        <asp:Panel ID="PanelYValues" runat="server" style="top: 36%; left: 0%; position: absolute; height: 22%; width: 100%; background-color: #003399;">
               <asp:Label ID="LabelYAxisName" runat="server" Text="Y :" Font-Names="Trebuchet MS" Font-Size="12pt" Width="2%"></asp:Label>
               <asp:TextBox ID="TextYBoxPort" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" Width="4%"></asp:TextBox>
               <asp:TextBox ID="TextYBoxRes" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 8%; position: absolute; width: 12%;"></asp:TextBox>
               <asp:TextBox ID="TextYBoxPosLimit" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 22%; position: absolute; width: 12%;"></asp:TextBox>
               <asp:TextBox ID="TextYBoxNegLimit" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 36%; position: absolute; width: 12%;"></asp:TextBox>
                <asp:TextBox ID="TextYBoxVel" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 50%; position: absolute; width: 8%;"></asp:TextBox>
                <asp:TextBox ID="TextYBoxAcc" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 60%; position: absolute; width: 8%;"></asp:TextBox>
                <asp:TextBox ID="TextYBoxHomeVelDir" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 70%; position: absolute; width: 10%;"></asp:TextBox>
                <asp:TextBox ID="TextYBoxHomePos" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 82%; position: absolute; width: 8%;"></asp:TextBox>
                <asp:TextBox ID="TextYBoxBacklash" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 92%; position: absolute; width: 7%;"></asp:TextBox>
          </asp:Panel>
        <asp:Panel ID="PanelZValues" runat="server" style="top: 58%; left: 0%; position: absolute; height: 22%; width: 100%; background-color: #003399;">
               <asp:Label ID="LabelZAxisName" runat="server" Text="Z :" Font-Names="Trebuchet MS" Font-Size="12pt" Width="2%"></asp:Label>
               <asp:TextBox ID="TextZBoxPort" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" Width="4%"></asp:TextBox>
               <asp:TextBox ID="TextZBoxRes" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 8%; position: absolute; width: 12%;"></asp:TextBox>
               <asp:TextBox ID="TextZBoxPosLimit" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 22%; position: absolute; width: 12%;"></asp:TextBox>
               <asp:TextBox ID="TextZBoxNegLimit" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 36%; position: absolute; width: 12%;"></asp:TextBox>
                <asp:TextBox ID="TextZBoxVel" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 50%; position: absolute; width: 8%;"></asp:TextBox>
                <asp:TextBox ID="TextZBoxAcc" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 60%; position: absolute; width: 8%;"></asp:TextBox>
                <asp:TextBox ID="TextZBoxHomeVelDir" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 70%; position: absolute; width: 10%;"></asp:TextBox>
                <asp:TextBox ID="TextZBoxHomePos" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 82%; position: absolute; width: 8%;"></asp:TextBox>
                <asp:TextBox ID="TextZBoxBacklash" runat="server" Font-Names="Trebuchet MS" Font-Size="12pt" style="top: 0px; left: 92%; position: absolute; width: 7%;"></asp:TextBox>
          </asp:Panel>
          <asp:Panel ID="PanelSaveButton" runat="server" style="top: 80%; left: 0%; position: absolute; height: 20%; width: 100%; background-color: #003399;">
            <asp:Button ID="ButtonSaveSettings" runat="server" Text="Save Settings" style="top: 0%; left: 44%; position: absolute; height: 100%; width: 12%;" Font-Names="Trebuchet MS" Font-Size="12pt" OnClick="ButtonSaveSettings_Click" />
          </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

