using UnityEngine.Events;
using Core.Animations;
using UnityEngine;
using Utils;

namespace Controllers
{
    public sealed class EpsilonController : NpcController, IAnimable<EpsilonAnimationType>
    {
        [SerializeField] private UnityEvent<EpsilonAnimationType> _onClickEvent;
        [SerializeField] private Animator _animator;

        public void PlayAnimation(EpsilonAnimationType type)
        {
            _animator.SetTrigger(AnimationUtils.GetAnimationName(type));
        }

        private void Start()
        {
            _onClickEvent.AddListener(PlayAnimation);
        }

        private void OnDestroy()
        {
            _onClickEvent.RemoveListener(PlayAnimation);
        }
    }
}