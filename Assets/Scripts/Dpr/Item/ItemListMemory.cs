namespace Dpr.Item
{
    public class ItemListMemory
    {
        public int CategoryIndex { get; set; }
        public int[] Indexes { get; set; }
        public float[] ScrollPositions { get; set; }
        public int CurrentIndex { get => Indexes[CategoryIndex]; }
        public float CurrentScrollPosition { get => ScrollPositions[CategoryIndex]; }

        public ItemListMemory()
        {
            CategoryIndex = 0;
            Indexes = new int[9];
            ScrollPositions = new float[Indexes.Length];
        }

        public void SetCategory(int index)
        {
            CategoryIndex = index;
        }

        public void SetIndexAndScrollPosition(int index, float pos)
        {
            Indexes[CategoryIndex] = index;
            ScrollPositions[CategoryIndex] = pos;
        }

        public void Reset()
        {
            CategoryIndex = 0;
            for (int i = 0; i < Indexes.Length; i++)
                Indexes[i] = 0;

            for (int i = 0; i < ScrollPositions.Length; i++)
                ScrollPositions[i] = 0.0f;
        }
    }
}