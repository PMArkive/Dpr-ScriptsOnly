using Dpr.NetworkUtils;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.SubContents
{
    public abstract class NetUseManager<T> : SingletonMonoBehaviour<T> where T : NetUseManager<T>
    {
        protected OpcManager _OpcManager;
        [SerializeField]
        private List<INetData> netDatas;
        protected SessionManager sessionManager;
        protected OnlinePlayerCharacter myPlayer;
        protected MatchingParam matchingParam;
        private NetRequestData netRequestData = new NetRequestData();
        private ZoneID[] enableZones;
        private MapType enableMapType = MapType.MAPTYPE_NOWHERE;
        [Space(30.0f)]
        [SerializeField]
        private int createCharacterID;
        [SerializeField]
        private int destroyCharacterID;
        [SerializeField]
        private Vector3 nextPos;
        [SerializeField]
        private int saveCount;
        [SerializeField]
        private int curSaveCount;
        [Button("_Debug_SaveCharacterPosition", "_Debug_SaveCharacterPosition", new object[0] { })]
        public int Button03;
        [Button("_Debug_SaveCharacterPosition", "_Debug_SaveCharacterPosition", new object[0] { })]
        public int Button04;

        // TODO
        protected virtual IEnumerator Start() { return null; }

        protected abstract void Init();

        protected abstract void MyUpdate(float deltaTime);

        // TODO
        protected virtual void SetNetData(INetData netDatas) { }

        protected abstract IEnumerator LoadAsset();

        public abstract void SetMatchingParam(MatchingParam matchingParam);

        // TODO
        public void SetEnableZone(ZoneID[] enableZones) { }

        // TODO
        public void SetEnableZone(MapType mapType) { }

        // TODO
        private void OnZoneChange() { }

        // TODO
        protected virtual void OnDestroy() { }

        // TODO
        protected virtual void OnReceiveData(INetData netData) { }

        // TODO
        protected virtual void OnSessionEvent(SessionEventData eventData) { }

        // TODO
        protected void RequestNetData(byte dataID) { }

        // TODO
        public void Talk() { }

        // TODO
        public void _Debug_RemoveNetCharacter() { }

        // TODO
        public void _Debug_SaveCharacterPosition() { }

        // TODO
        private bool CheckSavePosCount() { return false; }

        // Do we need <T> here?
        [Serializable]
        public class OPCNetTestPosition
        {
	        public GameObject go;
            public float radius = 2.0f;
            public float speed = 2.0f;
            private Vector3 CurrentPos;
            private Vector3 InitPos;

            public OPCNetTestPosition(Vector3 InitPos)
            {
                go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                this.InitPos = InitPos;
            }

            // TODO
            public void SetTsetPos() { }

            public Vector3 GetPos()
            {
                return CurrentPos;
            }
        }
    }
}