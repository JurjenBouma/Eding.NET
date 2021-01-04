using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdingDotNET.Types;
using EdingDotNET.Remote;
using System.Windows;
using wrapper = EdingDotNET.APIWrapper;

namespace EdingDotNET
{
    public class CNCController
    {
        private bool m_isActive;
        public bool IsActive { get { return m_isActive; } }

        private wrapper.CNCServer CNCServer;

        public CNCController(CNCRemote CNCRemote)
        {
            m_isActive = true;

            CNCRemote.CloseDotNetServerEvent += CloseServer;
            CNCRemote.CNCConnectServerEvent +=  CNCConnectServer;
            CNCRemote.CNCDisconnectServerEvent +=  CNCDisconnectServer;
            CNCRemote.CNCFloodOnEvent +=  CNCFloodOn;
            CNCRemote.CNCGetActualFeedEvent +=  CNCGetActualFeed;
            CNCRemote.CNCGetActualSpeedEvent += CNCGetActualSpeed;
            CNCRemote.CNCGetAllAxisHomedEvent +=CNCGetAllAxisHomed;
            CNCRemote.CNCGetCurrentToolNumberEvent += CNCGetCurrentToolNumber;
            CNCRemote.CNCGetInputEvent += CNCGetInput;
            CNCRemote.CNCGetJobStatusEvent += CNCGetJobStatus;
            CNCRemote.CNCGetMachinePositionEvent += CNCGetMachinePosition;
            CNCRemote.CNCGetProgrammedFeedEvent += CNCGetProgrammedFeed;
            CNCRemote.CNCGetProgrammedSpeedEvent += CNCGetProgrammedSpeed;
            CNCRemote.CNCGetSimulationModeEvent += CNCGetSimulationMode;
            CNCRemote.CNCGetStateEvent += CNCGetState;
            CNCRemote.CNCGetTrafficLightStatusEvent += CNCGetTrafficLightStatus;
            CNCRemote.CNCGetWorkPositionEvent += CNCGetWorkPosition;
            CNCRemote.CNCGraphFifoGetEvent += CNCGraphFifoGet;
            CNCRemote.CNCHomeAllEvent += CNCHomeAll;
            CNCRemote.CNCHomeEvent += CNCHome;
            CNCRemote.CNCLoadJobEvent += CNCLoadJob;
            CNCRemote.CNCMistAndFloodOffEvent += CNCMistAndFloodOff;
            CNCRemote.CNCMistOnEvent += CNCMistOn;
            CNCRemote.CNCPauseJobEvent += CNCPauseJob;
            CNCRemote.CNCResetEvent += CNCReset;
            CNCRemote.CNCRewindJobEvent += CNCRewindJob;
            CNCRemote.CNCRunOrResumeJobEvent += CNCRunOrResumeJob;
            CNCRemote.CNCRunSingleLineEvent += CNCRunSingleLine;
            CNCRemote.CNCSetOutputEvent += CNCSetOutput;
            CNCRemote.CNCSetSimulationModeEvent += CNCSetSimulationMode;
            CNCRemote.CNCSetSpindleSpeedEvent += CNCSetSpindleSpeed;
            CNCRemote.CNCSetVariableEvent += CNCSetVariable;
            CNCRemote.CNCSingleStepModeEvent += CNCSingleStepMode;
            CNCRemote.CNCStartJog2Event += CNCStartJog2;
            CNCRemote.CNCStartRenderGraphEvent += CNCStartRenderGraph;
            CNCRemote.CNCStartRenderSearchEvent += CNCStartRenderSearch;
            CNCRemote.CNCStartSpindleEvent += CNCStartSpindle;
            CNCRemote.CNCStopJogEvent += CNCStopJog;
            CNCRemote.CNCStopSpindleEvent += CNCStopSpindle;
            CNCRemote.CNCStartJogEvent += CNCStartJog;
            CNCRemote.CNCZeroAllEvent += CNCZeroAll;
            CNCRemote.CNCZeroEvent += CNCZero;
            CNCRemote.CNCGetToolDataEvent += CNCGetToolData;
            CNCRemote.CNCUpdateToolDataEvent += CNCUpdateToolData;
            CNCRemote.CNCGetVariableEvent += CNCGetVariable;
            CNCRemote.CNCIsServerConnectedEvent += CNCIsServerConnected;
            CNCRemote.CNCLoadToolTableEvent += CNCLoadToolTable;
            CNCRemote.CNCGetOutputEvent += CNCGetOutput;
            CNCRemote.CNCGetSpindleStatusEvent += CNCGetSpindleStatus;
            CNCRemote.SetSpindleOutputEvent += CNCSetSpindleOutput;
            CNCRemote.CNCCheckStartConditionOKEvent += CNCCheckStartConditionOK;
            CNCRemote.CNCGetMotionEnabledEvent += CNCGetMotionEnabled;
            CNCRemote.CNCGetSafetyModeEvent += CNCGetSafetyMode;
            CNCRemote.CNCGetJointConfigEvent += CNCGetJointConfig;
            CNCRemote.CNCSetJointConfigEvent += CNCSetJointConfig;
            CNCRemote.CNCStoreIniFileEvent += CNCStoreIniFile;
            CNCRemote.CNCReInitializeEvent += CNCReInitialize;
            CNCRemote.CNCGetLogFifoEvent += CNCGetLogFifo;
            CNCRemote.CNCGetSafetyConfigEvent += CNCGetSafetyConfig;
            CNCRemote.CNCSetSafetyConfigEvent += CNCSetSafetyConfig;
            CNCRemote.CNCGetPausePositionEvent += CNCGetPausePosition;
            CNCRemote.CNCGraphFifoGetArrayEvent += CNCGetGraphFifoArray;
            CNCRemote.CNCMoveToEvent += CNCMoveTo;
            CNCRemote.CNCResetPausePositionEvent += CNCResetPausePosition;
            CNCRemote.CNCGetPauseSatusEvent += CNCGetPauseStatus;
            CNCRemote.CNCGetSingleStepModeEvent += CNCGetSingleStepMode;
            CNCRemote.CNCGetEMStopActiveEvent += CNCGetEMStopActive;
            CNCRemote.CNCAbortJobEvent += CNCAbortJob;
            CNCRemote.CNCResetPauseStatusEvent += CNCResetPauseStatus;
            CNCRemote.CNCGetMachineZeroWorkPointEvent += CNCGetMachineZeroWorkPoint;
        }

        private void CloseServer()
        {
            m_isActive = false;
        }

        /// <summary>
        /// Connects to CncServer.exe
        /// </summary>
        ///<param name ="cncfile"> cnc.ini file(Just the file name)</param>
        public RCResult CNCConnectServer(string cncFile)
        {
            CNCServer = new wrapper.CNCServer();
            return CNCServer.CNCConnectServer(cncFile);
        }

        /// <summary>
        /// Disconnects and closes the CncServer.exe
        /// </summary>
        public void CNCDisconnectServer()
        {
            CNCServer.CNCDisconnectServer();
        }

        /// <summary>
        /// Recovers from errors 
        /// </summary>
        public RCResult CNCReset()
        {
            return CNCServer.CNCReset();
        }

        /// <summary>
        /// Set an output used to enable Drives 
        /// </summary>
        public RCResult CNCSetOutput(CNCIOID id, int value)
        {
            return CNCServer.CNCSetOutput(id, value);
        }

        /// <summary>
        ///Home All axis
        /// </summary>
        public RCResult CNCHomeAll()
        {
            return CNCServer.CNCHomeAll();
        }

        /// <summary>
        ///Homes specific axis
        /// </summary>
        ///<param name ="axis"> axis to home</param>
        public RCResult CNCHome(CNCAxis axis)
        {
            return CNCServer.CNCHome(axis);
        }


        /// <summary>
        ///Zero All axis
        /// </summary>
        public RCResult CNCZeroAll()
        {
            return CNCServer.CNCZeroAll();
        }

        /// <summary>
        ///Zero specific axis
        /// </summary>
        ///<param name ="axis"> axis to Zero</param>
        public RCResult CNCZero(CNCAxis axis)
        {
            return CNCServer.CNCZero(axis);
        }

        /// <summary>
        ///Execute single line of gcode
        /// </summary>
        ///<param name ="line"> gcode</param>
        public RCResult CNCRunSingleLine(string line)
        {
            return CNCServer.CNCRunSingleLine(line);
        }

        /// <summary>
        ///Load a gcode file
        /// </summary>
        ///<param name ="fileName"> File path of job</param>
        public RCResult CNCLoadJob(string fileName)
        {
            return CNCServer.CNCLoadJob(fileName);
        }

        /// <summary>
        ///Renders job into GraphFifo
        /// </summary>
        ///<param name ="Outlines"> render Outline</param>
        ///<param name ="Contour"> render Shape</param>
        public RCResult CNCStartRenderGraph(int outline, int contour)
        {
            return CNCServer.CNCStartRenderGraph(outline, contour);
        }

        /// <summary>
        ///Renders job into GraphFifo until line
        /// </summary>
        ///<param name ="Outlines"> render Outline</param>
        ///<param name ="Contour"> render Shape</param>
        ///<param name ="line">line to stop rendering at</param>
        public RCResult CNCStartRenderSearch(int outline, int contour, int line)
        {
            return CNCServer.CNCStartRenderSearch(outline, contour, line, 0, 0);
        }

        /// <summary>
        ///Runs or Resumes job
        /// </summary>
        public RCResult CNCRunOrResumeJob()
        {
            return CNCServer.CNCRunOrResumeJob();
        }

        /// <summary>
        ///Pause
        /// </summary>
        public RCResult CNCPauseJob()
        {
            return CNCServer.CNCPauseJob();
        }

        public RCResult CNCRewindJob()
        {
            return CNCServer.CNCRewindJob();
        }

        public CNCPositions CNCGetWorkPosition()
        {
            return CNCServer.CNCGetWorkPosition();
        }

        public CNCPositions CNCGetMachinePosition()
        {
            return CNCServer.CNCGetMachinePosition();
        }

        public CNCTrafficLightStatus CNCGetTrafficLightStatus()
        {
            return CNCServer.CNCGetTrafficLightStatus();
        }

        /// <summary>
        ///Reads Input Value
        /// </summary>
        ///<param name ="ioid"> ID of input</param>
        public int CNCGetInput(CNCIOID id)
        {
            return CNCServer.CNCGetInput(id);
        }

        /// <summary>
        ///Gets state of CNC
        /// </summary>
        public CNCState CNCGetState() { return (CNCState)CNCServer.CNCGetState(); }


        public CNCJobStatus CNCGetJobStatus()
        {
            return CNCServer.CNCGetJobStatus();
        }

        /// <summary>
        ///start jogging
        /// </summary>
        ///<param name ="axis"> axis to move as double[6] example 0,0,1,0,0,0 to move z axis in positive direction</param>
        ///<param name ="velocityFacotor">feedrate scaler, 1.0 for full feedrate</param>
        ///<param name ="continuous"> 0 for move distance specified in axis[] , 1 for coninuous movement</param>
        public RCResult CNCStartJog(double[] axis, double velocityFactor, int continuous)
        {
            return CNCServer.CNCStartJog(axis, velocityFactor, continuous);
        }

        /// <summary>
        ///start jogging
        /// </summary>
        ///<param name ="axis"> axis to jog</param>
        ///<param name ="stepSize">Determines direction and discance in mm to move when continuous =0</param>
        ///<param name ="velocityFacotor">feedrate scaler, 1.0 for full feedrate</param>
        ///<param name ="continuous"> 0 for move distance specified in stepSize , 1 for coninuous movement</param>
        public RCResult CNCStartJog2(CNCAxis axis, double stepSize, double velocityFactor, int continuous)
        {
            return CNCServer.CNCStartJog2(axis, stepSize, velocityFactor, continuous);
        }

        /// <summary>
        ///stop jogging of specific axis
        /// </summary>
        ///<param name ="axis"> axis to stop</param>
        public RCResult CNCStopJog(CNCAxis axis)
        {
            return CNCServer.CNCStopJog(axis);
        }

        public double CNCGetActualFeed() { return CNCServer.CNCGetActualFeed(); }
        public double CNCGetActualSpeed() { return CNCServer.CNCGetActualSpeed(); }
        public double CNCGetProgrammedFeed() { return CNCServer.CNCGetProgrammedFeed(); }
        public double CNCGetProgrammedSpeed() { return CNCServer.CNCGetProgrammedSpeed(); }

        /// <summary>
        ///Returns 1 if all axis are homed
        /// </summary>
        public int CNCGetAllAxisHomed() { return CNCServer.CNCGetAllAxisHomed(); }
        public int CNCGetCurrentToolNumber() { return CNCServer.CNCGetCurrentToolNumber(); }

        /// <summary>
        ///Set simmode
        /// </summary>
        ///<param name ="enable"> 0 fro disable, 1 for enable</param>
        public RCResult CNCSetSimulationMode(int enable) { return CNCServer.CNCSetSimulationMode(enable); }

        /// <summary>
        ///Gets Simulation mode
        /// </summary>
        public int CNCGetSimulationMode() { return CNCServer.CNCGetSimulationMode(); }

        /// <summary>
        ///Sets a Variable(eding manual for list)
        /// </summary>
        ///<param name ="index"> variable index</param>
        ///<param name ="index"> new value</param>
        public void CNCSetVariable(int index, double value) { CNCServer.CNCSetVariable(index, value); }

        /// <summary>
        ///StepMode
        /// </summary>
        ///<param name ="enable"> 0 for disable, 1 for enable</param>
        public RCResult CNCSingleStepMode(int enable) { return CNCServer.CNCSingleStepMode(enable); }

        /// <summary>
        ///Gets the Graph data rendered by CNCStartRenderGraph
        /// </summary>
        public CNCGraphData CNCGraphFifoGet() { return CNCServer.CNCGraphFifoGet(); }


        public RCResult CNCStartSpindle() { return CNCServer.CNCStartSpindle(); }
        public RCResult CNCStopSpindle() { return CNCServer.CNCStopSpindle(); }
        public RCResult CNCMistOn() { return CNCServer.CNCMistOn(); }
        public RCResult CNCFloodOn() { return CNCServer.CNCFloodOn(); }
        public RCResult CNCMistAndFloodOff() { return CNCServer.CNCMistAndFloodOff(); }

        /// <summary>
        ///Sets Spindle speed
        /// </summary>
        ///<param name ="rpm"> Speed in rpm</param>
        public RCResult CNCSetSpindleSpeed(int rpm) { return CNCServer.CNCSetSpindleSpeed(rpm); }

        public CNCToolData CNCGetToolData(int toolNumber)
        {
            return CNCServer.CNCGetToolData(toolNumber);
        }

        /// <summary>
        ///Updates Tool Data Call LoadToolTable to Load Results
        /// </summary>
        public RCResult CNCUpdateToolData(CNCToolData tool,int toolIndex)  {return CNCServer.CNCUpdateToolData(tool, toolIndex); }

        public double CNCGetVariable(int index) { return CNCServer.CNCGetVariable(index); }
        public int CNCIsServerConnected() { return CNCServer.CNCIsServerConnected(); }
        public RCResult CNCLoadToolTable() { return CNCServer.CNCLoadToolTable(); }
        public int CNCGetOutput(CNCIOID id) { return CNCServer.CNCGetOutput(id); }
        public CNCSpindleStatus CNCGetSpindleStatus() { return CNCServer.CNCGetSpindleStatus(); }
        public RCResult CNCSetSpindleOutput(int onOff, int direction, double absSpeed) { return CNCServer.CNCSetSpindleOutput(onOff,direction,absSpeed); }
        public int CNCGetMotionEnabled() { return CNCServer.CNCGetMotionEnabled(); }
        public int CNCCheckStartConditionOK(int ignoreHoming) { return CNCServer.CNCCheckStartConditionOK(ignoreHoming); }
        public int CNCGetSafetyMode() { return CNCServer.CNCGetSafetyMode(); }
        public CNCJointConfig CNCGetJointConfig(CNCAxis axis) { return CNCServer.CNCGetJointConfig(axis); }
        public void CNCSetJointConfig(CNCJointConfig config,CNCAxis axis) { CNCServer.CNCSetJointConfig(config,axis); }
        public void CNCStoreIniFile() { CNCServer.CNCStoreIniFile(); }
        public void CNCReInitialize() { CNCServer.CNCReInitialize(); }
        public CNCLogMessage CNCGetLogFifo() { return CNCServer.CNCGetLogFifo(); }
        public CNCSafetyConfig CNCGetSafetyConfig() { return CNCServer.CNCGetSafetyConfig(); }
        public void CNCSetSafetyConfig(CNCSafetyConfig safetyConfig) { CNCServer.CNCSetSafetyConfig(safetyConfig); }
        public CNCPositions CNCGetPausePosition() { return CNCServer.CNCGetPausePosition(); }
        public CNCGraphData[] CNCGetGraphFifoArray(int count) { return CNCServer.CNCGraphFifoGetArray(count); }
        public RCResult CNCMoveTo(CNCPositions pos, CNCAxisBools axis, double velocityFactor) { return CNCServer.CNCMoveTo(pos, axis, velocityFactor); }
        public void CNCResetPausePosition() { CNCServer.CNCResetPausePosition(); }
        public CNCPauseStatus CNCGetPauseStatus() { return CNCServer.CNCGetPauseSatus(); }
        public int CNCGetSingleStepMode() { return CNCServer.CNCGetSingleStepMode(); }
        public int CNCGetEMStopActive() { return CNCServer.CNCGetEMStopActive(); }
        public RCResult CNCAbortJob() { return CNCServer.CNCAbortJob(); }
        public void CNCResetPauseStatus() { CNCServer.CNCResetPauseStatus(); }
        public CNCPositions CNCGetMachineZeroWorkPoint() { return CNCServer.CNCGetMachineZeroWorkPoint(); }
    }
}
