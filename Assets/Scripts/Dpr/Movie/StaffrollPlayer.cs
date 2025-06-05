using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

namespace Dpr.Movie
{
    public class StaffrollPlayer : MonoBehaviour
    {
        [SerializeField]
        private StaffrollList _staffRollData;
        [SerializeField]
        private GameObject _staffRollRowCanvas;
        private StaffrollRow[] _staffRollRows;
        private List<StaffrollRow> _activeRows;
        private List<StaffrollRow> _deactiveRows;
        private float _displayHeight;
        private int _dataIndex;
        private float _time;
        private float _currentSpeed;
        private float _currentSize;
        private Sprite _logoSprite;
        private Sprite _endTextSprite;
        private Vector2 _logoSize;
        private Vector2 _endTextSize;

        // TODO
        public void Initialize() { }

        // TODO
        public void SetTextures(Texture2D logoTex, Texture2D endTextTex) { }

        // TODO
        public void OnUpadate(float time) { }

        // TODO
        private void SetData(float time, float dataTime, StaffrollList.SheetStaffroll data) { }

        // TODO
        private void UpdateRow(float time, StaffrollRow row) { }
    }
}
