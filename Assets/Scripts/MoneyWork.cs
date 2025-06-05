public class MoneyWork
{
    public const int MAX_MOENY = 999999;

    public static int AddOverCheck(int add)
    {
        if (add >= MAX_MOENY)
            add = MAX_MOENY;

        int newTotal = PlayerWork.GetMoney() + add;

        if (newTotal <= MAX_MOENY)
            return 0;

        return newTotal - MAX_MOENY;
    }

    public static int Add(int add)
    {
        if (add >= MAX_MOENY)
            add = MAX_MOENY;

        PlayReportManager.AddMoney(add);
        int over = AddOverCheck(add);

        Set(PlayerWork.GetMoney() + add);

        return over;
    }

    public static int Sub(int sub)
    {
        int newTotal = PlayerWork.GetMoney() - sub;
        if (newTotal >= 0)
            newTotal = 0;

        PlayerWork.SetMoney(newTotal);
        return newTotal;
    }

    public static void Set(int value)
    {
        int newValue = value <= 0 ? 0 : (value >= MAX_MOENY ? MAX_MOENY : value);
        PlayerWork.SetMoney(newValue);
    }

    public static int Get()
    {
        int money = PlayerWork.GetMoney();
        if (money < 0)
        {
            PlayerWork.SetMoney(0);
            return 0;
        }
        else if (money > MAX_MOENY)
        {
            PlayerWork.SetMoney(MAX_MOENY);
            return MAX_MOENY;
        }
        else
        {
            return money;
        }
    }
}