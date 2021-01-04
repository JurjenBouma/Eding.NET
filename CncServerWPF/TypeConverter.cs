using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdingDotNET.Types;

namespace EdingDotNET
{
    public static class TypeConverter
    {
       /* public static CNCPositions ConvertPosTypes(EdingDotNET.APIWrapper.CNCPositions pos)
        {
            CNCPositions result;
            result.x = pos.x;
            result.y = pos.y;
            result.z = pos.z;
            result.a = pos.a;
            result.b = pos.b;
            result.c = pos.c;
            return result;
        }

        public static CNCJobStatus ConvertJobStatusTypes(EdingDotNET.APIWrapper.CNCJobStatus wrapperStatus)
        {
            CNCJobStatus returnStatus = new CNCJobStatus();
            EdingDotNET.APIWrapper.CNCJobStatus cncJobStatus = wrapperStatus;

            returnStatus.curExLine = cncJobStatus.curExLine;
            returnStatus.curIpLine = cncJobStatus.curIpLine;
            returnStatus.curIpLineText = cncJobStatus.curIpLineText;
            returnStatus.doRepeatJob = cncJobStatus.doRepeatJob;
            returnStatus.extraLineWhenEndOfJob = cncJobStatus.extraLineWhenEndOfJob;
            returnStatus.isLongJob = cncJobStatus.isLongJob;
            returnStatus.isSuperLongJob = cncJobStatus.isSuperLongJob;
            returnStatus.jobActualRunningTime = cncJobStatus.jobActualRunningTime;
            returnStatus.jobEstimatedTime = cncJobStatus.jobEstimatedTime;
            returnStatus.jobIsRendered = cncJobStatus.jobIsRendered;
            returnStatus.jobLoadCounter = cncJobStatus.jobLoadCounter;
            returnStatus.jobName = cncJobStatus.jobName;
            returnStatus.jobProgress = cncJobStatus.jobProgress;
            returnStatus.jobRemainingRunningTime = cncJobStatus.jobRemainingRunningTime;
            returnStatus.jobRenderLine = cncJobStatus.jobRenderLine;
            returnStatus.jobRenderProgressPercentage = cncJobStatus.jobRenderProgressPercentage;
            returnStatus.lastKnownExcutedLineNumber = cncJobStatus.lastKnownExcutedLineNumber;
            returnStatus.lastKnownToolChangeLineNumber = cncJobStatus.lastKnownToolChangeLineNumber;
            returnStatus.MCACollision = cncJobStatus.MCACollision;
            returnStatus.nrOfJobRepeatsSet = cncJobStatus.nrOfJobRepeatsSet;
            returnStatus.nrOfRepeatsActual = cncJobStatus.nrOfRepeatsActual;
            returnStatus.numBytesInJob = cncJobStatus.numBytesInJob;
            returnStatus.numLinesInjob = cncJobStatus.numLinesInjob;
            returnStatus.numLinesInMacro = cncJobStatus.numLinesInMacro;
            returnStatus.numLinesInUserMacro = cncJobStatus.numLinesInUserMacro;
            returnStatus.TCACollision = cncJobStatus.TCACollision;
            returnStatus.totalJobLength = cncJobStatus.totalJobLength;
            returnStatus.xCollision = cncJobStatus.xCollision;
            returnStatus.yCollision = cncJobStatus.yCollision;
            returnStatus.zCollision = cncJobStatus.zCollision;

            return returnStatus;
        }

        public static CNCTrafficLightStatus ConvertLightStatus(EdingDotNET.APIWrapper.CNCTrafficLightStatus status)
        {
            CNCTrafficLightStatus returnstatus = new CNCTrafficLightStatus();
            returnstatus.trafficLightColor = (CNCTrafficLightColor)status.trafficLightColor;
            returnstatus.trafficLightBlink = status.trafficLightBlink;
            returnstatus.traficLightReason = status.traficLightReason;
            return returnstatus;
        }

        public static CNCGraphData ConvertGraphTypes(EdingDotNET.APIWrapper.CNCGraphData data)
        {
            CNCGraphData returnData;
            returnData.lineNumber = data.lineNumber;
            returnData.msgNumber = data.msgNumber;
            returnData.pos = TypeConverter.ConvertPosTypes(data.pos);
            returnData.type = (CNCMoveType)data.type;
            return returnData;
        }

        public static CNCToolData ConvertToolDataTypes(EdingDotNET.APIWrapper.CNCToolData data)
        {
            CNCToolData returnData;
            returnData.description = data.description;
            returnData.diameter = data.diameter;
            returnData.id = data.id;
            returnData.locationCode = data.locationCode;
            returnData.orientation = data.orientation;
            returnData.xDelta = data.xDelta;
            returnData.xOffset = data.xOffset;
            returnData.zDelta = data.zDelta;
            returnData.zOffset = data.zOffset;
            return returnData;
        }

        public static EdingDotNET.APIWrapper.CNCToolData ConvertToolDataTypes(CNCToolData data)
        {
            EdingDotNET.APIWrapper.CNCToolData returnData = new APIWrapper.CNCToolData();
            returnData.description = data.description;
            returnData.diameter = data.diameter;
            returnData.id = data.id;
            returnData.locationCode = data.locationCode;
            returnData.orientation = data.orientation;
            returnData.xDelta = data.xDelta;
            returnData.xOffset = data.xOffset;
            returnData.zDelta = data.zDelta;
            returnData.zOffset = data.zOffset;
            return returnData;
        }*/
    }

}
