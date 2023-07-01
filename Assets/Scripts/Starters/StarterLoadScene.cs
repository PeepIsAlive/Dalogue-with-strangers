using System.Threading.Tasks;
using Scenes;

namespace Starters
{
    public sealed class StarterLoadScene : Starter, ISceneLoadHandler<string>
    {
        private string _sceneToLoad;

        private void Awake()
        {
            LoadSceneProcessor.Instance.InvokeLoadAction();
        }

        private async void Start()
        {
            await Initialize();
        }

        protected override async Task Initialize()
        {
            await Task.Yield();
        }

        public override void OnSceneLoad(string argument)
        {
            _sceneToLoad = argument;

            UnityEngine.Debug.Log(argument);
        }
    }
}