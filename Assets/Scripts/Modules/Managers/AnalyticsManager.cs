using System.Collections.Generic;
using Unity.Services.Analytics;
using Events;

namespace Modules.Managers
{
    public static class AnalyticsManager
    {
        private const string SEND_MESSAGE_EVENT = "sendMessage";

        public static void OnStart()
        {
#if !UNITY_EDITOR

            EventSystem.Subscribe<OnMessageSendEvent>(OnMessageSend);
            AnalyticsService.Instance.StartDataCollection();
#endif
        }

        public static void OnDestroy()
        {
#if !UNITY_EDITOR
            EventSystem.Unsubscribe<OnMessageSendEvent>(OnMessageSend);
            AnalyticsService.Instance.StopDataCollection();
#endif
        }

        private static void OnMessageSend(OnMessageSendEvent data)
        {
            AnalyticsService.Instance.CustomData(SEND_MESSAGE_EVENT, new Dictionary<string, object>
            {
                { "Message", data.Message },
                { "NpcType", data.NpcType }
            });
        }
    }
}