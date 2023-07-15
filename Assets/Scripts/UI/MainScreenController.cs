using UnityEngine.UI;
using UnityEngine;

namespace UI.Controllers
{
    public sealed class MainScreenController : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _changeNpcButton;

        private void OnMenuButtonClick()
        {

        }

        private void OnChangeNpcButtonClick()
        {

        }

        private void Start()
        {
            _menuButton?.onClick.AddListener(OnMenuButtonClick);
            _changeNpcButton?.onClick.AddListener(OnChangeNpcButtonClick);
        }

        private void OnDestroy()
        {
            _menuButton?.onClick?.RemoveListener(OnMenuButtonClick);
            _changeNpcButton?.onClick?.RemoveListener(OnChangeNpcButtonClick);
        }
    }
}