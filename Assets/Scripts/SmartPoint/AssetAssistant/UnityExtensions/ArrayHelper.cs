using System.Linq;

namespace SmartPoint.AssetAssistant.UnityExtensions
{
    public class ArrayHelper
    {
        public static T[] Empty<T>()
        {
            return Enumerable.Empty<T>() as T[];
        }
    }
}