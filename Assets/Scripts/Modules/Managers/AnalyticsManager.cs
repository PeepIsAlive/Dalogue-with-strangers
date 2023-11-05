using System.Collections.Generic;
using UnityEngine.Analytics;
using Events;

namespace Modules.Managers
{
    public static class AnalyticsManager
    {
        private const string SEND_MESSAGE_EVENT = "sendMessage";

        public static void OnStart()
        {
#if !UNITY_EDITOR

            Analytics.enabled = true;

            Analytics.EnableCustomEvent(SEND_MESSAGE_EVENT, true);
            EventSystem.Subscribe<OnMessageSendEvent>(OnMessageSend);
#endif
        }

        public static void OnDestroy()
        {
#if !UNITY_EDITOR
            EventSystem.Unsubscribe<OnMessageSendEvent>(OnMessageSend);
#endif
        }

        private static void OnMessageSend(OnMessageSendEvent data)
        {
            Analytics.CustomEvent("sendMessage", new Dictionary<string, object>
            {
                { "Message", data.Message },
                { "NpcType", data.NpcType },
            });
        }
    }
}