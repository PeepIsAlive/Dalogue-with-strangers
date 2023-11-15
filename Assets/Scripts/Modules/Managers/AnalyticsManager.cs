using Application = Live_2D.Application;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using Extensions;
using Settings;
using Events;
using Utils;

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

            PopupExtensions.ShowDataCollectionPopup(npcCommonSettings.GetPreset(Application.CurrentNpcType).NpcColor, () =>
            {
                EventSystem.Subscribe<OnMessageSendEvent>(OnMessageSend);
                AnalyticsService.Instance.StartDataCollection();
            });
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
            AnalyticsService.Instance.StopDataCollection();
#endif
        }
    }


    public enum AnalyticsEvents
    {
        SendMessage = 0,
    }
}