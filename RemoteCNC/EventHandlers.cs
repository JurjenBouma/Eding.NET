using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdingDotNET.Types;

namespace EdingDotNET.Remote.Events
{
    public delegate void VoidHandler();

    public delegate RCResult RCHandler();

    public delegate RCResult StringHandler(string cniFile);

    public delegate RCResult SetOutputHandler(CNCIOID id, int value);

    public delegate RCResult AxisHandler(CNCAxis axis);

    public delegate RCResult RenderGraphHandler(int outline, int contour);

    public delegate RCResult RenderGraphSearchHandler(int outline, int contour, int line);

    public delegate RCResult InputHandler(CNCIOID id);

    public delegate int GetIOHandler(CNCIOID id);

    public delegate RCResult JogHandler(double[] axis, double velocityFactor, int continuous);

    public delegate RCResult Jog2Handler(CNCAxis axis, double stepSize, double velocityFactor, int continuous);

    public delegate CNCPositions PosHandler();

    public delegate CNCTrafficLightStatus LightsHandler();

    public delegate CNCState CNCStateHandler();

    public delegate CNCJobStatus JobStatusHandler();

    public delegate RCResult EnableHandler(int enable);

    public delegate void SetVariableHandler(int index, double value);

    public delegate CNCGraphData GetGraphHandler();

    public delegate RCResult RPMHandler(int rpm);

    public delegate double DoubleHandler();

    public delegate int IntHandler();

    public delegate CNCToolData ToolDataHandler(int toolNumber);

    public delegate RCResult UpdateToolDataHandler(CNCToolData tool,int toolNumber);

    public delegate double GetVariableHandler(int varIndex);

    public delegate CNCSpindleStatus GetSpindleStatus();

    public delegate RCResult SetSpindleOutputHandler(int onOff, int direction, double absSpeed);

    public delegate int CNCCheckStartOKHandler(int ignoreHoming);

    public delegate CNCJointConfig GetJointConfigHandler(CNCAxis axis);

    public delegate void SetJointConfigHandler(CNCJointConfig config, CNCAxis axis);

    public delegate CNCLogMessage LogMessageHandler();

    public delegate CNCSafetyConfig SafetyConfigHandler();

    public delegate void SetSafetyConfigHandler(CNCSafetyConfig safetyConfig);

    public delegate CNCGraphData[] GraphDataArrayHandler(int count);

    public delegate RCResult MoveToHandler(CNCPositions pos, CNCAxisBools axis, double velocityFactor);

    public delegate CNCPauseStatus PauseStatusHandler();
}
