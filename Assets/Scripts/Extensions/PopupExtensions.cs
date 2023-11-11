using Application = Live_2D.Application;
using UnityEngine.Localization.Settings;
using System.Collections.Generic;
using static TMPro.TMP_Dropdown;
using Localization.Metadata;
using Localization;
using UnityEngine;
using System.Linq;
using UI.Settings;
using Modules;
using System;
using Saves;
using UI;
using Controllers;

namespace Extensions
{
    public static class PopupExtensions
    {
        public static void ShowMenuPopup(Color? color)
        {
            var currentLanguage = LocalizationSettings.SelectedLocale.Metadata.GetMetadata<SystemLanguageMetadata>().SystemLanguage.ToString();
            var languages = new List<string>
            {
                SystemLanguage.Russian.ToString(),
                SystemLanguage.English.ToString()
            };

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
                            var language = Enum.Parse<SystemLanguage>(Application.DropdownController.GetCurrentValue());

                            SaveDataManager.Save(SaveDataManager.SETTINGS_KEY, new SettingsSaveData
                            {
                                Language = language,
                                HapticState = HapticProvider.State,
                                SoundState = SoundProvider.State
                            });
                            Application.PopupViewManager.HideCurrentPopup();

                            if (LocalizationSettings.SelectedLocale.Metadata.GetMetadata<SystemLanguageMetadata>().SystemLanguage != language)
                            {
                                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales
                                    .First(l => l.Metadata.GetMetadata<SystemLanguageMetadata>().SystemLanguage == language);
                            }
                        },
                        Color = color
                    }
                },
                DropdownSettings = new DropdownSettings
                {
                    OptionDataList = new OptionDataList
                    {
                        options = new List<OptionData>
                        {
                            new OptionData
                            {
                                text = languages.First(x => x == currentLanguage)
                            },
                            new OptionData
                            {
                                text = languages.First(x => x != currentLanguage)
                            }
                        }
                    },
                    Title = LocalizationProvider.GetText("dropdown_title/language"),
                    Color = color,
                },
                IgnoreOverlayButtonAction = true,
                Direction = Vector3.left
            });
        }

        public static void ShowChangeNpcPopup(Color? color, List<TextButtonSettings> buttonSettings)
        {
            Application.PopupViewManager.Show(new DefaultPopup
            {
                Title = LocalizationProvider.GetText("popup_title/change_npc"),
                Content = LocalizationProvider.GetText("popup_content/change_npc"),
                ButtonSettings = buttonSettings,
                Color = color
            });
        }

        public static void ShowDataCollectionPopup(Color? color, Action action)
        {
            Application.PopupViewManager.Show(new DefaultPopup
            {
                Title = LocalizationProvider.GetText("popup_title/data_collection"),
                Content = LocalizationProvider.GetText("popup_content/data_collection"),
                ButtonSettings = new List<TextButtonSettings>
                {
                    new TextButtonSettings
                    {
                        Title = LocalizationProvider.GetText("button_title/yes"),
                        Action = () =>
                        {
                            action?.Invoke();
                            Application.PopupViewManager.HideCurrentPopup();
                        },
                        Color = color
                    },
                    new TextButtonSettings
                    {
                        Title = LocalizationProvider.GetText("button_title/no"),
                        Action = () =>
                        {
                            Application.PopupViewManager.HideCurrentPopup();
                        },
                        Color = color
                    }
                },
                IgnoreOverlayButtonAction = true,
                Color = color
            });
        }
    }
}