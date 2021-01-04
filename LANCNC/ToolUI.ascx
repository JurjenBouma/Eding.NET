<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToolUI.ascx.cs" Inherits="LANCNC.ToolUI" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional"><ContentTemplate>
<asp:ListBox ID="ListBoxTools" runat="server" Height="259px" style="top: 0%; left: 0%; position: absolute; height: 100%; width: 35%" Width="294px" OnSelectedIndexChanged="ListBoxTools_SelectedIndexChanged"></asp:ListBox>
    <asp:Panel ID="PanelToolInfo" runat="server" style="top: 0%; left: 35%; position: absolute; height: 100%; width: 65%; background-color: #003399">
        <asp:Panel ID="PanelInfoTextTop" runat="server" style="top: 0%; left: 0px; position: absolute; height: 25%; width: 100%">
            <asp:Label ID="LabelToolDescription" runat="server" Text="Tool discription :" Font-Names="Trebuchet MS" Font-Size="14pt" Width="70%"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="PanelValuesTop" runat="server" style="top: 25%; left: 0px; position: absolute; height: 25%; width: 100%">
            <asp:TextBox ID="TextBoxToolDescription" runat="server" Font-Names="Trebuchet MS" Font-Size="14pt" Width="68%"></asp:TextBox>
            <asp:Button ID="ButtonSaveTool" runat="server" style="top: 0%; left: 70%; position: absolute; height: 29px; width: 14%" Text="Save tool" Font-Names="Trebuchet MS" Font-Size="12pt" OnClick="ButtonSaveTool_Click" />
            <asp:Button ID="ButtonSetActiveTool" runat="server" style="top: 0%; left: 85%; position: absolute; height: 29px; width:14%" Text="Set Active" Font-Names="Trebuchet MS" Font-Size="12pt" BackColor="Lime" OnClick="ButtonSetActiveTool_Click"  />
        </asp:Panel>
            <asp:Panel ID="PanelInfoTextBottom" runat="server" style="top: 50%; left: 0px; position: absolute; height: 25%; width: 100%">
            <asp:Label ID="LabelToolLenght" runat="server" Text="Tool Length :" Font-Names="Trebuchet MS" Font-Size="14pt" Width="30%"></asp:Label>
            <asp:Label ID="LabelToolzDelta" runat="server" Text="Tool zDelta :" Font-Names="Trebuchet MS" Font-Size="14pt"  Width="30%"></asp:Label>
            <asp:Label ID="LabelToolDiameter" runat="server" Text="Tool Diameter :" Font-Names="Trebuchet MS" Font-Size="14pt"  Width="30%"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="PanelValuesBottom" runat="server" style="top: 75%; left: 0px; position: absolute; height: 25%; width: 100%">
            <asp:TextBox ID="TextBoxToolLenght" runat="server" Font-Names="Trebuchet MS" Font-Size="14pt" Width="28%" ></asp:TextBox>
            <asp:TextBox ID="TextBoxToolzDelta" runat="server" Font-Names="Trebuchet MS" Font-Size="14pt" style="top: 0%; left: 30%; position: absolute; width: 28%" ></asp:TextBox>
            <asp:TextBox ID="TextBoxToolDiameter" runat="server" Font-Names="Trebuchet MS" Font-Size="14pt" style="top: 0%; left: 60%; position: absolute; width: 28%" ></asp:TextBox>
        </asp:Panel>
    </asp:Panel>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ListBoxTools" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>


