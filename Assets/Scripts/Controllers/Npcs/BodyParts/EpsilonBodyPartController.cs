using Core.Animations;
using UnityEngine;

namespace Controllers
{
    public sealed class EpsilonBodyPartController : MonoBehaviour
    {
        [SerializeField] private EpsilonAnimationType animationType;
        private EpsilonController _controller;

        public void StartAnimation()
        {
            _controller?.PlayAnimation(animationType);
        }

        private void Start()
        {
            _controller = GetComponentInParent<EpsilonController>();
        }
    }
}