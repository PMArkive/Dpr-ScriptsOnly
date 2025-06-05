using UnityEngine;

namespace Dpr.Field.Walking
{
    public interface ICorSystem
    {
        void Cancel();

        void Pause();

        Coroutine Restart();
    }
}