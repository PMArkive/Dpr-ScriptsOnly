namespace Dpr.Battle.Logic
{
    public static class PokeID
    {
        public const byte NUM = 30;
        public const byte INVALID = 31;
        private static readonly byte[] ClientBasePokeID = new byte[5] { 0, 12, 6, 18, 24 };

        public static byte GetClientBasePokeId(BTL_CLIENT_ID clientID)
        {
            return ClientBasePokeID[(int)clientID];
        }

        public static bool IsClientsPokeID(BTL_CLIENT_ID clientID, byte pokeID)
        {
            var id = GetClientBasePokeId(clientID);
            return id <= pokeID && pokeID <= (byte)(id + 5);
        }

        public static byte GetClientPokeId(BTL_CLIENT_ID clientID, byte pokeIndex)
        {
            return (byte)(GetClientBasePokeId(clientID) + ((pokeIndex > 5) ? 0 : pokeIndex));
        }

        public static byte PokeIdToStartMemberIndex(byte pokeID)
        {
            var id = GetClientBasePokeId(PokeIdToClientId(pokeID));

            if (id > pokeID)
                return 0;

            if (id + 6 <= pokeID)
                return 0;

            return (byte)(pokeID - id);
        }

        public static BTL_CLIENT_ID PokeIdToClientId(byte pokeID)
        {
            for (int i=0; i<ClientBasePokeID.Length; i++)
            {
                var id = GetClientBasePokeId((BTL_CLIENT_ID)i);

                if (id <= pokeID && pokeID <= id + 5)
                    return (BTL_CLIENT_ID)i;
            }

            return BTL_CLIENT_ID.BTL_CLIENT_PLAYER;
        }

        public static byte PokeIdToShortId(byte pokeID)
        {
            var id = pokeID - GetClientBasePokeId(PokeIdToClientId(pokeID));

            if (id < 0)
                return 0;

            if (id > 5)
                return 0;

            return (byte)id;
        }

        public static byte ShortIdToPokeId(BTL_CLIENT_ID clientID, byte shortID)
        {
            if (shortID < 6 && (int)clientID < ClientBasePokeID.Length)
                return (byte)(GetClientBasePokeId(clientID) + shortID);
            else
                return INVALID;
        }
    }
}