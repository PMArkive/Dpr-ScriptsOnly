namespace Pml.PokePara
{
    public class EvolveSituation
    {
        public bool isMagneticField;
        public bool isIceField;
        public bool isMossField;
        public bool isSnowMountain;
        public bool isUltraSpace;
        public bool isMorningOrNoon;
        public bool isNight;
        public bool isEvening;
        public bool isRain;
        public bool isDeviceTurnedOver;
        public bool isTurnRoundOnField;
        public byte criticalHitCount;
        public OwnerInfo owner_info = new OwnerInfo();

        public EvolveSituation()
        {
            isRain = false;
            isDeviceTurnedOver = false;
            isTurnRoundOnField = false;
            criticalHitCount = 0;
            isMagneticField = false;
            isIceField = false;
            isMossField = false;
            isSnowMountain = false;
            isUltraSpace = false;
            isMorningOrNoon = false;
            isNight = false;
            isEvening = false;
            owner_info = new OwnerInfo(); // Overwriting the field initializer is intended
        }

        public void CopyFrom(EvolveSituation src)
        {
            isMagneticField = src.isMagneticField;
            isIceField = src.isIceField;
            isMossField = src.isMossField;
            isSnowMountain = src.isSnowMountain;
            isUltraSpace = src.isUltraSpace;
            isMorningOrNoon = src.isMorningOrNoon;
            isNight = src.isNight;
            isEvening = src.isEvening;
            isRain = src.isRain;
            isDeviceTurnedOver = src.isDeviceTurnedOver;
            isTurnRoundOnField = src.isTurnRoundOnField;
            criticalHitCount = src.criticalHitCount;
            owner_info.CopyFrom(src.owner_info);
        }
    }
}