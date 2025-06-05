namespace nn.hid
{
	public static class VibrationFile
	{
		// TODO
		public static ErrorRange ResultInvalid { get; }

		public static extern Result Parse(ref VibrationFileInfo pOutInfo, ref VibrationFileParserContext pOutContext, byte[] address, long fileSize);
		public static extern void RetrieveValue(ref VibrationValue pOutValue, int position, ref VibrationFileParserContext pContext);
		private static extern void Generate(ref long pOutSize, byte[] outBuffer, long bufferSize, VibrationValueArrayInfo info, VibrationValue[] pValues);
		
		// TODO
		public static void Generate(ref long pOutSize, byte[] outBuffer, VibrationValueArrayInfo info, VibrationValue[] pValues) { }

		public static extern long CalculateSize(VibrationValueArrayInfo info);
	}
}