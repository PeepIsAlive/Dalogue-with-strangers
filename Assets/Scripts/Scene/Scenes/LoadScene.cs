using UnityEngine;

namespace Scenes
{
    public class Load : Scene
    {
        public const string Name = "LoadScene";

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