using Application = Live_2D.Application;
using System.Collections.Generic;
using Localization;
using System.Linq;
using UnityEngine;
using UI.Settings;
using Settings;
using System;
using Scenes;
using Core;

namespace UI.Controllers
{
    public sealed class MainScreenController : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private ImageButtonController _sendButton;
        [SerializeField] private ImageButtonController _menuButton;
        [SerializeField] private ImageButtonController _changeNpcButton;

        private NpcCommonSettings _npcCommonSettings;

        private void OnMenuButtonClick()
        {
            
        }

        private void OnChangeNpcButtonClick()
        {
            var buttonSettings = new List<TextButtonSettings>();
            var npcTypes = Enum.GetValues(typeof(NpcType)).OfType<NpcType>().ToList();

            npcTypes.Remove(Application.CurrentNpcType);
            npcTypes.ForEach(type =>
            {
                buttonSettings.Add
                (
                    new TextButtonSettings
                    {
                        Title = _npcCommonSettings.GetNpcName(type),
                        Action = () =>
                        {
                            Main.LoadScene(_npcCommonSettings.GetPreset(type).Id);
                        }
                    }
                );
            });

            buttonSettings.Add
            (
                new TextButtonSettings
                {
                    Title = LocalizationProvider.GetText("button_title/cancel"),
                    Action = () =>
                    {
                        Application.PopupViewManager.HideCurrentPopup();
                    }
                }
            );

            Application.PopupViewManager.Show(new DefaultPopup
            {
                Title = LocalizationProvider.GetText("popup_title/change_npc"),
                Content = LocalizationProvider.GetText("popup_content/change_npc"),
                ButtonSettings = buttonSettings
            });
        }

        private void OnSendButtonClick()
        {

        }

        private void Start()
        {
            _npcCommonSettings = SettingsProvider.Get<NpcCommonSettings>();

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