using System.Threading.Tasks;
using UnityEngine;

namespace Starters
{
    public abstract class Starter : MonoBehaviour
    {
        protected Transform parent;

        public virtual void OnSceneLoad(string argument) { }
        protected abstract Task Initialize();

        protected void DestroyStarter()
        {
            Destroy(gameObject);
        }

        private void Awake()
        {
            Application.targetFrameRate = 60;
            parent = transform.parent;
        }
    }
}