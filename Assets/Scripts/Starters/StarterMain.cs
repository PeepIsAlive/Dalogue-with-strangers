using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using Scenes;

namespace Starters
{
    public class StarterMain : Starter, ISceneLoadHandler<string>
    {
        [SerializeField] private Image _background;

        protected override async Task Initialize()
        {
            await Task.Yield();
        }

        private void Awake()
        {
            LoadSceneProcessor.Instance.InvokeLoadAction();
        }

        private async void Start()
        {
            await Initialize();
        }

        public override void OnSceneLoad(string argument)
        {
            
        }
    }
}