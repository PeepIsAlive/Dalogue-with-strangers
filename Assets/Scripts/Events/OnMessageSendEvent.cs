using Core;

namespace Events
{
    public struct OnMessageSendEvent
    {
        public string Message;
        public string NpcType;

        public TriggerType TriggerType;
    }
}