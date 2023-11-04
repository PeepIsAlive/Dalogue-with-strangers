using UnityEngine;

namespace Scenes
{
    public class CatsScene : Scene
    {
        public const string Name = "CatsScene";

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