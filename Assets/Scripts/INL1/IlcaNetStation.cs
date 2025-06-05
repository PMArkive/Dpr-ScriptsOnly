using System.ComponentModel;

namespace INL1
{
	public class IlcaNetStation : IlcaNetTransport
	{
		public IlcaNetStation()
        {
            // Empty, declared explicitly
        }

        ~IlcaNetStation()
		{
			// Empty
		}
		
		// TODO
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Init() { }

        // TODO
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Boot() { }
		
		// TODO
		private void CleanUp() { }

        // TODO
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Final() { }
	}
}