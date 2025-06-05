using Dpr.Battle.View.Playables;
using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Serializable]
    public class Macro
    {
        public static Macro Default = new Macro();

        public CommandNo CommandNo;
        public string Name;
        public List<Value> Values;
        public CameraFilePlayable CamFile;
        private static CultureInfo culture_us;

        public Macro()
        {
            // Empty
        }

        public Macro(Macro other)
        {
            CommandNo = other.CommandNo;
            Name = other.Name;
            Values = other.Values;
        }

        public Value GetValue(string key)
        {
            return Values.Find(x => x.Name == key);
        }

        public static string ParseString(Value value, string def = "")
        {
            if (string.IsNullOrEmpty(value.Name))
                return def;

            return value[0];
        }

        public static int ParseInt(Value value, int def = -1)
        {
            if (string.IsNullOrEmpty(value.Name))
                return def;

            return int.Parse(value[0]);
        }

        public static Vector3 ParseVector3(Value value, float def = 0.0f)
        {
            if (string.IsNullOrEmpty(value.Name))
                return new Vector3(def, def, def);

            return new Vector3(float_Parse(value[0]), float_Parse(value[1]), float_Parse(value[2]));
        }

        public static Vector3 ParseVector3(Value value, float defX, float defY, float defZ = 0.0f)
        {
            if (string.IsNullOrEmpty(value.Name))
                return new Vector3(defX, defY, defZ);

            return new Vector3(float_Parse(value[0]), float_Parse(value[1]), float_Parse(value[2]));
        }

        public static float ParseFloat(Value value, float def = 0.0f)
        {
            if (string.IsNullOrEmpty(value.Name))
                return def;

            return float_Parse(value[0]);
        }

        public static bool ParseBool(Value value, bool def = false)
        {
            if (string.IsNullOrEmpty(value.Name))
                return def;

            return int.Parse(value[0]) == 1;
        }

        public static bool ParseBool(Value value, int def)
        {
            if (string.IsNullOrEmpty(value.Name))
                return def == 1;

            return int.Parse(value[0]) == 1;
        }

        public static bool[] ParseBoolArray(Value value, bool def = true)
        {
            if (string.IsNullOrEmpty(value.Name))
                return new bool[] { def, def, def };

            return new bool[] { int.Parse(value[0]) == 1, int.Parse(value[1]) == 1, int.Parse(value[2]) == 1 };
        }

        public static bool[] ParseBoolArray(Value value, int def0, int def1, int def2)
        {
            if (string.IsNullOrEmpty(value.Name))
                return new bool[] { def0 == 1, def1 == 1, def2 == 1 };

            return new bool[] { int.Parse(value[0]) == 1, int.Parse(value[1]) == 1, int.Parse(value[2]) == 1 };
        }

        // TODO
        public static CLUSTER_SPAWN Parse_CLUSTER_SPAWN(Value value, CLUSTER_SPAWN def = 0) { return CLUSTER_SPAWN.CLUSTER_SPAWN_POINT; }

        // TODO
        public static CLUSTER_POS_AXIS Parse_CLUSTER_POS_AXIS(Value value, CLUSTER_POS_AXIS def = 0) { return CLUSTER_POS_AXIS.CLUSTER_AXIS_X; }

        // TODO
        public static SEQ_DEF_MOVETYPE Parse_SEQ_DEF_MOVETYPE(Value value, SEQ_DEF_MOVETYPE defaultMoveType = 0) { return default; }

        // TODO
        public static SEQ_DEF_POS Parse_SEQ_DEF_POS(Value value) { return SEQ_DEF_POS.SEQ_DEF_POS_ATK; }

        // TODO
        public static SEQ_DEF_NODE Parse_SEQ_DEF_NODE(Value value, SEQ_DEF_NODE def = 0) { return SEQ_DEF_NODE.SEQ_DEF_NODE_ORIGIN; }

        // TODO
        public static SEQ_DEF_TR_ENV Parse_SEQ_DEF_TR_ENV(Value value, SEQ_DEF_TR_ENV def = 0) { return default; }

        // TODO
        public static SEQ_DEF_TRAINER Parse_SEQ_DEF_TRAINER(Value value, SEQ_DEF_TRAINER def = 0) { return default; }

        // TODO
        public static SEQ_DEF_SPPOS Parse_SEQ_DEF_SPPOS(Value value, SEQ_DEF_SPPOS def = 0) { return default; }

        // TODO
        public static SEQ_DEF_ROTATE_ORDER Parse_SEQ_DEF_ROTATE_ORDER(Value value, SEQ_DEF_ROTATE_ORDER def = 0) { return SEQ_DEF_ROTATE_ORDER.SEQ_DEF_ROTATE_ORDER_XYZ; }

        // TODO
        public static SEQ_DEF_MOTION Parse_SEQ_DEF_MOTION(Value value, SEQ_DEF_MOTION def = 0) { return default; }

        // TODO
        public static SEQ_DEF_ATK_MOT Parse_SEQ_DEF_ATK_MOT(Value value, SEQ_DEF_ATK_MOT def = 0) { return default; }

        // TODO
        public static SEQ_DEF_AXIS Parse_SEQ_DEF_AXIS(Value value, SEQ_DEF_AXIS def = 0) { return default; }

        // TODO
        public static SEQ_DEF_GPOKE_EFFECT Parse_SEQ_DEF_GPOKE_EFFECT(Value value, SEQ_DEF_GPOKE_EFFECT def = 0) { return default; }

        // TODO
        public static SEQ_DEF_ANIMCONF Parse_SEQ_DEF_ANIMCONF(Value value, SEQ_DEF_ANIMCONF def = 0) { return default; }

        // TODO
        public static SEQ_DEF_TRAINER_ADD Parse_SEQ_DEF_TRAINER_ADD(Value value, SEQ_DEF_TRAINER_ADD def = 0) { return default; }

        // TODO
        public static SEQ_DEF_TR_CAM Parse_SEQ_DEF_TR_CAM(Value value, SEQ_DEF_TR_CAM def = 0) { return default; }

        // TODO
        public static SEQ_DEF_EFF_DRAWTYPE Parse_SEQ_DEF_EFF_DRAWTYPE(Value value, SEQ_DEF_EFF_DRAWTYPE def = 0) { return default; }

        // TODO
        public static SEQ_DEF_DRAWTYPE Parse_SEQ_DEF_DRAWTYPE(Value value, SEQ_DEF_DRAWTYPE def = 0) { return SEQ_DEF_DRAWTYPE.SEQ_DEF_DRAWTYPE_NORMAL; }

        // TODO
        public static BALL_ANIME Parse_BALL_ANIME(Value value, BALL_ANIME def = 0) { return default; }

        // TODO
        public static SEQ_DEF_TR_TEX Parse_SEQ_DEF_TR_TEX(Value value, SEQ_DEF_TR_TEX def = 0) { return default; }

        // TODO
        public static SEQ_DEF_MONS_SEX Parse_SEQ_DEF_MONS_SEX(Value value, SEQ_DEF_MONS_SEX def = 0) { return default; }

        // TODO
        public static SEQ_DEF_FOLLOW Parse_SEQ_DEF_FOLLOW(Value value, SEQ_DEF_FOLLOW def = 0) { return default; }

        // TODO
        public static VOICE_TYPE Parse_VOICE_TYPE(Value value, VOICE_TYPE def = 0) { return default; }

        // TODO
        public static SEQ_DEF_UI_FOG Parse_SEQ_DEF_UI_FOG(Value value, SEQ_DEF_UI_FOG def = 0) { return default; }

        // TODO
        public static FADE_TYPE Parse_FADE_TYPE(Value value, FADE_TYPE def = 0) { return default; }

        // TODO
        public static LIGHT_TYPE Parse_LIGHT_TYPE(Value value, LIGHT_TYPE def = 0) { return default; }

        // TODO
        public static SEQ_DEF_LIGHT_TRG_SIDE Parse_SEQ_DEF_LIGHT_TRG_SIDE(Value value, SEQ_DEF_LIGHT_TRG_SIDE def = 0) { return default; }

        // TODO
        public static CLUSTER_POS Parse_CLUSTER_POS(Value value, CLUSTER_POS def = 0) { return default; }

        // TODO
        public static CLUSTER_POS_PLANE Parse_CLUSTER_POS_PLANE(Value value, CLUSTER_POS_PLANE def = 0) { return default; }

        // TODO
        public static CLUSTER_REFRECT Parse_CLUSTER_REFRECT(Value value, CLUSTER_REFRECT def = 0) { return default; }

        // TODO
        public static CLUSTER_CHILD Parse_CLUSTER_CHILD(Value value, CLUSTER_CHILD def = 0) { return default; }

        // TODO
        public static SEQ_DEF_WINDOW_TYPE Parse_SEQ_DEF_WINDOW_TYPE(Value value, SEQ_DEF_WINDOW_TYPE def = 0) { return default; }

        // TODO
        public static SEQ_DEF_FAIRY_QUIZ_TYPE Parse_SEQ_DEF_FAIRY_QUIZ_TYPE(Value value, SEQ_DEF_FAIRY_QUIZ_TYPE def = 0) { return default; }

        // TODO
        public static SEQ_DEF_FAIRY_QUIZ_RESULT Parse_SEQ_DEF_FAIRY_QUIZ_RESULT(Value value, SEQ_DEF_FAIRY_QUIZ_RESULT def = 0) { return default; }

        // TODO
        public static SEQ_DEF_WAIT Parse_SEQ_DEF_WAIT(Value value, SEQ_DEF_WAIT def = 0) { return default; }

        // TODO
        public static SEQ_DEF_WEATHER Parse_SEQ_DEF_WEATHER(Value value, SEQ_DEF_WEATHER def = 0) { return default; }

        // TODO
        public static SEQ_DEF_POKE_G Parse_SEQ_DEF_POKE_G(Value value, SEQ_DEF_POKE_G def = 0) { return default; }

        // TODO
        public static SEQ_DEF_FWAZA_TYPE Parse_SEQ_DEF_FWAZA_TYPE(Value value, SEQ_DEF_FWAZA_TYPE def = 0) { return default; }

        // TODO
        public static SEQ_DEF_INPUT Parse_SEQ_DEF_INPUT(Value value, SEQ_DEF_INPUT def = 0) { return default; }

        // TODO
        public static SEQ_DEF_RENDERER_TYPE Parse_SEQ_DEF_RENDERER_TYPE(Value value, SEQ_DEF_RENDERER_TYPE def = 0) { return default; }

        // TODO
        public static SEQ_DEF_TIME_ZONE Parse_SEQ_DEF_TIME_ZONE(Value value, SEQ_DEF_TIME_ZONE def = 0) { return default; }

        // TODO
        public static ROTOM_EFFECT Parse_ROTOM_EFFECT(Value value, ROTOM_EFFECT def = 0) { return default; }

        // TODO
        public static SEQ_DEF_SEPAN Parse_SEQ_DEF_SEPAN(Value value, SEQ_DEF_SEPAN def = 0) { return default; }

        // TODO
        public static SEQ_DEF_VIGNETTE_TYPE Parse_SEQ_DEF_VIGNETTE_TYPE(Value value, SEQ_DEF_VIGNETTE_TYPE def = 0) { return default; }

        // TODO
        public static SEQ_DEF_FOG_MODE Parse_SEQ_DEF_FOG_MODE(Value value, SEQ_DEF_FOG_MODE def = 0) { return default; }

        // TODO
        public static SEQ_DEF_FIXPARAM_CALC Parse_SEQ_DEF_FIXPARAM_CALC(Value value, SEQ_DEF_FIXPARAM_CALC def = 0) { return default; }

        // TODO
        public static SEQ_DEF_LG_LUM Parse_SEQ_DEF_LG_LUM(Value value, SEQ_DEF_LG_LUM def = 0) { return default; }

        // TODO
        public static SEQ_DEF_LG_SHAPE Parse_SEQ_DEF_LG_SHAPE(Value value, SEQ_DEF_LG_SHAPE def = 0) { return default; }

        // TODO
        public static SEQ_DEF_MASK_TEX_PATTERN Parse_SEQ_DEF_MASK_TEX_PATTERN(Value value, SEQ_DEF_MASK_TEX_PATTERN def = 0) { return default; }

        // TODO
        public static SEQ_STENCIL_TARGET Parse_SEQ_STENCIL_TARGET(Value value, SEQ_STENCIL_TARGET def = 0) { return default; }

        // TODO
        public static SEQ_DEF_MODETYPE Parse_SEQ_DEF_MODETYPE(Value value, SEQ_DEF_MODETYPE def = 0) { return default; }

        // TODO
        public static SEQ_DEF_DEFAULT_PLACEMENT Parse_SEQ_DEF_DEFAULT_PLACEMENT(Value value, SEQ_DEF_DEFAULT_PLACEMENT def = 0) { return SEQ_DEF_DEFAULT_PLACEMENT.SEQ_DEF_DEFAULT_PLACEMENT_DEFAULT; }

        public static float float_Parse(string s)
        {
            if (culture_us == null)
                culture_us = CultureInfo.CreateSpecificCulture("en-us");

            if (float.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, culture_us, out float result))
                return result;
            else
                return 0.0f;
        }

        [Serializable]
        public struct Value
        {
            public string Name;
            public List<string> Values;

            public string this[int index] => Values[index];
        }
    }
}