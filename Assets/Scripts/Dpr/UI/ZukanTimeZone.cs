using UnityEngine;
using XLSXContent;

namespace Dpr.UI
{
    public class ZukanTimeZone : MonoBehaviour
    {
        private readonly int _animParamStateId = Animator.StringToHash("stateId");
        private readonly int _animParamConnectIdSrc = Animator.StringToHash("connectId01");
        private readonly int _animParamConnectIdDest = Animator.StringToHash("connectId02");
        private Animator _animator;
        private int _connectId = -1;

        public SheetDistributionTable.TimeZoneType timeZone { get => (SheetDistributionTable.TimeZoneType)(_connectId-1); }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Set(int connectId)
        {
            Change(connectId, 0);
        }

        public void Move(int move)
        {
            Change(_connectId == -1 ? 1 : UIManager.Repeat(_connectId + move, 1, 3));
        }

        private void Change(int connectId, int stateId = 1)
        {
            _animator.SetInteger(_animParamConnectIdSrc, _connectId);
            _animator.SetInteger(_animParamConnectIdDest, connectId);
            _animator.SetInteger(_animParamStateId, stateId);

            _connectId = connectId;
        }

        public static int ToConnectId(PeriodOfDay periodOfDay)
        {
            switch (periodOfDay)
            {
                case PeriodOfDay.Morning:
                    return 1;

                case PeriodOfDay.Daytime:
                case PeriodOfDay.Evening:
                    return 2;

                case PeriodOfDay.Night:
                case PeriodOfDay.Midnight:
                    return 3;

                default:
                    return -1;
            }
        }
    }
}