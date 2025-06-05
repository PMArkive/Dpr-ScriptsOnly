namespace nn.friends
{
	public struct FriendFilter
	{
		public PresenceStatusFilter presenceStatus;
		public bool isFavoriteOnly;
		public bool isSameAppPresenceOnly;
		public bool isSameAppPlayedOnly;
		public bool isArbitraryAppPlayedOnly;
		public ulong presenceGroupId;
		
		// TODO
		public override string ToString() { return default; }
	}
}