using UnityEngine.Events;
using Core.Animations;
using UnityEngine;
using Utils;

namespace Controllers
{
    public sealed class NatoriController : NpcController, IAnimable<NatoriAnimationType>
    {
        [SerializeField] private UnityEvent<NatoriAnimationType> _onClickEvent;
        [SerializeField] private Animator _animator;

        public void SetAnimation(NatoriAnimationType type)
        {

        }

        public void PlayAnimation(NatoriAnimationType type)
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