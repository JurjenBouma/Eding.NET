//============================================================================================
//    _____       _   _                    ____   _   _    ____      _   _   _____  _______
//   | ____|   __| | (_)  _ __     __ _   / ___| | \ | |  / ___|    | \ | | |  ___||___ ___|
//   |  _|    / _` | | | | '_ \   / _` | | |     |  \| | | |		|  \| |	|  _|     | |
//   | |___  | (_| | | | | | | | | (_| | | |___  | |\  | | |___   _ | |\  | | |___    | |
//   |_____|  \__,_| |_| |_| |_|  \__, |  \____| |_| \_|  \____| |_||_| \_| |_____|   |_|
//                                |___/                          
// ===========================================================================================
// Eding.NET.h

#pragma once
using namespace System;
using namespace EdingDotNET::Types;

namespace EdingDotNET {
	namespace APIWrapper {
		public ref class CNCServer
			{
			public:
				/// <summary>
				/// Connects to CncServer.exe
				/// </summary>
				///<param name ="cncFile"> cnc.ini file(Just the file name)</param>
				///<returns></returns>
				RCResult CNCConnectServer(String^ cncFile);

				/// <summary>
				/// Disconnects and closes the CncServer.exe
				/// </summary>
				///<returns></returns>
				void CNCDisconnectServer();

				/// <summary>
				/// Recovers from errors 
				/// </summary>
				RCResult CNCReset();

				/// <summary>
				/// Set an output used to enable Drives 
				/// </summary>
				RCResult CNCSetOutput(CNCIOID id, int value);

				/// <summary>
				///Home All axis
				/// </summary>
				RCResult CNCHomeAll();

				/// <summary>
				///Homes specific axis
				/// </summary>
				///<param name ="axis"> axis to home</param>
				RCResult CNCHome(CNCAxis axis);

				/// <summary>
				///Zero All axis
				/// </summary>
				RCResult CNCZeroAll();

				/// <summary>
				///Zero specific axis
				/// </summary>
				///<param name ="axis"> axis to Zero</param>
				RCResult CNCZero(CNCAxis axis);

				/// <summary>
				///Execute single line of gcode
				/// </summary>
				///<param name ="line"> gcode</param>
				RCResult CNCRunSingleLine(String^ line);

				/// <summary>
				///Load a gcode file
				/// </summary>
				///<param name ="fileName"> File path of job</param>
				RCResult CNCLoadJob(String^ fileName);

				/// <summary>
				///Renders job into GraphFifo
				/// </summary>
				///<param name ="Outlines"> render Outline</param>
				///<param name ="Contour"> render Shape</param>
				RCResult CNCStartRenderGraph(int Outlines, int Contour);

				/// <summary>
				///Renders job into GraphFifo until line
				/// </summary>
				///<param name ="Outlines"> render Outline</param>
				///<param name ="Contour"> render Shape</param>
				///<param name ="line">line to stop rendering at</param>
				RCResult CNCStartRenderSearch(int Outlines, int Contour, int line, int xArray, int yArray);

				/// <summary>
				///Runs or Resumes job
				/// </summary>
				RCResult CNCRunOrResumeJob();

				/// <summary>
				///Pause
				/// </summary>
				RCResult CNCPauseJob();

				RCResult CNCRewindJob();
				CNCPositions CNCGetWorkPosition();

				CNCTrafficLightStatus CNCGetTrafficLightStatus();

				/// <summary>
				///Reads Input Value
				/// </summary>
				///<param name ="ioid"> ID of input</param>
				int CNCGetInput(CNCIOID ioid);


				/// <summary>
				///Gets state of CNC
				/// </summary>
				CNCState CNCGetState();


				CNCJobStatus CNCGetJobStatus();

				/// <summary>
				///start jogging
				/// </summary>
				///<param name ="axis"> axis to jog</param>
				///<param name ="stepSize">Determines direction and discance in mm to move when continuous =0</param>
				///<param name ="velocyFactor">feedrate scaler, 1.0 for full feedrate</param>
				///<param name ="continuous"> 0 for move distance specified in stepSize , 1 for coninuous movement</param>
				RCResult CNCStartJog2(CNCAxis axis, double stepSize, double velocyFactor, int continuous);

				/// <summary>
				///start jogging
				/// </summary>
				///<param name ="axis"> axis to move as double[6] example 0,0,1,0,0,0 to move z axis in positive direction</param>
				///<param name ="velocityFactor">feedrate scaler, 1.0 for full feedrate</param>
				///<param name ="continuous"> 0 for move distance specified in axis[] , 1 for coninuous movement</param>
				RCResult CNCStartJog(array<double>^ axis, double velocityFactor, int continuous);

				/// <summary>
				///stop jogging of specific axis
				/// </summary>
				///<param name ="axis"> axis to stop</param>
				RCResult CNCStopJog(CNCAxis axis);


				double CNCGetActualFeed();
				double CNCGetActualSpeed();
				double CNCGetProgrammedFeed();
				double CNCGetProgrammedSpeed();

				/// <summary>
				///Returns 1 if all axis are homed
				/// </summary>
				int CNCGetAllAxisHomed();

				int CNCGetCurrentToolNumber();

				CNCPositions CNCGetMachinePosition();

				/// <summary>
				///Sets Simulation mode
				/// </summary>
				///<param name ="enable"> 0 fro disable, 1 for enable</param>
				RCResult CNCSetSimulationMode(int enable);

				/// <summary>
				///Gets Simulation mode
				/// </summary>
				int CNCGetSimulationMode();

				/// <summary>
				///Sets a Variable(eding manual for list)
				/// </summary>
				///<param name ="index"> variable index</param>
				///<param name ="index"> new value</param>
				void CNCSetVariable(int index, double value);

				/// <summary>
				///StepMode
				/// </summary>
				///<param name ="enable"> 0 for disable, 1 for enable</param>
				RCResult CNCSingleStepMode(int enable);

				/// <summary>
				///Gets the Graph data rendered by CNCStartRenderGraph
				/// </summary>
				CNCGraphData CNCGraphFifoGet();

				RCResult CNCStartSpindle();
				RCResult CNCStopSpindle();
				RCResult CNCMistOn();
				RCResult CNCFloodOn();
				RCResult CNCMistAndFloodOff();

				/// <summary>
				///Sets Spindle speed
				/// </summary>
				///<param name ="rpm"> Speed in rpm</param>
				RCResult CNCSetSpindleSpeed(int rpm);

				CNCToolData CNCGetToolData(int toolNumber); 

				/// <summary>
				///Updates Tool Data Call LoadToolTable to Load Results
				/// </summary>
				RCResult CNCUpdateToolData(CNCToolData tool, int toolNumber);

				RCResult CNCLoadToolTable();
				double CNCGetVariable(int varIndex);
				int CNCIsServerConnected();
				int CNCGetOutput(CNCIOID id);
				CNCSpindleStatus CNCGetSpindleStatus();
				RCResult CNCSetSpindleOutput(int onOff, int direction, double absSpeed);
				int CNCGetMotionEnabled();
				int CNCCheckStartConditionOK(int ignoreHoming);
				int CNCGetSafetyMode();
				CNCJointConfig CNCGetJointConfig(CNCAxis axis);
				void CNCSetJointConfig(CNCJointConfig config, CNCAxis axis);
				void CNCReInitialize();
				void CNCStoreIniFile();
				CNCLogMessage CNCGetLogFifo();
				CNCSafetyConfig CNCGetSafetyConfig();
				void CNCSetSafetyConfig(CNCSafetyConfig config);
				CNCPositions CNCGetPausePosition();
				array<CNCGraphData>^ CNCGraphFifoGetArray(int count);
				RCResult CNCMoveTo(CNCPositions pos, CNCAxisBools axis ,double velocityVector);
				void CNCResetPausePosition();
				CNCPauseStatus CNCGetPauseSatus();
				int CNCGetSingleStepMode();
				int CNCGetEMStopActive();
				RCResult CNCAbortJob();
				void CNCResetPauseStatus();
				CNCPositions CNCGetMachineZeroWorkPoint();
			};
	}
}