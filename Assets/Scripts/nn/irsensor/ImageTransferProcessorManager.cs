using System;

namespace nn.irsensor
{
	public class ImageTransferProcessorManager
	{
		private ImageTransferProcessorState state;

		public ImageTransferProcessorState State => state;
        public byte[] ImageBuffer { get; set; }

        private IntPtr pWorkBuffer = IntPtr.Zero;
		private long workBufferSize;
		private ImageTransferProcessorExConfig config;
		private IrCameraHandle handle;
		
		// TODO
		~ImageTransferProcessorManager() { }
		
		// TODO
		public void Initialize(IrCameraHandle handle, ImageTransferProcessorFormat format) { }
		
		// TODO
		public void Initialize(IrCameraHandle handle, ImageTransferProcessorConfig config) { }
		
		// TODO
		public void Initialize(IrCameraHandle handle, ImageTransferProcessorExConfig config) { }
		
		// TODO
		public void Destroy() { }
		
		// TODO
		public bool IsRunning() { return default; }
		
		// TODO
		public void Run() { }
		
		// TODO
		public Result Update() { return default; }
		
		// TODO
		public void Stop() { }
		
		// TODO
		private void _Destroy() { }
	}
}