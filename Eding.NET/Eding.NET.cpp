// This is the main DLL file.
//A wrapper for the Eding Cnc Api

#include "stdafx.h"
#include "Eding.NET.h"

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace EdingDotNET;
using namespace EdingDotNET::APIWrapper;
using namespace System::Collections::Generic;

RCResult APIWrapper::CNCServer::CNCConnectServer(String^ cncFile)
{
	IntPtr pFile = Marshal::StringToHGlobalAnsi(cncFile);//marhsal vars
	CNC_RC rc = CncConnectServer(static_cast<char*>(pFile.ToPointer()));//call native api connect
	CncLoadJob(L"");//load macro for homing
	RCResult returnvalue = static_cast<RCResult>(rc);
	
	return returnvalue;
}

void APIWrapper::CNCServer::CNCDisconnectServer()
{
	CncDisConnectServer();//call native api disconnect
}

RCResult APIWrapper::CNCServer::CNCReset()
{
	CNC_RC rc = CncReset();//call native api reset
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

RCResult APIWrapper::CNCServer::CNCSetOutput(CNCIOID id, int value)
{
	CNC_RC rc = CncSetOutput(static_cast<CNC_IO_ID>(id), value);//call native api setoutput
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

RCResult APIWrapper::CNCServer::CNCHomeAll()
{
	//Start sunroutine home_all which is in the macro.cnc file     
	CNC_RC rc = CncRunSingleLine((char*)"gosub home_all");//call native api runsingleline
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

RCResult APIWrapper::CNCServer::CNCHome(CNCAxis axis)
{
	//custom homing function
	CNC_RC rc;
	if(axis== CNCAxis::X_AXIS)
		rc = CncRunSingleLine((char*)"gosub home_x");
	if (axis == CNCAxis::Y_AXIS)
		rc = CncRunSingleLine((char*)"gosub home_y");
	if (axis == CNCAxis::Z_AXIS)
		rc = CncRunSingleLine((char*)"gosub home_z");
	if (axis == CNCAxis::A_AXIS)
		rc = CncRunSingleLine((char*)"gosub home_a");
	if (axis == CNCAxis::B_AXIS)
		rc = CncRunSingleLine((char*)"gosub home_b");
	if (axis == CNCAxis::C_AXIS)
		rc = CncRunSingleLine((char*)"gosub home_z");
	if (axis == CNCAxis::ALL_AXES)
		rc = CncRunSingleLine((char*)"gosub home_all");
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

RCResult APIWrapper::CNCServer::CNCZeroAll()
{   
	CNC_RC rc = CncRunSingleLine((char*)"G10 L20 P1 X0 Y0 Z0");// gcode zero g54 coord system (the eding way)
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

RCResult APIWrapper::CNCServer::CNCZero(CNCAxis axis)
{
	//custom zeroing func
	CNC_RC rc;
	if (axis == CNCAxis::X_AXIS)
		rc = CncRunSingleLine((char*)"G10 L20 P1 X0");
	if (axis == CNCAxis::Y_AXIS)
		rc = CncRunSingleLine((char*)"G10 L20 P1 Y0");
	if (axis == CNCAxis::Z_AXIS)
		rc = CncRunSingleLine((char*)"G10 L20 P1 Z0");
	if (axis == CNCAxis::A_AXIS)
		rc = CncRunSingleLine((char*)"G10 L20 P1 A0");
	if (axis == CNCAxis::B_AXIS)
		rc = CncRunSingleLine((char*)"G10 L20 P1 B0");
	if (axis == CNCAxis::C_AXIS)
		rc = CncRunSingleLine((char*)"G10 L20 P1 C0");
	if (axis == CNCAxis::ALL_AXES)
		rc = CncRunSingleLine((char*)"G10 L20 P1 X0 Y0 Z0");
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

RCResult APIWrapper::CNCServer::CNCRunSingleLine(String^ line)
{   
	IntPtr pLine = Marshal::StringToHGlobalAnsi(line);//marshalling
	CNC_RC rc = CncRunSingleLine(static_cast<char*>(pLine.ToPointer()));
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

RCResult APIWrapper::CNCServer::CNCLoadJob(String^ fileName)
{
	pin_ptr<const wchar_t> str = PtrToStringChars(fileName);//marshalling
	CNC_RC rc = CncLoadJob(str);//call native api loadjob
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

RCResult APIWrapper::CNCServer::CNCStartRenderGraph(int Outlines,int Contour)
{
	CNC_RC rc = CncStartRenderGraph(Outlines, Contour);//call native api rendergraph
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

RCResult APIWrapper::CNCServer::CNCStartRenderSearch(int Outlines, int Contour,int line,int arrayX, int arrayY)
{
	CNC_RC rc = CncStartRenderSearch(Outlines, Contour,line,arrayX,arrayY);//call native api rendersearch
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

RCResult APIWrapper::CNCServer::CNCRunOrResumeJob()
{
	CNC_RC rc = CncRunOrResumeJob();//call native api resume
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

RCResult APIWrapper::CNCServer::CNCPauseJob()
{
	CNC_RC rc = CncPauseJob();//call native api pause
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

RCResult APIWrapper::CNCServer::CNCRewindJob()
{
	CNC_RC rc = CncRewindJob();//call native api rewind
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

CNCPositions APIWrapper::CNCServer::CNCGetWorkPosition()
{
	CNC_CART_DOUBLE pos = CncGetWorkPosition();//call native api getworkpos
	Types::CNCPositions returnvalue;//marshalling
	returnvalue.a = pos.a;
	returnvalue.b = pos.b;
	returnvalue.c = pos.c;
	returnvalue.x = pos.x;
	returnvalue.y = pos.y;
	returnvalue.z = pos.z;
  	return returnvalue;
}

CNCTrafficLightStatus APIWrapper::CNCServer::CNCGetTrafficLightStatus()
{
	CNC_TRAFFIC_LIGHT_STATUS status = *CncGetTrafficLightStatus();
	CNCTrafficLightStatus ls;//call native api getlightstatus and marshalling
	ls.trafficLightBlink = status.trafficLightBlink;
	ls.trafficLightColor = static_cast<Types::CNCTrafficLightColor>(status.trafficLightColor);
	ls.traficLightReason = gcnew String(status.traficLightReason);
	return ls;
}

int APIWrapper::CNCServer::CNCGetInput(CNCIOID ioid)
{
	CNC_IO_ID id = static_cast<CNC_IO_ID>(ioid);
	return CncGetInput(id);//call native api getinput
}

CNCState APIWrapper::CNCServer::CNCGetState()
{
	return static_cast<CNCState>(CncGetState());//call native api getstate
}

CNCJobStatus APIWrapper::CNCServer::CNCGetJobStatus()
{
	CNC_JOB_STATUS nativestatus = *CncGetJobStatus();//call native api getjobstatus
	CNCJobStatus status;//marshalling
	status.curExLine = nativestatus.curExLine;
	status.curIpLine = nativestatus.curIpLine;
	status.curIpLineText = gcnew String(nativestatus.curIpLineText);
	status.doRepeatJob = nativestatus.doRepeatJob;
	status.extraLineWhenEndOfJob = gcnew String(nativestatus.extraLineWhenEndOfJob);
	status.isLongJob = nativestatus.isLongJob;
	status.isSuperLongJob = nativestatus.isSuperLongJob;
	status.jobActualRunningTime = nativestatus.jobActualRunningTime;
	status.jobEstimatedTime = nativestatus.jobEstimatedTime;
	status.jobIsRendered = nativestatus.jobIsRendered;
	status.jobLoadCounter = nativestatus.jobLoadCounter;
	status.jobName = gcnew String(nativestatus.jobName);
	status.jobProgress = nativestatus.jobProgress;
	status.jobRemainingRunningTime = nativestatus.jobRemainingRunningTime;
	status.jobRenderLine = nativestatus.jobRenderLine;
	status.jobRenderProgressPercentage = nativestatus.jobRenderProgressPercentage;
	status.lastKnownExcutedLineNumber = nativestatus.lastKnownExcutedLineNumber;
	status.lastKnownToolChangeLineNumber = nativestatus.lastKnownToolChangeLineNumber;
	status.MCACollision = nativestatus.MCACollision;
	status.nrOfJobRepeatsSet = nativestatus.nrOfJobRepeatsSet;
	status.nrOfRepeatsActual = nativestatus.nrOfRepeatsActual;
	status.numBytesInJob = nativestatus.numBytesInJob;
	status.numLinesInjob = nativestatus.numLinesInjob;
	status.numLinesInMacro = nativestatus.numLinesInMacro;
	status.TCACollision = nativestatus.TCACollision;
	status.totalJobLength = nativestatus.totalJobLength;
	status.xCollision = nativestatus.xCollision;
	status.yCollision = nativestatus.yCollision;
	status.zCollision = nativestatus.zCollision;

	return status;
}

RCResult APIWrapper::CNCServer::CNCStartJog(array<double>^ axis, double velocityFactor, int continuous)
{
	pin_ptr<double> pinPtrAxis = &axis[0];//marhsalling
	double* axisNative = pinPtrAxis;
	CNC_RC rc = CncStartJog(axisNative, velocityFactor, continuous);//call native api jog
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

RCResult APIWrapper::CNCServer::CNCStartJog2(CNCAxis axis , double stepSize , double velocityFactor ,int continuous)
{
	CNC_RC rc = CncStartJog2((int)axis,stepSize,velocityFactor,continuous);//call native api jog2
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

RCResult APIWrapper::CNCServer::CNCStopJog(CNCAxis axis)
{
	CNC_RC rc = CncStopJog((int)axis);//call native api stop jog
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

double APIWrapper::CNCServer::CNCGetActualFeed()
{
	return CncGetActualFeed();//call native api actualfeed
}

double APIWrapper::CNCServer::CNCGetActualSpeed()
{
	return CncGetActualSpeed();//call native api actualspeed
}

double APIWrapper::CNCServer::CNCGetProgrammedFeed()
{
	return CncGetProgrammedFeed();//call native api feed
}

double APIWrapper::CNCServer::CNCGetProgrammedSpeed()
{
	return CncGetProgrammedSpeed();//call native api speed
}

int APIWrapper::CNCServer::CNCGetAllAxisHomed()
{
	return CncGetAllAxesHomed();//call native api
}
int APIWrapper::CNCServer::CNCGetCurrentToolNumber()
{
	return  CncGetCurrentToolNumber(); //call native api
}

CNCPositions APIWrapper::CNCServer::CNCGetMachinePosition()
{
	CNC_CART_DOUBLE pos = CncGetMachinePosition();//call native api
	CNCPositions returnvalue;//marshalling
	returnvalue.a = pos.a;
	returnvalue.b = pos.b;
	returnvalue.c = pos.c;
	returnvalue.x = pos.x;
	returnvalue.y = pos.y;
	returnvalue.z = pos.z;
	return returnvalue;
}

RCResult APIWrapper::CNCServer::CNCSetSimulationMode(int enable)
{
	CNC_RC rc = CncSetSimulationMode(enable);//call native api
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

int APIWrapper::CNCServer::CNCGetSimulationMode()
{
	return CncGetSimulationMode();
}

void APIWrapper::CNCServer::CNCSetVariable(int index , double value)
{
	CncSetVariable(index,value);//call native api
}

RCResult APIWrapper::CNCServer::CNCSingleStepMode(int enable)
{
	CNC_RC rc = CncSingleStepMode(enable);//call native api
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

CNCGraphData APIWrapper::CNCServer::CNCGraphFifoGet()
{
	CNC_GRAPH_FIFO_DATA data;
	CncGraphFifoGet(&data);//call native api
	CNCGraphData gdata;//marshalling
	gdata.lineNumber = data.lineNumber;
	gdata.pos.a = data.pos.a;
	gdata.pos.b = data.pos.b;
	gdata.pos.c = data.pos.c;
	gdata.pos.x = data.pos.x;
	gdata.pos.y = data.pos.y;
	gdata.pos.z = data.pos.z;
	gdata.type = static_cast<CNCMoveType>(data.type);
	gdata.msgNumber = data.msgNumber;

	return gdata;
}

//custom startspindle func
RCResult APIWrapper::CNCServer::CNCStartSpindle() {
	CNC_RC rc = CncSetSpindleOutput(1, -1, CncGetSpindleStatus()->spindleCfg.NminRPM);
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

//custom stopspindle func
RCResult APIWrapper::CNCServer::CNCStopSpindle() {
	CNC_RC rc = CncSetSpindleOutput(0, -1, 0);
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

//custom func
RCResult APIWrapper::CNCServer::CNCMistOn() {
	CNC_RC rc = CncRunSingleLine((char*)"M7");
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}
//custom func
RCResult APIWrapper::CNCServer::CNCFloodOn() {
	CNC_RC rc = CncRunSingleLine((char*)"M8");
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}
//custom func
RCResult APIWrapper::CNCServer::CNCMistAndFloodOff() {
	CNC_RC rc = CncRunSingleLine((char*)"M9");
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}
//custom func
RCResult APIWrapper::CNCServer::CNCSetSpindleSpeed(int rpm) {
	CNC_RC rc = CncSetSpindleOutput(1, -1, rpm);
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

CNCToolData APIWrapper::CNCServer::CNCGetToolData(int toolNumber) {
	CNCToolData value;
	CNC_TOOL_DATA data = CncGetToolData(toolNumber);
	value.description = gcnew String(data.description);
	value.diameter = data.diameter;
	value.id = data.id;
	value.locationCode = data.locationCode;
	value.orientation = data.orientation;
	value.xDelta = data.xDelta;
	value.xOffset = data.xOffset;
	value.zDelta = data.zDelta;
	value.zOffset = data.zOffset;
	return value;
}

RCResult APIWrapper::CNCServer::CNCUpdateToolData(CNCToolData tool, int toolNumber)
{ 
	CNC_TOOL_DATA tooldata;
	IntPtr disc = Marshal::StringToHGlobalAnsi(tool.description);
	strncpy_s(tooldata.description, static_cast<char*>(disc.ToPointer()),sizeof(tooldata.description));
	tooldata.diameter = tool.diameter;
	tooldata.id = tool.id;
	tooldata.locationCode = tool.locationCode;
	tooldata.orientation = tool.orientation;
	tooldata.xDelta = tool.xDelta;
	tooldata.xOffset = tool.xOffset;
	tooldata.zDelta = tool.zDelta;
	tooldata.zOffset = tool.zOffset;

	CNC_RC rc = CncUpdateToolData(&tooldata,toolNumber);
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

RCResult APIWrapper::CNCServer::CNCLoadToolTable()
{
	CNC_RC rc = CncLoadToolTable();
	RCResult returnvalue = static_cast<RCResult>(rc);
	return returnvalue;
}

double APIWrapper::CNCServer::CNCGetVariable(int varIndex) 
{
	return CncGetVariable(varIndex);
}

int APIWrapper::CNCServer::CNCIsServerConnected() 
{
	return CncIsServerConnected();
}

int APIWrapper::CNCServer::CNCGetOutput(CNCIOID id)
{
	return CncGetOutput(static_cast<CNC_IO_ID>(id));
}

CNCSpindleStatus APIWrapper::CNCServer::CNCGetSpindleStatus()
{
	CNC_SPINDLE_STS status = *CncGetSpindleStatus();
	CNCSpindleStatus returnStatus;
	returnStatus.actualSpindleConfigurationIndex = status.actualSpindleConfigurationIndex;
	returnStatus.actualSpindleSpeedSigned = status.actualSpindleSpeedSigned;
	returnStatus.feedSpeedSyncAvailable = status.feedSpeedSyncAvailable;
	returnStatus.isRampingUp = status.isRampingUp;
	returnStatus.programmedSpindleSpeed = status.programmedSpindleSpeed;
	returnStatus.speedOverrideFactor = status.speedOverrideFactor;
	returnStatus.spindleDirection = status.spindleDirection;
	returnStatus.spindleIsOn = status.spindleIsOn;
	returnStatus.spindlePWMPrecentage = status.spindlePWMPrecentage;
	returnStatus.spindleReady = status.spindleReady;
	returnStatus.syncCount = status.syncCount;

	returnStatus.spindleCfg.countPerRev = status.spindleCfg.countPerRev;
	returnStatus.spindleCfg.directionOutputPortID = static_cast<CNCIOID>(status.spindleCfg.directionOutputPortID);
	returnStatus.spindleCfg.maxAvgSpeedFilterTimeMillisecs = status.spindleCfg.maxAvgSpeedFilterTimeMillisecs;
	returnStatus.spindleCfg.NmaxRPM = status.spindleCfg.NmaxRPM;
	returnStatus.spindleCfg.NminRPM = status.spindleCfg.NminRPM;	
	returnStatus.spindleCfg.onOffOutputPortID = static_cast<CNCIOID>(status.spindleCfg.onOffOutputPortID);
	returnStatus.spindleCfg.pwmCompensationFileName = gcnew String(status.spindleCfg.pwmCompensationFileName);
	returnStatus.spindleCfg.pwmCompensationOn = status.spindleCfg.pwmCompensationOn;
	returnStatus.spindleCfg.pwmOutputPortID = static_cast<CNCIOID>(status.spindleCfg.pwmOutputPortID);
	returnStatus.spindleCfg.rampUpTime = status.spindleCfg.rampUpTime;
	returnStatus.spindleCfg.rightOnLeftOnMNode = status.spindleCfg.rightOnLeftOnMNode;
	returnStatus.spindleCfg.sensorSpeedControlCycleTime = status.spindleCfg.sensorSpeedControlCycleTime;
	returnStatus.spindleCfg.sensorSpeedControlOn = status.spindleCfg.sensorSpeedControlOn;
	returnStatus.spindleCfg.smoothCountMode = status.spindleCfg.smoothCountMode;
	returnStatus.spindleCfg.spindleIndex = status.spindleCfg.spindleIndex;
	returnStatus.spindleCfg.spindleReadyPortID = static_cast<CNCIOID>(status.spindleCfg.spindleReadyPortID);
	returnStatus.spindleCfg.spindleReadyPortMode = status.spindleCfg.spindleReadyPortMode;
	returnStatus.spindleCfg.stepperMotorMode = status.spindleCfg.stepperMotorMode;
	returnStatus.spindleCfg.useRPMSensor = status.spindleCfg.useRPMSensor;

	return returnStatus;
}

RCResult APIWrapper::CNCServer::CNCSetSpindleOutput(int onOff,int direction,double absSpeed)
{
	return static_cast<RCResult>(CncSetSpindleOutput(onOff,direction,absSpeed));
}

int APIWrapper::CNCServer::CNCGetMotionEnabled()
{
	return CncGetControllerStatus()->motionEnabled;
}

int APIWrapper::CNCServer::CNCCheckStartConditionOK(int ignoreHoming)
{
	int result;
	CncCheckStartConditionOK(0, ignoreHoming, &result);
	return result;
}

int APIWrapper::CNCServer::CNCGetSafetyMode()
{
	return CncGetSafetyMode();
}


CNCJointConfig APIWrapper::CNCServer::CNCGetJointConfig(CNCAxis axis)
{
	CNCJointConfig result;
	CNC_JOINT_CFG* config = CncGetJointConfig((int)axis);

	result.backLash = config->backLash;
	result.cpuPortIndex = config->cpuPortIndex;
	result.highSpeedJogPercent = config->highSpeedJogPercent;
	result.homePosition = config->homePosition;
	result.homeVelocity = config->homeVelocity;
	result.homeVelocitySlow = config->homeVelocitySlow;
	result.isVisible = config->isVisible;
	result.medSpeedJogPercent = config->medSpeedJogPercent;
	result.lowSpeedJogPercent = config->lowSpeedJogPercent;
	result.maxAcceleration = config->maxAcceleration;
	result.maxVelocity = config->maxVelocity;
	result.name = (config->name).ToString();
	result.negativeLimit = config->negativeLimit;
	result.positiveLimit = config->positiveLimit;
	result.resolution = config->resolution;

	return result;
}


void APIWrapper::CNCServer::CNCSetJointConfig(CNCJointConfig jointConfig,CNCAxis axis)
{
	CNC_JOINT_CFG* config = CncGetJointConfig((int)axis);

	config->backLash = jointConfig.backLash;
	config->cpuPortIndex = jointConfig.cpuPortIndex;
	config->highSpeedJogPercent = jointConfig.highSpeedJogPercent;
	config->homePosition = jointConfig.homePosition;
	config->homeVelocity = jointConfig.homeVelocity;
	config->homeVelocitySlow = jointConfig.homeVelocitySlow;
	config->isVisible = jointConfig.isVisible;
	config->medSpeedJogPercent = jointConfig.medSpeedJogPercent;
	config->lowSpeedJogPercent = jointConfig.lowSpeedJogPercent;
	config->maxAcceleration = jointConfig.maxAcceleration;
	config->maxVelocity = jointConfig.maxVelocity;
	IntPtr pName = Marshal::StringToHGlobalAnsi(jointConfig.name);//marshalling
	config->name = (static_cast<char*>(pName.ToPointer()))[0];
	config->negativeLimit = jointConfig.negativeLimit;
	config->positiveLimit = jointConfig.positiveLimit;
	config->resolution = jointConfig.resolution;
}

void APIWrapper::CNCServer::CNCStoreIniFile()
{
	CncStoreIniFile(1);
}

void APIWrapper::CNCServer::CNCReInitialize()
{
	CncReInitialize();
}

CNCLogMessage APIWrapper::CNCServer::CNCGetLogFifo()
{
	CNC_LOG_MESSAGE data;
	CNCLogMessage result;

	result.getMessageFifoRC = static_cast<RCResult>(CncLogFifoGet(&data));
	result.code = static_cast<RCResult>(data.code);
	result.functionName = gcnew String(data.functionName);
	result.hint = data.hint;
	result.n = data.n;
	result.par1Name = gcnew String(data.par1Name);
	result.par2Name = gcnew String(data.par2Name);
	result.par3Name = gcnew String(data.par3Name);
	result.par4Name = gcnew String(data.par4Name);
	result.par5Name = gcnew String(data.par5Name);
	result.par6Name = gcnew String(data.par6Name);
	result.par7Name = gcnew String(data.par7Name);
	result.par8Name = gcnew String(data.par8Name);
	result.par9Name = gcnew String(data.par9Name);
	result.par10Name = gcnew String(data.par10Name);
	result.par11Name = gcnew String(data.par11Name);
	result.par12Name = gcnew String(data.par12Name);
	result.par13Name = gcnew String(data.par13Name);
	result.par14Name = gcnew String(data.par14Name);
	result.par15Name = gcnew String(data.par15Name);
	result.par1Number = data.par1Number;
	result.par2Number = data.par2Number;
	result.par3Number = data.par3Number;
	result.par4Number = data.par4Number;
	result.par5Number = data.par5Number;
	result.par6Number = data.par6Number;
	result.par7Number = data.par7Number;
	result.par8Number = data.par8Number;
	result.par9Number = data.par9Number;
	result.par10Number = data.par10Number;
	result.par11Number = data.par11Number;
	result.par12Number = data.par12Number;
	result.par13Number = data.par13Number;
	result.par14Number = data.par14Number;
	result.par15Number = data.par15Number;
	result.sourceInfo = gcnew String(data.sourceInfo);
	result.subCode = data.subCode;
	result.text = gcnew String(data.text);

	return result;
}

CNCSafetyConfig APIWrapper::CNCServer::CNCGetSafetyConfig()
{
	CNCSafetyConfig result;
	CNC_SAFETY_CONFIG* config = CncGetSafetyConfig();
	result.allowJoggingBeforeHoming = config->allowJoggingBeforeHoming;
	result.approachFeed = config->approachFeed;
	result.atEStopLeaveGPIOAsIs = config->atEStopLeaveGPIOAsIs;
	result.autoStartAfterPause = config->autoStartAfterPause;
	result.aux10_OffOnPause = config->aux10_OffOnPause;
	result.aux1_OffOnPause = config->aux1_OffOnPause;
	result.aux2_OffOnPause = config->aux2_OffOnPause;
	result.aux3_OffOnPause = config->aux3_OffOnPause;
	result.aux4_OffOnPause = config->aux4_OffOnPause;
	result.aux5_OffOnPause = config->aux5_OffOnPause;
	result.aux6_OffOnPause = config->aux6_OffOnPause;
	result.aux7_OffOnPause = config->aux7_OffOnPause;
	result.aux8_OffOnPause = config->aux8_OffOnPause;
	result.aux9_OffOnPause = config->aux9_OffOnPause;
	result.driveErrorInputSenseLevel = config->driveErrorInputSenseLevel;
	result.driveWarningInputSenseLevel = config->driveWarningInputSenseLevel;
	result.enableGPIOActions = config->enableGPIOActions;
	result.endOfStrokeInputSenseLevel = config->endOfStrokeInputSenseLevel;
	result.EStopInputSenseLevel1 = config->EStopInputSenseLevel2;
	result.EStopInputSenseLevel2 = config->EStopInputSenseLevel2;
	result.extErrorInputSenseLevel = config->extErrorInputSenseLevel;
	result.flood_OffOnPause = config->flood_OffOnPause;
	result.homeIsEstopAfterHomingAllAxes = config->homeIsEstopAfterHomingAllAxes;
	result.isoInputSenseLevel = config->isoInputSenseLevel;
	result.isoOutputSenseLevel = config->isoOutputSenseLevel;
	result.mandatoryHoming = config->mandatoryHoming;
	result.maxMasterSlaveDistance = config->maxMasterSlaveDistance;
	result.mist_OffOnPause = config->mist_OffOnPause;
	result.noStartJogIfPauseActive = config->noStartJogIfPauseActive;
	result.noStartMDIIfPauseActive = config->noStartMDIIfPauseActive;
	result.safetyFeed = config->safetyFeed;
	result.safetyFeedOverridePercent = config->safetyFeedOverridePercent;
	result.safetyRelayPresent = config->safetyRelayPresent;
	result.safetyRelayPulseLengthMs = config->safetyRelayPulseLengthMs;
	result.safetyRelayResetOutPortID = static_cast<CNCIOID>(config->safetyRelayResetOutPortID);
	result.safetySpeedPercent = config->safetySpeedPercent;
	result.stopSpindleOnPause = config->stopSpindleOnPause;
	result.systemReadyOutPortID = static_cast<CNCIOID>(config->systemReadyOutPortID);
	result.useXHomeinputForAllAxes = config->useXHomeinputForAllAxes;
	result.zUpMoveDistanceOnPause = config->zUpMoveDistanceOnPause;
	result.zUpOnPause = config->zUpOnPause;

	return result;
}

void  APIWrapper::CNCServer::CNCSetSafetyConfig(CNCSafetyConfig safetyConfig)
{
	CNC_SAFETY_CONFIG* config = CncGetSafetyConfig();
	config->allowJoggingBeforeHoming = safetyConfig.allowJoggingBeforeHoming;
	config->approachFeed = safetyConfig.approachFeed;
	config->atEStopLeaveGPIOAsIs = safetyConfig.atEStopLeaveGPIOAsIs;
	config->autoStartAfterPause = safetyConfig.autoStartAfterPause;
	config->aux10_OffOnPause = safetyConfig.aux10_OffOnPause;
	config->aux1_OffOnPause = safetyConfig.aux1_OffOnPause;
	config->aux2_OffOnPause = safetyConfig.aux2_OffOnPause;
	config->aux3_OffOnPause = safetyConfig.aux3_OffOnPause;
	config->aux4_OffOnPause = safetyConfig.aux4_OffOnPause;
	config->aux5_OffOnPause = safetyConfig.aux5_OffOnPause;
	config->aux6_OffOnPause = safetyConfig.aux6_OffOnPause;
	config->aux7_OffOnPause = safetyConfig.aux7_OffOnPause;
	config->aux8_OffOnPause = safetyConfig.aux8_OffOnPause;
	config->aux9_OffOnPause = safetyConfig.aux9_OffOnPause;
	config->driveErrorInputSenseLevel = safetyConfig.driveErrorInputSenseLevel;
	config->driveWarningInputSenseLevel = safetyConfig.driveWarningInputSenseLevel;
	config->enableGPIOActions = safetyConfig.enableGPIOActions;
	config->endOfStrokeInputSenseLevel = safetyConfig.endOfStrokeInputSenseLevel;
	config->EStopInputSenseLevel1 = safetyConfig.EStopInputSenseLevel2;
	config->EStopInputSenseLevel2 = safetyConfig.EStopInputSenseLevel2;
	config->extErrorInputSenseLevel = safetyConfig.extErrorInputSenseLevel;
	config->flood_OffOnPause = safetyConfig.flood_OffOnPause;
	config->homeIsEstopAfterHomingAllAxes = safetyConfig.homeIsEstopAfterHomingAllAxes;
	config->isoInputSenseLevel = safetyConfig.isoInputSenseLevel;
	config->isoOutputSenseLevel = safetyConfig.isoOutputSenseLevel;
	config->mandatoryHoming = safetyConfig.mandatoryHoming;
	config->maxMasterSlaveDistance = safetyConfig.maxMasterSlaveDistance;
	config->mist_OffOnPause = safetyConfig.mist_OffOnPause;
	config->noStartJogIfPauseActive = safetyConfig.noStartJogIfPauseActive;
	config->noStartMDIIfPauseActive = safetyConfig.noStartMDIIfPauseActive;
	config->safetyFeed = safetyConfig.safetyFeed;
	config->safetyFeedOverridePercent = safetyConfig.safetyFeedOverridePercent;
	config->safetyRelayPresent = safetyConfig.safetyRelayPresent;
	config->safetyRelayPulseLengthMs = safetyConfig.safetyRelayPulseLengthMs;
	config->safetyRelayResetOutPortID = static_cast<CNC_IO_ID>(safetyConfig.safetyRelayResetOutPortID);
	config->safetySpeedPercent = safetyConfig.safetySpeedPercent;
	config->stopSpindleOnPause = safetyConfig.stopSpindleOnPause;
	config->systemReadyOutPortID = static_cast<CNC_IO_ID>(safetyConfig.systemReadyOutPortID);
	config->useXHomeinputForAllAxes = safetyConfig.useXHomeinputForAllAxes;
	config->zUpMoveDistanceOnPause = safetyConfig.zUpMoveDistanceOnPause;
	config->zUpOnPause = safetyConfig.zUpOnPause; 
}

CNCPositions  APIWrapper::CNCServer::CNCGetPausePosition()
{
	CNC_PAUSE_STS* status = CncGetPauseStatus();
	CNCPositions result;
	result.x = status->pausePosition.x;
	result.y = status->pausePosition.y;
	result.z = status->pausePosition.z;
	result.a = status->pausePosition.a;
	result.b = status->pausePosition.b;
	result.c = status->pausePosition.c;

	return result;
}

array<CNCGraphData>^  APIWrapper::CNCServer::CNCGraphFifoGetArray(int count)
{
	CNC_GRAPH_FIFO_DATA data;
	CNCGraphData gdata;//marshalling
	CncGraphFifoGet(&data);//call native api
	List<CNCGraphData>^ gdataList = gcnew List<CNCGraphData>();
	for(int i =0;i<count;i++)
	{
		gdata.lineNumber = data.lineNumber;
		gdata.pos.a = data.pos.a;
		gdata.pos.b = data.pos.b;
		gdata.pos.c = data.pos.c;
		gdata.pos.x = data.pos.x;
		gdata.pos.y = data.pos.y;
		gdata.pos.z = data.pos.z;
		gdata.type = static_cast<CNCMoveType>(data.type);
		gdata.msgNumber = data.msgNumber;
		gdataList->Add(gdata);
		if (data.type == CNC_MOVE_TYPE_END)
			break;
		CncGraphFifoGet(&data);
	}

	return gdataList->ToArray();
}

RCResult  APIWrapper::CNCServer::CNCMoveTo(CNCPositions pos, CNCAxisBools axis, double velocityVector)
{
	CNC_CART_DOUBLE CNCpos;
	CNC_CART_BOOL bools;
	CNCpos.x = pos.x;
	CNCpos.y = pos.y;
	CNCpos.z = pos.z;
	CNCpos.a = pos.a;
	CNCpos.b = pos.b;
	CNCpos.c = pos.c;
	bools.x = axis.x;
	bools.y = axis.y;
	bools.z = axis.z;
	bools.a = axis.a;
	bools.b = axis.b;
	bools.c = axis.c;
	CNC_RC rc = CncMoveTo(CNCpos, bools, velocityVector);

	return static_cast<RCResult>(rc);
}
void  APIWrapper::CNCServer::CNCResetPausePosition()
{
	CNC_PAUSE_STS* status = CncGetPauseStatus();
	status->pausePosition.x = 0;
	status->pausePosition.y = 0;
	status->pausePosition.z = 0;
	status->pausePosition.a = 0;
	status->pausePosition.b = 0;
	status->pausePosition.c = 0;
}

CNCPauseStatus  APIWrapper::CNCServer::CNCGetPauseSatus()
{
	CNC_PAUSE_STS* status = CncGetPauseStatus();
	CNCPauseStatus result;
	result.allAxesInSync = status->allAxesInSync;
	result.curPosInSync.x = status->curPosInSync.x;
	result.curPosInSync.y = status->curPosInSync.y;
	result.curPosInSync.z = status->curPosInSync.z;
	result.curPosInSync.a = status->curPosInSync.a;
	result.curPosInSync.b = status->curPosInSync.b;
	result.curPosInSync.c = status->curPosInSync.c;
	result.floodInSync = status->floodInSync;
	result.mistInSync = status->mistInSync;
	result.pauseArrayIndexX = status->pauseArrayIndexX;
	result.pauseArrayIndexY = status->pauseArrayIndexY;
	result.pauseAux1IOValue = status->pauseAux1IOValue;
	result.pauseAux2IOValue = status->pauseAux2IOValue;
	result.pauseAux3IOValue = status->pauseAux3IOValue;
	result.pauseAux4IOValue = status->pauseAux4IOValue;
	result.pauseAux5IOValue = status->pauseAux5IOValue;
	result.pauseAux6IOValue = status->pauseAux6IOValue;
	result.pauseAux7IOValue = status->pauseAux7IOValue;
	result.pauseAux8IOValue = status->pauseAux8IOValue;
	result.pauseAux9IOValue = status->pauseAux9IOValue;
	result.pauseDoArray = status->pauseDoArray;
	result.pauseFloodIOValue = status->pauseFloodIOValue;
	result.pauseManualActionRequired = status->pauseManualActionRequired;
	result.pauseMistIOValue = status->pauseMistIOValue;
	result.pausePosition.x = status->pausePosition.x;
	result.pausePosition.y = status->pausePosition.y;
	result.pausePosition.z = status->pausePosition.z;
	result.pausePosition.a = status->pausePosition.a;
	result.pausePosition.b = status->pausePosition.b;
	result.pausePosition.c = status->pausePosition.c;
	result.pausePositionLine = status->pausePositionLine;
	result.pausePositionValid = status->pausePositionValid;
	result.pauseSpindleIOValue = status->pauseSpindleIOValue;
	result.spindleInSync = status->spindleInSync;

	return result;
}

int APIWrapper::CNCServer::CNCGetSingleStepMode()
{
	return CncGetSingleStepMode();
}

int APIWrapper::CNCServer::CNCGetEMStopActive()
{
	return CncGetEMStopActive();
}

RCResult APIWrapper::CNCServer::CNCAbortJob()
{
	CNC_RC rc = CncAbortJob();

	return static_cast<RCResult>(rc);
}
void APIWrapper::CNCServer::CNCResetPauseStatus()
{
	CNC_PAUSE_STS* status = CncGetPauseStatus();
	status->pausePosition.x = 0;
	status->pausePosition.y = 0;
	status->pausePosition.z = 0;
	status->pausePosition.a = 0;
	status->pausePosition.b = 0;
	status->pausePosition.c = 0;
	status->pauseSpindleIOValue = 0;
	status->pauseFloodIOValue = 0;
	status->pauseMistIOValue = 0;
	status->pauseAux1IOValue = 0;
	status->pauseAux2IOValue = 0;
	status->pauseAux3IOValue = 0;
	status->pauseAux4IOValue = 0;
	status->pauseAux5IOValue = 0;
	status->pauseAux6IOValue = 0;
	status->pauseAux7IOValue = 0;
	status->pauseAux8IOValue = 0;
	status->pauseAux9IOValue = 0;
}

CNCPositions APIWrapper::CNCServer::CNCGetMachineZeroWorkPoint()
{
	CNC_CART_DOUBLE pos;
	int rot;
	CncGetMachineZeroWorkPoint(&pos,&rot);//call native api getworkpos
	Types::CNCPositions returnvalue;//marshalling
	returnvalue.a = pos.a;
	returnvalue.b = pos.b;
	returnvalue.c = pos.c;
	returnvalue.x = pos.x;
	returnvalue.y = pos.y;
	returnvalue.z = pos.z;
	return returnvalue;
}

