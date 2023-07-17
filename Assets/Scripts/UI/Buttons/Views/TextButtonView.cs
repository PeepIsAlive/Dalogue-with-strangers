using UnityEngine;
using TMPro;

namespace UI.Views
{
    public sealed class TextButtonView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _titleLabel;

        public void SetText(string text)
        {
            if (_titleLabel == null)
                return;

            _titleLabel.text = text;
        }
    }
}
