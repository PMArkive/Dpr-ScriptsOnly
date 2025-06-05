using Dpr.UI;
using System.Collections;
using UnityEngine;

namespace Dpr.SecretBase
{
    public class SecretBaseController : MonoBehaviour
    {
        [SerializeField]
        private StatuePlacementEditController statuePlacement;
        [SerializeField]
        private SecretBaseCamera secretBaseCamera;
        [SerializeField]
        private SecretBaseZoomCamera zoomCamera;
        [SerializeField]
        private SecretBaseMasterDataManager masterData;
        [SerializeField]
        private StatueEffectWindow statueEffectWindow;
        [SerializeField]
        private SecretBaseCrystalEffectManager crystalEffectManager;
        [SerializeField]
        private BoxCollider exitArea;
        [SerializeField]
        private SecretBaseAudioManager audioManager;
        [SerializeField]
        private SecretBaseNamePlate namePlate;
        [SerializeField]
        private FieldCrystalEntity crystalEntity;
        private int initFacial;
        private FieldConnector fieldConnector;
        private bool isHaveState;
        private bool isExited;
        private bool isMineSecretBase = true;
        private State state;
        private ContextMenuItem selectedItem;

        // TODO
        public IEnumerator ActivateOperation(FieldConnector fieldConnector) { return null; }

        // TODO
        public void OnUpdate(float deltaTime) { }

        // TODO
        private bool IsEnableInput() { return false; }

        // TODO
        private void SystemInitialize() { }

        // TODO
        private IEnumerator Load() { return null; }

        // TODO
        private void Initialize() { }

        // TODO
        private void SetState(State state) { }

        // TODO
        private void SetStatueViewMode(bool isView) { }

        // TODO
        private void SelectCamera(CameraMode mode) { }

        // TODO
        private void ShowPcContextMenu() { }

        // TODO
        private bool CheckExit() { return false; }

        // TODO
        private void ExitSecretBase() { }

        // TODO
        private void SaveReport() { }

        // TODO
        private void ResetPostProcessFilter() { }

        private enum State : int
        {
            SecretBase = 0,
            PcMenu = 1,
            Zoom = 2,
            IdleMessage = 3,
            StatueEffectWindow = 4,
            StatuePlacementEdit = 5,
        }

        private enum CameraMode : int
        {
            Field = 0,
            Zoom = 1,
            StatueEdit = 2,
        }
    }
}