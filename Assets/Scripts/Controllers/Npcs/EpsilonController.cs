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
            _animator.SetTrigger(AnimationUtils.GetAnimationName(type));
        }
    }
}