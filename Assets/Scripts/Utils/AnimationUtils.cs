using Core.Animations;

namespace Utils
{
    public static class AnimationUtils
    {
        public static string GetAnimationName(NatoriAnimationType type)
        {
            return type.ToString();
        }

        public static string GetAnimationName(CatAnimationType type)
        {
            return type.ToString();
        }

        public static string GetAnimationName(EpsilonAnimationType type)
        {
            return type switch
            {
                EpsilonAnimationType.ToBeEmbarrassedAndShakeHead => "ToBeEmbarrassed&ShakeHead",
                _ => type.ToString()
            };
        }
    }
}