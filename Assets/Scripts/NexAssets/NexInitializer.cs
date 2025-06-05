using UnityEngine;

namespace NexAssets
{
    public class NexInitializer : MonoBehaviour
    {
        [SerializeField]
        private NexInitParam nexInitParam = new NexInitParam();

        public Common.NEX_INIT_PARAM GetNexInitParam()
        {
            return nexInitParam.GetNexInitParam();
        }
    }
}