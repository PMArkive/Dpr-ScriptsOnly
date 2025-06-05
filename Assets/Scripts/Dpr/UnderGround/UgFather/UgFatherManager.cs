using SmartPoint.AssetAssistant;
using System.Collections;
using System.Collections.Generic;

namespace Dpr.UnderGround.UgFather
{
    public class UgFatherManager : SingletonMonoBehaviour<UgFatherManager>
    {
        private List<string> TypeId = new List<string>()
        {
            "TREASURE", "HEALING", "GOODS_S", "GOODS_L",
        };
        private const string UgFatherId = "FATHER";
        private List<UgFatherBase> fathers = new List<UgFatherBase>();
        private UgFatherBase currentFather;

        // TODO
        private IEnumerator Start() { return null; }

        // TODO
        private void OnDestroy() { }

        // TODO
        private void InputUpdate(float deltaTime) { }

        // TODO
        private UgFatherBase GetContactFather() { return null; }

        // TODO
        private void Setup() { }

        // TODO
        private IEnumerator DelaySetup() { return null; }

        // TODO
        private void OnEventEnd() { }

        // TODO
        public void Clear() { }

        private enum Type : int
        {
            Treasure = 0,
            Healing = 1,
            Goods_S = 2,
            Goods_L = 3,
        }
    }
}