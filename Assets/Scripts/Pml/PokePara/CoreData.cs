namespace Pml.PokePara
{
	public struct CoreData
	{
		public const int SIZE = 328;
		public const int CORE_DATA_BLOCK_SIZE = 80;

		public CoreDataHeader header;
		public unsafe fixed byte blocks[320]; // TODO: Find a constant for this?
	}
}