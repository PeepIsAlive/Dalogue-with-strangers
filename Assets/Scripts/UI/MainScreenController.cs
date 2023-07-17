using Application = Live_2D.Application;
using System.Collections.Generic;
using UnityEngine;
using UI.Settings;

namespace UI.Controllers
{
    public sealed class MainScreenController : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private ImageButtonController _sendButton;
        [SerializeField] private ImageButtonController _menuButton;
        [SerializeField] private ImageButtonController _changeNpcButton;

        private void OnMenuButtonClick()
        {
            
        }

        private void OnChangeNpcButtonClick()
        {
            Application.PopupViewManager.Show(new DefaultPopup
            {
                Title = "[test] Title",
                Content = "{test] Content",
                ButtonSettings = new List<TextButtonSettings>
                {
                    new TextButtonSettings
                    {
                        Title = "[test] Title button 1"
                    },
                    new TextButtonSettings
                    {
                        Title = "[test] Title button 2"
                    }
                }
            });
        }

        private void OnSendButtonClick()
        {

        }

        private void Start()
        {
            _sendButton.Setup(new ImageButtonSettings
            {
                Action = OnSendButtonClick
            });
            _menuButton.Setup(new ImageButtonSettings
            {
                Action = OnMenuButtonClick
            });
            _changeNpcButton.Setup(new ImageButtonSettings
            {
                Action = OnChangeNpcButtonClick
            });
        }
    }
}