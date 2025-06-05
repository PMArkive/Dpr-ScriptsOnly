using System.ComponentModel;

namespace INL1
{
	public class IlcaNetGamer : IlcaNetTransport
	{
		private bool isActive;
		private int myGlobalIndex = -1;
		private int myLocalIndex = -1;
		private bool isHomeGamer;
		public string gamerName = " ";
		public byte nameStringLanguage = 1;
		public int TURNenable;
		
		~IlcaNetGamer()
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
        public void Final() { }
		
		// TODO
		private void CleanUp() { }

        // TODO
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CopyTo(ref IlcaNetGamer dst) { }
		
		// TODO
		public bool IsActive() { return default; }

        // TODO
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ActiveON() { }

        // TODO
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ActiveOFF() { }
		
		// TODO
		public bool IsHomeGamer() { return default; }

        // TODO
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void HomeGamerON() { }

        // TODO
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void HomeGamerOFF() { }

        // TODO
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void LocalIndexSet(int localindex, int portOffset = 0) { }

        // TODO
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void GlobalIndexSet(int globalindex) { }
		
		// TODO
		public override int Send(PacketWriter pw, IlcaNetPacketType type) { return default; }
		
		// TODO
		public override int SendTo(PacketWriter pw, IlcaNetPacketType type, int stationIndex) { return default; }
		
		// TODO
		public override int Recv(ref PacketReader pr) { return default; }
	}
}