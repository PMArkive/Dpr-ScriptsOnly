using SmartPoint.AssetAssistant.UnityExtensions;
using System.IO;
using UnityEngine.Networking;

namespace SmartPoint.AssetAssistant
{
    public class InstallHandler : DownloadHandlerScript
    {
        private ulong _contentLength;
        private FileStream _fileStream;
        private int _offsetInBytes;
        private string _installFileName = string.Empty;
        private static string _installPath = string.Empty;

        public static string installPath { get => _installPath; set => _installPath = value; }

        public InstallHandler(string fileName, byte[] preallocatedBuffer) : base(preallocatedBuffer)
        {
            _installFileName = fileName;
        }

        public InstallHandler(string fileName, int cacheSize) : base(new byte[cacheSize])
        {
            _installFileName = fileName;
        }

        public InstallHandler(string fileName)
        {
            _installFileName = fileName;
        }

        protected override bool ReceiveData(byte[] data, int bytesToRead)
        {
            if (_fileStream == null)
            {
                string path = _installPath.CombinePath(_installFileName);
                string dir = Path.GetDirectoryName(path);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                _fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            }

            _fileStream.Write(data, 0, bytesToRead);
            _offsetInBytes += bytesToRead;
            return true;
        }

        protected override void ReceiveContentLengthHeader(ulong contentLength)
        {
            _contentLength = contentLength;
        }

        protected override void CompleteContent()
        {
            CloseStream();
        }

        private void CloseStream()
        {
            if (_fileStream != null)
            {
                _fileStream.Flush();
                _fileStream.Close();
            }

            _fileStream = null;
        }

        protected override float GetProgress()
        {
            if (_contentLength != 0)
                return (float)_offsetInBytes / _contentLength;

            return 0.0f;
        }
    }
}