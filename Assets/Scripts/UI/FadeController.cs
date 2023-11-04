using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using System;

namespace UI.Controllers
{
    public sealed class FadeController : MonoBehaviour
    {
        public static FadeController Instance { get; private set; }

        [SerializeField] private Image _image;
        private const float _fadeDuration = 1.1f;

        public void FadeOffWithDelay(float delay, Action onFadeOffAction = null)
        {
            StartCoroutine(FadeOffRoutine());

            IEnumerator FadeOffRoutine()
            {
                yield return new WaitForSecondsRealtime(delay);
                FadeOff(onFadeOffAction);
                yield break;
            }
        }

        public void FadeOnWithDelay(float delay, Action onFadeOnAction = null)
        {
            StartCoroutine(FadeOnRoutine());

            IEnumerator FadeOnRoutine()
            {
                yield return new WaitForSecondsRealtime(delay);
                FadeOn(onFadeOnAction);
                yield break;
            }
        }

        public void FadeOff(Action onFadeOffAction = null)
        {
            _image.DOFade(0f, _fadeDuration)
                .SetLink(gameObject)
                .OnKill(() =>
                {
                    _image.enabled = false;
                    onFadeOffAction?.Invoke();
                });
        }

        public void FadeOn(Action onFadeOnAction = null)
        {
            _image.enabled = true;
            _image.DOFade(1f, _fadeDuration)
                .SetLink(gameObject)
                .OnKill(() =>
                {
                    onFadeOnAction?.Invoke();
                });
        }

        private void Start()
        {
            FadeOff();
        }

        private void Awake()
        {
            Instance = this;
        }
    }
}