using System;

namespace DPData
{
    [Serializable]
    public struct CONFIG
    {
        public MSGSPEED msg_speed;
        public int msg_lang_id;
        public bool is_kanji;
        public WINTYPE window_type;
        public WAZAEFF_MODE wazaeff_mode;
        public BATTLERULE battle_rule;
        public PARTYANDBOXMODE party_and_box;
        public bool regist_nickname;
        public bool gyrosensor;
        public bool camerashake_of_fossil;
        public CAMERAINPUTMODE camera_updown;
        public CAMERAINPUTMODE camera_leftright;
        public bool autoreport;
        public INPUTMODE input_mode;
        public bool show_nickname;
        public byte bgm_volume;
        public byte se_volume;
        public byte voice_volume;

        public int GetValue(ConfigID configId)
        {
            switch (configId)
            {
                case ConfigID.MessageSpeed: return (int)msg_speed;
                case ConfigID.LangJpnMode: return is_kanji ? 1 : 0;
                case ConfigID.WindowType: return (int)window_type;
                case ConfigID.BattleAnim: return (int)wazaeff_mode;
                case ConfigID.BattleRule: return (int)battle_rule;
                case ConfigID.PartyAndBox: return (int)party_and_box;
                case ConfigID.RegistNickname: return regist_nickname ? 0 : 1;
                case ConfigID.GyroSensor: return gyrosensor ? 0 : 1;
                case ConfigID.CameraShakeOfFossil: return camerashake_of_fossil ? 0 : 1;
                case ConfigID.AutoReport: return autoreport ? 0 : 1;
                case ConfigID.ShowNickname: return show_nickname ? 0 : 1;
                case ConfigID.BgmVolume: return bgm_volume;
                case ConfigID.SeVolume: return se_volume;
                case ConfigID.VoiceVolume: return voice_volume;
                default: return -1;
            }
        }

        public void SetValue(ConfigID configId, int value)
        {
            switch (configId)
            {
                case ConfigID.MessageSpeed: msg_speed = (MSGSPEED)value; break;
                case ConfigID.LangJpnMode: is_kanji = value != 0; break;
                case ConfigID.WindowType: window_type = (WINTYPE)value; break;
                case ConfigID.BattleAnim: wazaeff_mode = (WAZAEFF_MODE)value; break;
                case ConfigID.BattleRule: battle_rule = (BATTLERULE)value; break;
                case ConfigID.PartyAndBox: party_and_box = (PARTYANDBOXMODE)value; break;
                case ConfigID.RegistNickname: regist_nickname = value == 0; break;
                case ConfigID.GyroSensor: gyrosensor = value == 0; break;
                case ConfigID.CameraShakeOfFossil: camerashake_of_fossil = value == 0; break;
                case ConfigID.AutoReport: autoreport = value == 0; break;
                case ConfigID.ShowNickname: show_nickname = value == 0; break;
                case ConfigID.BgmVolume: bgm_volume = (byte)value; break;
                case ConfigID.SeVolume: se_volume = (byte)value; break;
                case ConfigID.VoiceVolume: voice_volume = (byte)value; break;
            }
        }

        public bool IsEqualValue(ConfigID configId, ref CONFIG t)
        {
            return GetValue(configId) == t.GetValue(configId);
        }

        public bool IsEqual(ref CONFIG t)
        {
            var names = Enum.GetNames(typeof(CONFIG));
            for (int i=0; i<names.Length; i++)
            {
                if (!IsEqualValue((ConfigID)i, ref t))
                    return false;
            }

            return true;
        }
    }
}
