<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="LANCNC.MainForm" %>

<%@ Register Src="~/MainControlUI.ascx" TagPrefix="uc1" TagName="MainControlUI" %>
<%@ Register Src="~/JobUI.ascx" TagPrefix="uc1" TagName="JobUI" %>
<%@ Register Src="~/JogUI.ascx" TagPrefix="uc1" TagName="JogUI" %>
<%@ Register Src="~/AdminUI.ascx" TagPrefix="uc1" TagName="AdminUI" %>
<%@ Register Src="~/ToolUI.ascx" TagPrefix="uc1" TagName="ToolUI" %>
<%@ Register Src="~/SettingsUI.ascx" TagPrefix="uc1" TagName="SettingsUI" %>
<%@ Register Src="~/WorkCoordDialog.ascx" TagPrefix="uc1" TagName="WorkCoordDialog" %>


<%@ Register src="ToolMeasurementUI.ascx" tagname="ToolMeasurementUI" tagprefix="uc2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
        <meta name="viewport" content="initial-scale=1.0" />
        <link href="StyleSheet.css" rel="stylesheet" />

        <title id="Title">CNC LAN</title>
         <link runat="server" rel="shortcut icon" href="~/favicon.ico" type="image/x-icon" />
         <link runat="server" rel="icon" href="~/favicon.ico" type="image/ico" />
        <style type="text/css">
            #RenderPanel {
                top: 0px;
                left: 0px;
                position: absolute;
                height: 100%;
                width: 70%;
                z-index: 1;
                background-color: #000000;
                right: 577px;
            } 
            #PanelPage {
                bottom: 0px;
                position: absolute;
                height: 1000px;
                width: 1900px;
            }
            #PanelCoords {
                top: 0px;
                left: 25%;
                height: 100%;
                width: 75%;
                position: absolute;
                background-color: #003399;
            }
            #PanelHomeZero {
                height: 100%;
                width: 25%;
                top: 0px;
                left: 0px;
                position: absolute;
                background-color: #003399;
            }
            #PanelWorkCoords {
                top: 1%;
                left: 2%;
                position: absolute;
                height: 48%;
                width: 96%;
                background-color: #003399;
            }
            #PanelMachineCoords {
                top: 51%;
                left: 2%;
                position: absolute;
                height: 48%;
                width: 96%;
                background-color: #003399;
            }
            #PanelMid {
                bottom: 0px;
                right: 0px;
                top: 70%;
                left: 0px;
                position: absolute;
                height: 20%;
                width: 100%;
                background-color: #003399;
            }
        </style>
    </head>
    <body>
        <form id="MasterPage" runat="server" enctype="multipart/form-data" defaultbutton="btnFake">
            <asp:ScriptManager ID="script1" runat="server"> </asp:ScriptManager>
            <div>
                <asp:LinkButton ID ="btnFake" runat="server" Style="display:none;" OnClientClick="return false;"></asp:LinkButton>
            </div>
            <asp:Panel ID="PanelPage" runat="server" style="min-width:1024px; min-height:576px; top: 0%; left: 0%; position: absolute; height: 99%; width: 100%">
                <div id="TopPanel" style="height: 70%; width: 100%; text-align: center; z-index: 0; left: 0px; top: 0px; position: absolute; bottom: 0px; right: 0px; background-color: #FF6666">
                    <div id="RenderPanel">
                        <canvas id="RenderSurface" width="800" height="600"> </canvas>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                    <asp:Label ID="LabelStatusInfo" runat="server" Font-Bold="True" Font-Names="Trebuchet MS" Text="RPM : 0 (25%) | Simulation : 1" CssClass="LabelStatusInfo" AutoPostBack="true"></asp:Label>  
                            </ContentTemplate>
                            <Triggers> <asp:AsyncPostBackTrigger ControlID="timer1" EventName="Tick" /> </Triggers>
                        </asp:UpdatePanel>  
                    </div>
                     
                    <div id="PanelTopLeft" style="top: 0px; left: 70%; position: absolute; height: 100%; width: 30%; z-index: 2; background-color: #FF6666">
                        <div id="PanelHomeZero">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                <ContentTemplate>
                                     <asp:Panel ID="PanelZeroButtons" runat="server" Style=" top: 1%; left: 1%; position: absolute; height: 48%; width: 98%; bottom: 345px; background-color: #003399;">
                                        <asp:ImageButton ID="ImageButtonZeroX" runat="server" ImageUrl="~/Images/Buttons/Eding/zero_x.bmp" style="height: 30%; width: auto; top: 0%; right: 1%; position: absolute;" OnClick="ImageButtonZeroX_Click" />
                                        <asp:ImageButton ID="ImageButtonZeroY" runat="server" ImageUrl="~/Images/Buttons/Eding/zero_y.bmp" style="height: 30%; width: auto;  top: 35%; right: 1%; position: absolute;" OnClick="ImageButtonZeroY_Click" />
                                        <asp:ImageButton ID="ImageButtonZeroZ" runat="server" ImageUrl="~/Images/Buttons/Eding/zero_z.bmp" style="height: 30%; width: auto; top: 70%; right: 1%; position: absolute;" OnClick="ImageButtonZeroZ_Click" />
                                    </asp:Panel>
                                     <asp:Panel ID="PanelHomeButtons"  runat="server" Style="top: 51%; left: 1%; position: absolute; height: 48%; width: 98%; background-color: #003399;">
                                          <asp:ImageButton ID="ImageButtonHomeX" runat="server" ImageUrl="~/Images/Buttons/Eding/home_x.bmp" style="height:  30%; width: auto;  top: 0%; right: 1%; position: absolute;" OnClick="ImageButtonHomeX_Click" />
                                        <asp:ImageButton ID="ImageButtonHomeY" runat="server" ImageUrl="~/Images/Buttons/Eding/home_y.bmp" style="height:  30%; width: auto; top: 35%; right: 1%; position: absolute;" OnClick="ImageButtonHomeY_Click" />
                                        <asp:ImageButton ID="ImageButtonHomeZ" runat="server" ImageUrl="~/Images/Buttons/Eding/home_z.bmp" style="height:  30%; width: auto; top: 70%; right: 1%; position: absolute;" OnClick="ImageButtonHomeZ_Click" />
                                     </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div id="PanelCoords">
                            <div id="PanelWorkCoords">
                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="PanelXwork" runat="server" style="top: 0%; left: 0px; position: absolute; height: 30%; width: 100%; background-color: #FF6666;">
                                            <asp:Label ID="LabelXwork" runat="server" Font-Bold="True" Font-Names="Trebuchet MS" Text="X : 000.000" CssClass="CoordLabels"></asp:Label>
                                        </asp:Panel>
                                        <asp:Panel ID="PanelYwork" runat="server" style="top: 35%; left: 0px; position: absolute; height: 30%; width: 100%; background-color: #66FF66;">
                                            <asp:Label ID="LabelYwork" runat="server" Font-Bold="True" Font-Names="Trebuchet MS" Text="Y : 000.000" CssClass="CoordLabels"></asp:Label>
                                        </asp:Panel>
                                        <asp:Panel ID="PanelZwork" runat="server" style="top: 70%; left: 0px; position: absolute; height: 30%; width: 100%; background-color: #3399FF;">
                                            <asp:Label ID="LabelZwork" runat="server" Font-Bold="True" Font-Names="Trebuchet MS" Text="Z : 000.000" CssClass="CoordLabels"></asp:Label>
                                        </asp:Panel>
                                    </ContentTemplate>
                                    <Triggers> <asp:AsyncPostBackTrigger ControlID="timer1" EventName="Tick" /> </Triggers>
                                 </asp:UpdatePanel>
                                 <asp:UpdatePanel ID="UpdatePanelWorkDialogs" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional"><ContentTemplate>
                                    <asp:Panel ID="PanelXWorkDialogHolder" runat="server" style="top: 0%; left: 0px; position: absolute; height: 30%; width: 100%;">
                                        <asp:ImageButton ID="ImageButtonXWorkDialog" runat="server" ImageUrl="~/Images/Buttons/trans.png" OnClick="ImageButtonXWorkDialog_Click" style="top: 0%; left: 0%; position: absolute; height: 100%; width: 100%;" />
                                        <uc1:WorkCoordDialog runat="server" ID="WorkCoordDialogX" Visible="False"/> 
                                    </asp:Panel>
                                     <asp:Panel ID="PanelYWorkDialogHolder" runat="server" style="top: 35%; left: 0px; position: absolute; height: 30%; width: 100%;">
                                        <asp:ImageButton ID="ImageButtonYWorkDialog" runat="server" ImageUrl="~/Images/Buttons/trans.png"  style="top: 0%; left: 0%; position: absolute; height: 100%; width: 100%;" OnClick="ImageButtonYWorkDialog_Click" />
                                        <uc1:WorkCoordDialog runat="server" ID="WorkCoordDialogY" Visible="False"/> 
                                    </asp:Panel>
                                     <asp:Panel ID="PanelZWorkDialogHolder" runat="server" style="top: 70%; left: 0px; position: absolute; height: 30%; width: 100%;">
                                        <asp:ImageButton ID="ImageButtonZWorkDialog" runat="server" ImageUrl="~/Images/Buttons/trans.png" style="top: 0%; left: 0%; position: absolute; height: 100%; width: 100%;" OnClick="ImageButtonZWorkDialog_Click" />
                                        <uc1:WorkCoordDialog runat="server" ID="WorkCoordDialogZ" Visible="False"/> 
                                    </asp:Panel>
                                </ContentTemplate></asp:UpdatePanel>
                            </div>
                             <div id="PanelMachineCoords">
                                 <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="PanelXmach" runat="server" style="top: 0%; left: 0px; position: absolute; height: 30%; width: 100%; background-color: #333333;">
                                             <asp:Label ID="LabelXmach" runat="server" Font-Bold="True" Font-Names="Trebuchet MS" Text="X : 000.000" CssClass="CoordLabels"></asp:Label>
                                        </asp:Panel>
                                        <asp:Panel ID="PanelYmach" runat="server" style="top: 35%; left: 0px; position: absolute; height: 30%; width: 100%; background-color: #333333;">
                                            <asp:Label ID="LabelYmach" runat="server" Font-Bold="True" Font-Names="Trebuchet MS" Text="Y : 000.000" CssClass="CoordLabels"></asp:Label>
                                        </asp:Panel>
                                        <asp:Panel ID="PanelzMach" runat="server" style="top: 70%; left: 0px; position: absolute; height: 30%; width: 100%; background-color: #333333;">
                                            <asp:Label ID="LabelZmach" runat="server" Font-Bold="True" Font-Names="Trebuchet MS" Text="Z : 000.000" CssClass="CoordLabels"></asp:Label>
                                        </asp:Panel>
                                    </ContentTemplate>
                                    <Triggers> <asp:AsyncPostBackTrigger ControlID="timer1" EventName="Tick" /> </Triggers>
                                 </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="PanelMid">               
                            <uc1:JogUI runat="server" ID="JogUI" visible="false"/>
                            <uc1:JobUI runat="server" ID="JobUI" visible="false"/>
                            <uc1:AdminUI runat="server" ID="AdminUI" visible="false"/>
                            <uc1:ToolUI runat="server" ID="ToolUI" visible="false" />
                            <uc1:SettingsUI runat="server" ID="SettingsUI"  visible="false"/>
                            <uc1:MainControlUI runat="server" ID="MainControlUI" visible="false"/>
                            <uc2:ToolMeasurementUI ID="ToolMeasurementUI" runat="server" visible="false"/>
                        </div>
                        <div id="PanelBottom" style="top: 90%; left: 0px; position: absolute; height: 10%; width: 100%; background-color: #FF6666; bottom: 0px;">
                            <asp:Panel ID="PanelMainMenu" runat="server" style="position:absolute; height: 100%; width: 70%; background-color: #003399;" >
                                <asp:ImageButton ID="ImageButtonMain" runat="server" ImageUrl="~/Images/Buttons/Eding/exit.bmp" style="height: 99%; width: auto; background-color: #66FF66" OnClick="ImageButtonMain_Click" />
                                <asp:ImageButton ID="ImageButtonAuto" runat="server" ImageUrl="~/Images/Buttons/Eding/auto.bmp" style="height: 99%; width: auto; background-color: #66FF66" OnClick="ImageButtonAuto_Click"/>
                                <asp:ImageButton ID="ImageButtonJog" runat="server" ImageUrl="~/Images/Buttons/Eding/jog.bmp" style=" height: 99%; width: auto; background-color: #66FF66" OnClick="ImageButtonJog_Click" />
                                <asp:ImageButton ID="ImageButtonToolMeasurement" runat="server" ImageUrl="~/Images/Buttons/Eding/U1.bmp" style="height: 100%; width: auto; background-color: #66FF66" OnClick="ImageButtonToolMeasurement_Click" />
                                <asp:ImageButton ID="ImageButtonTool" runat="server" ImageUrl="~/Images/Buttons/Eding/U2.bmp" style="height: 99%; width: auto; background-color: #66FF66" OnClick="ImageButtonTool_Click" />
                                <asp:ImageButton ID="ImageButtonSettings" runat="server" ImageUrl="~/Images/Buttons/Eding/edit.bmp" style="height: 99%; width: auto; background-color: #66FF66" OnClick="ImageButtonSettings_Click" />
                                <asp:ImageButton ID="ImageButtonAdmin" runat="server" ImageUrl="~/Images/Buttons/Eding/user.bmp" OnClick="ImageButtonAdmin_Click" style="height: 100%; width: auto; background-color: #66FF66" />
                            </asp:Panel>
                            <asp:Panel  ID="PanelMDI" runat="server" style="position: absolute; height:100%; width:30%; left:70%; background-color: #003399;">
                                <asp:TextBox ID="TextBoxMDI" runat="server" style="position:absolute; width: 65%; height:20px;" Font-Names="Trebuchet MS"></asp:TextBox>
                                 <asp:Button ID="ButtonMDI" runat="server" style="top: 0%; left: 70%; position: absolute; height: 29px; width: 25%" Text="Execute" Font-Names="Trebuchet MS" Font-Size="12pt" OnClick="ButtonMDI_Click" />
                            </asp:Panel>
                         </div>
                    </ContentTemplate>
                    <Triggers>
                       <asp:PostBackTrigger ControlID="JobUI$ButtonUploadFile" />
                    </Triggers>
                 </asp:UpdatePanel>
            </asp:Panel>
            <asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate>
            <asp:HiddenField ID="MachinePosition" runat="server" Value="[0,0,0]" />
            <asp:HiddenField ID="CameraPosition" runat="server" Value="[0,0,0]" />
            <asp:HiddenField ID="CameraLookAt" runat="server" Value="[0,0,0]" />
            <asp:HiddenField ID="ZeroPosition" runat="server" Value="[0,0,0]" />
            <asp:HiddenField ID="IsSpindleSpinning" runat="server" />
            </ContentTemplate></asp:UpdatePanel>
            <asp:Timer ID="timer1" runat ="server" Interval="20" OnTick="Timer1_Tick"></asp:Timer>
                <script src="Mat4.js"></script>
                            <script>

                                function StartMove(e, dir) {
                                    CNCMOVE(dir);
                                    console.log("startend");
                                    return false;
                                }

                                function StopMove(e, axis) {
                                    CNCSTOP(axis);
                                    console.log("mouseend");
                                }

                                function StartMoveT(e, dir) {
                                    CNCMOVE(dir);
                                    e.preventDefault();
                                    console.log("startend");
                                }

                                function StopMoveT(e, axis) {
                                    CNCSTOP(axis);
                                    e.preventDefault();
                                    console.log("mouseend");
                                }

                                function CNCMOVE(command) {
                                    document.getElementById('<%=JogUI.FindControl("EventTriggerStartMove").ClientID%>').value = command + "!" + performance.now().toString();
                                }

                                function CNCSTOP(command) {
                                    document.getElementById('<%=JogUI.FindControl("EventTriggerStopMove").ClientID%>').value = command + performance.now().toString();
                                }


                                var vertexShaderText =
                                    [
                                        'precision mediump float;',
                                        '',
                                        'attribute vec3 vertPosition;',
                                        'attribute vec4 vertColor;',
                                        'varying vec4 fragColor;',
                                        'uniform mat4 mWorld;',
                                        'uniform mat4 mView;',
                                        'uniform mat4 mProj;',
                                        '',
                                        'void main()',
                                        '{',
                                        '   fragColor = vertColor;',
                                        '   gl_Position = mProj * mView * mWorld * vec4(vertPosition, 1.0);',
                                        '}'
                                    ].join('\n');

                                var fragmentShaderText =
                                    [
                                        'precision mediump float;',
                                        'varying vec4 fragColor;',
                                        '',
                                        'void main()',
                                        '{',
                                        '   gl_FragColor = fragColor;',
                                        '}'
                                    ].join('\n');

                                var gl;
                                var lineVerts;
                                var lineVertBuffer;
                                var mViewLocation;
                                var gridVertCount;
                                var jobVertCount;
                                var colisionVertCount;
                                var zeroVertCount;
                                var posVertCount;

                                var Init3D = function () {
                                    var canvas = document.getElementById('RenderSurface');
                                    gl = canvas.getContext('webgl');

                                    if (!gl) { gl = canvas.getContext('experimental-webgl'); }
                                    if (!gl) { alert('A browser with webgl support is needed for rendering'); }

                                    //gl.viewport(0, 0, 800, 600);
                                    gl.clearColor(0.1, 0.1, 0.1, 1.0);
                                    gl.clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);
                                    gl.enable(gl.DEPTH_TEST);
                                    //gl.enable(gl.CULL_FACE);
                                    //gl.frontFace(gl.CCW);
                                    //gl.cullFace(gl.BACK);

                                    var vertexShader = gl.createShader(gl.VERTEX_SHADER);
                                    var fragmentShader = gl.createShader(gl.FRAGMENT_SHADER);

                                    gl.shaderSource(vertexShader, vertexShaderText);
                                    gl.shaderSource(fragmentShader, fragmentShaderText);

                                    gl.compileShader(vertexShader);
                                    if (!gl.getShaderParameter(vertexShader, gl.COMPILE_STATUS)) {
                                        console.error('Compile error vertex shader', gl.getShaderInfoLog(vertexShader));
                                        return;
                                    }

                                    gl.compileShader(fragmentShader);
                                    if (!gl.getShaderParameter(fragmentShader, gl.COMPILE_STATUS)) {
                                        console.error('Compile error fragment shader', gl.getShaderInfoLog(fragmentShader));
                                        return;
                                    }

                                    var program = gl.createProgram();
                                    gl.attachShader(program, vertexShader);
                                    gl.attachShader(program, fragmentShader);
                                    gl.linkProgram(program);

                                    lineVertBuffer = gl.createBuffer();
                                    gl.bindBuffer(gl.ARRAY_BUFFER, lineVertBuffer);

                                    UpdateLines();
                     
                                    var positionAttribLocation = gl.getAttribLocation(program, 'vertPosition');
                                    var colorAttribLocation = gl.getAttribLocation(program, 'vertColor');
                                    gl.vertexAttribPointer(
                                        positionAttribLocation,
                                        3,
                                        gl.FLOAT,
                                        gl.FALSE,
                                        7 * Float32Array.BYTES_PER_ELEMENT,
                                        0
                                    );
                                    gl.vertexAttribPointer(
                                        colorAttribLocation,
                                        4,
                                        gl.FLOAT,
                                        gl.FALSE,
                                        7 * Float32Array.BYTES_PER_ELEMENT,
                                        3 * Float32Array.BYTES_PER_ELEMENT
                                    );

                                    gl.enableVertexAttribArray(positionAttribLocation);
                                    gl.enableVertexAttribArray(colorAttribLocation);

                                    gl.useProgram(program);

                                    var mWorldLocation = gl.getUniformLocation(program, 'mWorld');
                                    mViewLocation = gl.getUniformLocation(program, 'mView');
                                    var mProjLocation = gl.getUniformLocation(program, 'mProj');

                                    var worldMatrix = new Float32Array(16);
                                    var viewMatrix = new Float32Array(16);
                                    var projMatrix = new Float32Array(16);
                                    identity(worldMatrix);
                                    lookAt(viewMatrix, <%=LANCNC.Rendering.serializer.Serialize(LANCNC.Rendering.camPos) %>, <%=LANCNC.Rendering.serializer.Serialize(LANCNC.Rendering.lookAt) %>, [0, 1, 0]);
                                    perspective(projMatrix, 45 * degree, canvas.width / canvas.height, 0.1, 10000.0);

                                    gl.uniformMatrix4fv(mWorldLocation, gl.FALSE, worldMatrix);
                                    gl.uniformMatrix4fv(mViewLocation, gl.FALSE, viewMatrix);
                                    gl.uniformMatrix4fv(mProjLocation, gl.FALSE, projMatrix);

                                    var identityMatrix = new Float32Array(16);
                                    identity(identityMatrix);
                                    var angle = 0;
                                    var machPos = [0, 0, 0];
                                    var zeroPos = [0, 0, 0];
                                    var renderPanel = document.getElementById('RenderPanel');
                                    
                                    var loop = function () {
                                        gl.clearColor(0.1, 0.1, 0.1, 1.0);
                                        gl.clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);

                                        if (canvas.clientWidth != renderPanel.clientWidth || canvas.clientHeight != renderPanel.clientHeight)
                                        {
                                            canvas.width = renderPanel.clientWidth;
                                            canvas.height = renderPanel.clientHeight;
                                            gl.viewport(0, 0, canvas.width, canvas.height);
                                            perspective(projMatrix, 45 * degree, renderPanel.clientWidth / renderPanel.clientHeight, 0.1, 10000.0);
                                            gl.uniformMatrix4fv(mProjLocation, gl.FALSE, projMatrix);
                                        }

                                        lookAt(viewMatrix, JSON.parse(document.getElementById('<%=CameraPosition.ClientID%>').value), JSON.parse(document.getElementById('<%=CameraLookAt.ClientID%>').value), [0, 1, 0]);
                                        gl.uniformMatrix4fv(mViewLocation, gl.FALSE, viewMatrix);

                                        identity(worldMatrix);
                                        gl.uniformMatrix4fv(mWorldLocation, gl.FALSE, worldMatrix);

                                        gl.drawArrays(gl.LINE_STRIP,0, gridVertCount/7,);//draw grid
                                        gl.drawArrays(gl.LINE_STRIP, gridVertCount / 7, jobVertCount / 7);//draw job
                                        gl.drawArrays(gl.LINE_STRIP, (gridVertCount + jobVertCount) / 7, colisionVertCount / 7);//draw colisions

                                        zeroPos = JSON.parse(document.getElementById('<%=ZeroPosition.ClientID%>').value);
                                        identity(worldMatrix);//reset worldmatrix
                                        translate(worldMatrix, worldMatrix, zeroPos);//roteate and move pos indicator
                                        gl.uniformMatrix4fv(mWorldLocation, gl.FALSE, worldMatrix);//update mWorld
                                        gl.drawArrays(gl.LINE_STRIP, (gridVertCount + jobVertCount + colisionVertCount) / 7, zeroVertCount / 7);//draw zero point

                                      
                                        machPos = JSON.parse(document.getElementById('<%=MachinePosition.ClientID%>').value);
                                        identity(worldMatrix);//reset worldmatrix
                                        translate(worldMatrix, worldMatrix, machPos);//roteate and move pos indicator
                                        rotate(worldMatrix, worldMatrix, angle, [0, 0, 1]);//rotate spindle

                                        if (document.getElementById('<%=IsSpindleSpinning.ClientID%>').value != 0)
                                        {
                                            angle = performance.now() / 1000 * 5 * 2 * Math.PI;
                                        }

                                        gl.uniformMatrix4fv(mWorldLocation, gl.FALSE, worldMatrix);//update mWorld
                                        gl.drawArrays(gl.TRIANGLES, (gridVertCount + jobVertCount + colisionVertCount + zeroVertCount) / 7, posVertCount / 7);//draw pos indicator
                                    
                                        requestAnimationFrame(loop);
                                    };
                                    requestAnimationFrame(loop);
                                }

                                function UpdateLines() {
                                    lineVerts = <%=LANCNC.Rendering.serializer.Serialize(LANCNC.Rendering.GetVertices) %>;

                                    gridVertCount = <%=LANCNC.Rendering.serializer.Serialize(LANCNC.Rendering.GridLenght) %>;
                                    jobVertCount =  <%=LANCNC.Rendering.serializer.Serialize(LANCNC.Rendering.JobLenght) %>;
                                    colisionVertCount =  <%=LANCNC.Rendering.serializer.Serialize(LANCNC.Rendering.ColisionLenght) %>;
                                    zeroVertCount =  <%=LANCNC.Rendering.serializer.Serialize(LANCNC.Rendering.ZeroLenght) %>;
                                    posVertCount = <%=LANCNC.Rendering.serializer.Serialize(LANCNC.Rendering.PosLenght) %>;

                                    gl.bufferData(gl.ARRAY_BUFFER, new Float32Array(lineVerts), gl.STATIC_DRAW);
                                }
                            </script>
        </form>
    </body>
</html>
