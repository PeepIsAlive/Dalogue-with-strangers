using UnityEngine;

namespace Scenes
{
    public class Main : Scene
    {
        public const string Name = "Main";

        public static AsyncOperation LoadScene()
        {
            return LoadScene(Name);
        }

        public static AsyncOperation LoadScene<T>(T argument)
        {
            return LoadScene(Name, argument);
        }
    }
}