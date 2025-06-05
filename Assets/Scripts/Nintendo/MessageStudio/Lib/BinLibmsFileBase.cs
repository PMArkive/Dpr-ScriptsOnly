using System;
using System.Runtime.InteropServices;

namespace Nintendo.MessageStudio.Lib
{
    public abstract class BinLibmsFileBase : IDisposable
    {
        private IntPtr resourceFilePtr = IntPtr.Zero;
        private IntPtr fileObjectPtr = IntPtr.Zero;
        private static LoadResource loadResourceFunc;
        private bool disposedValue;

        protected IntPtr FileObjectPtr { get => fileObjectPtr; }
        public bool IsFileLoaded { get => fileObjectPtr != IntPtr.Zero; }

        public static void SetLoadResourceFunc(LoadResource func)
        {
            loadResourceFunc = func;
        }

        public void Load(string fileName)
        {
            ResetResourceFilePtr(loadResourceFunc.Invoke(fileName));
        }

        protected void ResetResourceFilePtr(IntPtr resourceFilePtr)
        {
            Dispose();
            this.resourceFilePtr = resourceFilePtr;
            if (resourceFilePtr != IntPtr.Zero)
                fileObjectPtr = InitObject(resourceFilePtr);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue)
                return;

            if (fileObjectPtr != IntPtr.Zero)
            {
                CloseObject(fileObjectPtr);
                fileObjectPtr = IntPtr.Zero;
            }

            if (resourceFilePtr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(resourceFilePtr);
                resourceFilePtr = IntPtr.Zero;
            }

            disposedValue = true;
        }

        ~BinLibmsFileBase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected abstract IntPtr InitObject(IntPtr resourcePtr);

        protected abstract void CloseObject(IntPtr objectPtr);
    }
}