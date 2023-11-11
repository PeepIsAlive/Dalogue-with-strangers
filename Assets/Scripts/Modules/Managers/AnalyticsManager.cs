using Application = Live_2D.Application;
using System.Collections.Generic;
using Unity.Services.Analytics;
using System.Threading.Tasks;
using Unity.Services.Core;
using Localization;
using UnityEngine;
using UI.Settings;
using Extensions;
using Settings;
using Events;
using UI;

namespace Modules.Managers
{
    public sealed class AnalyticsManager : MonoBehaviour
    {
        public static AnalyticsManager Instance { get; private set; }

        private const string SEND_MESSAGE_EVENT = "sendMessage";
        private bool _isInitialized;

        public async Task Initialize()
        {
            await UnityServices.InitializeAsync();

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
            AnalyticsService.Instance.CustomData(SEND_MESSAGE_EVENT, new Dictionary<string, object>
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
}