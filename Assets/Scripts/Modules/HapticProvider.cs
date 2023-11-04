using MoreMountains.NiceVibrations;

namespace Modules
{
    public sealed class HapticProvider
    {
        public static bool State { get; private set; } = true;

        public static void SetState(bool state)
        {
            State = state;
        }

        public static void SwitchState()
        {
            State = !State;
        }

        public static void Haptic(HapticTypes type)
        {
            if (State)
                MMVibrationManager.Haptic(type);
        }
    }
}