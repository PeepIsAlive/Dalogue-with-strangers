using System.Threading.Tasks;
using Scenes;

namespace Starters
{
    public class StarterMain : Starter, ISceneLoadHandler<string>
    {
        protected override async Task Initialize()
        {
            await Task.Yield();
        }

        private async void Start()
        {
            await Initialize();
        }

        public override void OnSceneLoad(string argument)
        {
            ;
        }
    }
}