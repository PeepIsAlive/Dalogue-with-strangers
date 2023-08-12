using System.Collections.Generic;
using UnityEngine.Analytics;
using Events;

namespace Modules
{
    public static class AnalyticsManager
    {
        public static void OnStart()
        {
            EventSystem.Subscribe<OnMessageSendEvent>(OnMessageSend);
        }

        public static void OnDestroy()
        {
            EventSystem.Unsubscribe<OnMessageSendEvent>(OnMessageSend);
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