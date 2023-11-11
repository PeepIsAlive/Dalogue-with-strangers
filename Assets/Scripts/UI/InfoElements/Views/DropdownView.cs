using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using TMPro;

namespace UI.Views
{
    public sealed class DropdownView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _dropdownTitle;
        [SerializeField] private List<Image> _images;

        public void SetTitle(string text)
        {
            if (_dropdownTitle == null)
                return;

            _dropdownTitle.text = text;
        }

        public void SetColor(Color? color)
        {
            if (_images == null || !_images.Any())
                return;

            _images.ForEach(image =>
            {
                if (image == null || color == null)
                    return;

                image.color = (Color)color;
            });
        }
    }
}