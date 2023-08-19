using Core.Animations;
using UnityEngine;
using Modules;
using Events;
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

        public void PlayWelcomeAnimation(OnStartDialogEvent data)
        {
            PlayAnimation(EpsilonAnimationType.Greeting);
        }

        new private void Start()
        {
            base.Start();
            EventSystem.Subscribe<OnStartDialogEvent>(PlayWelcomeAnimation);
        }

        new private void OnDestroy()
        {
            base.OnDestroy();
            EventSystem.Unsubscribe<OnStartDialogEvent>(PlayWelcomeAnimation);
        }
    }
}