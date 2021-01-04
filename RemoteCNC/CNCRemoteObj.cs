using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using EdingDotNET.Types;

namespace EdingDotNET.Remote
{
    public class CNCRemote : MarshalByRefObject
    {
        public override object InitializeLifetimeService()
        {
            return null;
        }
        //bool m_IsConnected = false;
        //public bool IsConnected { get { return m_IsConnected; } }

        //Returns RemoteObject Call this on client side
        public static CNCRemote ConnectRemote(int port)
        {
            return (CNCRemote)Activator.GetObject(typeof(CNCRemote), "tcp://localhost:"+port.ToString()+"/CncServerDotNet");
        }

        //Creates and registers RemoteObject call this on server side
        public CNCRemote(int port)
        {
            TcpChannel channel = new TcpChannel(port);
            ChannelServices.RegisterChannel(channel, false);
            ObjRef objRefCNCRemoteObj;
            objRefCNCRemoteObj = RemotingServices.Marshal(this, "CncServerDotNet");
        }

        public event Events.VoidHandler CloseDotNetServerEvent;
        public void CloseDotNetServer()
        {
           // m_IsConnected = false;
            try { CloseDotNetServerEvent();}
            catch { }
        }

        public event Events.StringHandler CNCConnectServerEvent;
        /// <summary>
        /// Connects to CncServer.exe
        /// </summary>
        ///<param name ="cncfile"> cnc.ini file(Just the file name)</param>
        public RCResult CNCConnectServer(string cncFile)
        {
           // m_IsConnected = true;
            try { return CNCConnectServerEvent(cncFile); }
            catch (Exception e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
               // m_IsConnected = false;
                return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING;
            }
        }


        public event Events.VoidHandler CNCDisconnectServerEvent;
        /// <summary>
        /// Disconnects and closes the CncServer.exe
        /// </summary>
        public void CNCDisconnectServer()
        {
            //m_IsConnected = false;
            try { CNCDisconnectServerEvent(); }
            catch {  }
        }

        public event Events.RCHandler CNCResetEvent;
        /// <summary>
        /// Recovers from errors 
        /// </summary>
        public RCResult CNCReset()
        {
            try { return CNCResetEvent(); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.SetOutputHandler CNCSetOutputEvent;
        /// <summary>
        /// Set an output used to enable Drives 
        /// </summary>
        public RCResult CNCSetOutput(CNCIOID id, int value)
        {
            try { return CNCSetOutputEvent( id, value); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.RCHandler CNCHomeAllEvent;
        /// <summary>
        ///Home All axis
        /// </summary>
        public RCResult CNCHomeAll()
        {
            try { return CNCHomeAllEvent(); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.AxisHandler CNCHomeEvent;
        /// <summary>
        ///Homes specific axis
        /// </summary>
        ///<param name ="axis"> axis to home</param>
        public RCResult CNCHome(CNCAxis axis)
        {
            try { return CNCHomeEvent(axis); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }


        public event Events.RCHandler CNCZeroAllEvent;
        /// <summary>
        ///Zero All axis
        /// </summary>
        public RCResult CNCZeroAll()
        {
            try { return CNCZeroAllEvent(); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.AxisHandler CNCZeroEvent;
        /// <summary>
        ///Zero specific axis
        /// </summary>
        ///<param name ="axis"> axis to Zero</param>
        public RCResult CNCZero(CNCAxis axis)
        {
            try { return CNCZeroEvent(axis); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.StringHandler CNCRunSingleLineEvent;
        /// <summary>
        ///Execute single line of gcode
        /// </summary>
        ///<param name ="line"> gcode</param>
        public RCResult CNCRunSingleLine(string line)
        {
            try { return CNCRunSingleLineEvent(line); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.StringHandler CNCLoadJobEvent;
        /// <summary>
        ///Load a gcode file
        /// </summary>
        ///<param name ="fileName"> File path of job</param>
        public RCResult CNCLoadJob(string fileName)
        {
            try { return CNCLoadJobEvent(fileName); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.RenderGraphHandler CNCStartRenderGraphEvent;
        /// <summary>
        ///Renders job into GraphFifo
        /// </summary>
        ///<param name ="Outlines"> render Outline</param>
        ///<param name ="Contour"> render Shape</param>
        public RCResult CNCStartRenderGraph(int outline,int contour)
        {
            try { return CNCStartRenderGraphEvent(outline,contour); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.RenderGraphSearchHandler CNCStartRenderSearchEvent;
        /// <summary>
        ///Renders job into GraphFifo until line
        /// </summary>
        ///<param name ="Outlines"> render Outline</param>
        ///<param name ="Contour"> render Shape</param>
        ///<param name ="line">line to stop rendering at</param>
        public RCResult CNCStartRenderSearch(int outline, int contour,int line)
        {
            try { return CNCStartRenderSearchEvent(outline, contour,line); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.RCHandler CNCRunOrResumeJobEvent;
        /// <summary>
        ///Runs or Resumes job
        /// </summary>
        public RCResult CNCRunOrResumeJob()
        {
            try { return CNCRunOrResumeJobEvent(); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.RCHandler CNCPauseJobEvent;
        /// <summary>
        ///Pause
        /// </summary>
        public RCResult CNCPauseJob()
        {
            try { return CNCPauseJobEvent(); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }


        public event Events.RCHandler CNCRewindJobEvent;
        public RCResult CNCRewindJob()
        {
            try { return CNCRewindJobEvent(); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.PosHandler CNCGetWorkPositionEvent;
        public CNCPositions CNCGetWorkPosition()
        {
            try { return CNCGetWorkPositionEvent(); }
            catch { return new CNCPositions(); }
        }

        public event Events.PosHandler CNCGetMachinePositionEvent;
        public CNCPositions CNCGetMachinePosition()
        {
            try { return CNCGetMachinePositionEvent(); }
            catch { return new CNCPositions(); }
        }

        public event Events.LightsHandler CNCGetTrafficLightStatusEvent;
        public CNCTrafficLightStatus CNCGetTrafficLightStatus()
        {
            try { return CNCGetTrafficLightStatusEvent(); }
            catch { return new CNCTrafficLightStatus(); }
        }

        public event Events.GetIOHandler CNCGetInputEvent;
        /// <summary>
        ///Reads Input Value
        /// </summary>
        ///<param name ="ioid"> ID of input</param>
        public int CNCGetInput(CNCIOID id)
        {
            try { return CNCGetInputEvent(id); }
            catch { return -1; }
        }

        public event Events.CNCStateHandler CNCGetStateEvent;
        /// <summary>
        ///Gets state of CNC
        /// </summary>
        public CNCState CNCGetState()
        {
            try { return CNCGetStateEvent(); }
            catch { return CNCState.CNC_IE_INT_ERROR_STATE; }
        }

        public event Events.JobStatusHandler CNCGetJobStatusEvent;
        public CNCJobStatus CNCGetJobStatus()
        {
            try { return CNCGetJobStatusEvent(); }
            catch { return new CNCJobStatus(); }
        }

        public event Events.JogHandler CNCStartJogEvent;
        /// <summary>
        ///start jogging
        /// </summary>
        ///<param name ="axis"> axis to move as double[6] example 0,0,1,0,0,0 to move z axis in positive direction</param>
        ///<param name ="velocityFacotor">feedrate scaler, 1.0 for full feedrate</param>
        ///<param name ="continuous"> 0 for move distance specified in axis[] , 1 for coninuous movement</param>
        public RCResult CNCStartJog(double[] axis, double velocityFactor, int continuous)
        {
            try { return CNCStartJogEvent(axis,velocityFactor,continuous); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.Jog2Handler CNCStartJog2Event;
        /// <summary>
        ///start jogging
        /// </summary>
        ///<param name ="axis"> axis to jog</param>
        ///<param name ="stepSize">Determines direction and discance in mm to move when continuous =0</param>
        ///<param name ="velocityFacotor">feedrate scaler, 1.0 for full feedrate</param>
        ///<param name ="continuous"> 0 for move distance specified in stepSize , 1 for coninuous movement</param>
        public RCResult CNCStartJog2(CNCAxis axis, double stepSize, double velocityFactor, int continuous)
        {
            try { return CNCStartJog2Event(axis,stepSize,velocityFactor,continuous); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.AxisHandler CNCStopJogEvent;
        /// <summary>
        ///stop jogging of specific axis
        /// </summary>
        ///<param name ="axis"> axis to stop</param>
        public RCResult CNCStopJog(CNCAxis axis)
        {
            try { return CNCStopJogEvent(axis); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.DoubleHandler CNCGetActualFeedEvent;
        public double CNCGetActualFeed()
        {
            try { return CNCGetActualFeedEvent(); }
            catch { return -1; }
        }

        public event Events.DoubleHandler CNCGetActualSpeedEvent;
        public double CNCGetActualSpeed()
        {
            try { return CNCGetActualSpeedEvent(); }
            catch { return -1; }
        }

        public event Events.DoubleHandler CNCGetProgrammedFeedEvent;
        public double CNCGetProgrammedFeed()
        {
            try { return CNCGetProgrammedFeedEvent(); }
            catch { return -1; }
        }

        public event Events.DoubleHandler CNCGetProgrammedSpeedEvent;
        public double CNCGetProgrammedSpeed()
        {
            try { return CNCGetProgrammedSpeedEvent(); }
            catch { return -1; }
        }

        public event Events.IntHandler CNCGetAllAxisHomedEvent;
        /// <summary>
        ///Returns 1 if all axis are homed
        /// </summary>
        public int CNCGetAllAxisHomed()
        {
            try { return CNCGetAllAxisHomedEvent(); }
            catch { return -1; }
        }

        public event Events.IntHandler CNCGetCurrentToolNumberEvent;
        public int CNCGetCurrentToolNumber()
        {
            try { return CNCGetCurrentToolNumberEvent(); }
            catch { return -1; }
        }

        public event Events.EnableHandler CNCSetSimulationModeEvent;
        /// <summary>
        ///Set simmode
        /// </summary>
        ///<param name ="enable"> 0 fro disable, 1 for enable</param>
        public RCResult CNCSetSimulationMode(int enable){
            try { return CNCSetSimulationModeEvent(enable); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.IntHandler CNCGetSimulationModeEvent;
        /// <summary>
        ///Gets Simulation mode
        /// </summary>
        public int CNCGetSimulationMode()
        {
            try { return CNCGetSimulationModeEvent(); }
            catch { return -1; }
        }

        public event Events.SetVariableHandler CNCSetVariableEvent;
        /// <summary>
        ///Sets a Variable(eding manual for list)
        /// </summary>
        ///<param name ="index"> variable index</param>
        ///<param name ="index"> new value</param>
        public void CNCSetVariable(int index, double value)
        {
            try { CNCSetVariableEvent(index ,value); }
            catch { }
        }

        public event Events.EnableHandler CNCSingleStepModeEvent;
        /// <summary>
        ///StepMode
        /// </summary>
        ///<param name ="enable"> 0 for disable, 1 for enable</param>
        public RCResult CNCSingleStepMode(int enable)
        {
            try { return CNCSingleStepModeEvent(enable); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.GetGraphHandler CNCGraphFifoGetEvent;
        /// <summary>
        ///Gets the Graph data rendered by CNCStartRenderGraph
        /// </summary>
        public CNCGraphData CNCGraphFifoGet()
        {
            try { return CNCGraphFifoGetEvent(); }
            catch { return new CNCGraphData(); }
        }

        public event Events.RCHandler CNCStartSpindleEvent;
        public RCResult CNCStartSpindle()
        {
            try { return CNCStartSpindleEvent(); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.RCHandler CNCStopSpindleEvent;
        public RCResult CNCStopSpindle()
        {
            try { return CNCStopSpindleEvent(); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.RCHandler CNCMistOnEvent;
        public RCResult CNCMistOn()
        {
            try { return CNCMistOnEvent(); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.RCHandler CNCFloodOnEvent;
        public RCResult CNCFloodOn()
        {
            try { return CNCFloodOnEvent(); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.RCHandler CNCMistAndFloodOffEvent;
        public RCResult CNCMistAndFloodOff()
        {
            try { return CNCMistAndFloodOffEvent(); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.RPMHandler CNCSetSpindleSpeedEvent;
        /// <summary>
        ///Sets Spindle speed
        /// </summary>
        ///<param name ="rpm"> Speed in rpm</param>
        public RCResult CNCSetSpindleSpeed(int rpm)
        {
            try { return CNCSetSpindleSpeedEvent(rpm); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.ToolDataHandler CNCGetToolDataEvent;
        public CNCToolData CNCGetToolData(int toolNumber)
        {
            try { return CNCGetToolDataEvent(toolNumber); }
            catch { return new CNCToolData(); }
        }

        public event Events.UpdateToolDataHandler CNCUpdateToolDataEvent;
        public RCResult CNCUpdateToolData(CNCToolData tool, int toolNumber)
        {
            try { return CNCUpdateToolDataEvent(tool,toolNumber); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.RCHandler CNCLoadToolTableEvent;
        public RCResult CNCLoadToolTable()
        {
            try { return CNCLoadToolTableEvent(); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.GetVariableHandler CNCGetVariableEvent;
        public double CNCGetVariable(int varIndex)
        {
            try { return CNCGetVariableEvent(varIndex); }
            catch { return -1; }
        }

        public event Events.IntHandler CNCIsServerConnectedEvent;
        public int CNCIsServerConnected()
        {
            try { return CNCIsServerConnectedEvent(); }
            catch { return -1; }
        }

        public event Events.GetIOHandler CNCGetOutputEvent;
        public int CNCGetOutput(CNCIOID id)
        {
            try { return CNCGetOutputEvent(id); }
            catch { return -1; }
        }

        public event Events.GetSpindleStatus CNCGetSpindleStatusEvent;
        public CNCSpindleStatus CNCGetSpindleStatus()
        {
            try { return CNCGetSpindleStatusEvent(); }
            catch { return new CNCSpindleStatus(); }
        }

        public event Events.SetSpindleOutputHandler SetSpindleOutputEvent;
        public RCResult SetSpindleOutput(int onOff,int direction,double absSpeed)
        {
            try { return SetSpindleOutputEvent(onOff,direction,absSpeed); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.IntHandler CNCGetMotionEnabledEvent;
        public int CNCGetMotionEnabled()
        {
            try { return CNCGetMotionEnabledEvent(); }
            catch { return -1; }
        }

        public event Events.CNCCheckStartOKHandler CNCCheckStartConditionOKEvent;
        public int CNCCheckStartConditionOK(int ignoreHoming)
        {
            try { return CNCCheckStartConditionOKEvent(ignoreHoming); }
            catch { return  -1; }
        }

        public event Events.IntHandler CNCGetSafetyModeEvent;
        public int CNCGetSafetyMode()
        {
            try { return CNCGetSafetyModeEvent(); }
            catch { return -1; }
        }


        public event Events.GetJointConfigHandler CNCGetJointConfigEvent;
        public CNCJointConfig CNCGetJointConfig(CNCAxis axis)
        {
            try { return CNCGetJointConfigEvent(axis); }
            catch { return new CNCJointConfig(); }
        }

        public event Events.SetJointConfigHandler CNCSetJointConfigEvent;
        public void CNCSetJointConfig(CNCJointConfig config, CNCAxis axis)
        {
            try { CNCSetJointConfigEvent(config,axis); }
            catch { }
        }

        public event Events.VoidHandler CNCStoreIniFileEvent;
        public void CNCStoreIniFile()
        {
            try { CNCStoreIniFileEvent(); }
            catch { }
        }

        public event Events.VoidHandler CNCReInitializeEvent;
        public void CNCReInitialize()
        {
            try { CNCReInitializeEvent(); }
            catch { }
        }

        public event Events.LogMessageHandler CNCGetLogFifoEvent;
        public CNCLogMessage CNCGetLogFifo()
        {
            try { return CNCGetLogFifoEvent(); }
            catch { return new CNCLogMessage(); }
        }

        public event Events.SafetyConfigHandler CNCGetSafetyConfigEvent;
        public CNCSafetyConfig CNCGetSafetyConfig()
        {
            try { return CNCGetSafetyConfigEvent(); }
            catch { return new CNCSafetyConfig(); }
        }

        public event Events.SetSafetyConfigHandler CNCSetSafetyConfigEvent;
        public void CNCSetSafetyConfig(CNCSafetyConfig safetyConfig)
        {
            try { CNCSetSafetyConfigEvent(safetyConfig); }
            catch { }
        }

        public event Events.PosHandler CNCGetPausePositionEvent;
        public CNCPositions CNCGetPausePosition()
        {
            try { return CNCGetPausePositionEvent(); }
            catch { return new CNCPositions(); }
        }

        public event Events.GraphDataArrayHandler CNCGraphFifoGetArrayEvent;
        public CNCGraphData[] CNCGraphFifoGetArray(int count)
        {
            try { return CNCGraphFifoGetArrayEvent(count); }
            catch{ return new CNCGraphData[1] { new CNCGraphData { pos = new CNCPositions(), type = CNCMoveType.CNC_MOVE_TYPE_PROBE, lineNumber = -1, msgNumber=-1 } }; }
        }

        public event Events.MoveToHandler CNCMoveToEvent;
        public RCResult CNCMoveTo(CNCPositions pos,CNCAxisBools axis,double velocityFactor)
        {
            try { return CNCMoveToEvent(pos,axis,velocityFactor); }
            catch{ return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }

        public event Events.VoidHandler CNCResetPausePositionEvent;
        public void CNCResetPausePosition()
        {
            try { CNCResetPausePositionEvent(); }
            catch { }
        }


        public event Events.PauseStatusHandler CNCGetPauseSatusEvent;
        public CNCPauseStatus CNCGetPauseSatus()
        {
            try { return CNCGetPauseSatusEvent(); }
            catch { return new CNCPauseStatus(); }
        }

        public event Events.IntHandler CNCGetSingleStepModeEvent;
        public int CNCGetSingleStepMode()
        {
            try { return CNCGetSingleStepModeEvent(); }
            catch { return -1; }
        }

        public event Events.IntHandler CNCGetEMStopActiveEvent;
        public int CNCGetEMStopActive()
        {
            try { return CNCGetEMStopActiveEvent(); }
            catch { return -1; }
        }

        public event Events.RCHandler CNCAbortJobEvent;
        public RCResult CNCAbortJob()
        {
            try { return CNCAbortJobEvent(); }
            catch { return RCResult.CNC_RC_ERR_SERVER_NOT_RUNNING; }
        }


        public event Events.VoidHandler CNCResetPauseStatusEvent;
        public void CNCResetPauseStatus()
        {
            try { CNCResetPauseStatusEvent(); }
            catch {}
        }

        
        public event Events.PosHandler CNCGetMachineZeroWorkPointEvent;
        public CNCPositions CNCGetMachineZeroWorkPoint()
        {
            try { return CNCGetMachineZeroWorkPointEvent(); }
            catch { return new CNCPositions(); }
        }
    }
}
