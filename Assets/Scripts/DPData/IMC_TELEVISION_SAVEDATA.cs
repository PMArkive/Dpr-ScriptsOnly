namespace DPData
{
	internal struct IMC_TELEVISION_SAVEDATA
	{
		public uint init_flag;
		public IMC_SAVEDATA_POKEMON pokemon;
		public uint accessory_set_msk;
		public PMS_DATA title;
		public IMC_SAVEDATA_ACCESSORIE[] acce;
		public byte bg_id;
		public byte country;
	}
}