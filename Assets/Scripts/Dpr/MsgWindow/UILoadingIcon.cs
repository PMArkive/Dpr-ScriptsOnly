using UnityEngine;

namespace Dpr.MsgWindow
{
    public class UILoadingIcon
    {
        private readonly int playAnimHash = Animator.StringToHash("NetLoadingIcon1");
        private Animator loadingAnimator;
        private GameObject iconPrefab;
        private bool bIsPlayAnim;

        public void Setup(GameObject iconPrefab)
        {
            this.iconPrefab = iconPrefab;
            loadingAnimator = iconPrefab.GetComponent<Animator>();

            if (iconPrefab == null || !iconPrefab.activeSelf)
                return;

            bIsPlayAnim = false;
            iconPrefab.SetActive(false);
        }

        public void OnFinalize()
        {
            Object.Destroy(iconPrefab);
        }

        public void PlayAnim()
        {
            if (bIsPlayAnim)
                return;

            loadingAnimator.Play(playAnimHash);
        }

        public void SetLoadingIconActive(bool active)
        {
            if (iconPrefab == null || iconPrefab.activeSelf == active)
                return;

            bIsPlayAnim = active;
            iconPrefab.SetActive(active);
        }
    }
}