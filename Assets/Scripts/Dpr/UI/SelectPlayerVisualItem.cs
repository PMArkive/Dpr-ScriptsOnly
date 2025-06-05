namespace Dpr.UI
{
    public class SelectPlayerVisualItem : SelectOpeningItem
    {
        public bool sex = true;
        public int colorId;

        private void Awake()
        {
            var splitName = gameObject.name.Split(new char[1] { '_' });
            sex = int.Parse(splitName[0]) == 1;
            colorId = int.Parse(splitName[1]) - 1;
        }
    }
}