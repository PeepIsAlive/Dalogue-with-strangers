using Core.Animations;
using UnityEngine;

namespace Controllers
{
    public sealed class CatBodyPartController : MonoBehaviour
    {
        [SerializeField] private CatAnimationType animationType;
        private CatController _controller;

        public void StartAnimation()
        {
            _controller?.PlayAnimation(animationType);
        }

        private void Start()
        {
            _controller = GetComponentInParent<CatController>();
        }
    }
}