using System;

namespace Controllers
{
    public interface IAnimable<T> where T : Enum
    {
        public void PlayAnimation(T type);
    }
}