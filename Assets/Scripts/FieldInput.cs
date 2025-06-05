public static class FieldInput
{
    public static bool PushX()
    {
        int mask;
        if (PlayerWork.IsEasyInput())
            mask = GameController.ButtonMask.X | GameController.ButtonMask.Up;
        else
            mask = GameController.ButtonMask.X;

        return Push(mask);
    }

    public static bool PushY()
    {
        int mask;
        if (PlayerWork.IsEasyInput())
            mask = GameController.ButtonMask.Y | GameController.ButtonMask.Left;
        else
            mask = GameController.ButtonMask.Y;

        return Push(mask);
    }

    public static bool PushB()
    {
        int mask;
        if (PlayerWork.IsEasyInput())
            mask = GameController.ButtonMask.B | GameController.ButtonMask.Down;
        else
            mask = GameController.ButtonMask.B;

        return Push(mask);
    }

    public static bool PushA()
    {
        int mask;
        if (PlayerWork.IsEasyInput())
            mask = GameController.ButtonMask.A | GameController.ButtonMask.ZL | GameController.ButtonMask.ZR | GameController.ButtonMask.Right;
        else
            mask = GameController.ButtonMask.A | GameController.ButtonMask.ZL | GameController.ButtonMask.ZR;

        return Push(mask);
    }

    public static bool OnB()
    {
        int mask;
        if (PlayerWork.IsEasyInput())
            mask = GameController.ButtonMask.B | GameController.ButtonMask.Down;
        else
            mask = GameController.ButtonMask.B;

        return ButtonOn(mask);
    }

    public static bool PushAB()
    {
        return PushA() || PushB();
    }

    public static bool PushR()
    {
        return Push(GameController.ButtonMask.R);
    }

    public static bool PushL()
    {
        return Push(GameController.ButtonMask.L);
    }

    public static bool Push(int mask)
    {
        return (GameController.push & mask) != 0;
    }

    public static bool ButtonOn(int mask)
    {
        return (GameController.on & mask) != 0;
    }

    public static bool ButtonRelease(int mask)
    {
        return (GameController.release & mask) != 0;
    }
}