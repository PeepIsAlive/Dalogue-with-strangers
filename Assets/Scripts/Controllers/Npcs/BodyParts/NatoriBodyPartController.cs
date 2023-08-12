using Core.Animations;
using UnityEngine;

namespace Controllers
{
    public sealed class NatoriBodyPartController : MonoBehaviour
    {
        [SerializeField] private NatoriAnimationType animationType;
        private NatoriController _controller;

        public void StartAnimation()
        {
            _controller?.PlayAnimation(animationType);
        }

        private void Start()
        {
            _controller = GetComponentInParent<NatoriController>();
        }
    }
}