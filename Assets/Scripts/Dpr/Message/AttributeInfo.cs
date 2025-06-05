﻿namespace Dpr.Message
{
    public class AttributeInfo
    {
        public int gender = -1;
        public int initialSound = -1;
        public int countability = -1;
        public int displayPattern = -1;
        public int articlePresence = -1;

        public AttributeInfo(int[] attriValueArray)
        {
            gender = attriValueArray[0];
            initialSound = attriValueArray[1];
            countability = attriValueArray[2];
            displayPattern = attriValueArray[3];
            articlePresence = attriValueArray[4];
        }
    }
}