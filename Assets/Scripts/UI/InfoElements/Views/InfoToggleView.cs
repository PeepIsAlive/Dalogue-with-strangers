using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace UI.Views
{
    public sealed class InfoToggleView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _contentLabel;

        [Header("Images")]
        [SerializeField] private Image _checkmarkImage;
        [SerializeField] private Image _rootImage;

        public void SetText(string text)
        {
            if (_contentLabel == null)
                return;

            _contentLabel.text = text;
        }

        public void SetColor(Color? color)
        {
            if (color == null)
                return;

            if (_rootImage != null)
                _rootImage.color = (Color)color;

            if (_checkmarkImage != null)
                _checkmarkImage.color = (Color)color;
        }

        public void SetCheckmarkState(bool state)
        {
            _checkmarkImage?.gameObject.SetActive(state);
        }
    }
}