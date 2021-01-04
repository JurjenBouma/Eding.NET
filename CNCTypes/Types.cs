using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdingDotNET.Types
{
    public enum RCResult
    {
        CNC_RC_ERR_NOT_CONNECTED = -17,
        CNC_RC_ERR_VERSION_MISMATCH = -16,
        CNC_RC_ERR_SERVER_NOT_RUNNING = -15,
        CNC_RC_ERR_COLLISION = -14,
        CNC_RC_ERR_FILEOPEN = -13,
        CNC_RC_EXE_CE = -12,
        CNC_RC_ERR_TIMEOUT = -11,
        CNC_RC_ERR_SYS = -10,
        CNC_RC_ERR_MOT = -9,
        CNC_RC_ERR_CPU = -8,
        CNC_RC_ERR_EXE = -7,
        CNC_RC_ERR_CE = -6,
        CNC_RC_ERR_INT = -5,
        CNC_RC_ERR_CONFIG = -4,
        CNC_RC_ERR_STATE = -3,
        CNC_RC_ERR_PAR = -2,
        CNC_RC_ERR = -1,
        CNC_RC_OK = 0,
        CNC_RC_BUF_EMPTY = 1,
        CNC_RC_TRACE = 2,
        CNC_RC_USER_INFO = 3,
        CNC_RC_SHUTDOWN = 4,
        CNC_RC_EXISTING = 5,
        CNC_RC_ALREADY_RUNS = 6,
        CNC_RC_ALREADY_CONNECTED = 7
    }

    public enum CNCAxis
    {
        X_AXIS = 0,
        Y_AXIS = 1,
        Z_AXIS = 2,
        A_AXIS = 3,
        B_AXIS = 4,
        C_AXIS = 5,
        ALL_AXES = 6
    }

    public enum CNCIOID
    {
        CNC_IOID_NONE = 0,
        CNC_IOID_MACHINE_ON_OUT = 1,
        CNC_IOID_DRIVE_ENABLE_OUT = 2,
        CNC_IOID_TOOL_OUT = 3,
        CNC_IOID_COOLANT1_OUT = 4,
        CNC_IOID_COOLANT2_OUT = 5,
        CNC_IOID_TOOLDIR_OUT = 6,
        CNC_IOID_AUX1_OUT = 7,
        CNC_IOID_AUX2_OUT = 8,
        CNC_IOID_AUX3_OUT = 9,
        CNC_IOID_AUX4_OUT = 10,
        CNC_IOID_AUX5_OUT = 11,
        CNC_IOID_AUX6_OUT = 12,
        CNC_IOID_AUX7_OUT = 13,
        CNC_IOID_AUX8_OUT = 14,
        CNC_IOID_AUX9_OUT = 15,
        CNC_IOID_PWM_VAL1_OUT = 16,
        CNC_IOID_PWM_VAL2_OUT = 17,
        CNC_IOID_PWM_VAL3_OUT = 18,
        CNC_IOID_EMSTOP1_IN = 19,
        CNC_IOID_EMSTOP2_IN = 20,
        CNC_IOID_EXTERR_IN = 21,
        CNC_IOID_PROBE_IN = 22,
        CNC_IOID_SYNC_IN = 23,
        CNC_IOID_RUN_IN = 24,
        CNC_IOID_PAUSE_IN = 25,
        CNC_IOID_HOME_X_IN = 26,
        CNC_IOID_HOME_Y_IN = 27,
        CNC_IOID_HOME_Z_IN = 28,
        CNC_IOID_HOME_A_IN = 29,
        CNC_IOID_HOME_B_IN = 30,
        CNC_IOID_HOME_C_IN = 31,
        CNC_IOID_HOME_1_IN = 32,
        CNC_IOID_HOME_2_IN = 33,
        CNC_IOID_HOME_3_IN = 34,
        CNC_IOID_HOME_4_IN = 35,
        CNC_IOID_HOME_5_IN = 36,
        CNC_IOID_HOME_6_IN = 37,
        CNC_IOID_HW1A_IN = 38,
        CNC_IOID_HW1B_IN = 39,
        CNC_IOID_EMSTOP_FROM_GPIO = 40,
        CNC_IOID_SSTOP_FROM_GPIO = 41,
        CNC_IOID_WARNING_FROM_GPIO = 42,
        CNC_IOID_AUX1_IN = 43,
        CNC_IOID_AUX2_IN = 44,
        CNC_IOID_AUX3_IN = 45,
        CNC_IOID_AUX4_IN = 46,
        CNC_IOID_AUX5_IN = 47,
        CNC_IOID_AUX6_IN = 48,
        CNC_IOID_AUX7_IN = 49,
        CNC_IOID_AUX8_IN = 50,
        CNC_IOID_ANA1_IN = 51,
        CNC_IOID_ANA2_IN = 52,
        CNC_IOID_ANA3_IN = 53,
        CNC_IOID_ANA4_IN = 54,
        CNC_IOID_ANA5_IN = 55,
        CNC_IOID_DRIVEALM_IN = 56,
        CNC_IOID_DRIVEWARN_IN = 57,
        CNC_IOID_OUTPUTPROBLEM_IN = 58,
        CNC_IOID_INPUTPROBLEM_IN = 59,
        CNC_IOID_LAST = 60
    }

    public enum CNCTrafficLightColor
    {
        CNC_TRAFFIC_LIGHT_COLOR_OFF = 0,
        CNC_TRAFFIC_LIGHT_COLOR_GREEN = 1,
        CNC_TRAFFIC_LIGHT_COLOR_YELLOW = 2,
        CNC_TRAFFIC_LIGHT_COLOR_RED = 3
    }

    public enum CNCState
    {
        CNC_IE_POWERUP_STATE = 0, /* no interpreter threads running yet */
        CNC_IE_IDLE_STATE,               /* thread is started but IE not initialized */
        CNC_IE_READY_STATE,              /* ready to load/run */
        CNC_IE_EXEC_ERROR_STATE,         /* Execution error */
        CNC_IE_INT_ERROR_STATE,          /* interpreter error */
        CNC_IE_ABORTED_STATE,            /* job was aborted */

        /* Running states from which Pause is possible */
        CNC_IE_RUNNING_JOB_STATE,        /* Job running */
        CNC_IE_RUNNING_LINE_STATE,       /* single line running */
        CNC_IE_RUNNING_SUB_STATE,        /* single subroutine running */
        CNC_IE_RUNNING_SUB_SEARCH_STATE, /* single subroutine running from search */
        CNC_IE_RUNNING_LINE_SEARCH_STATE,/* single line running from search*/

        /* the belonging paused states */
        CNC_IE_PAUSED_LINE_STATE,        /* single line paused, by pause command */
        CNC_IE_PAUSED_JOB_STATE,         /* paused running job, by pause command */
        CNC_IE_PAUSED_SUB_STATE,         /* paused running sub , by pause command */
        CNC_IE_PAUSED_LINE_SEARCH_STATE, /* paused running line search line running from search*/
        CNC_IE_PAUSED_SUB_SEARCH_STATE,  /* paused running sub search subroutine running from search */

        /* special Running states, no pause possible */
        CNC_IE_RUNNING_HANDWHEEL_STATE,  /* hand wheel operation */
        CNC_IE_RUNNING_LINE_HANDWHEEL_STATE, /* single line running from hand wheel mode, can only be G92... */
        CNC_IE_RUNNING_LINE_PAUSED_STATE,/* single line running from hand wheel mode, can only be G92... */
        CNC_IE_RUNNING_AXISJOG_STATE,    /* running joint jog */
        CNC_IE_RUNNING_IPJOG_STATE,      /* running joint jog */

        /* Rendering and searching states */
        CNC_IE_RENDERING_GRAPH_STATE,    /* running interpreter for graph view only */
        CNC_IE_SEARCHING_STATE,          /* searching line */
        CNC_IE_SEARCHED_DONE_STATE,      /* searched line found */

        CNC_IE_LAST_STATE                /* keep last */
    }

    public enum CNCMoveType
    {
        CNC_MOVE_TYPE_UNKNOWN = 0,
        CNC_MOVE_TYPE_G0 = 1,
        CNC_MOVE_TYPE_G1 = 2,
        CNC_MOVE_TYPE_ARC = 3,
        CNC_MOVE_TYPE_PROBE = 4,
        CNC_MOVE_TYPE_JOG = 5,
        CNC_MOVE_TYPE_HOME = 6,
        CNC_MOVE_TYPE_ORIGIN_OFFSET = 7,
        CNC_MOVE_TYPE_START_POSITION = 8,
        CNC_MOVE_TYPE_SET_GRAPH_START_POINT = 9,
        CNC_MOVE_TYPE_OUT_LINE = 10,
        CNC_MOVE_TYPE_END = 11,
        CNC_MOVE_TYPE_END_COLLISION = 12
    }


    [Serializable]
    public struct CNCPositions
    {
        public double x;
        public double y;
        public double z;
        public double a;
        public double b;
        public double c;
    }

    [Serializable]
    public struct CNCGraphData
    {
        public int lineNumber;
        public CNCPositions pos;
        public CNCMoveType type;
        public int msgNumber;
    }

    [Serializable]
    public struct CNCJobStatus
    {
        public string jobName;
        public int nrOfRepeatsActual;
        public int nrOfJobRepeatsSet;
        public int doRepeatJob;
        public int lastKnownToolChangeLineNumber;
        public int lastKnownExcutedLineNumber;
        public int curExLine;
        public string curIpLineText;
        public int curIpLine;
        public double jobRenderProgressPercentage;
        public int jobRenderLine;
        public int zCollision;
        public int yCollision;
        public int xCollision;
        public string extraLineWhenEndOfJob;
        public int MCACollision;
        public double jobEstimatedTime;
        public double jobRemainingRunningTime;
        public double jobActualRunningTime;
        public double jobProgress;
        public double totalJobLength;
        public int jobIsRendered;
        public int isSuperLongJob;
        public int isLongJob;
        public long numBytesInJob;
        public int numLinesInUserMacro;
        public int numLinesInMacro;
        public int numLinesInjob;
        public int jobLoadCounter;
        public int TCACollision;
    }

    [Serializable]
    public struct CNCTrafficLightStatus
    {
        public CNCTrafficLightColor trafficLightColor;
        public int trafficLightBlink;//True if blink
        public string traficLightReason;
	}

    [Serializable]
    public struct CNCToolData
    {
        public int id;
        public int locationCode;
        public string description;
        public double diameter;    //Variable index 5400 .. 5499
        public double zOffset;    //Variable index 5500 .. 5599  (Length)
        public double xOffset;    //Variable index 5600 .. 5699  (width, for turning)
        public double zDelta;      //Variable index 5900 .. 5999
        public double xDelta;      //Variable index 5800 .. 5899
        public int orientation;
    }

    [Serializable]
    public struct CNCSpindleStatus
    {
        /* sync count, spindle pulse */
        public int syncCount;

        /* spindle rate, rev/sec RPS */
        public double actualSpindleSpeedSigned;

        /* programmed spindle speed RPS */
        public double programmedSpindleSpeed;

        /* Speed override Factor */
        public double speedOverrideFactor;

        /* 1 of on */
        public int spindleIsOn;

        /* 1 if ccw */
        public int spindleDirection;

        /* value 0-1000%% */
        public int spindlePWMPrecentage;

        /* set if CPU supports spindle/feed synchronization */
        public int feedSpeedSyncAvailable;

        /* index 0-2, tells actual configuration */
        public int actualSpindleConfigurationIndex;

        /* spindle is ramping up */
        public int isRampingUp;

        /* Spindle ready IO input */
        public int spindleReady;

        public CNCSpindleConfig spindleCfg;
    }

    [Serializable]
    public struct CNCSpindleConfig
    {
        public int spindleIndex;

        /* time to wait after spindle on, before moving */
        public double rampUpTime;

        /* if 1 ramp uptime is proportional with speed */
        /* int proportionalRampUpTime; */

        /* max/min spindle revolutions/sec five 100% PWM output */
        public double NmaxRPM;
        public double NminRPM;

        /* for step/pulse spindle, 0 for normal PWM spindle */
        public int countPerRev;
        public int stepperMotorMode;

        /* smooth count mode uses 32 bit counter i.s.o 16 bit, this however makes PWM2/3 no longer as separate PWM usable on cpu5b */
        public int smoothCountMode;

        /* if true, use sensor (if available) to measure spindle speed */
        public int useRPMSensor;

        /* IO's to be used for spindle */
        public CNCIOID onOffOutputPortID;
        public CNCIOID directionOutputPortID;
        public CNCIOID pwmOutputPortID;
        public CNCIOID spindleReadyPortID;

        /* 0 = spindle ready with M3 and M5, 1 = spindle ready with m3, 2 spindle not ready with m5 */
        public int spindleReadyPortMode;

        /* id this is set our direction and onoff port change into rightOnOff and leftOnOff port */
        public int rightOnLeftOnMNode;

        /* spindle PWM correction table */
        public string pwmCompensationFileName;
        public int pwmCompensationOn;

        /* max time for averaging the spindles speed, is o.a. used for thread cutting */
        public int maxAvgSpeedFilterTimeMillisecs;

        /* correction of speed measured by sensor, not used yet */
        public int sensorSpeedControlOn;
        public double sensorSpeedControlCycleTime;
    }

    [Serializable]
    public struct CNCJointConfig
    {
        /* logical name of the joint, used in GUI, one character */
        public string name;
        public int isVisible;      //True if axis visible in GUI
        public int cpuPortIndex;   //0-5 for 6 axes board, -1 if not used

        /* Axis resolution number of increments for one application unit */
        public double resolution;
        public double positiveLimit;
        public double negativeLimit;

        /* max values for velocity, acceleration, AU  */
        public double maxVelocity;
        public double maxAcceleration;

        /* homing parameters, AU  */
        public double homeVelocity;     //Sign is direction
        public double homeVelocitySlow; //Slow vel for 2nd move
        public double homePosition;     //Position at home sensor

        /* backlash parameters */
        public double backLash;

        /* jog speed percentages */
        public double lowSpeedJogPercent;
        public double medSpeedJogPercent;
        public double highSpeedJogPercent;
    }

    [Serializable]
    public struct CNCLogMessage
    {
        //RCResult from getmessage function
        public RCResult getMessageFifoRC;

        /* code where the error or what kind of message did occur, see CNC_RC */
        public RCResult code;

        /* subcode is only relevant when code specifies a subcode */
        public int subCode;

        /* textual error or dialog description */
        public string text;

        /* parameter names */
        public string par1Name;
        public string par2Name;
        public string par3Name;
        public string par4Name;
        public string par5Name;
        public string par6Name;
        public string par7Name;
        public string par8Name;
        public string par9Name;
        public string par10Name;
        public string par11Name;
        public string par12Name;
        public string par13Name;
        public string par14Name;
        public string par15Name;

        /* parameter numbers to set, 1..MAX_VARS -1 */
        public int par1Number;
        public int par2Number;
        public int par3Number;
        public int par4Number;
        public int par5Number;
        public int par6Number;
        public int par7Number;
        public int par8Number;
        public int par9Number;
        public int par10Number;
        public int par11Number;
        public int par12Number;
        public int par13Number;
        public int par14Number;
        public int par15Number;


        /* textual description of c-source and line number,
         * this extra is debug information to see where the error
         * occurred in the server.
         */
        public string sourceInfo;
        public string functionName;

        /* number */
        public int n;

        /* for internal use only */
        public int hint;

    };

    [Serializable]
    public struct CNCSafetyConfig
    {
        /* switch on e stop function on home sensors if all axes are homed */
        public int homeIsEstopAfterHomingAllAxes;

        /* emergency stop sense level */
        public int EStopInputSenseLevel1;

        /* only cpu5b */
        public int EStopInputSenseLevel2;

        /* drive warning input sense level for i600 */
        public int driveWarningInputSenseLevel;
        public int driveErrorInputSenseLevel;
        public int isoInputSenseLevel;
        public int isoOutputSenseLevel;

        /* input sense level, 0=low-e-stop, 1=hi-e-stop, 2=none, 3=low-stop, 4=hi-stop, 5=low-warning, 6=hi-warning*/
        public int extErrorInputSenseLevel;


        /* switch on/off gpio warnings/sstop/estop */
        public int enableGPIOActions;

        /* if this one is 1, no GPIO actions are taken on ESTOP */
        public int atEStopLeaveGPIOAsIs;

        /* max feed in safety mode */
        public double safetyFeed;

        /* max speed in safety mode */
        public double safetySpeedPercent;

        /* FeedOverride in safety mode */
        public double safetyFeedOverridePercent;

        /* max distance between master-slave axis after both are homed */
        public double maxMasterSlaveDistance;

        /* use end of stroke switch as emergency stop after homing */
        public int useXHomeinputForAllAxes;

        /* end of stroke sense level, used for homing */
        public int endOfStrokeInputSenseLevel;


        /* Homing mandatory or not, 1=mandatory */
        public int mandatoryHoming;
        public int allowJoggingBeforeHoming;

        public int stopSpindleOnPause;
        public int noStartSpindleIfPauseActive;
        public int noStartJogIfPauseActive;
        public int noStartMDIIfPauseActive;
        public int aux1_OffOnPause;
        public int aux2_OffOnPause;
        public int aux3_OffOnPause;
        public int aux4_OffOnPause;
        public int aux5_OffOnPause;
        public int aux6_OffOnPause;
        public int aux7_OffOnPause;
        public int aux8_OffOnPause;
        public int aux9_OffOnPause;
        public int aux10_OffOnPause;

        public int mist_OffOnPause;
        public int flood_OffOnPause;


        /* start spindle when resumed from pause */
        public int autoStartAfterPause;

        /* move Z up on pause */
        public int zUpOnPause;

        /* Z up distance */
        public double zUpMoveDistanceOnPause;

        /* feed during approach of Z at resume */
        public double approachFeed;

        /* safety relay present */
        public int safetyRelayPresent;
        public CNCIOID systemReadyOutPortID;
        public CNCIOID safetyRelayResetOutPortID;

        /* pulse length of reset pulse for safety relay */
        public int safetyRelayResetDelayMs;
        public int safetyRelayPulseLengthMs;

    }

    [Serializable]
    public struct CNCAxisBools
    {
        public int x, y, z, a, b, c;

    }

    [Serializable]
    public struct CNCPauseStatus
    {
        /* 1 if paused for manual action, like manual tool change */
        public int pauseManualActionRequired;

        /* position which is stored after pause */
        public CNCPositions pausePosition;
        public int pausePositionValid;
        public int pausePositionLine;
        public int pauseSpindleIOValue;
        public int pauseAux1IOValue;
        public int pauseAux2IOValue;
        public int pauseAux3IOValue;
        public int pauseAux4IOValue;
        public int pauseAux5IOValue;
        public int pauseAux6IOValue;
        public int pauseAux7IOValue;
        public int pauseAux8IOValue;
        public int pauseAux9IOValue;
        public int pauseMistIOValue;
        public int pauseFloodIOValue;

        /* So GUI knows Array indices where paused */
        public int pauseArrayIndexX;
        public int pauseArrayIndexY;
        public int pauseDoArray;

        //These are monitored and updated by the server
        //GUI can show axes/IO that are in sync (at correct value for resume)
        public CNCAxisBools curPosInSync;
        public int spindleInSync;
        public int floodInSync;
        public int mistInSync;
        public int allAxesInSync;
    }
}
