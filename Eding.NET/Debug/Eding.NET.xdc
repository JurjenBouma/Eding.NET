<?xml version="1.0"?><doc>
<members>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCConnectServer(System.String)" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="20">
<summary>
Connects to CncServer.exe
</summary>
<param name="cncFile"> cnc.ini file(Just the file name)</param>
<returns></returns>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCDisconnectServer" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="27">
<summary>
Disconnects and closes the CncServer.exe
</summary>
<returns></returns>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCReset" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="33">
<summary>
Recovers from errors 
</summary>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCSetOutput(EdingDotNET.Types.CNCIOID,System.Int32)" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="38">
<summary>
Set an output used to enable Drives 
</summary>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCHomeAll" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="43">
<summary>
Home All axis
</summary>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCHome(EdingDotNET.Types.CNCAxis)" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="48">
<summary>
Homes specific axis
</summary>
<param name="axis"> axis to home</param>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCZeroAll" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="54">
<summary>
Zero All axis
</summary>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCZero(EdingDotNET.Types.CNCAxis)" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="59">
<summary>
Zero specific axis
</summary>
<param name="axis"> axis to Zero</param>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCRunSingleLine(System.String)" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="65">
<summary>
Execute single line of gcode
</summary>
<param name="line"> gcode</param>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCLoadJob(System.String)" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="71">
<summary>
Load a gcode file
</summary>
<param name="fileName"> File path of job</param>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCStartRenderGraph(System.Int32,System.Int32)" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="77">
<summary>
Renders job into GraphFifo
</summary>
<param name="Outlines"> render Outline</param>
<param name="Contour"> render Shape</param>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCStartRenderSearch(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="84">
<summary>
Renders job into GraphFifo until line
</summary>
<param name="Outlines"> render Outline</param>
<param name="Contour"> render Shape</param>
<param name="line">line to stop rendering at</param>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCRunOrResumeJob" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="92">
<summary>
Runs or Resumes job
</summary>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCPauseJob" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="97">
<summary>
Pause
</summary>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCGetInput(EdingDotNET.Types.CNCIOID)" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="107">
<summary>
Reads Input Value
</summary>
<param name="ioid"> ID of input</param>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCGetState" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="114">
<summary>
Gets state of CNC
</summary>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCStartJog2(EdingDotNET.Types.CNCAxis,System.Double,System.Double,System.Int32)" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="122">
<summary>
start jogging
</summary>
<param name="axis"> axis to jog</param>
<param name="stepSize">Determines direction and discance in mm to move when continuous =0</param>
<param name="velocyFactor">feedrate scaler, 1.0 for full feedrate</param>
<param name="continuous"> 0 for move distance specified in stepSize , 1 for coninuous movement</param>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCStartJog(System.Double[],System.Double,System.Int32)" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="131">
<summary>
start jogging
</summary>
<param name="axis"> axis to move as double[6] example 0,0,1,0,0,0 to move z axis in positive direction</param>
<param name="velocityFactor">feedrate scaler, 1.0 for full feedrate</param>
<param name="continuous"> 0 for move distance specified in axis[] , 1 for coninuous movement</param>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCStopJog(EdingDotNET.Types.CNCAxis)" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="139">
<summary>
stop jogging of specific axis
</summary>
<param name="axis"> axis to stop</param>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCGetAllAxisHomed" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="151">
<summary>
Returns 1 if all axis are homed
</summary>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCSetSimulationMode(System.Int32)" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="160">
<summary>
Sets Simulation mode
</summary>
<param name="enable"> 0 fro disable, 1 for enable</param>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCGetSimulationMode" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="166">
<summary>
Gets Simulation mode
</summary>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCSetVariable(System.Int32,System.Double)" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="171">
<summary>
Sets a Variable(eding manual for list)
</summary>
<param name="index"> variable index</param>
<param name="index"> new value</param>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCSingleStepMode(System.Int32)" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="178">
<summary>
StepMode
</summary>
<param name="enable"> 0 for disable, 1 for enable</param>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCGraphFifoGet" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="184">
<summary>
Gets the Graph data rendered by CNCStartRenderGraph
</summary>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCSetSpindleSpeed(System.Int32)" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="195">
<summary>
Sets Spindle speed
</summary>
<param name="rpm"> Speed in rpm</param>
</member>
<member name="M:EdingDotNET.APIWrapper.CNCServer.CNCUpdateToolData(EdingDotNET.Types.CNCToolData,System.Int32)" decl="true" source="c:\users\jurjen\documents\visual studio 2017\projects\eding.net\eding.net\eding.net.h" line="203">
<summary>
Updates Tool Data Call LoadToolTable to Load Results
</summary>
</member>
</members>
</doc>