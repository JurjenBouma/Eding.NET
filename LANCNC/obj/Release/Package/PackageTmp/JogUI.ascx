<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JogUI.ascx.cs" Inherits="LANCNC.JogUI" %>
    <asp:HiddenField ID="EventTriggerStartMove" runat="server" OnValueChanged="EventTriggerStartMove_ValueChanged" />
    <asp:HiddenField ID="EventTriggerStopMove" runat="server" OnValueChanged="EventTriggerStopMove_ValueChanged"/>
 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="PanelJogTop" style="top: 0px; left: 0px; position: absolute; height: 50%; width: 100%"> 
                <asp:ImageButton ID="ImageButtonFeedUp" runat="server" style="height:  99%; width: auto;" ImageUrl="~/Images/Buttons/Eding/min_feed.bmp" OnClick="ImageButtonFeedUp_Click" />

                <asp:ImageButton ID="ImageButtonYUp" runat="server" ImageUrl="~/Images/Buttons/Eding/jog_up.bmp" onmousedown="StartMove(event,'Y+')" onmouseup="StopMove(event,'Y')" ondragend="StopMove(event,'Y')" ontouchstart="StartMoveT(event,'Y+')" ontouchend="StopMoveT(event,'Y')" 
                    Text="" style="height:  99%; width: auto; " />

                <asp:ImageButton ID="ImageButtonFeedDown" runat="server"  style="height:  99%; width: auto;" ImageUrl="~/Images/Buttons/Eding/plus_feed.bmp" OnClick="ImageButtonFeedDown_Click" />

                <asp:ImageButton ID="ImageButtonZUp" runat="server" ImageUrl="~/Images/Buttons/Eding/jog_up3.bmp" onmousedown="StartMove(event,'Z+')" onmouseup="StopMove(event,'Z')" ondragend="StopMove(event,'Z')" ontouchstart="StartMoveT(event,'Z+')" ontouchend="StopMoveT(event,'Z')" 
                    Text="" style="height:  99%; width: auto;" /> 
            </div> 
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="PanelJogBottom" style="top: 0px; left: 0px; position: absolute; height: 50%; width: 100%; top: 50%;">
        <asp:ImageButton ID="ImageButtonXLeft" runat="server" ImageUrl="~/Images/Buttons/Eding/jog_left.bmp" onmousedown="StartMove(event,'X-')" onmouseup="StopMove(event,'X')" ondragend="StopMove(event,'X')" ontouchstart="StartMoveT(event,'X-')" ontouchend="StopMoveT(event,'X')" 
            Text="" style="height: 99%; width:auto; left: 0px;" /> 
    
        <asp:ImageButton ID="ImageButtonYDown" runat="server" ImageUrl="~/Images/Buttons/Eding/jog_down.bmp" onmousedown="StartMove(event,'Y-')" onmouseup="StopMove(event,'Y')" ondragend="StopMove(event,'Y')" ontouchstart="StartMoveT(event,'Y-')" ontouchend="StopMoveT(event,'Y')" 
            Text="" style=" height:  99%; width: auto;" />
        
        <asp:ImageButton ID="ImageButtonXRight" runat="server" ImageUrl="~/Images/Buttons/Eding/jog_right.bmp" onmousedown="StartMove(event,'X+')" onmouseup="StopMove(event,'X')" ondragend="StopMove(event,'X')" ontouchstart="StartMoveT(event,'X+')" ontouchend="StopMoveT(event,'X')" 
            Text="" style="height:  99%; width: auto; " />
          
        <asp:ImageButton ID="ImageButtonZDown" runat="server" ImageUrl="~/Images/Buttons/Eding/jog_down3.bmp" onmousedown="StartMove(event,'Z-')" onmouseup="StopMove(event,'Z')" ondragend="StopMove(event,'Z')" ontouchstart="StartMoveT(event,'Z-')" ontouchend="StopMoveT(event,'Z')" 
            Text="" style=" height:  99%; width: auto; " />

        <asp:CheckBox ID="CheckBoxSingleStep" runat="server" OnCheckedChanged="CheckBoxPreciseJog_CheckedChanged" Text="Precise Jog" Font-Names="Trebuchet MS" Font-Size="12pt" Style=" display:inline-block; position: absolute; top:10px" />
    </div>

