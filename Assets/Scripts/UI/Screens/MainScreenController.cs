using Application = Live_2D.Application;
using System.Collections.Generic;
using Localization;
using System.Linq;
using UnityEngine;
using UI.Settings;
using Settings;
using Modules;
using System;
using Scenes;
using Events;
using TMPro;
using Core;

namespace UI.Controllers
{
    public sealed class MainScreenController : MonoBehaviour
    {
        public event Action OnSendButtonClickEvent;

        [field:Header("For chat")]
        [field:SerializeField] public TMP_InputField InputField { get; private set; }

        [Header("Buttons")]
        [SerializeField] private ImageButtonController _sendButton;
        [SerializeField] private ImageButtonController _changeNpcButton;

        [Header("Other")]
        [SerializeField] private FadeController _fade;

        private NpcCommonSettings _npcCommonSettings;

        private void OnSendButtonClick()
        {
            EventSystem.Send<OnSendEvent>();
            OnSendButtonClickEvent?.Invoke();
        }

        private void OnChangeNpcButtonClick()
        {
            var currentNpcType = Application.CurrentNpcType;
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
                        Color = _npcCommonSettings.GetPreset(currentNpcType).NpcColor,
                        Action = () =>
                        {
                            Application.PopupViewManager.HideCurrentPopup();

                            _fade?.FadeOn(() =>
                            {
                                Main.LoadScene(_npcCommonSettings.GetPreset(type).Id);
                            });
                        }
                    }
                );
            });

            buttonSettings.Add
            (
                new TextButtonSettings
                {
                    Title = LocalizationProvider.GetText("button_title/cancel"),
                    Color = _npcCommonSettings.GetPreset(currentNpcType).NpcColor,
                    Action = () =>
                    {
                        Application.PopupViewManager.HideCurrentPopup();
                    }
                }
            );

            Application.PopupViewManager.Show(new DefaultPopup
            {
                Color = _npcCommonSettings.GetPreset(currentNpcType).NpcColor,
                Title = LocalizationProvider.GetText("popup_title/change_npc"),
                Content = LocalizationProvider.GetText("popup_content/change_npc"),
                ButtonSettings = buttonSettings
            });
        }

        private void Start()
        {
            _npcCommonSettings = SettingsProvider.Get<NpcCommonSettings>();

            _sendButton.Setup(new ImageButtonSettings
            {
                Action = OnSendButtonClick
            });
            _changeNpcButton.Setup(new ImageButtonSettings
            {
                Action = OnChangeNpcButtonClick
            });

            _fade?.FadeOff();
        }
    }
}