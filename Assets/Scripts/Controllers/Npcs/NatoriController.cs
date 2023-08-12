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
            _animator.SetTrigger(AnimationUtils.GetAnimationName(type));
        }
    }
}