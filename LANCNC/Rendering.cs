using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EdingDotNET.Types;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LANCNC
{
    public static class Rendering
    {
        private static List<float> gridLines;
        public static float[] camPos;
        public static float[] lookAt;
        private static float m_zoom;
        private static bool m_lastToggleFitMachine = true;
        private static List<float> jobLines;
        public static int GridLenght { get { return gridLines.Count; } }
        public static int JobLenght { get { return jobLines.Count; } }
        public static int ColisionLenght { get { return colisionLines.Count; } }
        public static int ZeroLenght { get { return ZeroLines.Count; } }
        public static int PosLenght { get { return PosLines.Count; } }
        private static List<float> ZeroLines;
        private static List<float> PosLines;
        private static List<float> colisionLines;

        public static JavaScriptSerializer serializer;

        public static float[] GetVertices
        {
            get
            {
                List<float> verts = new List<float>();
                verts.AddRange(gridLines);
                verts.AddRange(jobLines);
                verts.AddRange(colisionLines);
                verts.AddRange(ZeroLines);
                verts.AddRange(PosLines);
                return verts.ToArray();
            }
        }
        private static bool m_isInitialized = false;

        public static void Initialize()
        {
            if (!m_isInitialized)
            {
                gridLines = new List<float>();
                jobLines = new List<float>();
                colisionLines = new List<float>();
                ZeroLines = new List<float>();
                PosLines = new List<float>();
                camPos = new float[3];
                lookAt = new float[3];


                double yNegLimit = CNCGlobals.CNC.CNCGetVariable(5102);
                double yPosLimit = CNCGlobals.CNC.CNCGetVariable(5112);

                float machHeight = (float)(Math.Abs(yNegLimit) + yPosLimit);


                CreateGrid(50f, 1, 0, 0);
                RenderZero();
                RenderPos();
                m_zoom = 1.5f * machHeight;

                FitMachine();

                serializer = new JavaScriptSerializer();
                serializer.MaxJsonLength = 100000000;
                m_isInitialized = true;
            }
        }

        public static void ReRenderGrid()
        {
            CreateGrid(50f, 1, 0, 0);

            double yNegLimit = CNCGlobals.CNC.CNCGetVariable(5102);
            double yPosLimit = CNCGlobals.CNC.CNCGetVariable(5112);

            float machHeight = (float)(Math.Abs(yNegLimit) + yPosLimit);

            RenderZero();
            RenderPos();
            m_zoom = 1.5f * machHeight;

            FitMachine();
        }

        public static void Zoom(float scaler)
        {
            if (m_zoom * (1 / scaler) > 1f && m_zoom * (1 / scaler) < 10000f)
            {
                m_zoom *= 1 / scaler;
            }

            camPos[2] = m_zoom;//width *zoom
        }

        public static void ToggleFit()
        {
            if (m_lastToggleFitMachine && jobLines.Count > 0)
                FitJob();
            else
                FitMachine();
        }

        public static void FitMachine()
        {
            m_lastToggleFitMachine = true;
            double xNegLimit = CNCGlobals.CNC.CNCGetVariable(5101);
            double xPosLimit = CNCGlobals.CNC.CNCGetVariable(5111);
            double yNegLimit = CNCGlobals.CNC.CNCGetVariable(5102);
            double yPosLimit = CNCGlobals.CNC.CNCGetVariable(5112);


            camPos[0] = (float)(xNegLimit + xPosLimit) / 2;
            camPos[1] = (float)(yNegLimit + yPosLimit) / 2;
            camPos[2] = m_zoom;

            lookAt[0] = camPos[0];
            lookAt[1] = camPos[1];
            lookAt[2] = 0;
        }

        public static void FitJob()
        {
            if (jobLines.Count > 70)
            {
                m_lastToggleFitMachine = false;
                float minX = 999999;
                float maxX = -999999;
                float minY = 999999;
                float maxY = -999999;
                for (int x = 7; x < jobLines.Count; x += 7)
                {
                    if (jobLines[x + 3] == 0)//if not G0 Color check
                    {
                        minX = Math.Min(minX, jobLines[x]);
                        maxX = Math.Max(maxX, jobLines[x]);
                        minY = Math.Min(minY, jobLines[x + 1]);
                        maxY = Math.Max(maxY, jobLines[x + 1]);
                    }
                }

                camPos[0] = minX + ((maxX - minX) / 2);
                camPos[1] = minY + ((maxY - minY) / 2);
                camPos[2] = m_zoom;

                lookAt[0] = camPos[0];
                lookAt[1] = camPos[1];
                lookAt[2] = 0;
            }
        }

        private static void RenderPos()
        {
            PosLines = new List<float>();
            PosLines.AddRange(new float[] {
            0f, 0f, 0f,     0.5f, 1f, 0.2f, 1.0f,//front
            3f, -3f, 30f,   0.5f, 1f, 0.2f,1.0f,
            -3f, -3f, 30f,   0.5f, 1f, 0.2f,1.0f,

            0f, 0f, 0f,     0.5f, 1f, 0.2f, 1.0f,//right
            3f, -3f, 30f,   0.5f, 1f, 0.2f,1.0f,
            3f, 3f, 30f,   0.5f, 1f, 0.2f,1.0f,

            0f, 0f, 0f,     0.5f, 1f, 0.2f, 1.0f,///back
            3f, 3f, 30f,   0.5f, 1f, 0.2f,1.0f,
            -3f, 3f, 30f,   0.5f, 1f, 0.2f,1.0f,

            0f, 0f, 0f,     0.5f, 1f, 0.2f, 1.0f,//left
            -3f, 3f, 30f,   0.5f, 1f, 0.2f,1.0f,
            -3f, -3f, 30f,   0.5f, 1f, 0.2f,1.0f,

            -3f, 3f, 30f,     0.5f, 1f, 0.2f, 1.0f,//top top
            -3f, -3f, 30f,   0.5f, 1f, 0.2f,1.0f,
            3f, 3f, 30f,   0.5f, 1f, 0.2f,1.0f,

            -3f, -3f, 30f,     0.5f, 1f, 0.2f, 1.0f,//top top
            3f, -3f, 30f,   0.5f, 1f, 0.2f,1.0f,
            3f, 3f, 30f,   0.5f, 1f, 0.2f,1.0f});
        }

        public static void RenderZero()
        {
            ZeroLines = new List<float>();

            float ZeroSize = 4;
            AddZeroLine(
                  (float)(-ZeroSize),
                  (float)(+ZeroSize),
                  (float)(0),
                  1, 1, 1, 1);

            AddZeroLine(
                   (float)(+ZeroSize),
                   (float)(-ZeroSize),
                   (float)(0),
                   1, 1, 1, 1);

            AddZeroLine(
                    (float)(+ZeroSize),
                    (float)(+ZeroSize),
                    (float)(0),
                    1, 1, 1, 1);

            AddZeroLine(
                    (float)(-ZeroSize),
                    (float)(-ZeroSize),
                    (float)(0),
                    1, 1, 1, 1);

            AddZeroLine(
                    (float)(-ZeroSize),
                    (float)(+ZeroSize),
                    (float)(0),
                    1, 1, 1, 1);

            AddZeroLine(
                    (float)(+ZeroSize),
                    (float)(+ZeroSize),
                    (float)(0),
                    1, 1, 1, 1);

            AddZeroLine(
                    (float)(+ZeroSize),
                    (float)(-ZeroSize),
                    (float)(0),
                    1, 1, 1, 1);

            AddZeroLine(
                    (float)(-ZeroSize),
                    (float)(-ZeroSize),
                    (float)(0),
                    1, 1, 1, 1);
        }

        private static void CreateGrid(float gridSize, float r, float g, float b)
        {
            gridLines = new List<float>();

            double xNegLimit = CNCGlobals.CNC.CNCGetVariable(5101);
            double xPosLimit = CNCGlobals.CNC.CNCGetVariable(5111);
            double yNegLimit = CNCGlobals.CNC.CNCGetVariable(5102);
            double yPosLimit = CNCGlobals.CNC.CNCGetVariable(5112);

            for (float x = (float)xNegLimit; x < xPosLimit; x += gridSize)
            {
                for (float y = (float)yNegLimit; y < yPosLimit; y += gridSize)
                {
                    AddGridLine(x, y, 0.0f, r, g, b, 1);
                    AddGridLine((x + gridSize), y, 0.0f, r, g, b, 1);
                    AddGridLine((x + gridSize), (y + gridSize), 0.0f, r, g, b, 1);
                    AddGridLine(x, (y + gridSize), 0.0f, r, g, b, 1);
                }
                AddGridLine(x, (float)yNegLimit, 0.0f, r, g, b, 1);
            }
        }

        private static void AddGridLine(float x, float y, float z, float r, float g, float b, float a)
        {
            gridLines.Add(x);
            gridLines.Add(y);
            gridLines.Add(z);
            gridLines.Add(r);
            gridLines.Add(g);
            gridLines.Add(b);
            gridLines.Add(a);
        }

        private static void AddJobLine(float x, float y, float z, float r, float g, float b, float a)
        {
            jobLines.Add(x);
            jobLines.Add(y);
            jobLines.Add(z);
            jobLines.Add(r);
            jobLines.Add(g);
            jobLines.Add(b);
            jobLines.Add(a);
        }

        private static void AddColisionLine(float x, float y, float z, float r, float g, float b, float a)
        {
            colisionLines.Add(x);
            colisionLines.Add(y);
            colisionLines.Add(z);
            colisionLines.Add(r);
            colisionLines.Add(g);
            colisionLines.Add(b);
            colisionLines.Add(a);
        }

        private static void AddZeroLine(float x, float y, float z, float r, float g, float b, float a)
        {
            ZeroLines.Add(x);
            ZeroLines.Add(y);
            ZeroLines.Add(z);
            ZeroLines.Add(r);
            ZeroLines.Add(g);
            ZeroLines.Add(b);
            ZeroLines.Add(a);
        }

        public static void RenderJobGraph()
        {
            RenderJobArray();
        }

        private static void RenderColision(CNCPositions colisionPoint)
        {

            float colisionRenderSize = 10;
            AddColisionLine(
                  (float)(colisionPoint.x - colisionRenderSize),
                  (float)(colisionPoint.y + colisionRenderSize),
                  (float)(colisionPoint.z),
                  1, 0, 0, 1);

            AddColisionLine(
                   (float)(colisionPoint.x + colisionRenderSize),
                   (float)(colisionPoint.y - colisionRenderSize),
                   (float)(colisionPoint.z),
                   1, 0, 0, 1);

            AddColisionLine(
                    (float)(colisionPoint.x + colisionRenderSize),
                    (float)(colisionPoint.y + colisionRenderSize),
                    (float)(colisionPoint.z),
                    1, 0, 0, 1);

            AddColisionLine(
                    (float)(colisionPoint.x - colisionRenderSize),
                    (float)(colisionPoint.y - colisionRenderSize),
                    (float)(colisionPoint.z),
                    1, 0, 0, 1);

            AddColisionLine(
                    (float)(colisionPoint.x - colisionRenderSize),
                    (float)(colisionPoint.y + colisionRenderSize),
                    (float)(colisionPoint.z),
                    1, 0, 0, 1);

            AddColisionLine(
                    (float)(colisionPoint.x + colisionRenderSize),
                    (float)(colisionPoint.y + colisionRenderSize),
                    (float)(colisionPoint.z),
                    1, 0, 0, 1);

            AddColisionLine(
                    (float)(colisionPoint.x + colisionRenderSize),
                    (float)(colisionPoint.y - colisionRenderSize),
                    (float)(colisionPoint.z),
                    1, 0, 0, 1);

            AddColisionLine(
                    (float)(colisionPoint.x - colisionRenderSize),
                    (float)(colisionPoint.y - colisionRenderSize),
                    (float)(colisionPoint.z),
                    1, 0, 0, 1);
        }
        private static void RenderJobArray()//fastest method
        {
            jobLines = new List<float>();
            colisionLines = new List<float>();

            CNCJobStatus status = CNCGlobals.CNC.CNCGetJobStatus();
            CNCGlobals.CNC.CNCStartRenderGraph(0, 1);//get info

            float[] color = new float[3];
            CNCGraphData[] graphData;
            bool done = false;
            while (!done)
            {
                graphData = CNCGlobals.CNC.CNCGraphFifoGetArray(1000);//grab 1000 graphdatas
                for (int i = 0; i < 1000; i++)
                {
                    if (graphData[i].type == CNCMoveType.CNC_MOVE_TYPE_END)//check data
                    {
                        done = true;
                        break;
                    }
                    else if (graphData[i].type == CNCMoveType.CNC_MOVE_TYPE_END_COLLISION)
                    {
                        RenderColision(graphData[i].pos);
                    }
                    else if (graphData[i].type == CNCMoveType.CNC_MOVE_TYPE_ARC | graphData[i].type == CNCMoveType.CNC_MOVE_TYPE_G0 |
                        graphData[i].type == CNCMoveType.CNC_MOVE_TYPE_G1 | graphData[i].type == CNCMoveType.CNC_MOVE_TYPE_JOG)
                    {
                        color[0] = 0; color[1] = 0; color[2] = 1;
                        if (graphData[i].type == CNCMoveType.CNC_MOVE_TYPE_G0)
                        { color[0] = 1f; color[1] = 0.8f; color[2] = 0.0f; }

                        jobLines.Add((float)graphData[i].pos.x);//fill list
                        jobLines.Add((float)graphData[i].pos.y);
                        jobLines.Add((float)graphData[i].pos.z);
                        jobLines.Add(color[0]);
                        jobLines.Add(color[1]);
                        jobLines.Add(color[2]);
                        jobLines.Add(1);
                    }
                }
            }
        }

        private static void RenderJobGraphOld()//slow and ol methods
        {
            jobLines = new List<float>();
            colisionLines = new List<float>();

            CNCJobStatus status = CNCGlobals.CNC.CNCGetJobStatus();
            CNCGlobals.CNC.CNCStartRenderSearch(0, 1, CNCGlobals.CNC.CNCGetJobStatus().numLinesInjob);//get info

            float[] color = new float[3];
            CNCGraphData graphData;
            bool done = false;
            float[] verts = new float[140000];
            int jobEnd = 0;
            while (!done)
            {
                for (int i = 0; i < verts.Length; i += 7)
                {
                    graphData = CNCGlobals.CNC.CNCGraphFifoGet();
                    if (graphData.type == CNCMoveType.CNC_MOVE_TYPE_END)
                    {
                        done = true;
                        break;
                    }
                    else if (graphData.type == CNCMoveType.CNC_MOVE_TYPE_END_COLLISION)
                    {
                        RenderColision(graphData.pos);
                    }
                    else if(graphData.type == CNCMoveType.CNC_MOVE_TYPE_ARC | graphData.type == CNCMoveType.CNC_MOVE_TYPE_G0 |
                        graphData.type == CNCMoveType.CNC_MOVE_TYPE_G1 | graphData.type == CNCMoveType.CNC_MOVE_TYPE_JOG)
                    {
                        color[0] = 0; color[1] = 0; color[2] = 1;
                        if (graphData.type == CNCMoveType.CNC_MOVE_TYPE_G0)
                        { color[0] = 1f; color[1] = 0.8f; color[2] = 0.0f; }

                        verts[i] = (float)graphData.pos.x;
                        verts[i + 1] = (float)graphData.pos.y;
                        verts[i + 2] = (float)graphData.pos.z;
                        verts[i + 3] = color[0];
                        verts[i + 4] = color[1];
                        verts[i + 5] = color[2];
                        verts[i + 6] = 1;
                        jobEnd += 7;
                    }
                    
                }
                jobLines.AddRange(verts);
            }
            jobLines.RemoveRange(jobEnd, jobLines.Count - jobEnd);

        }
    }
}