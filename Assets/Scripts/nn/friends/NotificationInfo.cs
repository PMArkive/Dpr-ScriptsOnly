using nn.account;

namespace nn.friends
{
	public struct NotificationInfo
	{
		public NotificationType type;
		public NetworkServiceAccountId accountId;
		
		// TODO
		public override string ToString() { return default; }
	}
}