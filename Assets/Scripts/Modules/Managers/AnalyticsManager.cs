using Application = DWS.Application;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using Extensions;
using Settings;
using Events;
using System;
using Utils;
using Saves;

namespace Modules.Managers
{
    public sealed class AnalyticsManager : MonoBehaviour
    {
        public static AnalyticsManager Instance { get; private set; }
        private bool _isInitialized;

        public void Initialize()
        {
            if (_isInitialized)
                return;

#if !UNITY_EDITOR
            var npcCommonSettings = SettingsProvider.Get<NpcCommonSettings>();
            Action startDataCollectionAction = () =>
            {
                EventSystem.Subscribe<OnMessageSendEvent>(OnMessageSend);
                EventSystem.Subscribe<OnTriggerEvent>(OnTriggerEvent);

                AnalyticsService.Instance.StartDataCollection();
            };

            if (SaveDataManager.HasSave(SaveDataManager.DATA_COLLECTION_KEY))
            {
                SaveDataManager.LoadSave<bool>(SaveDataManager.DATA_COLLECTION_KEY, dataCollectionAnswer =>
                {
                    if (dataCollectionAnswer)
                        startDataCollectionAction?.Invoke();
                });
            }
            else
            {
                PopupExtensions.ShowDataCollectionPopup(npcCommonSettings.GetPreset(Application.CurrentNpcType).NpcColor, startDataCollectionAction);
            }
#endif

            _isInitialized = true;
        }

        private static void OnMessageSend(OnMessageSendEvent data)
        {
            AnalyticsService.Instance.CustomData(AnalyticsUtils.ToString(AnalyticsEvents.SendMessage), new Dictionary<string, object>
            {
                { "Message", data.Message },
                { "NpcType", data.NpcType }
            });
        }

        private static void OnTriggerEvent(OnTriggerEvent data)
        {
            AnalyticsService.Instance.CustomData(AnalyticsUtils.ToString(AnalyticsEvents.OnTrigger), new Dictionary<string, object>
            {
                { "TriggerType", data.TriggerType },
                { "NpcType", data.NpcType }
            });
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance == this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        private void OnDestroy()
        {
#if !UNITY_EDITOR
            EventSystem.Unsubscribe<OnMessageSendEvent>(OnMessageSend);
            EventSystem.Unsubscribe<OnTriggerEvent>(OnTriggerEvent);

            AnalyticsService.Instance.StopDataCollection();
#endif
        }
    }


    public enum AnalyticsEvents
    {
        SendMessage = 0,
        OnTrigger = 1,
    }
}