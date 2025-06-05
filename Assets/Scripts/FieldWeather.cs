public class FieldWeather
{
    private const float _cloudChangeTime = 2.0f;
    private float _cloudTime;
    private bool cloudEnable = true;

    public void SetCloudShadowBaseEnable()
    {
        cloudEnable = true;
    }

    public void SetCloudShadowBaseDisable()
    {
        cloudEnable = false;
        EnvironmentController.global._CloudShadowBase = 0.0f;
    }

    public void Update(float time)
    {
        if (!cloudEnable)
            return;

        switch (WeatherWork.WeatherID)
        {
            case SYS_WEATHER.SUNNY:
            case SYS_WEATHER.SNOW:
            case SYS_WEATHER.SNOWSTORM:
            case SYS_WEATHER.SNOWSTORM_H:
            case SYS_WEATHER.FOG:
            case SYS_WEATHER.VOLCANO:
            case SYS_WEATHER.SANDSTORM:
            case SYS_WEATHER.DIAMONDDUST:
            case SYS_WEATHER.SPIRIT:
            case SYS_WEATHER.MYSTIC:
            case SYS_WEATHER.MIST1:
            case SYS_WEATHER.MIST2:
            case SYS_WEATHER.FLASH:
            case SYS_WEATHER.SPARK_EFF:
            case SYS_WEATHER.FOGS:
            case SYS_WEATHER.FOGM:
                CloudUpdate(time, false);
                break;

            case SYS_WEATHER.CLOUDINESS:
            case SYS_WEATHER.RAIN:
            case SYS_WEATHER.STRAIN:
            case SYS_WEATHER.SPARK:
                CloudUpdate(time, true);
                break;
        }
    }

    public void CheckZoneWeather()
    {
        var mapInfo = GameManager.mapInfo[(int)PlayerWork.zoneID];
        WeatherWork.WeatherID = CalendarEnc.CalEnc_GetWeather(mapInfo.ZoneID, mapInfo.Weather, SystemTimeWork.IsPenalty());
    }

    private void CloudUpdate(float time, bool cloud_on)
    {
        if (!cloud_on)
            time = -time;

        _cloudTime += time;

        if (_cloudTime <= 0.0f)
        {
            _cloudTime = 0.0f;
            EnvironmentController.global._CloudShadowBase = 0.0f;
        }
        else if (_cloudTime >= _cloudChangeTime)
        {
            _cloudTime = _cloudChangeTime;
            EnvironmentController.global._CloudShadowBase = 1.0f;
        }
        else
        {
            EnvironmentController.global._CloudShadowBase = _cloudTime * 0.5f;
        }
    }
}