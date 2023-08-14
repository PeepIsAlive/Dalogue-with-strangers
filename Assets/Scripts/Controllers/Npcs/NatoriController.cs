using Core.Animations;
using UnityEngine;
using Utils;

namespace Controllers
{
    public sealed class NatoriController : NpcController, IAnimable<NatoriAnimationType>
    {
        [SerializeField] private Animator _animator;

        public void PlayAnimation(NatoriAnimationType type)
        {
            var clipInfo = _animator.GetCurrentAnimatorStateInfo(0);
            var animationName = AnimationUtils.GetAnimationName(NatoriAnimationType.Idle);

            if (!clipInfo.IsName(animationName))
                return;

            _animator.SetTrigger(AnimationUtils.GetAnimationName(type));
        }
    }
}