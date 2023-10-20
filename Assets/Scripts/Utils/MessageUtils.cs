using System.Linq;
using Settings;
using Core;

namespace Utils
{
    public static class MessageUtils
    {
        private static MessageSettings _settings;

        static MessageUtils()
        {
            _settings = SettingsProvider.Get<MessageSettings>();
        }

        public static bool IsTriggerMessage(string message, out TriggerType triggerType)
        {
            triggerType = TriggerType.None;

            if (_settings == null)
                return false;

            triggerType = _settings.GetTrigger(message.ToLower().Split().ToList());

            return triggerType != TriggerType.None;
        }
    }
}