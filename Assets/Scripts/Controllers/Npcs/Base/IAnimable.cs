using Events;
using System;

namespace Controllers
{
    public interface IAnimable<T> where T : Enum
    {
        public void PlayAnimation(T type);
        public void PlayWelcomeAnimation(OnStartDialogEvent data);
    }
}