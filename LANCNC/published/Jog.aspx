<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Jog.aspx.cs" Inherits="LANCNC.Jog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script> 
        function StartMove(e, dir) {
            console.log("startend");
            Move(dir);
            return false;
        }

        function StopMove(e, axis) {
            console.log("mouseend");
            Move(axis);
        }

        function StartMoveT(e, dir) {
            console.log("startend");
            Move(dir);
            e.preventDefault();
        }

        function StopMoveT(e, axis) {
            console.log("mouseend");
            Move(axis);
            e.preventDefault();
        }

        function Move(command)
        {
            document.getElementById('<%=EventTrigger.ClientID %>').value = command + "!";
        }

    </script>
    <asp:HiddenField ID="EventTrigger" runat="server" OnValueChanged="TriggerEvent" />
    <div id="PanelJogTop" style="top: 0px; left: 0px; position: absolute; height: 50%; width: 100%"> 
        <asp:ImageButton ID="ImageButtonSpeedUp" runat="server" style="height:  99%; width: auto;" ImageUrl="~/Images/Buttons/Eding/speed_min.bmp" OnClick="ImageButtonSpeedUp_Click" />

        <asp:ImageButton ID="ImageButtonYUp" runat="server" ImageUrl="~/Images/Buttons/Eding/jog_up.bmp" onmousedown="StartMove(event,'Y+')" onmouseup="StopMove(event,'Y')" ondragend="StopMove(event,'Y')" ontouchstart="StartMoveT(event,'Y+')" ontouchend="StopMoveT(event,'Y')" 
            Text="" style="height:  99%; width: auto; " />

        <asp:ImageButton ID="ImageButtonSpeedDown" runat="server"  style="height:  99%; width: auto;" ImageUrl="~/Images/Buttons/Eding/speed_plus.bmp" OnClick="ImageButtonSpeedDown_Click" />

        <asp:ImageButton ID="ImageButtonZUp" runat="server" ImageUrl="~/Images/Buttons/Eding/jog_up3.bmp" onmousedown="StartMove(event,'Z+')" onmouseup="StopMove(event,'Z')" ondragend="StopMove(event,'Z')" ontouchstart="StartMoveT(event,'Z+')" ontouchend="StopMoveT(event,'Z')" 
            Text="" style="height:  99%; width: auto;" />
                
        <asp:Label ID="LabelSpeed" runat="server" Text="Feed  : 100%" Font-Names="Calibri" Font-Size="20pt" ForeColor="#000014" style="color: #FFFFFF; background-color: #325190;" CssClass="LabelFeed" AutoPostBack="true"></asp:Label>
    </div> 
    <div id="PanelJogBottom" style="top: 0px; left: 0px; position: absolute; height: 50%; width: 100%; top: 50%;">
        <asp:ImageButton ID="ImageButtonXLeft" runat="server" ImageUrl="~/Images/Buttons/Eding/jog_left.bmp" onmousedown="StartMove(event,'X-')" onmouseup="StopMove(event,'X')" ondragend="StopMove(event,'X')" ontouchstart="StartMoveT(event,'X-')" ontouchend="StopMoveT(event,'X')" 
            Text="" style="height: 99%; width:auto; left: 0px;" /> 
    
        <asp:ImageButton ID="ImageButtonYDown" runat="server" ImageUrl="~/Images/Buttons/Eding/jog_down.bmp" onmousedown="StartMove(event,'Y-')" onmouseup="StopMove(event,'Y')" ondragend="StopMove(event,'Y')" ontouchstart="StartMoveT(event,'Y-')" ontouchend="StopMoveT(event,'Y')" 
            Text="" style=" height:  99%; width: auto;" />
        
        <asp:ImageButton ID="ImageButtonXRight" runat="server" ImageUrl="~/Images/Buttons/Eding/jog_right.bmp" onmousedown="StartMove(event,'X+')" onmouseup="StopMove(event,'X')" ondragend="StopMove(event,'X')" ontouchstart="StartMoveT(event,'X+')" ontouchend="StopMoveT(event,'X')" 
            Text="" style="height:  99%; width: auto; " />
           
        <asp:ImageButton ID="ImageButtonZDown" runat="server" ImageUrl="~/Images/Buttons/Eding/jog_down3.bmp" onmousedown="StartMove(event,'Z-')" onmouseup="StopMove(event,'Z')" ondragend="StopMove(event,'Z')" ontouchstart="StartMoveT(event,'Z-')" ontouchend="StopMoveT(event,'Z')" 
            Text="" style=" height:  99%; width: auto; " />
    </div>
</asp:Content>
