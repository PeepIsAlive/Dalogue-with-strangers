using UnityEngine.Events;
using Core.Animations;
using UnityEngine;
using Utils;

namespace Controllers
{
    public sealed class EpsilonController : NpcController, IAnimable<EpsilonAnimationType>
    {
        [SerializeField] private Animator _animator;

        public void PlayAnimation(EpsilonAnimationType type)
        {
            var clipInfo = _animator.GetCurrentAnimatorStateInfo(0);
            var animationName = AnimationUtils.GetAnimationName(EpsilonAnimationType.Idle);

            if (!clipInfo.IsName(animationName))
                return;

            _animator.SetTrigger(AnimationUtils.GetAnimationName(type));
        }
    }
}