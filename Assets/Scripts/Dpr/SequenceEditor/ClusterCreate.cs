using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ClusterCreate, "orange", "", "")]
    public class ClusterCreate : Macro
    {
        public string file;
        public string fileAnm;
        public bool useAnm;
        public SEQ_DEF_DRAWTYPE drawType;
        public SEQ_DEF_ROTATE_ORDER rotOrder;
        public int spawnMax;
        public int spawnTime;
        public int spawnInterval;
        public int spawnNum;
        public int spawnRate;
        public int spawnLife;
        public CLUSTER_SPAWN spawnType;
        public CLUSTER_POS_AXIS spawnAxis;
        public Vector3 spawnSize;
        public int spawnDegS;
        public int spawnDegE;
        public int spawnLen;
        public bool isMulti;

        public ClusterCreate(Macro macro) : base(macro)
        {
            file = ParseString(macro.GetValue("file"));
            fileAnm = ParseString(macro.GetValue("fileAnm"));
            useAnm = ParseBool(macro.GetValue("useAnm"));
            drawType = Parse_SEQ_DEF_DRAWTYPE(macro.GetValue("drawType"));
            rotOrder = Parse_SEQ_DEF_ROTATE_ORDER(macro.GetValue("rotOrder"));
            spawnMax = ParseInt(macro.GetValue("spawnMax"), 8);
            spawnTime = ParseInt(macro.GetValue("spawnTime"));
            spawnInterval = ParseInt(macro.GetValue("spawnInterval"), 1);
            spawnNum = ParseInt(macro.GetValue("spawnNum"), 1);
            spawnRate = ParseInt(macro.GetValue("spawnRate"), 100);
            spawnLife = ParseInt(macro.GetValue("spawnLife"));
            spawnType = Parse_CLUSTER_SPAWN(macro.GetValue("spawnType"));
            spawnAxis = Parse_CLUSTER_POS_AXIS(macro.GetValue("spawnAxis"));
            spawnSize = ParseVector3(macro.GetValue("spawnSize"), 1.0f, 1.0f, 1.0f);
            spawnDegS = ParseInt(macro.GetValue("spawnDegS"));
            spawnDegE = ParseInt(macro.GetValue("spawnDegE"), 360);
            spawnLen = ParseInt(macro.GetValue("spawnLen"), 0);
            isMulti = ParseBool(macro.GetValue("isMulti"));
        }
    }
}