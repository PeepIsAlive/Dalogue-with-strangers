using DG.Tweening;
using UnityEngine;
using TMPro;

namespace UI.Controllers
{
    public sealed class BubbleController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;

        public void AddText(string text)
        {
            if (_label == null)
                return;

            _label.text += $"{text} ";
        }

        private void OnEnable()
        {
            var startSize = transform.localScale;
            var endSize = new Vector3(0f, 0f, 1f);

            transform.localScale = endSize;
            transform.DOScale(startSize, 0.15f)
                .SetLink(gameObject)
                .SetEase(Ease.Linear);
        }
    }
}