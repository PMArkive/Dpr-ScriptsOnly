namespace DPData
{
    public static class TopMenuWork
    {
        public const int TOPMENUITEM_NUM = 8;

        public static TOPMENU_WORK Create()
        {
            var work = new TOPMENU_WORK();
            work.items = new TOPMENUITEM_WORK[TOPMENUITEM_NUM];

            work.items[0].isNew = true;
            work.items[0].index = 0;

            work.items[1].isNew = true;
            work.items[1].index = 1;

            work.items[2].isNew = true;
            work.items[2].index = 2;

            work.items[3].isNew = true;
            work.items[3].index = 3;

            work.items[4].isNew = true;
            work.items[4].index = 4;

            work.items[5].isNew = true;
            work.items[5].index = 5;

            work.items[6].isNew = true;
            work.items[6].index = 6;

            work.items[7].isNew = true;
            work.items[7].index = 7;

            work.selectType = TOPMENUITEMTYPE.BAG;
            return work;
        }
    }
}