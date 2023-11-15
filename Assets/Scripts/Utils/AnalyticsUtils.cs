using Modules.Managers;

namespace Utils
{
    public static class AnalyticsUtils
    {
        public static string ToString(AnalyticsEvents analyticsEvent)
        {
            var eventName = analyticsEvent.ToString();
            var result = char.ToLower(eventName[0]) + eventName.Substring(1);

            return result;
        }
    }
}