<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToolMeasurementUI.ascx.cs" Inherits="LANCNC.ToolMeasurementUI" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="PanelRow1" style="top: 0px; left: 0px; position: absolute; height: 25%; width: 100%"> 
            <asp:Label ID="LabelTool" runat="server" Text="Tool : " style="top: 4px; left:0px; position: absolute; width: 250px; text-align:center" Font-Names="Trebuchet MS"></asp:Label> 
            <asp:Label ID="LabelHeight" runat="server" Text="Hieght" style="top: 4px; left:350px; position: absolute; width: 100px; text-align:center" Font-Names="Trebuchet MS"></asp:Label> 
            <asp:Label ID="LabelProbeDist" runat="server" Text="Probe Distance" style="top: 4px; left:670px; position: absolute; width: 160px; text-align:center" Font-Names="Trebuchet MS"></asp:Label>
        </div> 
        <div id="PanelRow2" style="top: 25%; left: 0px; position: absolute; height: 25%; width: 100%"> 
            <asp:DropDownList ID="DropDownListTools" runat="server" Height="20px" Width="250px" Font-Names="Trebuchet MS" OnSelectedIndexChanged="DropDownListTools_SelectedIndexChanged"></asp:DropDownList>
            <asp:Button ID="ButtonMeasure" runat="server" Text="Measure" Font-Names="Trebuchet MS" Height="29px" Font-Size="12pt" OnClick="ButtonMeasure_Click"/>
            <asp:TextBox ID="TextBoxHeight" runat="server" Height="20px" Width="100px" style="left:350px; position: absolute; text-align:center;" Font-Names="Trebuchet MS"></asp:TextBox>
            <asp:Button ID="ButtonProbeOutside" runat="server" Text="Probe Outside -->[]<--" style="left:460px; position: absolute;" Font-Names="Trebuchet MS" Width="200px" Height="29px" Font-Size="12pt" OnClick="ButtonProbeOutside_Click"/>
            <asp:TextBox ID="TextBoxProbeDist" runat="server" Height="20px" Width="200px" style="left:670px; position: absolute; text-align:center;" Font-Names="Trebuchet MS"></asp:TextBox>
        </div> 
        <div id="PanelRow3" style="top: 50%; left: 0px; position: absolute; height: 25%; width: 100%"> 
           <asp:Label ID="LabelLenght" runat="server" Text="Approximate Lenght : " style="top: 4px; left:0px; position: absolute; width: 250px; text-align:center" Font-Names="Trebuchet MS"></asp:Label> 
           <asp:Label ID="LabelWidth" runat="server" Text="Width" style="top: 4px; left:350px; position: absolute; width: 100px; text-align:center" Font-Names="Trebuchet MS"></asp:Label> 
             <asp:Button ID="ButtonMeasrureAngle" runat="server" Text="/\ Measure X Angle /\" style="left:670px; position: absolute;" Font-Names="Trebuchet MS" Width="200px" Height="29px" Font-Size="12pt" OnClick="ButtonMeasrureAngle_Click"/>
        </div>
        <div id="PanelRow4" style="top: 75%; left: 0px; position: absolute; height: 25%; width: 100%"> 
            <asp:TextBox ID="TextBoxLenght" runat="server" Height="20px" Width="250px" Font-Names="Trebuchet MS"></asp:TextBox>
            <asp:TextBox ID="TextBoxWidth" runat="server" Height="20px" Width="100px" style=" left:350px; position: absolute; text-align:center;" Font-Names="Trebuchet MS"></asp:TextBox>
            <asp:Button ID="ButtonProbeInside" runat="server" Text="Probe Inside [<---->]" style="left:460px; position: absolute;"  Font-Names="Trebuchet MS" Width="200px" Height="29px" Font-Size="12pt" OnClick="ButtonProbeInside_Click"/>
            <asp:Button ID="ButtonG68" runat="server" Text="G68" style="left:670px; position: absolute;" Font-Names="Trebuchet MS" Width="60px" Height="29px" Font-Size="12pt" OnClick="ButtonG68_Click"/>
            <asp:Button ID="ButtonG69" runat="server" Text="G69" style="left:810px; position: absolute;" Font-Names="Trebuchet MS" Width="60px" Height="29px" Font-Size="12pt" OnClick="ButtonG69_Click"/>
        </div> 
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="DropDownListTools" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>