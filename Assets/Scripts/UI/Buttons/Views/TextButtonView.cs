using UnityEngine;
using TMPro;

namespace UI.Views
{
    public sealed class TextButtonView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;

        public void SetText(string text)
        {
            if (_label == null)
                return;

            _label.text = text;
        }
    }
}
