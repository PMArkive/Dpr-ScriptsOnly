namespace Dpr.UnderGround.UgFather
{
	public class UgFatherInput
	{
		public static bool Talk => FieldInput.Push(GameController.ButtonMask.A);
        public static bool Decide => FieldInput.Push(GameController.ButtonMask.A);
    }
}