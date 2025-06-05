using System.Collections;
using UnityEngine;

namespace Dpr.UI
{
    public class TownmapIcon : MonoBehaviour
    {
        protected static readonly int animStateIn = Animator.StringToHash("in");
        protected Animator _animator;

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        protected virtual void OnEnable()
        {
            if (_animator != null)
                StartCoroutine(OpPlay());
        }

        protected virtual IEnumerator OpPlay()
        {
            while (!_animator.isActiveAndEnabled)
                yield return null;

            _animator.Play(animStateIn, 0, 0.0f);
        }
    }
}