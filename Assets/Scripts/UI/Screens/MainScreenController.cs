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
using Utils;
using Core;
using Saves;

namespace UI.Controllers
{
    public sealed class MainScreenController : MonoBehaviour
    {
        public event Action OnSendButtonClickEvent;

        [field:Header("For chat")]
        [field:SerializeField] public TMP_InputField InputField { get; private set; }

        [Header("Buttons")]
        [SerializeField] private ImageButtonController _sendButton;
        [SerializeField] private ImageButtonController _menuButton;
        [SerializeField] private ImageButtonController _changeNpcButton;

        private NpcCommonSettings _npcCommonSettings;

        private void OnSendButtonClick()
        {
            EventSystem.Send(new OnMessageSendEvent
            {
                Message = InputField.text,
                NpcType = Application.CurrentNpcType.ToString()
            });

            OnSendButtonClickEvent?.Invoke();
            InputField.text = string.Empty;
        }

        private void OnMenuButtonClick()
        {
            var currentNpcType = Application.CurrentNpcType;

            Application.PopupViewManager.Show(new MenuPopup
            {
                Color = _npcCommonSettings.GetPreset(currentNpcType).NpcColor,
                Title = LocalizationProvider.GetText("popup_title/menu"),
                InfoToggleSettings = new List<InfoToggleSettings>
                {
                    new InfoToggleSettings
                    {
                        Title = LocalizationProvider.GetText("toggle_vibrations/menu"),
                        Color = _npcCommonSettings.GetPreset(currentNpcType).NpcColor,
                        StartState = HapticProvider.State,
                        Action = () =>
                        {
                            HapticProvider.SwitchState();
                            return HapticProvider.State;
                        }
                    },
                    new InfoToggleSettings
                    {
                        Title = LocalizationProvider.GetText("toggle_sound/menu"),
                        Color = _npcCommonSettings.GetPreset(currentNpcType).NpcColor,
                        StartState = SoundProvider.State,
                        Action = () =>
                        {
                            SoundProvider.SwitchState();
                            return SoundProvider.State;
                        }
                    }
                },
                ButtonSettings = new List<TextButtonSettings>
                {
                    new TextButtonSettings
                    {
                        Title = LocalizationProvider.GetText("button_title/close"),
                        Color = _npcCommonSettings.GetPreset(currentNpcType).NpcColor,
                        Action = () =>
                        {
                            SaveDataManager.Save(SaveDataManager.SETTINGS_KEY, new SettingsSaveData
                            {
                                HapticState = HapticProvider.State,
                                SoundState = SoundProvider.State
                            });
                            Application.PopupViewManager.HideCurrentPopup();
                        }
                    }
                },
                IgnoreOverlayButtonAction = true,
                Direction = Vector3.left,
            });
        }

        private void OnChangeNpcButtonClick()
        {
            var currentNpcType = Application.CurrentNpcType;
            var buttonSettings = new List<TextButtonSettings>();
            var npcTypes = Enum.GetValues(typeof(NpcType)).OfType<NpcType>().SkipLast(1).ToList();

            npcTypes.Remove(currentNpcType);
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

                            FadeController.Instance.FadeOn(() =>
                            {
                                Main.LoadScene(_npcCommonSettings.GetPreset(type).Id);
                                SaveDataManager.Save(SaveDataManager.NPC_PRESET_KEY, _npcCommonSettings.GetPreset(type).Id);
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

        private void TurnOffInputFieldInteractable(OnTriggerEvent data)
        {
            InputField.interactable = false;
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

            EventSystem.Subscribe<OnTriggerEvent>(TurnOffInputFieldInteractable);
        }

        private void OnDestroy()
        {
            EventSystem.Unsubscribe<OnTriggerEvent>(TurnOffInputFieldInteractable);
        }
    }
}