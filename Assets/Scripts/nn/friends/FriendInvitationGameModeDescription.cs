using System.Text;

namespace nn.friends
{
	public struct FriendInvitationGameModeDescription
	{
		public const int TextSize = 192;

		private byte[] data;
		
		public string enUs   { get => Get(Language.EnUs);   set => Set(value, Language.EnUs); }
		public string enGb   { get => Get(Language.EnGb);   set => Set(value, Language.EnGb); }
        public string ja     { get => Get(Language.Ja);     set => Set(value, Language.Ja); }
        public string fr     { get => Get(Language.Fr);     set => Set(value, Language.Fr); }
        public string de     { get => Get(Language.De);     set => Set(value, Language.De); }
        public string es419  { get => Get(Language.Es419);  set => Set(value, Language.Es419); }
        public string es     { get => Get(Language.Es);     set => Set(value, Language.Es); }
        public string it     { get => Get(Language.It);     set => Set(value, Language.It); }
        public string nl     { get => Get(Language.Nl);     set => Set(value, Language.Nl); }
        public string frCa   { get => Get(Language.FrCa);   set => Set(value, Language.FrCa); }
        public string pt     { get => Get(Language.Pt);     set => Set(value, Language.Pt); }
        public string ru     { get => Get(Language.Ru);     set => Set(value, Language.Ru); }
        public string zhHans { get => Get(Language.ZhHans); set => Set(value, Language.ZhHans); }
        public string zhHant { get => Get(Language.ZhHant); set => Set(value, Language.ZhHant); }
        public string ko     { get => Get(Language.Ko);     set => Set(value, Language.Ko); }
        public string ptBr   { get => Get(Language.ptBr);   set => Set(value, Language.ptBr); }

        private string Get(Language language)
		{
			if (data != null)
				return Encoding.UTF8.GetString(data, (int)language * TextSize, TextSize);
			else
				return string.Empty;
		}
		
		// TODO
		private void Set(string value, Language language) { }

		private enum Language : int
		{
			EnUs = 0,
			EnGb = 1,
			Ja = 2,
			Fr = 3,
			De = 4,
			Es419 = 5,
			Es = 6,
			It = 7,
			Nl = 8,
			FrCa = 9,
			Pt = 10,
			Ru = 11,
			ZhHans = 12,
			ZhHant = 13,
			Ko = 14,
			ptBr = 15,
			Length = 16,
		}
	}
}