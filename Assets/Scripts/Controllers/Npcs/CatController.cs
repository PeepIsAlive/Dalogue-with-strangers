using System.Collections;
using Core.Animations;
using UnityEngine;
using System.Linq;
using Extensions;
using System;
using Utils;

namespace Controllers
{
    public sealed class CatController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void PlayAnimation(CatAnimationType type)
        {
            var clipInfo = _animator.GetCurrentAnimatorStateInfo(0);
            var idleAnimationName = AnimationUtils.GetAnimationName(CatAnimationType.Idle);

            if (!clipInfo.IsName(idleAnimationName))
                return;

            _animator?.SetTrigger(AnimationUtils.GetAnimationName(type));
        }

        private IEnumerator AnimationRoutine()
        {
            PlayAnimation(GetRandomAnimation());

            yield return new WaitForSecondsRealtime(15f);
            yield return StartCoroutine(AnimationRoutine());
        }

        private static CatAnimationType GetRandomAnimation()
        {
            return Enum.GetValues(typeof(CatAnimationType))
                .OfType<CatAnimationType>().Skip(3).ToList().GetRandomElement();
        }

        private void Start()
        {
            StartCoroutine(AnimationRoutine());
        }
    }
}