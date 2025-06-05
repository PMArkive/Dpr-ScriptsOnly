using System;

namespace Dpr
{
    public static class PlayTimeManager
    {
        private static bool _isInitialized = false;
        private static DateTime _prevDateTime;
        private static int _limitSec = 3599999;
        private static int _limitAddSec = 1;

        public static bool isInitialized { get => _isInitialized; }

        // TODO
        public static void Initialize() { }

        // TODO
        private static void OnUpdate(float deltaTime) { }
    }
}