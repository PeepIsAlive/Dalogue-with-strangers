using System.Collections.Generic;
using UnityEngine.Analytics;
using Events;

namespace Modules
{
    public static class AnalyticsManager
    {
        public static void OnStart()
        {
#if !UNITY_EDITOR
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