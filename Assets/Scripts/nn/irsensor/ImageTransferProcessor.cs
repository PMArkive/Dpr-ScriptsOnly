using System;

namespace nn.irsensor
{
	public static class ImageTransferProcessor
	{
		public const int QvgaImageSize = 76800;
		public const int QqvgaImageSize = 19200;
		public const int QqqvgaImageSize = 4800;
		public const int ImageSize320x240 = 76800;
		public const int ImageSize160x120 = 19200;
		public const int ImageSize80x60 = 4800;
		public const int ImageSize40x30 = 1200;
		public const int ImageSize20x15 = 300;
		public const int QvgaWorkBufferSize = 155648;
		public const int QqvgaWorkBufferSize = 40960;
		public const int QqqvgaWorkBufferSize = 12288;
		public const int WorkBufferSize320x240 = 155648;
		public const int WorkBufferSize160x120 = 40960;
		public const int WorkBufferSize80x60 = 12288;
		public const int WorkBufferSize40x30 = 4096;
		public const int WorkBufferSize20x15 = 4096;
		public const long ExposureTimeMinNanoSeconds = 7000;
		public const long ExposureTimeMaxNanoSeconds = 600000;

		public static extern void GetDefaultConfig(ref ImageTransferProcessorConfig pOutValue);
		public static extern void GetDefaultConfig(ref ImageTransferProcessorExConfig pOutValue);
		public static extern void Run(IrCameraHandle handle, ImageTransferProcessorConfig config, IntPtr workBuffer, long workBufferSize);
		public static extern void Run(IrCameraHandle handle, ImageTransferProcessorExConfig config, IntPtr workBuffer, long workBufferSize);
		public static extern Result GetState(ref ImageTransferProcessorState pOutState, IntPtr pOutImage, long size, IrCameraHandle handle);
		public static extern void InitializeWorkBuffer(ref IntPtr pOutWorkBuffer, ref long pOutWorkBufferSize, ImageTransferProcessorConfig config);
		public static extern void InitializeWorkBuffer(ref IntPtr pOutWorkBuffer, ref long pOutWorkBufferSize, ImageTransferProcessorExConfig config);
		public static extern void DestroyWorkBuffer(IntPtr workBuffer);
		
		// TODO
		public static int GetWorkBufferSize(ImageTransferProcessorFormat format) { return default; }
		
		// TODO
		public static int GetImageSize(ImageTransferProcessorFormat format) { return default; }
		
		// TODO
		public static int GetImageWidth(ImageTransferProcessorFormat format) { return default; }
		
		// TODO
		public static int GetImageHeight(ImageTransferProcessorFormat format) { return default; }
	}
}