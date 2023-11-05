using Application = Live_2D.Application;
using System.Collections.Generic;
using Localization;
using UnityEngine;
using UI.Settings;
using Modules;
using Saves;
using UI;

namespace Extensions
{
    public static class PopupExtensions
    {
        public static void ShowMenuPopup(Color? color)
        {
            Application.PopupViewManager.Show(new MenuPopup
            {
                Color = color,
                Title = LocalizationProvider.GetText("popup_title/menu"),
                InfoToggleSettings = new List<InfoToggleSettings>
                {
                    new InfoToggleSettings
                    {
                        Title = LocalizationProvider.GetText("toggle_vibrations/menu"),
                        StartState = HapticProvider.State,
                        Action = () =>
                        {
                            HapticProvider.SwitchState();
                            return HapticProvider.State;
                        },
                        Color = color
                    },
                    new InfoToggleSettings
                    {
                        Title = LocalizationProvider.GetText("toggle_sound/menu"),
                        StartState = SoundProvider.State,
                        Action = () =>
                        {
                            SoundProvider.SwitchState();
                            return SoundProvider.State;
                        },
                        Color = color
                    }
                },
                ButtonSettings = new List<TextButtonSettings>
                {
                    new TextButtonSettings
                    {
                        Title = LocalizationProvider.GetText("button_title/close"),
                        Action = () =>
                        {
                            SaveDataManager.Save(SaveDataManager.SETTINGS_KEY, new SettingsSaveData
                            {
                                HapticState = HapticProvider.State,
                                SoundState = SoundProvider.State
                            });
                            Application.PopupViewManager.HideCurrentPopup();
                        },
                        Color = color
                    }
                },
                IgnoreOverlayButtonAction = true,
                Direction = Vector3.left,
            });
        }

        public static void ShowChangeNpcPopup(Color? color, List<TextButtonSettings> buttonSettings)
        {
            Application.PopupViewManager.Show(new DefaultPopup
            {
                Title = LocalizationProvider.GetText("popup_title/change_npc"),
                Content = LocalizationProvider.GetText("popup_content/change_npc"),
                ButtonSettings = buttonSettings,
                Color = color,
            });
        }
    }
}