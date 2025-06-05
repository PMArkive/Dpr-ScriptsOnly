using System;
using XLSXContent;

public class CalendarEnc
{
    public static uint CalEnc_GetProb(uint inProb, bool inPenalty)
    {
        if (inPenalty)
            return inProb;

        if (inProb == 0)
            return 0;

        var calendarData = GetCalenderEncData(GameManager.nowTime);
        if (calendarData == null)
            return inProb < 0 ? 1 : inProb;
        else
            return inProb + calendarData.add_rate < 0 ? 1 : inProb + (uint)calendarData.add_rate;
    }

    public static int CalEnc_GetHaching()
    {
        if (SystemTimeWork.IsPenalty())
            return 0;

        var calendarData = GetCalenderEncData(GameManager.nowTime);
        if (calendarData != null)
            return calendarData.add_hatching;
        else
            return 0;
    }

    private static CalenderEncTable.Sheetdata GetCalenderEncData(in DateTime dateTime)
    {
        for (int i=0; i<GameManager.calenderEncTable.data.Length; i++)
        {
            var item = GameManager.calenderEncTable.data[i];
            if (item.month == dateTime.Month && item.day == dateTime.Day)
                return item;
        }

        return null;
    }

    // TODO
    public static SYS_WEATHER CalEnc_GetWeather(ZoneID id, SYS_WEATHER in_weather, bool inPenalty)
    {
        if (inPenalty)
            return in_weather;

        switch (id)
        {
            case ZoneID.C09:
            case ZoneID.L03:
            case ZoneID.R212AR0103:
            case ZoneID.R212B:
            // TODO

            default:
                return in_weather;
        }


    }

    // TODO
    private static int GetMonthDayIndex(int month)
    {
        if (month < 2)
            return 0;

        return 0;
    }

    // TODO
    private static int GetMonthDay(int month) { return 0; }
}