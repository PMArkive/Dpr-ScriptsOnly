using Dpr.Battle.Logic;

public class WeatherWork
{
    public static SYS_WEATHER WeatherID { set => PlayerWork.FieldWeather = value; get => PlayerWork.FieldWeather; }

    public static EffectFieldID GetFieldEffectID()
    {
        switch (WeatherID)
        {
            case SYS_WEATHER.CLOUDINESS:
            case SYS_WEATHER.FOG:
            case SYS_WEATHER.SPIRIT:
            case SYS_WEATHER.MYSTIC:
            case SYS_WEATHER.MIST1:
            case SYS_WEATHER.MIST2:
            case SYS_WEATHER.FLASH:
            case SYS_WEATHER.SPARK_EFF:
            case SYS_WEATHER.FOGS:
            default:
                return EffectFieldID.NONE;

            case SYS_WEATHER.RAIN:
                return EffectFieldID.EF_F_WEATHER_RAIN;

            case SYS_WEATHER.STRAIN:
                return EffectFieldID.EF_F_WEATHER_RAIN_H;

            case SYS_WEATHER.SPARK:
                return EffectFieldID.EF_F_WEATHER_THUNDER;

            case SYS_WEATHER.SNOW:
                return EffectFieldID.EF_F_WEATHER_SNOW;

            case SYS_WEATHER.SNOWSTORM:
                return EffectFieldID.EF_F_WEATHER_SNOWSTORM;

            case SYS_WEATHER.SNOWSTORM_H:
                return EffectFieldID.EF_F_WEATHER_SNOWSTORM_H;

            case SYS_WEATHER.VOLCANO:
                return EffectFieldID.EF_F_WEATHER_VOLCANO;

            case SYS_WEATHER.SANDSTORM:
                return EffectFieldID.EF_F_WEATHER_SANDSTORM;

            case SYS_WEATHER.DIAMONDDUST:
                return EffectFieldID.EF_F_WEATHER_DIAMONDDUST;
        }
    }

    public static void GetBtlWeatherID(out BtlWeather weather, out BtlGround ground, SYS_WEATHER weatherID = SYS_WEATHER.MAX)
    {
        if (weatherID == SYS_WEATHER.MAX)
            weatherID = WeatherID;

        switch (weatherID)
        {
            case SYS_WEATHER.SUNNY:
            case SYS_WEATHER.CLOUDINESS:
                weather = BtlWeather.BTL_WEATHER_NONE;
                ground = BtlGround.BTL_GROUND_NONE;
                break;

            case SYS_WEATHER.RAIN:
            case SYS_WEATHER.STRAIN:
                weather = BtlWeather.BTL_WEATHER_RAIN;
                ground = BtlGround.BTL_GROUND_NONE;
                break;

            case SYS_WEATHER.SPARK:
            case SYS_WEATHER.SPARK_EFF:
                weather = BtlWeather.BTL_WEATHER_RAIN;
                ground = BtlGround.BTL_GROUND_ELEKI;
                break;

            case SYS_WEATHER.SNOW:
            case SYS_WEATHER.SNOWSTORM:
            case SYS_WEATHER.SNOWSTORM_H:
            case SYS_WEATHER.DIAMONDDUST:
                weather = BtlWeather.BTL_WEATHER_SNOW;
                ground = BtlGround.BTL_GROUND_NONE;
                break;

            case SYS_WEATHER.SANDSTORM:
                weather = BtlWeather.BTL_WEATHER_SAND;
                ground = BtlGround.BTL_GROUND_NONE;
                break;

            case SYS_WEATHER.MIST1:
            case SYS_WEATHER.MIST2:
                weather = BtlWeather.BTL_WEATHER_NONE;
                ground = BtlGround.BTL_GROUND_MIST;
                break;

            default:
                weather = BtlWeather.BTL_WEATHER_NONE;
                ground = BtlGround.BTL_GROUND_NONE;
                break;
        }
    }

    public static bool GetFieldSunny()
    {
        switch (WeatherID)
        {
            case SYS_WEATHER.SUNNY:
            case SYS_WEATHER.CLOUDINESS:
            case SYS_WEATHER.SNOW:
            case SYS_WEATHER.SNOWSTORM:
            case SYS_WEATHER.SNOWSTORM_H:
            case SYS_WEATHER.FOG:
            case SYS_WEATHER.VOLCANO:
            case SYS_WEATHER.SANDSTORM:
            case SYS_WEATHER.SPIRIT:
            case SYS_WEATHER.MYSTIC:
            case SYS_WEATHER.MIST1:
            case SYS_WEATHER.MIST2:
            case SYS_WEATHER.FLASH:
            case SYS_WEATHER.SPARK_EFF:
            case SYS_WEATHER.FOGS:
            case SYS_WEATHER.FOGM:
                return true;

            default:
                return false;
        }
    }

    public static bool GetFieldRain()
    {
        switch (WeatherID)
        {
            case SYS_WEATHER.DIAMONDDUST:
            case SYS_WEATHER.RAIN:
            case SYS_WEATHER.STRAIN:
            case SYS_WEATHER.SPARK:
                return true;

            default:
                return false;
        }
    }
}